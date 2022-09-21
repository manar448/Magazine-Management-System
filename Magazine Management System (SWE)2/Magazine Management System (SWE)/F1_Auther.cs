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

namespace Magazine_Management_System
{
    public partial class Author : Form
    {
        string ordb = "Data Source = ORCL; User Id = scott; Password = tiger;";
        OracleConnection conn;
        public Author()
        {
            InitializeComponent();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "Get_All_Authors";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = c.ExecuteReader();
            while(dr.Read())
            {
                cmb_name.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F5_Disconnected send = new F5_Disconnected();
            send.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Get_ID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name", txt_Name.Text);
            cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            cmb_id.Items.Add(cmd.Parameters["id"].Value.ToString());
        }

        private void Author_Closing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
