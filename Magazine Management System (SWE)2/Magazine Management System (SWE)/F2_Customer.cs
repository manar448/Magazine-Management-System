using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Magazine_Management_System__SWE_;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Magazine_Management_System
{
    public partial class Customer : Form
    {
        string ordb = "Data Source = ORCL; User Id = scott; Password = tiger;";
        OracleConnection conn;

        CrystalReport2 CR;

        public Customer()
        {
            InitializeComponent();
        }

        private void CstmrViewRating (object sender, EventArgs e)
        {
            Magazine_Management_System.View_Best_Magazine magazine = new View_Best_Magazine();
            magazine.Show();
        }
        private void CstmrViewAllMagazines(object sender, EventArgs e)
        {
            F3_Magazines magazine = new F3_Magazines();
            magazine.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void Customer_Closing(object sender, FormClosingEventArgs e)
        {
            //conn.Dispose();
        }

        private void Customer_Load_1(object sender, EventArgs e)
        {

        }
    }
}
