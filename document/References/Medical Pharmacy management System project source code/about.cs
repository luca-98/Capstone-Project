using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace databaseC
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http:\\www.yahoomail.com"); 
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http:\\www.jaferali.webs.com");
        }

        private void label5_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http:\\www.yahoomail.com"); 
        }
    }
}