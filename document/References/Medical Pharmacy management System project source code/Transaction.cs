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
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from BILL", con);

            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGrid1.DataSource = ds2.Tables[0];



          //  string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
           // SqlConnection con = new SqlConnection(connecrionstring);
           // SqlCommand cm = new SqlCommand();
           
            int i = 0;
            Decimal sum = 0;
            {
                for (i = 0; i < ds2.Tables[0].Rows.Count; )
                {
                    
                    sum = sum + Convert.ToDecimal (ds2.Tables[0].Rows[i][1]);

                   label1.Text  = sum.ToString();
                    i++;
                    // MessageBox.Show(sum.ToString());
                }
            }



            SqlDataAdapter da3 = new SqlDataAdapter("Select distinct[date] from bill ", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            if (ds3.Tables[0].Rows.Count > 0)
            {
                int j = 0;
                for (j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    comboBox1.Items.Add((ds3.Tables[0].Rows[j]["date"]));
                    comboBox2.Items.Add((ds3.Tables[0].Rows[j]["date"]));
                    // cboZone.Items.Add(Trim(ds1.Tables(0).Rows(i)(1)))
                }

            }







        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
                SqlDataAdapter da4 = new SqlDataAdapter("Select * from bill ", con);
                SqlCommand cm = new SqlCommand();
                //  if (MessageBox.Show("Are You Sure to Delete the all Bill Details?", "Pharmacy",
                //        
                //                      MessageBoxButtons.OKCancel , MessageBoxIcon.Exclamation ))

                if (MessageBox.Show("Are You Sure to Delete the all Bill Details?", "My Application",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
                {
                    cm.Connection = con;
                    con.Open();

                    cm.CommandText = "delete  from BILL";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from bill where [Date]>='" + comboBox1.Text + "' and [Date]<='" + comboBox2.Text + "'", con);
            // SqlDataAdapter da2 = new SqlDataAdapter("Select * from bill where [Date]>='" + dateTimePicker1.Text + "' and [Date]<='" + dateTimePicker2.Text + "'order by [Date]", con);

            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGrid1.DataSource = ds2.Tables[0];

            int i = 0;
            Decimal sum = 0;
            {
                for (i = 0; i < ds2.Tables[0].Rows.Count; )
                {

                    sum = sum + Convert.ToDecimal(ds2.Tables[0].Rows[i][1]);

                    label1.Text = sum.ToString();
                    i++;
                    // MessageBox.Show(sum.ToString());
                }
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
                cm.CommandText = "Delete from bill where [Date]>='" + comboBox1.Text + "' and [Date]<='" + comboBox2.Text + "'";
                cm.ExecuteNonQuery();

                MessageBox.Show("Deleted successfully", "Jafer Ali",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                SqlDataAdapter da4 = new SqlDataAdapter("Select * from bill ", con);


                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                dataGrid1.DataSource = ds4.Tables[0];


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

    }
}