using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient ;
using Microsoft.VisualBasic;
namespace databaseC
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {

                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                DataSet ds2 = new DataSet();
                SqlConnection con = new SqlConnection(connecrionstring);
                SqlCommand cm = new SqlCommand();
                SqlDataAdapter da2 = new SqlDataAdapter("select * from login where Name='" + (txtusername.Text) + "'and password='" + (txtpassword.Text) + "'", con);
               int s= (da2.Fill(ds2));
            if(s>=1)
               {
               
                    main jform3 = new main();
                    jform3.ShowDialog();
                    this.Hide();
                    this.Close();
                    Close();
             }
              
                else
                {
                  MessageBox.Show("Invalid Password or Username", "Jafer Ali",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
             this.Close();

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message , "Jafer Ali",
                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           this.Close();
            
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void LabelUserName_Click(object sender, EventArgs e)
        {

        }

        private void GroupBoxMain_Enter(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LabelHeader_Click(object sender, EventArgs e)
        {

        }

        private void LabelPassword_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxLogin_Click(object sender, EventArgs e)
        {

        }
    }
}