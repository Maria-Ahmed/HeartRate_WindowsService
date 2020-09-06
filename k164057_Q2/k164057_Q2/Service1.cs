using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;

namespace k164057_Q2
{
    public partial class Service1 : ServiceBase
    {

        int ScheduleInterval = Convert.ToInt32(ConfigurationSettings.AppSettings["ThreadSleepTimeInMin"]);
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
                foreach (XmlNode patient in listOfPatients)
                {
                    string name = patient.Attributes["name"]?.InnerText;
                    if (!Directory.Exists(FolderPath + "\\" + name))
                    {
                        Directory.CreateDirectory(FolderPath + "\\" + name);// folder for name of patient  @"D:\Maria"*/
                        Directory.CreateDirectory(FolderPath + "\\" + name + "\\" + "user-profile"); // @"D:\Murtaza\user-profile"
                        Directory.CreateDirectory(FolderPath + "\\" + name + "\\" + "user-detail");
                    }

                    //node's attributes for user-profile

                    string email = patient.Attributes["Email"]?.InnerText; //got them sequenced acc to Xml
                    string gender = patient.Attributes["Gender"]?.InnerText;
                    string DOB = patient.Attributes["DOB"]?.InnerText;


                    UserProfile profileinfo = new UserProfile(); // object
                    profileinfo.Name = name;
                    profileinfo.Email = email;
                    profileinfo.Gender = gender;
                    profileinfo.DOB = DOB;

                    string profileinfoJSON = JsonConvert.SerializeObject(profileinfo, Newtonsoft.Json.Formatting.Indented); // a JSON object from the class object



                    string UserProfileJSONPath = @"C:\Temp\" + name + "\\user-profile\\User-Profile.json";

                    if (!File.Exists(UserProfileJSONPath))
                    {
                        // Create a file to write to.   
                        using (StreamWriter sw = File.CreateText(UserProfileJSONPath))
                        {
                            sw.WriteLine(profileinfoJSON);
                        }
                    }
                    /* else
                     {
                         using (StreamWriter sw = File.AppendText(UserProfileJSONPath))
                         {
                             sw.WriteLine(profileinfoJSON);
                         }
                     }*/



                    List<UserDetail> details = new List<UserDetail>(); //MashaAllah

                    //Childnode's attributes for user-detail
                    UserDetail detailObject = new UserDetail();
                    detailObject.datetime = patient["time"].InnerText;
                    detailObject.Value.bpm = patient["bpm"].InnerText;
                    detailObject.Value.confidence = "0";





                    string UserDetailJSONPath = @"C:\Temp\" + name + "\\user-detail\\User-Detail.json";

                    if (!File.Exists(UserDetailJSONPath))
                    {
                        // Create a file to write to.   
                        using (StreamWriter sw = File.CreateText(UserDetailJSONPath))
                        {
                            details.Add(detailObject);
                            string detailObjectJSON = JsonConvert.SerializeObject(details, Newtonsoft.Json.Formatting.Indented); // a JSON object from the class object
                            sw.WriteLine(detailObjectJSON);
                        }
                    }
                    else
                    {
                        //reading json

                        var json = File.ReadAllText(UserDetailJSONPath);
                        //Console.Write(json);
                        List<UserDetail> ud = JsonConvert.DeserializeObject<List<UserDetail>>(json);     //Deserializing, Ud: C#ki list
                        ud.Add(detailObject);                                      //Add to the object
                        string HeartRateJson = JsonConvert.SerializeObject(ud, Newtonsoft.Json.Formatting.Indented); //Serialize again to json
                        File.WriteAllText(UserDetailJSONPath, HeartRateJson);

                    }

                    //File.WriteAllText(path, text)


                }
                //C:\Temp\Ahmed\user-profile\
                /* C:\TempAhmed\user-profile  
                 * 
                        using (StreamWriter sw = File.CreateText(UseDetailsJSONPath))*/




                Thread.Sleep(ScheduleInterval * 60 * 1000);

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

