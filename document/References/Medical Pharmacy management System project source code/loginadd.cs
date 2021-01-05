using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace databaseC
{
    public partial class loginadd : Form
    {
        public loginadd()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusername.Text == "" || txtpassword.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Enter the Details", "Jafer Ali",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtusername.Focus();
                }
                else
                {

                    string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                    //   DataSet ds2 = new DataSet();
                    SqlConnection con = new SqlConnection(connectionstring);
                    SqlCommand cm = new SqlCommand();
                    //  cm.CommandText = "insert into login values ('" + txtusername.Text + "','" + txtpassword.Text + "')";
                    cm.Connection = con;
                    con.Open();
                    cm.CommandText = "update login set password='" + textBox1.Text + "' where [name]='" + txtusername.Text + "'";

                    cm.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully", "Jafer Ali",
                                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtusername.Clear();
                    txtpassword.Clear();
                    textBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LabelPassword_Click(object sender, EventArgs e)
        {

        }
    }
}