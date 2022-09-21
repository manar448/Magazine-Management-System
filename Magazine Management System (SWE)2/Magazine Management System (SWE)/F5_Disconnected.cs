using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Magazine_Management_System;
using Magazine_Management_System__SWE_;
//using System.Data.OleDb;
//using System.Data.SqlClient;

namespace Magazine_Management_System__SWE_
{
    public partial class F5_Disconnected : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        string ordb = "Data Source = orcl; User Id = scott; Password = tiger;";
        OracleConnection conn;
        //OracleConnection conn;

        public F5_Disconnected()
        {
            InitializeComponent();
        }

        private void Disconnected_Load(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            string constr = "Data Source = orcl; User Id = scott; Password = tiger;";
            string cmdstr = @"select CODE,NAME,CATEGORY,VERSION,QUANTITY,PRICE,RATE
                              from SYS_MAGAZINEPRODUCTS
                              where NAME = :m ";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("m", textBox2.Text);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("The Magazine has been added.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constr = "Data Source = orcl; User Id = scott; Password = tiger;";
            string cmdstr = "select * from SYS_MAGAZINEPRODUCTS";
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
