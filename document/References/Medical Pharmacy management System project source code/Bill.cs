using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace databaseC
{
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
              
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                txtbat.Focus();
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);
                SqlCommand cm = new SqlCommand();
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from sto", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGrid1.DataSource = ds2.Tables[0];




                /*  SqlDataAdapter da3 = new SqlDataAdapter("Select * from bill", con);
                  DataSet ds3 = new DataSet();
                  da3.Fill(ds3);
    
            
                     if (ds3.Tables[0].Rows.Count > 0 )
                     {
                   
                        string txt = Convert.ToString  (ds3.Tables[0].Rows.Count);
                       int  txtbil=Convert.ToInt32 ( txt)+ Convert.ToInt32 (1);
                      // MessageBox.Show(txtbil.ToString());
                       txtbill.Text ="CB"+txtbil.ToString ();
                     }
                         else
                     {
                         txtbill.Text = "CB"+Convert.ToString(1);
          
                     }*/



                string date1;
                date1 = DateTime.Now.Date.ToString("dd/MM/yyyy");
                date.Text = date1.ToString();

                string time1;
                time1 = DateTime.Now.ToLongTimeString();
                time.Text = time1.ToString();

                // string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                // SqlConnection con = new SqlConnection(connecrionstring);
                SqlDataAdapter da3 = new SqlDataAdapter("Select * from bill ", con);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                // textBox5.Text = "CB01";
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)

                        txtbill.Text = ds3.Tables[0].Rows[i][0].ToString();
                    int txtbil = Convert.ToInt32(txtbill.Text) + Convert.ToInt32(1);
                    txtbill.Text = txtbil.ToString();
                }
                  else
                     {
                         txtbill.Text = Convert.ToString(1);
          
                     }

            }
            catch (Exception ex)
            {
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
                    MessageBox.Show("No Record Found");
                }
                else
                {
                    //txtbat.Text = (ds.Tables[0].Rows[0][0].ToString());
                    txtmed.Text = (ds.Tables[0].Rows[0][1].ToString());
                    txtmfc.Text = (ds.Tables[0].Rows[0][2].ToString());
                    txtpri.Text = (ds.Tables[0].Rows[0][3].ToString());
                   // txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                    txtexp.Text = (ds.Tables[0].Rows[0][4].ToString());
                    txtloc.Text = (ds.Tables[0].Rows[0][5].ToString());
                    //
                    // txtuni.Text = (ds.Tables[0].Rows[0][4].ToString());
                 txttaxper.Text = (ds.Tables[0].Rows[0][6].ToString());
                   txttaxamt.Text = (ds.Tables[0].Rows[0][7].ToString());
                  //  txtpri.Text = (ds.Tables[0].Rows[0][8].ToString());
                   // txtstock.Text = (ds.Tables[0].Rows[0][9].ToString());

                  //  txttotamt.Text = (ds.Tables[0].Rows[0][10].ToString());


                    txtqty.Focus();






                }
              
              
               
            }
            if (e.KeyCode == Keys.Up  )
            {
                print();
             //   MessageBox.Show("hai");
                txtbat.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                //print();
                newbill();
                //   MessageBox.Show("hai");
                txtbat.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                //print();
                remove();
                //   MessageBox.Show("hai");
                txtbat.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                //print();
                Stockdetails jform3 = new Stockdetails();
                jform3.ShowDialog();
                //   MessageBox.Show("hai");
                txtbat.Focus();
            }
            if (e.KeyCode == Keys.F10 )
            {
                //print();
                main  jform3 = new main ();
                jform3.ShowDialog();
                //   MessageBox.Show("hai");
                txtbat.Focus();
            }
            if (e.KeyCode == Keys.F9)
            {
               
                System.Diagnostics.Process.Start("calc.exe");
 

                txtbat.Focus();
            }

            if (e.KeyCode == Keys.Space)
            {
                txtpatient.Focus();
            }




        }

        private void txtqty_KeyDown(object sender, KeyEventArgs e)
        {
          //  try
           // {

                if (e.KeyCode == Keys.Enter)
                {
                    if (txtqty.Text == "")
                    {
                        MessageBox.Show("Enter the Quantity");
                        txtqty.Focus();

                    }
                    else
                    {
                        decimal amt = decimal.Parse(txtqty.Text) * decimal.Parse(txtpri.Text);


                        txtamt.Text = amt.ToString();

                        string connectionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                        SqlConnection con = new SqlConnection(connectionstring);

                        SqlCommand cm = new SqlCommand();

                        cm.Connection = con;
                        con.Open();

                        cm.CommandText = "insert into sto values ('" + txtbat.Text + "','" + txtmed.Text + "','" + txtloc.Text + "','" + txtmfc.Text + "','" + txtpri.Text + "','" + txtexp.Text + "', '" + txttaxper.Text + "','" + txttaxamt.Text + "','" + txtqty.Text + "','" + txtamt.Text + "')";
                        cm.ExecuteNonQuery();

                        cm.CommandText = "insert into billbackup values ('" + txtbill.Text + "','" + txtbat.Text + "','" + date.Text + "','" + time.Text + "','" + txtmed.Text + "','" + txtmfc.Text + "','" + txtpri.Text + "','" + txtqty.Text + "','" + txtamt.Text + "')";
                        cm.ExecuteNonQuery();



                        SqlDataAdapter da1 = new SqlDataAdapter("Select * from sto  ", con);
                        DataSet ds = new DataSet();
                        da1.Fill(ds);
                        dataGrid1.DataSource = ds.Tables[0];
                        SqlDataAdapter da2 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        int qty = Convert.ToInt32(ds2.Tables[0].Rows[0][9]) - int.Parse(txtqty.Text);
                        //      MessageBox.Show(qty.ToString());
                        cm.CommandText = "update stock set quantity=" + qty + " where [batch no]='" + txtbat.Text + "'";
                        cm.ExecuteNonQuery();






                        txtmed.Clear();
                        txtmfc.Clear();
                        txtpri.Clear();
                        // txtmfcd.Text = (ds.Tables[0].Rows[0][4].ToString());
                        txtexp.Clear();
                        txtloc.Clear();
                        //
                        // txtuni.Text = (ds.Tables[0].Rows[0][4].ToString());
                        txttaxper.Clear();
                        txttaxamt.Clear();
                        txtpri.Clear();
                        txtbat.Clear();
                        txtqty.Clear();
                        txtamt.Clear();
                        txtbat.Focus();



                    }

                    if (e.KeyCode == Keys.Enter)
                    {
                        total();
                    }
                }


            }
           // catch (Exception ex)
           // {
            //    MessageBox.Show(ex.Message);
          //  }










      //  }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);

                SqlCommand cm = new SqlCommand();

                cm.Connection = con;
                con.Open();

                cm.CommandText = "delete  from BILL";
                cm.ExecuteNonQuery();
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
                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from sto where [batch no]='" + txtbat.Text + "'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);


                    int qty1 = Convert.ToInt32(ds2.Tables[0].Rows[0][8]);
                    int qty2 = Convert.ToInt32(ds3.Tables[0].Rows[0][9]);
                    // cm.CommandText ="Update 
                    // MessageBox.Show(qty1.ToString());
                    //  MessageBox.Show(qty2.ToString());
                    int qty3 = qty1 + qty2;
                    //   MessageBox.Show(qty3.ToString());
                    SqlDataAdapter da4 = new SqlDataAdapter("delete from sto where [batch no]='" + txtbat.Text + "'", con);
                    //cm.ExecuteNonQuery();
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    SqlDataAdapter da = new SqlDataAdapter("delete from billbackup where [batch no]='" + txtbat.Text + "' and [Bill No]='" + txtbill.Text + "'", con);
                    //cm.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    MessageBox.Show("Removed Successfully", "Pharmacy",
                                       
                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cm.Connection = con;
                    con.Open();
                    cm.CommandText ="update stock set quantity=" + qty3 + " where [batch no]='" + txtbat.Text + "'" ;
                    cm.ExecuteNonQuery();
                    SqlDataAdapter da5 = new SqlDataAdapter("Select * from sto ", con);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    dataGrid1.DataSource = ds5.Tables[0];

                   txtbat.Focus();

                }
            }
            catch (Exception exp)
            {
                 MessageBox.Show(exp.Message , "Jafer Ali");
             //  MessageBox.Show("Already Printed:", "Jafer Ali");
            }
            txtbat.Focus();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                SqlConnection con = new SqlConnection(connecrionstring);
                SqlCommand cm = new SqlCommand();
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from sto ", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                int i = 0;
                Decimal sum = 0;
                {
                    for (i = 0; i < ds2.Tables[0].Rows.Count; )
                    {

                        sum = sum + Convert.ToDecimal(ds2.Tables[0].Rows[i][9]);

                        amt.Text = sum.ToString();
                        label11.Text = sum.ToString();
                        i++;
                        //  MessageBox.Show(sum.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          //    while (i < ds2.Tables[0].Rows.Count)
            //{
             //   sum = sum + Convert.ToInt32(ds2.Tables[0].Rows[i][9]);
            //     MessageBox.Show(sum.ToString());

             //    i++;
            //
            // } 

            // textBox1.Text = sum.ToString ();
            // MessageBox.Show(i.ToString());
            // MessageBox.Show(sum.ToString());
            txtbat.Focus(); 
        }

        private string FormatException(int sum, string p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);

                SqlCommand cm = new SqlCommand();

                cm.Connection = con;
                con.Open();
                cm.CommandText = "insert into bill values('" + txtbill.Text + "','" + amt.Text + "','" + date.Text + "','" + time.Text + "')";
                cm.ExecuteNonQuery();

                cm.CommandText = "insert into netamt values('" + txtbill.Text + "','" + amt.Text + "')";
                cm.ExecuteNonQuery();

                cm.CommandText = "insert into name values('" + (txtpatient.Text).ToUpper () + "')";
                cm.ExecuteNonQuery();

                crystalReportViewer1.RefreshReport();
                crystalReportViewer1.PrintReport();
            }
            catch (Exception exp)
            {
               // MessageBox.Show("Already Entered:" + exp, "Jafer Ali");
                MessageBox.Show("Already Printed:" , "Jafer Ali");
            }
            txtbat.Focus();
        }

        private string Ucase(string p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);

                SqlCommand cm = new SqlCommand();

                cm.Connection = con;
                con.Open();
                cm.CommandText = "delete  from sto";
                cm.ExecuteNonQuery();

                SqlDataAdapter da2 = new SqlDataAdapter("Select * from sto ", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGrid1.DataSource = ds2.Tables[0];


                cm.CommandText = "delete  from netamt";
                cm.ExecuteNonQuery();

                cm.CommandText = "delete  from name";
                cm.ExecuteNonQuery();


                crystalReportViewer1.RefreshReport();



                loadbill();
                txtpatient.Clear();

               /* SqlDataAdapter da3 = new SqlDataAdapter("Select * from bill", con);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    string txt = Convert.ToString(ds3.Tables[0].Rows.Count);
                    int txtbil = Convert.ToInt32(txt) + Convert.ToInt32(1);
                    // MessageBox.Show(txtbil.ToString());
                    txtbill.Text = "CB" + txtbil.ToString();
                }
                else
                {
                    txtbill.Text = "CB" + Convert.ToString(1);

                }*/

                ////timer1_Tick = Enabled();

                amt.Clear();

                string time1;
                time1 = DateTime.Now.ToLongTimeString();
                time.Text = time1.ToString();
                txtbat.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  time.Enabled();  
        }

      
       
    
        


       

      
       
    

      

     ///  public string Right(string s1, int Length)
   /////    {
          /// Right(s1, 2);
     ////   return s1;
      
      ///// }




        private void total()
        {
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
            SqlConnection con = new SqlConnection(connecrionstring);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from sto ", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            int i = 0;
            Decimal  sum = 0;
            {
              //  for (i =0; i <(ds2.Tables[0].Rows.Count); )
                while (i < (ds2.Tables[0].Rows.Count)) 
                {

                    sum = sum + Convert.ToDecimal (ds2.Tables[0].Rows[i][9]);

                    amt.Text = sum.ToString();
                    label11.Text = sum.ToString();
                    i++;
                    //  MessageBox.Show(sum.ToString());
                }
                
            }

        }



        private void print()
        {
            try
            {

                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

                SqlConnection con = new SqlConnection(connecrionstring);

                SqlCommand cm = new SqlCommand();

                cm.Connection = con;
                con.Open();
                cm.CommandText = "insert into bill values('" + txtbill.Text + "','" + amt.Text + "','" + date.Text + "','" + time.Text + "')";
                cm.ExecuteNonQuery();

                cm.CommandText = "insert into netamt values('" + txtbill.Text + "','" + amt.Text + "')";
                cm.ExecuteNonQuery();

                cm.CommandText = "insert into name values('" + (txtpatient.Text).ToUpper () + "')";
                cm.ExecuteNonQuery();

                crystalReportViewer1.RefreshReport();
                crystalReportViewer1.PrintReport();
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Already Entered:" + exp, "Jafer Ali");
                MessageBox.Show("Already Printed:", "Jafer Ali");
            }
            txtbat.Focus();
        }

