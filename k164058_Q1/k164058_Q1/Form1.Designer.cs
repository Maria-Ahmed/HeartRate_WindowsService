namespace DemoApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dateOfBirthPicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtBPM = new System.Windows.Forms.TextBox();
            this.timePickerBPM = new System.Windows.Forms.DateTimePicker();
            this.lblTimeBPM = new System.Windows.Forms.Label();
            this.lblBPM = new System.Windows.Forms.Label();
            this.btnSubmitPatient = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(284, 94);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(284, 223);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // dateOfBirthPicker
            // 
            this.dateOfBirthPicker.Location = new System.Drawing.Point(284, 175);
            this.dateOfBirthPicker.Name = "dateOfBirthPicker";
            this.dateOfBirthPicker.Size = new System.Drawing.Size(200, 20);
            this.dateOfBirthPicker.TabIndex = 2;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBoxGender.Location = new System.Drawing.Point(284, 135);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGender.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(147, 94);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(147, 138);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Gender";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(147, 181);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(66, 13);
            this.lblDOB.TabIndex = 6;
            this.lblDOB.Text = "Date of Birth";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(147, 223);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // txtBPM
            // 
            this.txtBPM.Enabled = false;
            this.txtBPM.Font = new System.Drawing.Font("Engravers MT", 8.25F);
            this.txtBPM.Location = new System.Drawing.Point(284, 299);
            this.txtBPM.Name = "txtBPM";
            this.txtBPM.Size = new System.Drawing.Size(100, 20);
            this.txtBPM.TabIndex = 9;
            // 
            // timePickerBPM
            // 
            this.timePickerBPM.Enabled = false;
            this.timePickerBPM.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerBPM.Location = new System.Drawing.Point(284, 336);
            this.timePickerBPM.Name = "timePickerBPM";
            this.timePickerBPM.ShowUpDown = true;
            this.timePickerBPM.Size = new System.Drawing.Size(200, 20);
            this.timePickerBPM.TabIndex = 10;
            // 
            // lblTimeBPM
            // 
            this.lblTimeBPM.AutoSize = true;
            this.lblTimeBPM.Location = new System.Drawing.Point(150, 343);
            this.lblTimeBPM.Name = "lblTimeBPM";
            this.lblTimeBPM.Size = new System.Drawing.Size(30, 13);
            this.lblTimeBPM.TabIndex = 11;
            this.lblTimeBPM.Text = "Time";
            // 
            // lblBPM
            // 
            this.lblBPM.AutoSize = true;
            this.lblBPM.Location = new System.Drawing.Point(150, 302);
            this.lblBPM.Name = "lblBPM";
            this.lblBPM.Size = new System.Drawing.Size(30, 13);
            this.lblBPM.TabIndex = 12;
            this.lblBPM.Text = "BMP";
            // 
            // btnSubmitPatient
            // 
            this.btnSubmitPatient.Location = new System.Drawing.Point(284, 258);
            this.btnSubmitPatient.Name = "btnSubmitPatient";
            this.btnSubmitPatient.Size = new System.Drawing.Size(164, 23);
            this.btnSubmitPatient.TabIndex = 13;
            this.btnSubmitPatient.Text = "Submit Patient Details";
            this.btnSubmitPatient.UseVisualStyleBackColor = true;
            this.btnSubmitPatient.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(284, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(216, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Submit Blood Rate Details";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(506, 385);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(216, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Enter Another BPM";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Enter Another Patient";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSubmitPatient);
            this.Controls.Add(this.lblBPM);
            this.Controls.Add(this.lblTimeBPM);
            this.Controls.Add(this.timePickerBPM);
            this.Controls.Add(this.txtBPM);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.dateOfBirthPicker);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dateOfBirthPicker;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtBPM;
        private System.Windows.Forms.DateTimePicker timePickerBPM;
        private System.Windows.Forms.Label lblTimeBPM;
        private System.Windows.Forms.Label lblBPM;
        private System.Windows.Forms.Button btnSubmitPatient;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}

