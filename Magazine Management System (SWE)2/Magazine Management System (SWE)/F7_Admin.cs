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



namespace Magazine_Management_System__SWE_
{
    public partial class F7_Admin : Form
    {
        string ordb = "Data Source = ORCL; User Id = scott; Password = tiger;";
        OracleConnection conn;
        
        public F7_Admin()
        {
            InitializeComponent();
        }
        private void Admin_Closing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
                Author author = new Author();
                author.Show();
        }
    }
}
