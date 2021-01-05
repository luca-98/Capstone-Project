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
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from billbackup", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGrid1.DataSource = ds2.Tables[0];

            SqlDataAdapter da = new SqlDataAdapter("Select * from billbackup ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = 0;
            Decimal sum = 0;
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; )
                {

                    sum = sum + Convert.ToDecimal(ds.Tables[0].Rows[i][8]);

                    // amt.Text = sum.ToString();
                    label3.Text = sum.ToString();
                    i++;
                    //  MessageBox.Show(sum.ToString());
                }
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            DataSet ds2 = new DataSet();
            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from billbackup where [bill no] like '%" + textBox1.Text + "%'" + "", con);

            da2.Fill(ds2);
            dataGrid1.DataSource = ds2.Tables[0];

         //   string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
          //  SqlConnection con = new SqlConnection(connecrionstring);
            //SqlCommand cm = new SqlCommand();
           



        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
           
                SqlDataAdapter da = new SqlDataAdapter("Select * from billbackup where [Bill No]='"+textBox1.Text +"'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = 0;
                Decimal sum = 0;
                {
                    for (i = 0; i < ds.Tables[0].Rows.Count; )
                    {

                        sum = sum + Convert.ToDecimal(ds.Tables[0].Rows[i][8]);

                        // amt.Text = sum.ToString();
                        label3.Text = sum.ToString();
                        i++;
                        //  MessageBox.Show(sum.ToString());
                    }
                }
              //  SqlDataAdapter da2 = new SqlDataAdapter("Select * from billbackup", con);
              //  DataSet ds2 = new DataSet();
              //  da2.Fill(ds2);
               // dataGrid1.DataSource = ds2.Tables[0];

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
                SqlDataAdapter da4 = new SqlDataAdapter("Select * from billbackup ", con);
                SqlCommand cm = new SqlCommand();
                //  if (MessageBox.Show("Are You Sure to Delete the all Bill Details?", "Pharmacy",
                //        
                //                      MessageBoxButtons.OKCancel , MessageBoxIcon.Exclamation ))

                if (MessageBox.Show("Are You Sure to Delete the all Bill Backup?", "My Application",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
                {
                    cm.Connection = con;
                    con.Open();

                    cm.CommandText = "delete  from billbackup";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("You must Enter the Batch No", "Jafer Ali",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Focus();
                }
                else
                {


                    string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                    SqlConnection con = new SqlConnection(connecrionstring);
                    SqlCommand cm = new SqlCommand();

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from billbackup where [Bill no]='" + textBox1.Text + "'", con);
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

                        cm.CommandText = "delete from billbackup where [Bill No]='" + textBox1.Text + "'";
                        //cm.CommandText = "delete from stock";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from billbackup", con);
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
    }
}