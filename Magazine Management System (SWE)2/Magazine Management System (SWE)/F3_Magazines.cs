using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Magazine_Management_System__SWE_;

namespace Magazine_Management_System
{
    public partial class F3_Magazines : Form
    {
        CrystalReport1 CR;
        public F3_Magazines()
        {
            InitializeComponent();
        }

        private void Show_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport1();
            /*foreach (ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
            Category_cmb.Items.Add(v.Value);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }
    }
}
