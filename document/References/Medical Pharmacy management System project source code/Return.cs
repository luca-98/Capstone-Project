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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txtin.Focus();

            string date1;
            date1 = DateTime.Now.Date.ToString("dd/MM/yyyy");
            date.Text = date1.ToString();

            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from stockreturn", con);

            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGrid1.DataSource = ds2.Tables[0];

            txtin.Focus();

        }

        private void txtbat_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtin_KeyDown(object sender, KeyEventArgs e)
        {
            {
                {
                    if (e.KeyCode == Keys.Enter)
                    {

                        string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                        SqlConnection con = new SqlConnection(connecrionstring);
                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from stockpurchase where [invoice No]='" + txtin.Text + "'", con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        if (txtin.Text == "")
                        {
                            // MessageBox.Show("Enter The Invoice No");
                            MessageBox.Show("You must Enter a Invoice No.", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtin.Focus();
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

                            txtbat.Text = (ds2.Tables[0].Rows[0][2].ToString());
                            txtmed.Text = (ds2.Tables[0].Rows[0][3].ToString());
                            txtmfc.Text = (ds2.Tables[0].Rows[0][4].ToString());
                            txtpri.Text = (ds2.Tables[0].Rows[0][5].ToString());
                            // txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                            // txtexp.Text = (ds.Tables[0].Rows[0][5].ToString());
                            txtuni.Text = (ds2.Tables[0].Rows[0][7].ToString());
                            txttaxper.Text = (ds2.Tables[0].Rows[0][8].ToString());
                            txttaxamt.Text = (ds2.Tables[0].Rows[0][9].ToString());

                          ////  txtpurstk.Text = (ds2.Tables[0].Rows[0][10].ToString());
                          ////  currentamt.Text = (ds2.Tables[0].Rows[0][11].ToString());
                            //
                            // txtuni.Text = (ds.Tables[0].Rows[0][4].ToString());
                            //  txttaxper.Text = (ds.Tables[0].Rows[0][6].ToString());
                            //   txttaxamt.Text = (ds.Tables[0].Rows[0][7].ToString());






                            SqlDataAdapter da1 = new SqlDataAdapter("Select * from stock where [Batch No]='" + txtbat.Text + "'", con);
                            DataSet ds = new DataSet();
                            da1.Fill(ds);

                            if (ds.Tables[0].Rows.Count < 1)
                            {
                                //   MessageBox.Show((ds.Tables[0].Rows.Count < 1).ToString());
                                //  MessageBox.Show("no record");
                                MessageBox.Show("No Record Found.", "Jafer Ali",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtbat.Focus();
                            }
                            else
                            {
                                //txtbat.Text = (ds.Tables[0].Rows[0][0].ToString());
                                txtmed.Text = (ds.Tables[0].Rows[0][1].ToString());


                                txtmfc.Text = (ds.Tables[0].Rows[0][2].ToString());
                            ////    currentamt.Text = (ds.Tables[0].Rows[0][10].ToString());
                                //  txtmrpp.Text = (ds.Tables[0].Rows[0][3].ToString());
                                //  txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                                //   txtexp.Text = (ds.Tables[0].Rows[0][4].ToString());
                                //

                                //  txtloc.Text = (ds.Tables[0].Rows[0][5].ToString());
                                //   txttaxper.Text = (ds.Tables[0].Rows[0][6].ToString());
                                //  txttaxp.Text = (ds.Tables[0].Rows[0][7].ToString());
                                //   txtsell.Text = (ds.Tables[0].Rows[0][8].ToString());
                                txtstock.Text = (ds.Tables[0].Rows[0][9].ToString());

                                //  txttotamt.Text = (ds.Tables[0].Rows[0][10].ToString());





                                //    button10.Enabled = false;







                                // string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                                // SqlConnection con = new SqlConnection(connecrionstring);


                            }






                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                SqlConnection con = new SqlConnection(connecrionstring);
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
                DataSet ds2 = new DataSet();
                SqlCommand cm = new SqlCommand();
                da2.Fill(ds2);
                MessageBox.Show(ds2.Tables[0].Rows[0][9].ToString());
                int qty = int.Parse(txtstock.Text) - int.Parse(txtqty.Text);
                MessageBox.Show(qty.ToString());
                txtstock.Text = qty.ToString();
                decimal amt = decimal.Parse(txtqty.Text) * decimal.Parse(txtpri.Text);
                MessageBox.Show(amt.ToString());
                txttotamt.Text = amt.ToString();
                cm.Connection = con;
                con.Open();
                cm.CommandText = "update stock set quantity=" + qty + "where [batch no]='" + txtbat.Text + "'";
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtin.Text == "")
                {
                    MessageBox.Show("Enter the Invoice No", "Jafer Ali",
                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                    SqlConnection con = new SqlConnection(connecrionstring);
                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
                    DataSet ds2 = new DataSet();
                    SqlCommand cm = new SqlCommand();
                    int qty = int.Parse(txtstock.Text) - int.Parse(txtqty.Text);
                    //  MessageBox.Show(qty.ToString());
                    txtstock.Text = qty.ToString();
                    decimal amt = decimal.Parse(txtqty.Text) * decimal.Parse(txtpri.Text);
                  //  MessageBox.Show(amt.ToString());
                    txttotamt.Text = amt.ToString();
                    // 14-11-08
                  //  decimal amt1 = decimal.Parse(currentamt.Text) - decimal.Parse(txttotamt.Text);
                  //  MessageBox.Show(amt1.ToString());
                    // 14-11-08
                    cm.Connection = con;
                    con.Open();
                    cm.CommandText = "update stock set quantity=" + qty + "where [batch no]='" + txtbat.Text + "'";
                    cm.ExecuteNonQuery();
                    //  cm.Connection = con;
                    //   con.Open();
                   // 14-11-08
                 //   SqlDataAdapter da5 = new SqlDataAdapter("Select * from stockpurchase where [invoice no]='" + txtin.Text + "'", con);
                 //   DataSet ds5 = new DataSet();
                  //  int qty1 = int.Parse(txtpurstk.Text) - int.Parse(txtqty.Text);
                 
               //     cm.CommandText = "update stockpurchase set quantity=" + qty1 + "where [invoice No]='" + txtin.Text + "'";
                 //   cm.ExecuteNonQuery();
                    // 14-11-08

                    cm.CommandText = "insert into stockreturn values('" + txtin.Text + "','" + date.Text + "','" + txtbat.Text + "','" + txtmed.Text + "','" + txtmfc.Text + "','" + txtqty.Text + "','" + txtpri.Text + "','" + txttotamt.Text + "')";
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Returned successfully", "Jafer Ali",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtin.Clear();
                    txtmfc.Clear();
                    txtbat.Clear();
                    txtpri.Clear();
                    txtqty.Clear();
                    txttotamt.Clear();
                    txtmed.Clear();
                    //txtmrpp.Clear();
                    txtstock.Clear();
                    txttaxper.Clear();
                    txtuni.Clear();
                   // currentamt.Clear();
                    txttaxamt.Clear();

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from stockreturn", con);

                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    dataGrid1.DataSource = ds3.Tables[0];


                }
            }
            catch (Exception ex)
            { }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtin.Clear();
            //txtexp.Enabled = false;
          //  txtloc.Clear();
            txtmfc.Clear();
           // txtmrpp.Clear();
            txtpri.Clear();
          //  txtsell.Clear();
            txtstock.Clear();
            txttaxamt.Clear();
            txttaxamt.Clear();
          //  txttaxp.Clear();
            txttaxper.Clear();
            txttotamt.Clear();
            txtuni.Clear();
            txtbat.Clear();
        //    txtexp.Clear();
            txtqty.Clear();
       //     currentamt.Clear();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtin.Text == "")
                {
                    MessageBox.Show("You must Enter the Invoice No", "Jafer Ali",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtin.Focus();
                }
                else
                {
                    string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                    SqlConnection con = new SqlConnection(connecrionstring);

                    SqlCommand cm = new SqlCommand();


                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from stockreturn where [invoice no]='" + txtin.Text + "'", con);
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
                        cm.CommandText = "delete from stockreturn where [Invoice No]='" + txtin.Text + "'";
                        //cm.CommandText = "delete from stock";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from stockreturn", con);
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

        private void Return_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {

                System.Diagnostics.Process.Start("calc.exe");


              //  txtbat.Focus();
            }
        }
    }
}