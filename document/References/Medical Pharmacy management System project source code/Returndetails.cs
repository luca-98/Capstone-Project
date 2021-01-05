using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient ;
namespace databaseC
{
    public partial class Returndetails : Form
    {
        public Returndetails()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from stockreturn", con);

            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGrid1.DataSource = ds2.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            DataSet ds2 = new DataSet();
            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from stockreturn where [batch no] like '%" + textBox1.Text + "%'" + "or [medicine name] like '%" + textBox1.Text + "%'" + "or quantity like'%" + textBox1.Text + "%'"+"or [Invoice No] like '%" + textBox1.Text + "%'", con);

            da2.Fill(ds2);
            dataGrid1.DataSource = ds2.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
                SqlDataAdapter da4 = new SqlDataAdapter("Select * from stockreturn ", con);
                SqlCommand cm = new SqlCommand();
                //  if (MessageBox.Show("Are You Sure to Delete the all Bill Details?", "Pharmacy",
                //        
                //                      MessageBoxButtons.OKCancel , MessageBoxIcon.Exclamation ))

                if (MessageBox.Show("Are You Sure to Delete the all Stock Return?", "My Application",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
                {
                    cm.Connection = con;
                    con.Open();

                    cm.CommandText = "delete  from stockreturn";
                    cm.ExecuteNonQuery();
                }
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                dataGrid1.DataSource = ds4.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}