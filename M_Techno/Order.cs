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
    public partial class Order : Form
    {
        public string usertype2;
        string back;
        public Order()
        {
            InitializeComponent();
            FillCombocode();
            FillComboName();
        }

        public void validattion1(String usertype1)
        {
            usertype2 = usertype1;
            if (usertype1 == "Manager" || usertype1 == "Cashier" || usertype1 == "DeliveryShop")
            {
                back = "ok";
            }
            else
            {
                back = "no";
            }

        }



        void DataGrideSee()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `CName` AS 'Name', `CTP` AS 'ContactNo',`ProductName`,`unitePrice`,`Quantity`,`TAmount` FROM `order` WHERE `CTP` = '" + this.textBox6.Text + "';";
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
                //MessageBox.Show("asdf");
            }


        }



        private bool CheckEmpty()
        {
            if ((textBox2.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (unitrPrice.Text == "") || (buyquantity.Text == "") || (Tamount.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("Please Fill All the Field");
                return false;
            }
            else
            {
                return true;
            }
        }




        void TypeProductCode()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `products` WHERE ProductCode ='" + this.comboBox1.Text + "' OR ProductName = '" + this.comboBox2.Text + "'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    comboBox1.Text = MyReader.GetString("ProductCode");

                    comboBox2.Text = MyReader.GetString("ProductName");


                    unitrPrice.Text = MyReader.GetString("SalesPrice");
                }
                while (MyReader.Read()) ;
                {
                }
                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("serch by ID");
            }
        }


        void ClearTextBox()
        {
            Tamount.Text = "";
            buyquantity.Text = "";
            unitrPrice.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
        }



        void FillCombocode()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `ProductCode` FROM `products` ";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                comboBox1.Items.Clear();
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    String ID = MyReader.GetString("ProductCode");
                    comboBox1.Items.Add(ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("search auto code");
            }
        }






        void FillComboName()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `ProductName` FROM `products` ";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                comboBox2.Items.Clear();
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    String ID = MyReader.GetString("ProductName");
                    comboBox2.Items.Add(ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("search auto name");
            }
        }



        private void Order_Load(object sender, EventArgs e)
        {
            //orders.BackColor = Color.FromArgb(50, 123, 176);
            // orders.FlatAppearance.BorderSize = 0;

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

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            TypeProductCode();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            TypeProductCode();
            buyquantity.Focus();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                try
                {
                    String MyConnection = "datasource=localhost;Database=m_techno;username=root;password=;";
                    string Query = "INSERT INTO `order`( `CName`, `CTP`, `NIC`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount`, `OrderBy`) VALUES (" +
                        "'" + this.textBox2.Text + "'," +
                        "'" + this.textBox6.Text + "'," +
                        "'" + this.textBox7.Text + "'," +
                        "'" + this.comboBox1.Text + "'," +
                        "'" + this.comboBox2.Text + "'," +
                        "'" + this.unitrPrice.Text + "'," +
                        "'" + this.buyquantity.Text + "'," +
                        "'" + this.Tamount.Text + "'," +
                        "'" + "What app" + "')";


                    MySqlConnection Myconn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader;
                    Myconn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    MessageBox.Show("Order Add successfully ");
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
                DataGrideSee();
            }
        }


        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            DataGrideSee();
        }

        private void textBox6_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            DataGrideSee();
        }

        private void buyquantity_TextChanged(object sender, EventArgs e)
        {
            if (buyquantity.Text != "" && comboBox2.Text!="")
            {
                Double TotalAmount = Convert.ToDouble(buyquantity.Text) * Convert.ToDouble(unitrPrice.Text);
                Tamount.Text = Convert.ToString(TotalAmount);
            }
            else
            {
                Tamount.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (back == "ok")
            {
                welocome frn2 = new welocome();
                frn2.Show();
                this.Close();
            }
            else
            {
                login frn2 = new login();
                frn2.Show();
                this.Close();

            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (back == "ok")
            {
                welocome frn2 = new welocome();
                frn2.Show();
                this.Close();
            }
            else
            {
                login frn2 = new login();
                frn2.Show();
                this.Close();

            }
        }
    }
}
