using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace k164058_Q3
{
    public partial class Service1 : ServiceBase
    {
        int ScheduleInterval = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["ThreadSleepTimeInMin"]);
        public Thread worker = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            try
            {
                ThreadStart start = new ThreadStart(Working);
                worker = new Thread(start);
                worker.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }

            public void onDebug()
            {
                OnStart(null);
            }

            public void Working()
            {

                while (true)
                {

                    string xmlFilePath = @"C:\Temp\PatientDetails_2020_5_6.xml";
                    string FolderPath = @"C:\Temp";
                    XmlDocument Xmldoc = new XmlDocument(); //Xmldoc's type is XmlDocument (not int, char etc)
                    Xmldoc.Load(xmlFilePath);

                    /*string Output = "C:\\sampley.txt";
                    using (StreamWriter writer = new StreamWriter(Output, true))
                    {
                        writer.WriteLine(Xmldoc.Root.ToString());
                        writer.Close();
                    }*/

                    XmlNodeList listOfPatients = Xmldoc.SelectNodes("/Patients/Patient"); //only list of patients (nested node)
                    foreach (System.Xml.XmlNode patient in listOfPatients)
                    {
                        string name = patient.Attributes["name"]?.InnerText;


                        string ConsolidatedJSONPath = @"C:\Temp\" + name + "\\ConsolidateHeartRate.json";

                        if (!File.Exists(ConsolidatedJSONPath))
                        {
                            // Create a file to write to.   
                            using (StreamWriter sw = File.CreateText(ConsolidatedJSONPath))
                            {
                                /*details.Add(detailObject);
                                string detailsJSON = JsonConvert.SerializeObject(details, Newtonsoft.Json.Formatting.Indented); // a JSON object from the class object*/
                                sw.WriteLine("[]");
                            }
                        }

                        DirectoryInfo directory = new DirectoryInfo(@"C:\Temp\\" + name + "\\user-detail\\");//Assuming Test is your Folder

                        FileInfo[] Files = directory.GetFiles("*.json"); //Getting Text files
                        List<String> Jsonfiles = new List<String>();
                        foreach (FileInfo file in Files)
                        {
                            //file.Name;
                            if (!Jsonfiles.Contains(file.Name))
                            {
                                var oldjson = File.ReadAllText(ConsolidatedJSONPath);
                                var newjson = File.ReadAllText(@"C:\Temp\\" + name + "\\user-detail\\" + file.Name);
                                List<UserDetails> readDetails = JsonConvert.DeserializeObject<List<UserDetails>>(oldjson);
                                List<UserDetails> readDetails1 = JsonConvert.DeserializeObject<List<UserDetails>>(newjson);
                                if (readDetails == null)
                                {
                                    readDetails = readDetails1;
                                }
                                else
                                {
                                    readDetails.AddRange(readDetails1);
                                }

                                string detailsJSON = JsonConvert.SerializeObject(readDetails1, Newtonsoft.Json.Formatting.Indented); // a JSON object from the class object
                                File.WriteAllText(ConsolidatedJSONPath, detailsJSON);
                                Jsonfiles.Add(file.Name);
                            }

                        }
                    }



                    Thread.Sleep(5 * 60 * 1000);

                }
            }

        


        protected override void OnStop()
        {
            try
            {
                if ((worker != null) & worker.IsAlive)
                {
                    worker.Abort();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
