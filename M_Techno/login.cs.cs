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
    public partial class login : Form
    {
        public String UserType ;
        string selectUser = "Cashier";
 
        public login()
        {
            InitializeComponent();
            button3.BackColor = Color.FromArgb(7, 11, 235);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `users` WHERE " +
                    "`UserName` = '"+ this.textBox1.Text + 
                    "' AND `Password` = '"+this.textBox2.Text+"' AND `post` = '"+selectUser+"' ";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    UserType = MyReader.GetString("post");

                    welocome frn2 = new welocome();
                    frn2.validattion(UserType);

                    frn2.Show();
                    UserType = "";
                    this.Hide();

                }


                else
                {
                    MessageBox.Show("Invalied UserName or Password");
                }
                while (MyReader.Read()) ;
                {

                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orders_Click(object sender, EventArgs e)
        {

            Order frn2 = new Order();
            frn2.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {        
         
            orders.FlatAppearance.BorderSize = 0;


           
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            forgetPassword fp = new forgetPassword();
            fp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(7, 11, 235);
            button3.BackColor = Color.FromArgb(0, 124, 158);
            button4.BackColor = Color.FromArgb(0, 124, 158);
            label6.Text = "Manager";
            selectUser = "Manager";
            label6.Location = new Point(535, 295);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(7, 11, 235);
            button2.BackColor = Color.FromArgb(0, 124, 158);
            button4.BackColor = Color.FromArgb(0, 124, 158);
            label6.Text = "Cashier";
            selectUser = "Cashier";
            label6.Location = new Point(538, 295);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(7, 11, 235);
            button2.BackColor = Color.FromArgb(0, 124, 158);
            button3.BackColor = Color.FromArgb(0, 124, 158);
            label6.Text = "DeliveryShop";
            selectUser = "DeliveryShop";
            label6.Location = new Point(515, 295);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
