using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoftwareLocker
{
    public partial class frmDialog : Form
    {
        private string _Pass;
        private string _UID;
        private bool IsSubscpt;
        public frmDialog(string BaseString, string Password,int DaysToEnd,int Runed, string info,string UIDString ,bool isSubcriptions=false )
        {
            InitializeComponent();
            sebBaseString.Text = BaseString;
            _UID = UIDString;
            _Pass = Password;
            IsSubscpt = isSubcriptions;
            lblDays.Text = DaysToEnd.ToString() + " Day(s)";
            lblTimes.Text = Runed.ToString() + " Time(s)";
            lblText.Text = info;
            if (IsSubscpt == true)
            {
                grbTrialRunning.Visible = false;
                grbTrialRunning.Enabled = false;
            }

            if (DaysToEnd <= 0 || Runed <= 0)
            {
                lblDays.Text = "Finished";
                lblTimes.Text = "Finished";
                btnTrial.Enabled = false;
            }

            sebPassword.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_Pass == sebPassword.Text && _UID==TxtAppID.Text )
            {
                MessageBox.Show("Password is correct, Thank you for Activate", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Error: Password is incorrect,Plz check the keys and product ID", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }
    }
}