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
    public partial class UserControl2 : UserControl
    {
        string ordb = "Data Source = ORCL; User Id = scott; Password = tiger;";
        OracleConnection conn;
        public UserControl2()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ID, Type from MAGAZINSYSUSER";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                user_id.Items.Add(dr["ID"]);
                user_type.Items.Add(dr["Type"]);
            }
            dr.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into MAGAZINSYSUSER values(:id,:name,:email,:password,:phoneNumber,:cardNumber,:type)";
            cmd.Parameters.Add("id", user_id.Text);
            cmd.Parameters.Add("name", txt_Name.Text);
            cmd.Parameters.Add("email", txt_Email.Text);
            cmd.Parameters.Add("password", textBox_Password.Text);
            cmd.Parameters.Add("phoneNumber", txt_Phone.Text);
            cmd.Parameters.Add("cardNumber", txt_Card.Text);
            cmd.Parameters.Add("type", user_type.Text);
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                user_id.Items.Add(user_id.Text);
                MessageBox.Show("Registring Successfully.");
                if (user_type.Text == "Author")
                {
                    Author author = new Author();
                    author.Show();
                }
                else if (user_type.Text == "Customer")
                {
                    Customer customer = new Customer();
                    customer.Show();
                }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void user_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
