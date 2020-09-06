using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            if (!Directory.Exists(@"C:\Temp"))
            {
                Directory.CreateDirectory(@"C:\Temp");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            dateOfBirthPicker.Enabled = false;
            comboBoxGender.Enabled = false;

            txtBPM.Enabled = true;
            timePickerBPM.Enabled = true;
            

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            string xmlFilePath = @"C:\Temp\PatientDetails_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".xml";

            if (!File.Exists(xmlFilePath))
            {
                XmlWriter writer = XmlWriter.Create(xmlFilePath,settings);

                writer.WriteStartDocument();

                writer.WriteStartElement("Patients");
                //writer.WriteStartElement("Patient");
                //writer.WriteAttributeString("name", txtName.Text);
                //writer.WriteAttributeString("DOB", dateOfBirthPicker.Text);
                //writer.WriteAttributeString("Gender", comboBoxGender.SelectedItem.ToString());
                //writer.WriteAttributeString("Email", txtEmail.Text);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            dateOfBirthPicker.Enabled = true;
            comboBoxGender.Enabled = true;
            txtName.Text = "";
            txtEmail.Text = "";
            

            txtBPM.Enabled = false;
            timePickerBPM.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtBPM.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xmlFilePath = @"C:\Temp\PatientDetails_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day+".xml";
            XDocument doc = XDocument.Load(xmlFilePath);
            
            //XElement particularPatient = doc.Element("Patients").Elements("Patient")
            //                    .Where(patient => patient.Attribute("name").Value == txtName.Text)
            //                    .FirstOrDefault();

            //if (particularPatient != null)
            //{
            //    particularPatient.AddAfterSelf(
            //  new XElement("bpm", "David"),
            //  new XElement("time", timePickerBPM.Text),
            //  new XElement("confidence", 0));
            //}
             XElement elements = doc.Element("Patients");
                elements.Add(new XElement("Patient",
                new XAttribute("name", txtName.Text),
                new XAttribute("DOB", dateOfBirthPicker.Text),
                new XAttribute("Gender", comboBoxGender.SelectedItem),
                new XAttribute("Email", txtEmail.Text),
                new XElement("bpm", txtBPM.Text),
                new XElement("time", timePickerBPM.Text),
                new XElement("confidence", 0)));
          
            doc.Save(xmlFilePath);
        }
    }
}