private void newbill()
    {
        string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

        SqlConnection con = new SqlConnection(connecrionstring);

        SqlCommand cm = new SqlCommand();

        cm.Connection = con;
        con.Open();
        cm.CommandText = "delete  from sto";
        cm.ExecuteNonQuery();

        SqlDataAdapter da2 = new SqlDataAdapter("Select * from sto ", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        dataGrid1.DataSource = ds2.Tables[0];


        cm.CommandText = "delete  from netamt";
        cm.ExecuteNonQuery();

        cm.CommandText = "delete  from name";
        cm.ExecuteNonQuery();


        crystalReportViewer1.RefreshReport();



        loadbill();
        txtpatient.Clear();


     /*   SqlDataAdapter da3 = new SqlDataAdapter("Select * from bill", con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            string txt = Convert.ToString(ds3.Tables[0].Rows.Count);
            int txtbil = Convert.ToInt32(txt) + Convert.ToInt32(1);
            // MessageBox.Show(txtbil.ToString());
            txtbill.Text = "CB" + txtbil.ToString();
        }
        else
        {
            txtbill.Text = "CB" + Convert.ToString(1);

        }*/

        ////timer1_Tick = Enabled();

        amt.Clear();







        string time1;
        time1 = DateTime.Now.ToLongTimeString();
        time.Text = time1.ToString();
    }

        private void remove()
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
                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from sto where [batch no]='" + txtbat.Text + "'", con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from stock where [batch no]='" + txtbat.Text + "'", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                  
                    int qty1 = Convert.ToInt32(ds2.Tables[0].Rows[0][8]);
                    int qty2 = Convert.ToInt32(ds3.Tables[0].Rows[0][9]);
                    // cm.CommandText ="Update 
                    // MessageBox.Show(qty1.ToString());
                    //  MessageBox.Show(qty2.ToString());
                    int qty3 = qty1 + qty2;
                    //   MessageBox.Show(qty3.ToString());
                    SqlDataAdapter da4 = new SqlDataAdapter("delete from sto where [batch no]='" + txtbat.Text + "'", con);
                    //cm.ExecuteNonQuery();
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    SqlDataAdapter da = new SqlDataAdapter("delete from billbackup where [batch no]='" + txtbat.Text + "' and [Bill No]='" + txtbill.Text + "'", con);
                    //cm.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    MessageBox.Show("Removed Successfully", "Pharmacy",

                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cm.Connection = con;
                    con.Open();
                    cm.CommandText = "update stock set quantity=" + qty3 + " where [batch no]='" + txtbat.Text + "'";
                    cm.ExecuteNonQuery();
                    SqlDataAdapter da5 = new SqlDataAdapter("Select * from sto ", con);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    dataGrid1.DataSource = ds5.Tables[0];

                    txtbat.Focus();

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message , "Jafer Ali");
               
            }
            txtbat.Focus();

        }
        private void loadbill()
        {
            try
            {
                string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";
                SqlConnection con = new SqlConnection(connecrionstring);
                SqlDataAdapter da3 = new SqlDataAdapter("Select * from bill ", con);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                // textBox5.Text = "CB01";
                {
                    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)

                        txtbill.Text = ds3.Tables[0].Rows[i][0].ToString();
                    int txtbil = Convert.ToInt32(txtbill.Text) + Convert.ToInt32(1);
                    txtbill.Text = txtbil.ToString();
                }

            }

            catch (Exception ex)
            {
            }






        }
   

        private void txtpatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbat.Focus();
            }
            

        }
            

       
        private void txtbat_TextChanged(object sender, EventArgs e)
        {
            
        }
    



    }
}