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
    public partial class ManageStock : Form
    {
        public ManageStock()
        {
            InitializeComponent();
            DataGrideSee();
            FillComboName();
        }
        private bool CheckEmpty()
        {
            if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == "") && (textBox5.Text == "") && (textBox6.Text == "") && (comboBox1.Text == ""))
            {
                MessageBox.Show("Please Fill All the Field");
                return false;
            }
            else
            {
                return true;
            }
        }



        void ClearTextBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";

        }



        void DataGrideSee()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `products`  ";
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
            }
        }


        void FillComboName()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
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
               // MessageBox.Show("search auto name");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                try
                {
                    String MyConnection = "datasource=localhost;Database=m_techno;username=root;password=;";
                    string Query = "INSERT INTO `products`(`ProductCode`, `ProductName`, `GroupName`, `PurchasePrice`, `SalesPrice`, `Quantity`, `ReOrderLevel`) " +
                        "VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.comboBox1.Text + "','" + this.textBox3.Text + "','" + this.textBox5.Text + "','" + this.textBox4.Text + "','" + this.textBox6.Text + "')";


                    MySqlConnection Myconn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader;
                    Myconn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    MessageBox.Show("Item Add successfully ");
                    while (MyReader.Read())
                    {

                    }
                    Myconn.Close();

                    //cear text box after add item.
                    ClearTextBox();
                    FillComboName();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Add button");
                }
                DataGrideSee();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `products` WHERE ProductCode ='"+this.textBox7.Text+"'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    textBox1.Text =  MyReader.GetString("ProductCode");
                    textBox2.Text =  MyReader.GetString("ProductName");
                    comboBox1.Text=  MyReader.GetString("GroupName");
                    textBox3.Text =  MyReader.GetString("PurchasePrice");
                    textBox4.Text = MyReader.GetString("Quantity");
                    textBox5.Text =  MyReader.GetString("SalesPrice");
                    textBox6.Text =  MyReader.GetString("ReOrderLevel");
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `products` WHERE ProductCode ='" + this.textBox7.Text + "'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    textBox1.Text = MyReader.GetString("ProductCode");
                    textBox2.Text = MyReader.GetString("ProductName");
                    comboBox1.Text = MyReader.GetString("GroupName");
                    textBox3.Text = MyReader.GetString("PurchasePrice");
                    textBox4.Text = MyReader.GetString("Quantity");
                    textBox5.Text = MyReader.GetString("SalesPrice");
                    textBox6.Text = MyReader.GetString("ReOrderLevel");
                }
                while (MyReader.Read()) ;
                {

                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("serch by ID");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ClearTextBox();
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `products` WHERE ProductName ='" + this.comboBox2.Text + "'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    textBox1.Text = MyReader.GetString("ProductCode");
                    textBox2.Text = MyReader.GetString("ProductName");
                    comboBox1.Text = MyReader.GetString("GroupName");
                    textBox3.Text = MyReader.GetString("PurchasePrice");
                    textBox4.Text = MyReader.GetString("Quantity");
                    textBox5.Text = MyReader.GetString("SalesPrice");
                    textBox6.Text = MyReader.GetString("ReOrderLevel");
                }
                while (MyReader.Read()) ;
                {

                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("serch by ProductName");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                String MyConnection = "datasource=localhost;Database=m_techno;username=root;password=; ";
                string Query = "DELETE  FROM `products` WHERE `ProductCode` = '" + this.textBox1.Text + "'";
                MySqlConnection Myconn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                MySqlDataReader MyReader;
                Myconn.Open();
                MyReader = MyCommand.ExecuteReader();
                MessageBox.Show("Delete successfully ");
                while (MyReader.Read())
                {
                }
                Myconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              //  MessageBox.Show("Delete error");
            }
            DataGrideSee();
            ClearTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {


                try
                {
                    String MyConnection = "datasource=localhost;Database=m_techno; username=root;password=; ";
                    string Query = "UPDATE `products` SET " +
                        "`ProductCode`='" + this.textBox1.Text + "'," +
                        "`ProductName`='" + this.textBox2.Text + "'," +
                        "`GroupName`='" + this.comboBox1.Text + "'," +
                        "`PurchasePrice`='" + this.textBox3.Text + "'," +
                        "`SalesPrice`='" + this.textBox5.Text + "'," +
                        "`Quantity`='" + this.textBox4.Text + "'," +
                        "`ReOrderLevel`='" + this.textBox6.Text + "'" +
                        " WHERE `ProductCode` = '" + this.textBox1.Text + "'";
                    MySqlConnection Myconn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader;
                    Myconn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    MessageBox.Show("Update successfully ");
                    DataGrideSee();
                    while (MyReader.Read())
                    {

                    }
                    Myconn.Close();
                    ClearTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("UPdate eorr");

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=; ";
                string Query = "SELECT MAX(ProductCode) AS ID FROM products";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    String ID = MyReader.GetString("ID");
                    int IDnum = Convert.ToInt16(ID.Substring(2, 3));
                    if (IDnum < 9) { textBox1.Text = "PC00" + Convert.ToString(IDnum + 1); }
                    else if (IDnum <= 99) { textBox1.Text = "PC0" + Convert.ToString(IDnum + 1); }
                    else { textBox1.Text = "PC" + Convert.ToString(IDnum + 1); }
                }
                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            welocome frn2 = new welocome();
            frn2.Show();
            this.Close();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            welocome ff = new welocome();
            ff.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
