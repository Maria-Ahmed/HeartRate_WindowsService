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


namespace k164058_Q4
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


            var directories = Directory.GetDirectories(@"C:\Temp"); //gives full paths to the subdirectories
            //traverse each foldername in array of directories 

            XDocument document;
            XElement tagRegistry = null;

            if (!File.Exists("C:\\Temp\\UserChart.xml"))  // marker for not overwrite
            {
                //create userchart.xml and then add
                XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Users" //this first level XElement is the root
                                            )//end of root level XElement
                         );
                //save the data into a file name/path.
                xDoc.Save("C:/Temp/UserChart.xml");
                document = xDoc;
                tagRegistry = document.Descendants("Users").FirstOrDefault();



            }

            else // file already exist
            {

                document = XDocument.Load("C:\\Temp\\UserChart.xml"); // read and then apend further users
                tagRegistry = document.Descendants("Users").FirstOrDefault();


            }


            XDocument document1;
            XElement tagRegistry1 = null;

            if (!File.Exists("C:\\Temp\\ConsolidatedChart.xml"))  // marker for not overwrite
            {
                //create userchart.xml and then add
                XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Patients" //this first level XElement is the root
                                            )//end of root level XElement
                         );
                //save the data into a file name/path.
                xDoc.Save("C:/Temp/ConsolidatedChart.xml");
                document1 = xDoc;
                tagRegistry1 = document1.Descendants("Patients").FirstOrDefault();



            }

            else // file already exist
            {

                document1 = XDocument.Load("C:\\Temp\\ConsolidatedChart.xml"); // read and then apend further users
                tagRegistry1 = document.Descendants("Patients").FirstOrDefault();

            }



            for (int i = 0; i < directories.Length; i++)
            {
                //Console.WriteLine(directories[i]); // got all the paths up till here
                string foldername = Path.GetFileName(directories[i]);
                Console.WriteLine(foldername);
                string consolidateHR_path = @"C:\Temp\\" + foldername + "\\ConsolidateHeartRate.json";

                using (StreamReader sr = new StreamReader(consolidateHR_path))  //Created an instance of StreamReader 
                {
                    string line; // Read and display lines from the file until the end of the file is reached.
                    string completeFile = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        completeFile += line;

                    }
                    Console.WriteLine(completeFile);
                }


                // reading JSON-(UserProfile) from Question2 for name and email
                string UserProfileJSONPath = @"C:\Temp\\" + foldername + "\\user-profile\\User-Profile.json";

                var json = File.ReadAllText(UserProfileJSONPath); //Read json inside a variable
                UserProfile profile = new UserProfile();

                profile = JsonConvert.DeserializeObject<UserProfile>(json);     //Deserializing,;                                               //JSON into .NET objects (deserialize)
                                                                                // Console.WriteLine(profile.Name);
                string fetchedname = profile.Name;
                //Console.WriteLine(profile.Email);
                string fetchedmailing = profile.Email;
                //Console.WriteLine(profile.DOB);


                // reading JSON-(UserDetail) from Question2 for BPM ----(Also,need age for Consolidated Chart)
                string UserDetailJSONPath = @"C:\Temp\\" + foldername + "\\user-detail\\User-Detail.json";
                int Max = 0;  // doing work for MAX HeartRange
                int age = 0;
                string dob = profile.DOB;
                //Console.WriteLine(dob);
                string yearOfBirth = profile.DOB.Split(',')[2];
                //Console.WriteLine(yearOfBirth);
                int presentyear = DateTime.Now.Year;
                age = presentyear - Int32.Parse(yearOfBirth);
                //Console.WriteLine(age);
                int maxheart_range = 220 - age;




                int Sum = 0;
                //int range = 0;
                var detailjson = File.ReadAllText(UserDetailJSONPath); //Read json inside a variable
                List<UserDetail> details = new List<UserDetail>(); //userdetail object

                List<UserDetail> ud = JsonConvert.DeserializeObject<List<UserDetail>>(detailjson);     //Deserializing,
                String heartrate = ud[0].Value.bpm;  // not taking it as int 
                //Console.WriteLine(heartrate);
                int Min = Int32.Parse(ud[0].Value.bpm);
                foreach (UserDetail d in ud)
                {
                    if (Int32.Parse(d.Value.bpm) > Max)
                    {
                        Max = Int32.Parse(d.Value.bpm);
                    }


                    if (Int32.Parse(d.Value.bpm) < Min)
                    {
                        Min = Int32.Parse(d.Value.bpm);

                    }


                    Sum = Sum + Int32.Parse(d.Value.bpm);
                    //Console.WriteLine("Max, Min {0}, {0}", Max,Min);
                }
                int Avg = Sum / ud.Count();

                //Console.WriteLine("Average is {0}",  Avg);



                // Adding each user's info in UserChart
                tagRegistry.Add(
                new XElement("User",

                    new XAttribute("Name", fetchedname),
                    new XAttribute("Email", fetchedmailing),
                        //new XAttribute("DOB", "fetchDOB"), // for age and range bpm ONLY

                        new XElement("High", Max),
                        new XElement("Avg", Avg),
                        new XElement("Low", Min),
                        new XElement("Range", maxheart_range)

                )); //basic child element

                string fetchedvalue = "0";

                if (age > 0 && age < 10)
                {
                    fetchedvalue = "1";
                }
                if (age > 11 && age < 20)
                {
                    fetchedvalue = "2";
                }
                if (age > 21 && age < 30)
                {
                    fetchedvalue = "3";
                }
                if (age > 31 && age < 40)
                {
                    fetchedvalue = "4";
                }
                if (age > 41 && age < 50)
                {
                    fetchedvalue = "5";
                }
                if (age > 51 && age < 60)
                {
                    fetchedvalue = "6";
                }
                if (age > 61 && age < 70)
                {
                    fetchedvalue = "7";
                }
                if (age > 71 && age < 80)
                {
                    fetchedvalue = "8";
                }


                // Adding users agegroups in CONSOLIDATED XML 
                tagRegistry1.Add(
                        new XElement("AgeGroup",
                                           new XAttribute("value", fetchedvalue),
                                    new XElement("Average", fetchedvalue),
                                    new XElement("Low", fetchedvalue)
                                    ) //basic child element

                );


            }



            document.Save("C:/Temp/UserChart.xml"); // saving userchart
            document1.Save("C:/Temp/ConsolidatedChart.xml"); // saving
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
