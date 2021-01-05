using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace databaseC
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void stockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stockdetails jform3 = new Stockdetails();
            jform3.ShowDialog();
        }

        private void billTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction  jform3 = new  Transaction ();
            jform3.ShowDialog();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill  jform3 = new Bill ();
            jform3.ShowDialog();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase1   jform3 = new Purchase1 ();
            jform3.ShowDialog();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return  jform3 = new Return ();
            jform3.ShowDialog();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchasereport  jform3 = new Purchasereport ();
            jform3.ShowDialog();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salesreport  jform3 = new salesreport ();
            jform3.ShowDialog();
        }

        private void returnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Returndetails jform3 = new Returndetails();
            jform3.ShowDialog();
        }

        private void purchaseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchasedetails  jform3 = new purchasedetails ();
            jform3.ShowDialog();
        }

        private void returnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            returnreport jform3 = new returnreport ();
            jform3.ShowDialog();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            menuStrip2.Focus();
            
        }

        private void Form9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {

                System.Diagnostics.Process.Start("calc.exe");


               // txtin.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stockdetails jform3 = new Stockdetails ();
            jform3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bill jform3 = new Bill ();
            jform3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transaction jform3 = new Transaction ();
            jform3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            purchasedetails jform3 = new purchasedetails ();
            jform3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("calc.exe"); 
        }

        private void button5_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
     //      int x=0;

       if (Convert .ToBoolean(timer1.Tag )==true )
        {
           LabelHeader.ForeColor = Color.Aqua;
           timer1.Tag=false ;

        }
      
       else
       {
           LabelHeader.ForeColor = Color.DarkGreen ;
           timer1.Tag = true  ;
       }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about jform3 = new about();
            jform3.ShowDialog();
        }

        private void userAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginadd   jform3 = new loginadd  ();
           jform3.ShowDialog();
          //  Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customerReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custtomer_medicine_return jj = new custtomer_medicine_return();
            jj.ShowDialog();

        }

        private void customerReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 jj = new Form1();
            jj.ShowDialog();



        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup jj = new Backup();
            jj.ShowDialog();

        }
    }
}