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
    public partial class Purchase1 : Form
    {
       
        public Purchase1()
        {
            InitializeComponent();
          

        }
        //public static Form1 jaja;
        
         
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtin.Text == "")
                {
                    MessageBox.Show("You must enter the Invoice No.", "Jafer Ali",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtin.Focus();
                }

                else
                {
                    string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";


                    SqlConnection con = new SqlConnection(connectionstring);

                    SqlCommand cm = new SqlCommand();

                    cm.Connection = con;
                    con.Open();
                    // cm.CommandText = "Insert into stock values('" + txtsrno.Text + "','" + txtmed.Text + "','" + txtmfc.Text + "','" + txtbat.Text + "','" + txtpri.Text + "','" + txtmfcd.Text + "','" + txtexp.Text + "','" + txttaxper.Text + "','" + txttaxamt.Text + "','" + txtuni.Text + "','" + txtqty.Text +"','" + txttotamt.Text +"')";
                    // cm.CommandText = "INSERT INTO stockpurchase values([Invoice no],[batch no],[medicine name],[company name],[mfg.date],[expiry date],[unit price],[quantity],[amount])('" + txtin.Text + "','" + txtbat.Text + "','" + txtmed.Text + "','" + txtmfc.Text + "','" + txtmfcd.Text + "','" + txtexp.Text + "','" + txtuni.Text + "','" + txtqty.Text + "','" + txttotamt.Text + "')";
                    cm.CommandText = "INSERT INTO stockpurchase values('" + txtin.Text + "','" + date.Text + "','" + txtbat.Text + "','" + txtmed.Text + "','" + txtmfc.Text + "','" + txtpri.Text + "','" + txtexp.Text + "','" + txtuni.Text + "','" + txttaxper.Text + "','" + txttaxamt.Text + "','" + txtqty.Text + "','" + txttotamt.Text + "')";
                    cm.ExecuteNonQuery();

//15

                    //SqlCommand cm = new SqlCommand();
                    SqlDataAdapter da5 = new SqlDataAdapter("Select * from stock where [Batch No]='" + txtbat.Text + "'", con);
                    DataSet ds6 = new DataSet();
                    da5.Fill(ds6);
                    //int quantity =(ds.Tables[0].Rows[0][9]).ToString () + (txtqty.Text).ToString ();
                    int quantity;
                    //  quantity = (ds.Tables[0].Rows[0][9]).ToString ()+int.Parse (txtqty.Text );
                    quantity = Convert.ToInt32(ds6.Tables[0].Rows[0][9]) + int.Parse(txtqty.Text);

                   // MessageBox.Show(quantity.ToString());

//15
                    cm.CommandText = "Update stock  set [Medicine Name]='" + txtmed.Text + "',[Company Name]='" + txtmfc.Text + "',mrp='" + txtmrpp.Text + "',[Expiry Date]='" + txtexp.Text + "',[Location]='" + txtloc.Text + "',[Tax Percent]='" + txttaxper.Text + "',[Tax Amount]='" + txttaxp.Text + "',[Unit Price]='" + txtsell.Text + "',Quantity='" + quantity + "',Amount='" + txttotamt.Text + "' where [batch no]='" + txtbat.Text + "'";
                    cm.ExecuteNonQuery();
                   // MessageBox.Show("Record has been saved Successfully");
                    MessageBox.Show("Record has been saved Successfully.", "Jafer Ali",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clear();

                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from stockpurchase", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    dataGrid1.DataSource = ds2.Tables[0];

                }
                txtded.Text = "0";
                txtqty.Text = "0";
                txttotamt.Text = "0";
             //   txttaxp.Text = "0";
                txttaxper.Text = "0";
                txtsell.Text = "0.00";
                txtuni.Text = "0.00";
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
                MessageBox.Show("Already Exist", "Jafer Ali");
            }


        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //int txtamt1 = Convert.ToInt32(txtqty.Text) * Convert.ToInt32(txtuni.Text);

                //  txtamt.Text = txtamt1.ToString();
                //txtamt.Text =Convert.ToInt32 (txtuni.Text)/100 * Convert.ToInt32(txttax.Text);
                decimal p, q, z, m, j, a, f;
                if (txtuni.Text =="")
                {
                   // MessageBox.Show("Enter the Purchase Price", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("You must Enter a Purchase Price.", "Purchase Entry Error", 
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtuni.Focus ();
                }
                p = decimal.Parse(txtuni.Text);


                if ((txtsell.Text) == "")
                {
                    //MessageBox.Show("Enter the Sell Price");
                    MessageBox.Show("You must Enter a Sell Price.", "Sell Entry Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtsell.Focus();
                }
                j = decimal.Parse(txtsell.Text);




                q = 100;

                z = p / q;
                a = j / q;
               // MessageBox.Show(z.ToString());
                if (txttaxper.Text == "")
                {
                  //  MessageBox.Show("Enter the Tax Percentage");
                    MessageBox.Show("You must Enter a Tax Percentage.", "VAT Entry Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txttaxper.Focus();
                }

                z = decimal.Parse(txttaxper.Text) * z;
                a = decimal.Parse(txttaxper.Text) * a;
              // txttaxamt.Text = System.Convert.ToString(z).ToString();
               txttaxamt.Text = z.ToString();
              
                int d;
             string s2 = txttaxamt.Text;
               d = s2.LastIndexOf(".");
            //  string ssa = s2.Substring(0, d + 2);
             //  txttaxamt.Text = ssa;
            // MessageBox.Show(d.ToString());
               if (d==d )
               {
                   string ssa = s2.Substring(0, d + 3);
                   txttaxamt.Text = ssa;
               }
               else
               {
                   txttaxamt.Text = z.ToString();
               }


                // txttaxamt.Text = FormatException(a, "#,###.##");
              //  Label8.Text = Format(count, "#,###.##")


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


                //txtpri.Text =Convert.ToInt32 (txtuni.Text).ToString () + int.Parse(txtamt.Text ); 
                // txtpri.Text = System.Convert.ToInt32 (p).ToString   + Convert.ToInt32(txtamt.Text) ;

                m = p + z;
                f = j + a;
                txtpri.Text = m.ToString();

                int n;
                string s1 = txtpri.Text;
                n = s1.LastIndexOf(".");
               //MessageBox.Show(n.ToString());
                if (n == n)
                {
                    string sss = s1.Substring(0, n + 3);
                    txtpri.Text = sss;
                }
               
                else
                {
                    txtpri.Text = m.ToString();
                }
               
              // txtpri.Text = sss;

                txtmrpp.Text = f.ToString();

                int k;
                string s = txtmrpp.Text;
                k= s.LastIndexOf(".");
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



                if (txtqty.Text == "")
                {
                   // MessageBox.Show("Enter the Quantity");
                    MessageBox.Show("You must Enter a Quantity.", "Quantity Entry Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtqty.Focus();
                }
                decimal totqty = decimal.Parse(txtqty.Text);
                decimal x, y;
                y = Decimal.Parse(txtuni.Text);
                x = totqty * Decimal.Parse (txtpri.Text) ;

                //15-11-08
                Decimal ded;
                ded = (x) - Decimal.Parse(txtded.Text);

           //     txttotamt.Text = x.ToString();
                txttotamt.Text = ded.ToString();


               

               


           }
            catch (Exception ex) 
           {
              MessageBox.Show("YOU MUST ENTER THE FORMAT 0.00",ex.Message);
            }
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
         //  for (int i = textBox1; i <= textBox2 ; i++)
            button3.Enabled = false;
          button8.Enabled = false ;
          button10.Enabled = false;
   // int answer=0;
//answer = answer + i;
//listBox1.Items.Add( answer.ToString() );
            DataSet ds2 = new DataSet();

            string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connectionstring);

            SqlDataAdapter da1 = new SqlDataAdapter("Select * from stockpurchase ", con);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            dataGrid1.DataSource = ds.Tables[0];




            string date1;
            date1 = DateTime.Now.Date.ToString("dd/MM/yyyy");
            date.Text = date1.ToString();







        }

        private void button4_Click(object sender, EventArgs e)
        {

            string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
            
            SqlConnection con = new SqlConnection(connectionstring);

            SqlDataAdapter da1 = new SqlDataAdapter("Select * from stock where [Batch No]='" + txtbat.Text + "'", con);
            DataSet ds =new DataSet();
            da1.Fill(ds);
           
                if (ds.Tables[0].Rows.Count < 1 )
                {
                    //MessageBox.Show((ds.Tables[0].Rows.Count < 1).ToString());
                    // MessageBox.Show("no record");
                }
                else
                {
                    txtbat.Text = (ds.Tables[0].Rows[0][0].ToString());
                    txtmed.Text = (ds.Tables[0].Rows[0][1].ToString());
                    txtmfc.Text = (ds.Tables[0].Rows[0][2].ToString());
                    txtpri.Text = (ds.Tables[0].Rows[0][3].ToString());
                   // txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                    txtexp.Text = (ds.Tables[0].Rows[0][5].ToString());
                    //
                   // txtuni.Text = (ds.Tables[0].Rows[0][4].ToString());
                    txttaxper.Text = (ds.Tables[0].Rows[0][6].ToString());
                    txttaxamt.Text = (ds.Tables[0].Rows[0][7].ToString());
                    txtuni.Text = (ds.Tables[0].Rows[0][8].ToString());
                    txtqty.Text = (ds.Tables[0].Rows[0][9].ToString());

                      txttotamt.Text = (ds.Tables[0].Rows[0][10].ToString()); 
                }
            }   
        
//Update
      /*  private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);

                SqlCommand cm = new SqlCommand();
                cm.Connection = con;
                con.Open();
                int qty = int.Parse(txtstock.Text) + int.Parse(txtqty.Text);
                txtqty.Text = qty.ToString();

                cm.CommandText = "update stock set [Medicine Name]='" + txtmed.Text + "',[company Name]='" + txtmfc.Text + "',[MRP]='" + txtmrpp.Text + "',[Expiry Date]='" + txtexp.Text + "',[tax percent]='" + txttaxper.Text + "',[tax amount]='" + txttaxp.Text + "',[Quantity]='" + txtqty.Text + "',[Amount]='" + txttotamt.Text + "',[Unit Price]='"+txtsell.Text +"' where [batch No]='" + txtbat.Text + "'";
                //    cm.CommandText = "update stock set [Medicine Name]='" + txtmed.Text + "',[company Name]='" + txtmfc.Text + "',[Expiry Date]='" + txtexp.Text + "',[Location ]='"+ txtloc.Text +"' where [batch No]='" + txtbat.Text + "'";
                cm.ExecuteNonQuery();
                MessageBox.Show("Updated successfully", "Jafer Ali",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                clear();
                button1.Enabled = true ;
                button4.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("UPDATE ONLY FOR STOCK RECORDS.YOU MUST ENTER THE BATCH NO AND PRESS ENTER BUTTON");
                txtbat.Focus();
            }
        }*/

        private void button6_Click(object sender, EventArgs e)
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
                    string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                    SqlConnection con = new SqlConnection(connectionstring);
                    SqlCommand cm = new SqlCommand();

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from stockpurchase where [invoice no]='"+ txtin.Text +"'", con);
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
                        cm.CommandText = "delete from stockpurchase where [invoice No]='" + txtin.Text + "'";
                        //cm.CommandText = "delete from stock";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully", "Jafer Ali",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtin.Clear();

                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from stockpurchase", con);
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connectionstring);
                SqlDataAdapter da1 = new SqlDataAdapter("Select * from stockpurchase where [invoice No]='" + txtin.Text + "'", con);
                DataSet ds = new DataSet();
                da1.Fill(ds);
                if (txtin.Text == "")
                {
                    // MessageBox.Show("Enter The Invoice No");
                    MessageBox.Show("You must Enter a Invoice No.", "Jafer Ali",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtin.Focus();
                }
                else if (ds.Tables[0].Rows.Count < 1)
                {
                    //   MessageBox.Show((ds.Tables[0].Rows.Count < 1).ToString());
                    // MessageBox.Show("No record ");
                    MessageBox.Show("No Record Found.", "Jafer Ali",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    date.Text = (ds.Tables[0].Rows[0][1].ToString());
                    txtbat.Text = (ds.Tables[0].Rows[0][2].ToString());
                    txtmed.Text = (ds.Tables[0].Rows[0][3].ToString());
                    txtmfc.Text = (ds.Tables[0].Rows[0][4].ToString());
                    txtpri.Text = (ds.Tables[0].Rows[0][5].ToString());
                    // txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                    txtexp.Text = (ds.Tables[0].Rows[0][6].ToString());
                    txtuni.Text = (ds.Tables[0].Rows[0][7].ToString());
                    txttaxper.Text = (ds.Tables[0].Rows[0][8].ToString());
                    txttaxamt.Text = (ds.Tables[0].Rows[0][9].ToString());

                    txtstock.Text = (ds.Tables[0].Rows[0][10].ToString());
                    currentamt.Text = (ds.Tables[0].Rows[0][11].ToString());
                    //
                    // txtuni.Text = (ds.Tables[0].Rows[0][4].ToString());
                    //  txttaxper.Text = (ds.Tables[0].Rows[0][6].ToString());
                    //   txttaxamt.Text = (ds.Tables[0].Rows[0][7].ToString());


                    //Edit
                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [Batch No]='" + txtbat.Text + "'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    if (ds2.Tables[0].Rows.Count < 1)
                    {
                        //   MessageBox.Show((ds.Tables[0].Rows.Count < 1).ToString());
                        // MessageBox.Show("no record");
                        MessageBox.Show("No Record Found in Stock.", "Jafer Ali",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //txtbat.Text = (ds.Tables[0].Rows[0][0].ToString());
                        //     txtmed.Text = (ds2.Tables[0].Rows[0][1].ToString());


                        //       txtmfc.Text = (ds2.Tables[0].Rows[0][2].ToString());
                        txtmrpp.Text = (ds2.Tables[0].Rows[0][3].ToString());
                        //  txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                        txtexp.Text = (ds2.Tables[0].Rows[0][4].ToString());
                        //

                        txtloc.Text = (ds2.Tables[0].Rows[0][5].ToString());
                        txttaxper.Text = (ds2.Tables[0].Rows[0][6].ToString());
                        txttaxp.Text = (ds2.Tables[0].Rows[0][7].ToString());
                        txtsell.Text = (ds2.Tables[0].Rows[0][8].ToString());
                        /////  txtstock.Text = (ds2.Tables[0].Rows[0][9].ToString());

                        //  txttotamt.Text = (ds2.Tables[0].Rows[0][10].ToString());
                    }
                    //edit
                    button7.Enabled = false;
               //  edit  // button5.Enabled = false;
                    button6.Enabled = false;
                    button3.Enabled = false;

                  button4.Enabled = false;
                  button10.Enabled = true;

                }


                
                // button10.Enabled = false;



            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }








        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbat.Text == "" || txtmed.Text == "")
                {
                    MessageBox.Show("Enter the Details", "Pharmacy",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtbat.Focus();
                }
                else
                {
                    string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";


                    SqlConnection con = new SqlConnection(connectionstring);

                    SqlCommand cm = new SqlCommand();

                    cm.Connection = con;
                    con.Open();
                    // cm.CommandText = "Insert into stock values('" + txtsrno.Text + "','" + txtmed.Text + "','" + txtmfc.Text + "','" + txtbat.Text + "','" + txtpri.Text + "','" + txtmfcd.Text + "','" + txtexp.Text + "','" + txttaxper.Text + "','" + txttaxamt.Text + "','" + txtuni.Text + "','" + txtqty.Text +"','" + txttotamt.Text +"')";
                   // cm.CommandText = "INSERT INTO stock([Batch No],[medicine name]) values('" + txtbat.Text + "','" + txtmed.Text + "')";

                    cm.CommandText = "INSERT INTO stock([Batch No],[medicine name],[Quantity]) values('" + txtbat.Text + "','" + txtmed.Text + "','"+txtqty.Text +"')";


                    cm.ExecuteNonQuery();
                    MessageBox.Show("Item has been saved successfully", "Pharmacy",
                     
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    enabled();
                    txtin.Focus();
                }
            }
            catch (Exception exp)
            {
             //   MessageBox.Show("ERROR:" + exp, "Jafer Ali");
                MessageBox.Show("Already Exist","Jafer Ali");
            }
          //  clear();.
         //   enabled();
        }

        private void txtbat_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void txtbat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {

                string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connectionstring);
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
                   txtstock.Text = (ds.Tables[0].Rows[0][9].ToString());

                    txttotamt.Text = (ds.Tables[0].Rows[0][10].ToString());





                    button10.Enabled = false;

                    txtqty.Text = "0";
                    button3.Enabled = true;

                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
          Bill jform=new Bill();
          jform.ShowDialog();


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cm = new SqlCommand();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * from stock where [Batch No]='" + txtbat.Text + "'", con);
                DataSet ds = new DataSet();
                da1.Fill(ds);
                //int quantity =(ds.Tables[0].Rows[0][9]).ToString () + (txtqty.Text).ToString ();
                int quantity;
                //  quantity = (ds.Tables[0].Rows[0][9]).ToString ()+int.Parse (txtqty.Text );
                quantity = Convert.ToInt32(ds.Tables[0].Rows[0][9]) + int.Parse(txtqty.Text);
                //
                //   MessageBox.Show((ds.Tables[0].Rows[0][9]).ToString());
                textBox1.Text = quantity.ToString();
//15-10
                SqlDataAdapter da5 = new SqlDataAdapter("Select * from stockpurchase where [invoice No]='" + txtin.Text + "'", con);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                int qty;

                qty = Convert.ToInt32(ds5.Tables[0].Rows[0][10]) + int.Parse(txtqty.Text);

           //     MessageBox.Show(qty.ToString());

                //15
                decimal tot = Decimal.Parse(currentamt.Text) + Decimal.Parse(txttotamt.Text);
                txttotamt.Text = tot.ToString();
                cm.Connection = con;
                con.Open();
                cm.CommandText = "Update stockpurchase set [invoice no]='" + txtin.Text + "',[batch no]='" + txtbat.Text + "',[medicine name]='" + txtmed.Text + "',[company name]='" + txtmfc.Text + "',[Purchase Price]='" + txtpri.Text + "',[expiry date]='" + txtexp.Text + "',[unit price]='" + txtuni.Text + "',[tax percent]='" + txttaxper.Text + "',[tax amount]='" + txttaxamt.Text + "',[quantity]='" + qty + "',[amount]='" + txttotamt.Text + "' where [invoice no]='" + txtin.Text + "'";
                cm.ExecuteNonQuery();
                MessageBox.Show("Updated Stock Purchase");
                //   cm.CommandText = "Update stock set quantity =" + quantity +" where [batch no]='" + txtbat.Text + "'";
                cm.CommandText = "Update stock  set [Medicine Name]='" + txtmed.Text + "',[Company Name]='" + txtmfc.Text + "',mrp='" + txtmrpp.Text + "',[Expiry Date]='" + txtexp.Text + "',[Location]='" + txtloc.Text + "',[Tax Percent]='" + txttaxper.Text + "',[Tax Amount]='" + txttaxp.Text + "',[Unit Price]='" + txtsell.Text + "',Quantity=" + quantity + ",Amount='" + txttotamt.Text + "' where [batch no]='" + txtbat.Text + "'";

                cm.ExecuteNonQuery();
                MessageBox.Show("Updated Stock");
                clear();
                SqlDataAdapter da8 = new SqlDataAdapter("Select * from stockpurchase", con);
                DataSet ds8 = new DataSet();
                da8.Fill(ds8);
                dataGrid1.DataSource = ds8.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Stockdetails jform3 = new Stockdetails();
            jform3.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
           button8.Enabled = true;
           txtmed.Visible = true;
           txtbat.Visible = true;
           txtin.Enabled  = false;
           txtexp.Enabled = false;
           txtloc.Enabled = false;
           txtmfc.Enabled = false;
           txtmrpp.Enabled = false;
           txtpri.Enabled = false;
           txtsell.Enabled = false;
           txtstock.Enabled = false;
           txttaxamt.Enabled = false;
           txttaxamt.Enabled = false;
           txttaxp.Enabled = false;
           txttaxper.Enabled = false;
           txttotamt.Enabled = false;
           txtuni.Enabled = false;
         //  txtuni.Enabled = false;
           txtqty.Enabled = false;
           button7.Enabled = false;
       // edit//   button5.Enabled = false;
           button6.Enabled = false;
           button3.Enabled = false;
           button1.Enabled = false;
           button10.Enabled = false;
          // button2.Enabled = false;
           currentamt.Enabled = false;
            textBox1 .Enabled = false;



          //  button4.Enabled = false;
            txtbat.Focus();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button8.Enabled = true;
            txtmed.Clear ();
            txtbat.Visible = true;
            txtin.Clear();
            txtexp.Enabled = false;
            txtloc.Clear();
            txtmfc.Clear();
            txtmrpp.Clear();
            txtpri.Clear();
            
            txtstock.Clear();
            txttaxamt.Clear();
            txttaxamt.Clear();
            txttaxp.Clear();
            txttaxper.Clear();
            txttotamt.Clear();
            
            txtbat.Clear();
            txtexp.Clear();
            //  txtuni.Enabled = false;
            txtqty.Clear();
            button7.Enabled = true;
          //  edit//button5.Enabled = true;
            button6.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = true;
            button10.Enabled = false;
            button2.Enabled = true;
            currentamt.Clear();
            textBox1.Clear();
            enabled();
            txtin.Focus();
            button1.Enabled = true;
          //  button4.Visible = true;
            button3.Enabled = false;
            button12.Enabled = true;
            txtded.Text = "0";
            txtqty.Text = "0";
            txttotamt.Text = "0";
          //  txttaxp.Text = "0";
            txttaxper.Text = "0";
            txtsell.Text = "0.00";
            txtuni.Text = "0.00";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Return jform = new Return();
            jform.ShowDialog();
        }

        private void clear()
        {
            button8.Enabled = false;
            txtmed.Clear();
            txtbat.Visible = true;
            txtin.Clear();
          //  txtexp.Enabled = false;
            txtloc.Clear();
            txtmfc.Clear();
            txtmrpp.Clear();
            txtpri.Clear();
           // txtsell.Clear();
            txtstock.Clear();
            txttaxamt.Clear();
            txttaxamt.Clear();
            txttaxp.Clear();
            txttaxper.Clear();
            txttotamt.Clear();
           // txtuni.Clear();
            txtbat.Clear();
            txtexp.Clear();
            //  txtuni.Enabled = false;
            txtqty.Clear();
            button7.Enabled = true;
         // Edit  button5.Enabled = true;
            button6.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            button10.Enabled = false;
            button2.Enabled = true;
            currentamt.Clear();
            textBox1.Clear();
            txtded.Text = "0";
            txtqty.Text = "0";
            txttotamt.Text = "0";
            //  txttaxp.Text = "0";
            txttaxper.Text = "0";
            txtsell.Text = "0.00";
            txtuni.Text = "0.00";
            
        }

        private void enabled()
        {

            button8.Enabled = false;
            txtmed.Visible = true;
            txtbat.Visible = true;
            txtin.Enabled = true;
            txtexp.Enabled = true;
            txtloc.Enabled = true;
            txtmfc.Enabled = true;
            txtmrpp.Enabled = true;
            txtpri.Enabled = true;
            txtsell.Enabled = true;
            txtstock.Enabled = true;
            txttaxamt.Enabled = true;
            txttaxamt.Enabled = true;
            txttaxp.Enabled = true;
            txttaxper.Enabled = true;
            txttotamt.Enabled = true;
            txtuni.Enabled = true;
            //  txtuni.Enabled = false;
            txtqty.Enabled = true;
            button7.Enabled = true;
           //Edit button5.Enabled = true;
            button6.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = true;
           // button10.Enabled = true;
            button2.Enabled = true;
            currentamt.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Returndetails jform = new Returndetails();
            jform.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Transaction jform = new Transaction();
            jform.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form7 jform = new Form7();
            jform.ShowDialog();
        }
//Edit
      /*  private void button4_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("This button you can update only Stored Stock and you can't update in purchase Stock.If you want to update in stored stock enter the Batch No and press Enter Button ", "Jafer Ali",
       
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtbat.Focus();
            button4.Visible = false;
            button1.Enabled = true;
            button10.Enabled = false;
            //14-11-08
            button12.Enabled = false;
            button7.Enabled = false;
            button6.Enabled = false;
         txtqty.Text = "0";


        }*/

        private void Purchase1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {

                System.Diagnostics.Process.Start("calc.exe");


                txtin.Focus();
            }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("calc.exe");
        }

      

      

        }
    }
