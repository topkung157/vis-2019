using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from users where users = '" + textBox1.Text + "'and password = '" + textBox2.Text + "'";
            //sql = "insert into users(users,password) values('" + txtuser.Text + "','" + txtpass.Text + "')";
            MySqlConnection con = new MySqlConnection("host = localhost;user=root;password=a123456789;database=test");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //MessageBox.Show("Login ได้แล้ว");
                this.Hide();
                Main f = new Main();
                f.Show();
            }
            else
            {
                MessageBox.Show("The username or password is incorrect.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //register
            //INSERT INTO cenima_user (id, password, name, tel) VALUES('111', '111', 'zzz', '0000000000');
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username.Length >= 6 && username.Length <= 60)
            {
                if (password.Length >= 6 && password.Length <= 20)
                {
                    string sql = "select * from users";
                    sql = "insert into users(ID,Pass) values('" + username + "','" + password + "')";
                    MySqlConnection con = new MySqlConnection("host = localhost;user=root;password=a123456789;database=test");

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registered Please return to the login page.");
                }
                else
                {
                    MessageBox.Show("Username and password must be longer than 6 characters.");
                }

            }
            else
            {
                MessageBox.Show("Username and password must be longer than 6 characters.");
            }
        }
    }
}