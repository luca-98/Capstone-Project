using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient ;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace databaseC
{
    public partial class Stockdetails : Form
    {
        public Stockdetails()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock", con);

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
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [batch no] like '%" + textBox1.Text + "%'" + "or [medicine name] like '%" + textBox1.Text + "%'" + "or quantity like'%" + textBox1.Text + "%'" + "or [expiry date]like'%" + textBox1.Text + "%'", con);

        da2.Fill(ds2);
        dataGrid1.DataSource = ds2.Tables[0];
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
               // MessageBox.Show("HAI");
            }    
        }

        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.F10 )
            {
              //  e.Handled = true;
                
            //    MessageBox.Show("HAI");
            }

        }

        private void Form3_KeyUp(object sender, KeyEventArgs e)
        {

         //   if (e.KeyCode == Keys.F10)
          //  {
             //   MessageBox.Show("HAI");
          //  }  
        }

        private void Form3_Leave(object sender, EventArgs e)
        {
           
        }

        private void Form3_Layout(object sender, LayoutEventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
              //  MessageBox.Show("HAI");
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbat.Text == "")
                {
                    MessageBox.Show("You must Enter the Batch No", "Jafer Ali",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtbat.Focus();
                }
                else
                {


                    string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                    SqlConnection con = new SqlConnection(connecrionstring);
                    SqlCommand cm = new SqlCommand();

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from stock where [Batch no]='" + txtbat.Text + "'", con);
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

                        cm.CommandText = "delete from stock where [Batch No]='" + txtbat.Text + "'";
                        //cm.CommandText = "delete from stock";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
                SqlDataAdapter da4 = new SqlDataAdapter("Select * from stock ", con);
                SqlCommand cm = new SqlCommand();
                //  if (MessageBox.Show("Are You Sure to Delete the all Bill Details?", "Pharmacy",
                //        
                //                      MessageBoxButtons.OKCancel , MessageBoxIcon.Exclamation ))

                if (MessageBox.Show("Are You Sure to Delete the all Stock?", "My Application",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
                {
                    cm.Connection = con;
                    con.Open();

                    cm.CommandText = "delete  from stock";
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

        private void txtbat_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
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
                    txtmrpp.Text = (ds.Tables[0].Rows[0][3].ToString());
                    //  txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                    txtexp.Text = (ds.Tables[0].Rows[0][4].ToString());
                    //

                    txtloc.Text = (ds.Tables[0].Rows[0][5].ToString());
                    txttaxper.Text = (ds.Tables[0].Rows[0][6].ToString());
                    txttaxp.Text = (ds.Tables[0].Rows[0][7].ToString());
                    txtsell.Text = (ds.Tables[0].Rows[0][8].ToString());
                  ////  txtstock.Text = (ds.Tables[0].Rows[0][9].ToString());

                  //  txttotamt.Text = (ds.Tables[0].Rows[0][10].ToString());





                  //  button10.Enabled = false;

                 //   txtqty.Text = "0";
                  //  button3.Enabled = true;

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
            ////    int qty = int.Parse(txtstock.Text) + int.Parse(txtqty.Text);
       ////         txtqty.Text = qty.ToString();

                cm.CommandText = "update stock set [Medicine Name]='" + txtmed.Text + "',[company Name]='" + txtmfc.Text + "',[MRP]='" + txtmrpp.Text + "',[Expiry Date]='" + txtexp.Text + "',[tax percent]='" + txttaxper.Text + "',[tax amount]='" + txttaxp.Text + "',[Unit Price]='" + txtsell.Text + "' where [batch No]='" + txtbat.Text + "'";
                //    cm.CommandText = "update stock set [Medicine Name]='" + txtmed.Text + "',[company Name]='" + txtmfc.Text + "',[Expiry Date]='" + txtexp.Text + "',[Location ]='"+ txtloc.Text +"' where [batch No]='" + txtbat.Text + "'";
                cm.ExecuteNonQuery();
                MessageBox.Show("Updated successfully", "Jafer Ali",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

               clear();
                button1.Enabled = true;
                button4.Visible = true;
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGrid1.DataSource = ds2.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("UPDATE ONLY FOR STOCK RECORDS.YOU MUST ENTER THE BATCH NO AND PRESS ENTER BUTTON");
                txtbat.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           try
            {
                decimal p, q, z, m, j, a, f;
                if ((txtsell.Text) == "")
                {
                    //MessageBox.Show("Enter the Sell Price");
                    MessageBox.Show("You must Enter a Sell Price.", "Sell Entry Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtsell.Focus();
                }
                               
                    j = decimal.Parse(txtsell.Text);
                    q = 100;
                    a = j / q;
                    // MessageBox.Show(z.ToString());
                
                if (txttaxper.Text == "")
                {

                    MessageBox.Show("You must Enter a Tax Percentage.", "VAT Entry Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txttaxper.Focus();


                   }
                else
                {
                    // z = decimal.Parse(txttaxper.Text) * z;
                    a = decimal.Parse(txttaxper.Text) * a;





                    txttaxp.Text = System.Convert.ToString(a).ToString();

                    int v;
                    string v1 = txttaxp.Text;
                    v = v1.LastIndexOf(".");
                    //  string vv = v1.Substring(0, v + 3);
                    //  txttaxp.Text = vv;
                    if (v == v)
                    {
                        string vv = v1.Substring(0, v + 3);
                        txttaxp.Text = vv;
                    }

                    else
                    {
                        txttaxp.Text = System.Convert.ToString(a).ToString();
                    }




                    //    m = p + z;
                    f = j + a;
                    //    txtpri.Text = m.ToString();
                    txtmrpp.Text = f.ToString();


                    int k;
                    string s = txtmrpp.Text;
                    k = s.LastIndexOf(".");
                    //  string ss = s.Substring(0, k+ 3);
                    // txtmrpp.Text = ss;
                    if (k == k)
                    {
                        string ss = s.Substring(0, k + 3);
                        txtmrpp.Text = ss;
                    }

                    else
                    {
                        txtmrpp.Text = f.ToString();
                    }





                }
           }


           catch (Exception ex)
           {
               MessageBox.Show("YOU MUST ENTER THE FORMAT 0.00 ", ex.Message);
              txtbat.Focus();
            }
        }
        private void clear()
        {
            txtmed.Clear();
          //  txtbat.Visible = true;
          //  txtin.Clear();
          //  txtexp.Enabled = false;
            txtloc.Clear();
            txtmfc.Clear();
            txtmrpp.Text = "0.00";
          //  txtpri.Clear();
            txtsell.Clear();
          //  txtstock.Clear();
          //  txttaxamt.Clear();
          //  txttaxamt.Clear();
            txttaxp.Clear();
            txttaxper.Text = "0";
          //  txttotamt.Clear();
          //  txtuni.Clear();
            txtbat.Clear();
            txtexp.Clear();

        }


    }
}