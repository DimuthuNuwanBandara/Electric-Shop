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
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
            datag();
        }

        void ClearTextBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox6.Text = "";
        }
        void datag() 
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `Name`, `post`, `ContacNo`, `UserName`, `Password` FROM `users` ";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              //  MessageBox.Show("see all the datagride err");
            }
        }


        private void users_Load(object sender, EventArgs e)
        {

            dataGridView1.BackgroundColor = Color.FromArgb(157, 161, 163);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(200, 213, 219);//Rows color
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 196, 71);//select the row
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(81, 92, 158);//title color
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;////titile font
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String MyConnection = "datasource=localhost;Database=m_techno;username=root;password=;";
                string Query = "INSERT INTO `users`(`Name`, `post`, `ContacNo`, `UserName`, `Password`) VALUES (" +
                    "'" + this.textBox6.Text + "'," +
                    "'" + this.comboBox1.Text + "'," +
                    "'" + this.textBox4.Text + "'," +
                    "'" + this.textBox3.Text + "'," +
                    "'" + this.textBox2.Text + "')";

                MySqlConnection Myconn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                MySqlDataReader MyReader;
                Myconn.Open();
                MyReader = MyCommand.ExecuteReader();
                MessageBox.Show("Add successfully ");
                while (MyReader.Read())
                {

                }
                Myconn.Close();

                //cear text box after add item.
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Order button err");
            }
            datag();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            welocome frn2 = new welocome();
            frn2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `users` WHERE `Name` = '"+this.textBox1.Text+"'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    textBox6.Text = MyReader.GetString("Name");
                    comboBox1.Text = MyReader.GetString("post");
                    textBox4.Text = MyReader.GetString("ContacNo");
                    textBox3.Text = MyReader.GetString("UserName");
                    textBox2.Text = MyReader.GetString("Password");
                }
                while (MyReader.Read()) ;
                {

                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("serch by NAme");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String MyConnection = "datasource=localhost;Database=m_techno; username=root;password=; ";
                string Query = "UPDATE `users` SET " +
                    "`Name`= '" + this.textBox6.Text + "' ," +
                    "`ContacNo`= '" + this.textBox4.Text + "' ," +
                    "`UserName`= '" + this.textBox3.Text + "' ," +
                    "`Password`= '" + this.textBox2.Text + "' " +
                    " WHERE `Name` = '"+this.textBox6.Text+"' ;";
                MySqlConnection Myconn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                MySqlDataReader MyReader;
                Myconn.Open();
                MyReader = MyCommand.ExecuteReader();
                MessageBox.Show("Update successfully ");
                datag();
                while (MyReader.Read())
                {
                }
                Myconn.Close();
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("UPdate eorr");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Manager" && comboBox1.Text != "DeliveryShop")
            {
                try
                {
                    String MyConnection = "datasource=localhost;Database=m_techno; username=root;password=; ";
                    string Query = "DELETE FROM `users` WHERE `Name`= '" + this.textBox6.Text + "'";
                    MySqlConnection Myconn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader;
                    Myconn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    MessageBox.Show("Delete successfully ");
                    datag();
                    while (MyReader.Read())
                    {
                    }
                    Myconn.Close();
                    ClearTextBox();
                    datag();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("No select user");
                }
            }
            else
            {
                MessageBox.Show("Can't Delete Manager");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            welocome ff = new welocome();
            ff.Show();
            this.Close();
        }
    }
    
}
