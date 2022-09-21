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
using Magazine_Management_System;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Magazine_Management_System
{
    public partial class View_Best_Magazine : Form
    {
        CrystalReport2 Cr;
        public View_Best_Magazine()
        {
            InitializeComponent();
        }

        private void View_Best_Magazine_Load(object sender, EventArgs e)
        {
            Cr = new CrystalReport2();
            foreach (ParameterDiscreteValue v in Cr.ParameterFields[0].DefaultValues)
                Category_cmb.Items.Add(v.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Cr.SetParameterValue(0, Category_cmb.Text);
            Cr.SetParameterValue(1, Rate_Txt.Text);
            crystalReportViewer1.ReportSource = Cr;*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cr.SetParameterValue(0, Category_cmb.Text);
            Cr.SetParameterValue(1, Rate_Txt.Text);
            crystalReportViewer1.ReportSource = Cr;
        }
    }
}
