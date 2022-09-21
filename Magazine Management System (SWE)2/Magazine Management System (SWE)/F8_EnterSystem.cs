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

    public partial class F8_EnterSystem : Form
    {
        string ordb = "Data Source = ORCL;User ID = scott; Password = tiger;";
        OracleConnection conn;

        private void F8_EnterSystem_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            // to show all id in logIn
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ID from SYS_MAGAZINEUSERS";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                user_id.Items.Add(dr["ID"]);
            }
            dr.Close();
            
            // to show all id in signUp
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select ID, Type from SYS_MAGAZINEUSERS";
            c.CommandType = CommandType.Text;
            OracleDataReader d = c.ExecuteReader();
            while (d.Read())
            {
                comboBox1.Items.Add(d["ID"]);
            }
            d.Close();
        }

        public F8_EnterSystem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // signUp
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into SYS_MAGAZINEUSERS values(:id,:name,:email,:password,:phoneNumber,:cardNumber,:type)";
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
                if (user_type.Text == "Author")
                {
                    F7_Admin admn = new F7_Admin();
                    admn.Show();
                }
                else if (user_type.Text == "Customer")
                {
                    Customer customer = new Customer();
                    customer.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // logIn
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

        private void checkBox_Show_Hide_CheckedChanged(object sender, EventArgs e)
        {
            // show password in logIn
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
            // check id, pass, show type
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

        private void checkBox_Show_CheckedChanged(object sender, EventArgs e)
        {
            // show password in aignUp
            if (checkBox_Show.Checked)
            {
                textBox1.UseSystemPasswordChar = true;
            }
            else
            {
                textBox1.UseSystemPasswordChar = false;
            }
        }
    }
}
