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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtpri.Focus();
            string date1;
            date1 = DateTime.Now.Date.ToString("dd/MM/yyyy");
            date.Text = date1.ToString();
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
            SqlConnection con = new SqlConnection(connecrionstring);
            //SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from re", con);

            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGrid1.DataSource = ds3.Tables[0];



            SqlDataAdapter da8 = new SqlDataAdapter("Select distinct[return date] from re ", con);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);

            if (ds8.Tables[0].Rows.Count > 0)
            {
                int j = 0;
                for (j = 0; j < ds8.Tables[0].Rows.Count; j++)
                {
                    comboBox1.Items.Add((ds8.Tables[0].Rows[j]["return date"]));
                    comboBox2.Items.Add((ds8.Tables[0].Rows[j]["return date"]));
                    // cboZone.Items.Add(Trim(ds1.Tables(0).Rows(i)(1)))
                }

            }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpri.Text == "")
                {
                    MessageBox.Show("You must Enter the Bill No", "Jafer Ali",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtpri.Focus();
                }
                else
                {
                    string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                    SqlConnection con = new SqlConnection(connecrionstring);

                    SqlCommand cm = new SqlCommand();


                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from re where [bill no]='" + txtpri.Text + "'", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);


                    if (ds3.Tables[0].Rows.Count < 1)
                    {
                        //   MessageBox.Show((ds.Tables[0].Rows.Count < 1).ToString());
                        MessageBox.Show("No Record Found");
                    }
                    else
                    {




                        cm.Connection = con;
                        con.Open();
                        cm.CommandText = "delete from re where [bill No]='" + txtpri.Text + "'";
                        //cm.CommandText = "delete from stock";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from re", con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        dataGrid1.DataSource = ds2.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             try
            {

                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
                SqlCommand cm = new SqlCommand();
                cm.Connection = con;
                con.Open();
                cm.CommandText = "Delete from re where [return Date]>='" + comboBox1.Text + "' and [return Date]<='" + comboBox2.Text + "'";
                cm.ExecuteNonQuery();

                MessageBox.Show("Deleted successfully", "Jafer Ali",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                SqlDataAdapter da4 = new SqlDataAdapter("Select * from re ", con);


                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                dataGrid1.DataSource = ds4.Tables[0];


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe"); 
        }

        
    }
}