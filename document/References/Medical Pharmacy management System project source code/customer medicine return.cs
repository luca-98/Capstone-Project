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
    public partial class custtomer_medicine_return : Form
    {
        public custtomer_medicine_return()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.RefreshReport();


            crystalReportViewer1.SelectionFormula = "{re.return date}>='" + comboBox1.Text + "' and {re.return date}<= '" + comboBox2.Text + "'";
            crystalReportViewer1.RefreshReport();

        }

        private void custtomer_medicine_return_Load(object sender, EventArgs e)
        {
            string connecrionstring = "Initial Catalog=medical;Data Source=.;Integrated Security=true";

            SqlConnection con = new SqlConnection(connecrionstring);

            SqlDataAdapter da3 = new SqlDataAdapter("Select distinct[return date] from re", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            if (ds3.Tables[0].Rows.Count > 0)
            {
                int j = 0;
                for (j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    comboBox1.Items.Add((ds3.Tables[0].Rows[j]["return date"]));
                    comboBox2.Items.Add((ds3.Tables[0].Rows[j]["return date"]));
                    // cboZone.Items.Add(Trim(ds1.Tables(0).Rows(i)(1)))
                }

            }
        }

       
    }
}