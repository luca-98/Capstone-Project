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
    public partial class Purchasereport : Form
    {
        public Purchasereport()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connecrionstring);

            SqlDataAdapter da3 = new SqlDataAdapter("Select distinct[purchase date] from stockpurchase ", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            if (ds3.Tables[0].Rows.Count > 0)
            {
                int j = 0;
                for (j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    comboBox1.Items.Add((ds3.Tables[0].Rows[j]["purchase date"]));
                    comboBox2.Items.Add((ds3.Tables[0].Rows[j]["purchase date"]));
                    // cboZone.Items.Add(Trim(ds1.Tables(0).Rows(i)(1)))
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.RefreshReport();


            crystalReportViewer1.SelectionFormula = "{stockpurchase.purchase date}>='" + comboBox1.Text + "' and {stockpurchase.purchase date}<= '" + comboBox2.Text + "'";
            crystalReportViewer1.RefreshReport();

        }
    }
}