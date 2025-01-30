using System;
using System.Windows.Forms;

namespace GPM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel panel1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRecNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.txtEPF_ETFNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPermanentAddress = new System.Windows.Forms.TextBox();
            this.txtCommercialAddress = new System.Windows.Forms.TextBox();
            this.txtTel2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTel1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNIC = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::GPM.Properties.Resources.Cloath;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(434, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 731);
            this.panel1.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(156, 332);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(172, 24);
            this.label20.TabIndex = 2;
            this.label20.Text = "Employee Details";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(215, 705);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(41, 705);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtRecNo);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 730);
            this.panel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(317, 704);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(136, 704);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRecNo
            // 
            this.txtRecNo.Location = new System.Drawing.Point(317, 11);
            this.txtRecNo.Name = "txtRecNo";
            this.txtRecNo.Size = new System.Drawing.Size(100, 20);
            this.txtRecNo.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Controls.Add(this.cmbStatus);
            this.groupBox3.Controls.Add(this.dtpAppointmentDate);
            this.groupBox3.Controls.Add(this.cmbCategory);
            this.groupBox3.Controls.Add(this.cmbDesignation);
            this.groupBox3.Controls.Add(this.txtEPF_ETFNo);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(17, 497);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 191);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Official Details";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(152, 156);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(230, 21);
            this.cmbStatus.TabIndex = 9;
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Location = new System.Drawing.Point(153, 126);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(228, 20);
            this.dtpAppointmentDate.TabIndex = 8;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(153, 95);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(228, 21);
            this.cmbCategory.TabIndex = 7;
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Location = new System.Drawing.Point(153, 63);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(228, 21);
            this.cmbDesignation.TabIndex = 6;
            // 
            // txtEPF_ETFNo
            // 
            this.txtEPF_ETFNo.Location = new System.Drawing.Point(153, 34);
            this.txtEPF_ETFNo.Name = "txtEPF_ETFNo";
            this.txtEPF_ETFNo.Size = new System.Drawing.Size(228, 20);
            this.txtEPF_ETFNo.TabIndex = 5;

            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(26, 155);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "Status";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(26, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "Appoinment Date";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(26, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Category";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(26, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 15);
            this.label14.TabIndex = 1;
            this.label14.Text = "Designation";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(26, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "EPF/ETF No";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(17, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 160);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Working Experience";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(153, 63);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(228, 70);
            this.txtDescription.TabIndex = 4;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(153, 30);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(145, 20);
            this.textBox9.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(26, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Description";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(304, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "(Month/s)";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Duration";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtPermanentAddress);
            this.groupBox1.Controls.Add(this.txtCommercialAddress);
            this.groupBox1.Controls.Add(this.txtTel2);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtTel1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtNIC);
            this.groupBox1.Controls.Add(this.dtpBirthDate);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 254);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Details";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(155, 220);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(228, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // txtPermanentAddress
            // 
            this.txtPermanentAddress.Location = new System.Drawing.Point(155, 194);
            this.txtPermanentAddress.Name = "txtPermanentAddress";
            this.txtPermanentAddress.Size = new System.Drawing.Size(228, 20);
            this.txtPermanentAddress.TabIndex = 16;
            // 
            // txtCommercialAddress
            // 
            this.txtCommercialAddress.Location = new System.Drawing.Point(155, 168);
            this.txtCommercialAddress.Name = "txtCommercialAddress";
            this.txtCommercialAddress.Size = new System.Drawing.Size(228, 20);
            this.txtCommercialAddress.TabIndex = 15;
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(296, 113);
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(87, 20);
            this.txtTel2.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(275, 118);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "2.";
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(176, 113);
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(83, 20);
            this.txtTel1.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(152, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "1.";
            // 
            // txtNIC
            // 
            this.txtNIC.Location = new System.Drawing.Point(155, 84);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.Size = new System.Drawing.Size(228, 20);
            this.txtNIC.TabIndex = 10;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(155, 55);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(228, 20);
            this.dtpBirthDate.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(155, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 20);
            this.txtName.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Permenent";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Commercial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tel No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "NIC No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Birth Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name with Initials";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rec No:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 783);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Employee Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        

        private void label11_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel2;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private GroupBox groupBox3;
        private Label label14;
        private Label label13;
        private GroupBox groupBox2;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtRecNo;
        private Label label17;
        private Label label16;
        private Label label15;
        private DateTimePicker dtpBirthDate;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPermanentAddress;
        private TextBox txtCommercialAddress;
        private TextBox txtTel2;
        private Label label19;
        private TextBox txtTel1;
        private Label label18;
        private TextBox txtNIC;
        private TextBox textBox9;
        private TextBox txtDescription;
        private TextBox txtEPF_ETFNo;
        private ComboBox cmbStatus;
        private DateTimePicker dtpAppointmentDate;
        private ComboBox cmbCategory;
        private ComboBox cmbDesignation;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label20;
    }
}

