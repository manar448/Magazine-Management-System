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
    public partial class UserControl1 : UserControl
    {
        string ordb = "Data Source = ORCL; User Id = scott; Password = tiger;";
        OracleConnection conn;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void user_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select Type from SYS_MAGAZINEUSERS where ID=:id and PASSWORD=:password";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", user_id.SelectedItem.ToString());
            c.Parameters.Add("password", textBox_Password.Text);
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                txt_type.Text = dr["Type"].ToString();
            }
            dr.Close();
        }

        private void Button2_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show("LogIn Successfully.");
            if (txt_type.Text == "Author")
            {
                Author author = new Author();
                author.Show();
            }
            else if (txt_type.Text == "Customer")
            {
                Customer customer = new Customer();
                customer.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox_Show_Hide.Checked)
            {
                textBox_Password.UseSystemPasswordChar = true;
            }
            else
            {
                textBox_Password.UseSystemPasswordChar = false;
            }
        }

        private void checkBox_Show_Hide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Show_Hide.Checked)
            {
                textBox_Password.UseSystemPasswordChar = true;
            }
            else
            {
                textBox_Password.UseSystemPasswordChar = false;
            }
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;
            c2.CommandText = "select Type from SYS_MAGAZINEUSERS where ID=:id and PASSWORD=:password";
            c2.CommandType = CommandType.Text;
            c2.Parameters.Add("id", user_id.SelectedItem.ToString());
            c2.Parameters.Add("password", textBox_Password.Text);
            OracleDataReader dr = c2.ExecuteReader();
            if (dr.Read())
            {
                txt_type.Text = dr["Type"].ToString();
            }
            dr.Close();
        }
    }
}
