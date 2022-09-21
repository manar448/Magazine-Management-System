using Magazine_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazine_Management_System__SWE_
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F8_EnterSystem wlcm = new F8_EnterSystem();
            wlcm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F7_Admin admn = new F7_Admin();
            admn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Author authr = new Author();
            authr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer cstmr = new Customer();
            cstmr.Show();
        }
    }
}
