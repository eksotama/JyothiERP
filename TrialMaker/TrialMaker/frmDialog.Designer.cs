namespace SoftwareLocker
{
    partial class frmDialog
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
            this.sebBaseString = new SerialBox.SerialBox();
            this.sebPassword = new SerialBox.SerialBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTrial = new System.Windows.Forms.Button();
            this.grbRegister = new System.Windows.Forms.GroupBox();
            this.TxtAppID = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCallPhone = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblDaysToEnd = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblRunTimesLeft = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.grbTrialRunning = new System.Windows.Forms.GroupBox();
            this.grbRegister.SuspendLayout();
            this.grbTrialRunning.SuspendLayout();
            this.SuspendLayout();
            // 
            // sebBaseString
            // 
            this.sebBaseString.CaptleLettersOnly = true;
            this.sebBaseString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sebBaseString.Location = new System.Drawing.Point(14, 31);
            this.sebBaseString.Name = "sebBaseString";
            this.sebBaseString.ReadOnly = true;
            this.sebBaseString.Size = new System.Drawing.Size(361, 27);
            this.sebBaseString.TabIndex = 2;
            // 
            // sebPassword
            // 
            this.sebPassword.CaptleLettersOnly = true;
            this.sebPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sebPassword.Location = new System.Drawing.Point(14, 74);
            this.sebPassword.Name = "sebPassword";
            this.sebPassword.Size = new System.Drawing.Size(361, 27);
            this.sebPassword.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(69, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(221, 36);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&Activate";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTrial
            // 
            this.btnTrial.Location = new System.Drawing.Point(228, 19);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(145, 39);
            this.btnTrial.TabIndex = 2;
            this.btnTrial.Text = "Try Trail";
            this.btnTrial.UseVisualStyleBackColor = true;
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // grbRegister
            // 
            this.grbRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbRegister.Controls.Add(this.TxtAppID);
            this.grbRegister.Controls.Add(this.lblText);
            this.grbRegister.Controls.Add(this.label1);
            this.grbRegister.Controls.Add(this.lblSerial);
            this.grbRegister.Controls.Add(this.lblID);
            this.grbRegister.Controls.Add(this.lblCallPhone);
            this.grbRegister.Controls.Add(this.sebBaseString);
            this.grbRegister.Controls.Add(this.btnOK);
            this.grbRegister.Controls.Add(this.sebPassword);
            this.grbRegister.Location = new System.Drawing.Point(12, 57);
            this.grbRegister.Name = "grbRegister";
            this.grbRegister.Size = new System.Drawing.Size(395, 215);
            this.grbRegister.TabIndex = 1;
            this.grbRegister.TabStop = false;
            this.grbRegister.Text = "Registration Info";
            // 
            // TxtAppID
            // 
            this.TxtAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAppID.Location = new System.Drawing.Point(89, 106);
            this.TxtAppID.MaxLength = 20;
            this.TxtAppID.Name = "TxtAppID";
            this.TxtAppID.PasswordChar = '*';
            this.TxtAppID.Size = new System.Drawing.Size(126, 21);
            this.TxtAppID.TabIndex = 7;
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(9, 177);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(380, 35);
            this.lblText.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Application ID";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(11, 58);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(62, 13);
            this.lblSerial.TabIndex = 3;
            this.lblSerial.Text = "Serial Keys ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(11, 15);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(44, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID Keys";
            // 
            // lblCallPhone
            // 
            this.lblCallPhone.AutoSize = true;
            this.lblCallPhone.Location = new System.Drawing.Point(6, 21);
            this.lblCallPhone.Name = "lblCallPhone";
            this.lblCallPhone.Size = new System.Drawing.Size(0, 13);
            this.lblCallPhone.TabIndex = 0;
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(12, 9);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(317, 43);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "To use this application, you must buy it.\r\nBefore buying, you can run application" +
    " as trial. in trial mode some parts may be inactive and after buying they will b" +
    "e active";
            // 
            // lblDaysToEnd
            // 
            this.lblDaysToEnd.AutoSize = true;
            this.lblDaysToEnd.Location = new System.Drawing.Point(9, 22);
            this.lblDaysToEnd.Name = "lblDaysToEnd";
            this.lblDaysToEnd.Size = new System.Drawing.Size(118, 13);
            this.lblDaysToEnd.TabIndex = 3;
            this.lblDaysToEnd.Text = "Days to end trial period:";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.ForeColor = System.Drawing.Color.Red;
            this.lblDays.Location = new System.Drawing.Point(132, 22);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(37, 13);
            this.lblDays.TabIndex = 4;
            this.lblDays.Text = "[Days]";
            // 
            // lblRunTimesLeft
            // 
            this.lblRunTimesLeft.AutoSize = true;
            this.lblRunTimesLeft.Location = new System.Drawing.Point(9, 48);
            this.lblRunTimesLeft.Name = "lblRunTimesLeft";
            this.lblRunTimesLeft.Size = new System.Drawing.Size(74, 13);
            this.lblRunTimesLeft.TabIndex = 5;
            this.lblRunTimesLeft.Text = "Run times left:";
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.ForeColor = System.Drawing.Color.Red;
            this.lblTimes.Location = new System.Drawing.Point(132, 48);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(41, 13);
            this.lblTimes.TabIndex = 6;
            this.lblTimes.Text = "[Times]";
            // 
            // grbTrialRunning
            // 
            this.grbTrialRunning.Controls.Add(this.lblDaysToEnd);
            this.grbTrialRunning.Controls.Add(this.lblRunTimesLeft);
            this.grbTrialRunning.Controls.Add(this.lblDays);
            this.grbTrialRunning.Controls.Add(this.lblTimes);
            this.grbTrialRunning.Controls.Add(this.btnTrial);
            this.grbTrialRunning.Location = new System.Drawing.Point(12, 279);
            this.grbTrialRunning.Name = "grbTrialRunning";
            this.grbTrialRunning.Size = new System.Drawing.Size(395, 74);
            this.grbTrialRunning.TabIndex = 8;
            this.grbTrialRunning.TabStop = false;
            this.grbTrialRunning.Text = "Trial Running";
            // 
            // frmDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(419, 371);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.grbTrialRunning);
            this.Controls.Add(this.grbRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialog";
            this.Text = "Regitration Dialog ";
            this.grbRegister.ResumeLayout(false);
            this.grbRegister.PerformLayout();
            this.grbTrialRunning.ResumeLayout(false);
            this.grbTrialRunning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SerialBox.SerialBox sebBaseString;
        private SerialBox.SerialBox sebPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnTrial;
        private System.Windows.Forms.GroupBox grbRegister;
        private System.Windows.Forms.Label lblCallPhone;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDaysToEnd;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblRunTimesLeft;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.GroupBox grbTrialRunning;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtAppID;

    }
}