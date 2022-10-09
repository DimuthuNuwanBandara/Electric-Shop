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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }




        void income()
        {

        }






        private void Income_Load(object sender, EventArgs e)
        {


            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query = "SELECT SUM(`TAmount`) AS Total FROM `sales` ";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    label5.Text = MyReader.GetString("Total");
                }
                while (MyReader.Read()) ;
                {

                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("income err");
            }



            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query = "SELECT SUM(`PurchasePrice`*`quantity`) AS Total FROM `sales` ";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    label4.Text = MyReader.GetString("Total");
                }
                while (MyReader.Read()) ;
                {

                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("cost err");
            }

            double profitt = (Convert.ToDouble(label5.Text)) - (Convert.ToDouble(label4.Text));
            label6.Text = Convert.ToString(profitt);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                welocome frn2 = new welocome();
                frn2.Show();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            welocome ff = new welocome();
            ff.Show();
            this.Close();
        }
    }
}
