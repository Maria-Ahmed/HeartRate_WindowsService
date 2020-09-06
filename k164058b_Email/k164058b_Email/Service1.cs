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
using System.Net.Mail;
using System.Net;

namespace k164058b_Email
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
            XDocument initial = XDocument.Load("C:\\Temp\\UserChart.xml");
            XDocument initial1 = null;

            while (true)
            {
                initial1 = XDocument.Load("C:\\Temp\\UserChart.xml");

                if (XNode.DeepEquals(initial, initial1))

                {
                    Console.WriteLine("No changes");
                }
                else // send mail
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential("ahmedmaria241@gmail.com", "marias96");
                    MailMessage msg = new MailMessage();
                    msg.To.Add("hassaannahmed@gmail.com");
                    msg.From = new MailAddress("ahmedmaria241@gmail.com");
                    msg.Subject = "Its changed";
                    msg.Body = "UserChart.xml is modified!";
                    client.Send(msg);
                }

                Thread.Sleep(1 * 60 * 1000);
                initial = initial1;
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
