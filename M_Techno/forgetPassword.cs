using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_Techno
{
    public partial class forgetPassword : Form
    {
        public forgetPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "ELECTRIC") 
            {
                try
                {
                    String MyConnection = "datasource=localhost;Database=m_techno; username=root;password=; ";
                    string Query = "UPDATE `users` SET `UserName`= '"+this.textBox2.Text+"' ,`Password`= '"+this.textBox2.Text+"' WHERE `post` = 'Manager';";
                    MySqlConnection Myconn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader;
                    Myconn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    MessageBox.Show("Password Change Successfully");
                    while (MyReader.Read())
                    {
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    Myconn.Close();

                    login ll = new login();
                    ll.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Security Key Not match");
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            login kk = new login();
            kk.Show();
            this.Close();
        }

        private void forgetPassword_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            login ff = new login();
            ff.Show();
            this.Close();
        }
    }
}
