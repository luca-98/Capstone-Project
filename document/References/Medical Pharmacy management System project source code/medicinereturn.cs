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
    public partial class Form7 : Form
    {
        
        
        public Form7()
        {
            InitializeComponent();
           
        }

        private void txtbat_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyCode == Keys.Enter)
                    {

                        string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                        SqlConnection con = new SqlConnection(connecrionstring);
                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        if (txtbat.Text == "")
                        {
                            // MessageBox.Show("Enter The Invoice No");
                            MessageBox.Show("You must Enter a Batch No", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtbat.Focus();
                        }
                        else if (ds2.Tables[0].Rows.Count < 1)
                        {
                            //   MessageBox.Show((ds.Tables[0].Rows.Count < 1).ToString());
                            // MessageBox.Show("No record ");
                            MessageBox.Show("No Record Found.", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        else
                        {

                            txtbat.Text = (ds2.Tables[0].Rows[0][0].ToString());
                            txtmed.Text = (ds2.Tables[0].Rows[0][1].ToString());
                            txtmfc.Text = (ds2.Tables[0].Rows[0][2].ToString());
                            txtpri.Text = (ds2.Tables[0].Rows[0][3].ToString());
                            txtstock.Text = (ds2.Tables[0].Rows[0][9].ToString());
                             txtexp.Text = (ds2.Tables[0].Rows[0][4].ToString());
                          txtloc.Text = (ds2.Tables[0].Rows[0][5].ToString());
                          //  txttaxper.Text = (ds2.Tables[0].Rows[0][8].ToString());
                         //  txttaxamt.Text = (ds2.Tables[0].Rows[0][9].ToString());
                        }

        }
           
                }

        private void Form7_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                if (txtbat.Text == "")
                {
                    MessageBox.Show("Enter the Batch No", "Jafer Ali",
                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                    SqlConnection con = new SqlConnection(connecrionstring);
                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
                    DataSet ds2 = new DataSet();
                    SqlCommand cm = new SqlCommand();
                    int qty = int.Parse(txtstock.Text) + int.Parse(txtqty.Text);
                    //  MessageBox.Show(qty.ToString());
                    txtstock.Text = qty.ToString();
                    decimal amt = decimal.Parse(txtqty.Text) * decimal.Parse(txtpri.Text);
                    //  MessageBox.Show(amt.ToString());
                    txttotamt.Text = amt.ToString();
                    cm.Connection = con;
                    con.Open();
                    cm.CommandText = "update stock set quantity=" + qty + "where [batch no]='" + txtbat.Text + "'";
                    cm.ExecuteNonQuery();
                  //  con.Close();
                    cm.CommandText = "insert into re values('" + txtbill.Text + "','" + txtbat.Text + "','" + txtmed.Text + "','" + txtmfc.Text + "','" + txtpur.Text + "','" + date.Text + "','" + txtqty.Text + "','" + txtpri.Text + "','" + txttotamt.Text + "')";
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Returned successfully", "Jafer Ali",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
 
                    txtbill.Clear();
                    txtmfc.Clear();
                    txtbat.Clear();
                    txtpri.Clear();
                   txtqty.Clear();
                   txttotamt.Clear();
                    txtmed.Clear();
                   
                   txtstock.Clear();
                 
                   // txttaxamt.Clear();

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from re", con);

                   DataSet ds3 = new DataSet();
                   da3.Fill(ds3);
                    dataGrid1.DataSource = ds3.Tables[0];


                }
            }

       
           catch (Exception ex)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbill.Text == "")
                {
                    MessageBox.Show("You must Enter the Bill No", "Jafer Ali",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtbill.Focus();
                }
                else
                {
                    string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                    SqlConnection con = new SqlConnection(connecrionstring);

                    SqlCommand cm = new SqlCommand();


                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from re where [bill no]='" + txtbill.Text + "'", con);
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
                        cm.CommandText = "delete from re where [bill No]='" + txtbill.Text + "'";
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

        
    }
}