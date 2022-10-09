using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_Techno
{
    public partial class OrderDetails : Form
    {
        public OrderDetails()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                try
                {
                    string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `InvoiceNo`, `ProductCode`, `ProductName`, `PurchasePrice`, `SalesPrice`, `quantity`, `TAmount` FROM `sales` ";
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
                    //MessageBox.Show("see all the slaes button err");
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `OrderID`, `CName` AS CustomerName, `CTP` AS Contact_No, `NIC`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount`, `OrderBy` FROM `order`";
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
                //MessageBox.Show("see all the orders button err");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `OrderID`, `CName` AS CustomerName, `CTP` AS Contact_No, `NIC`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount`, `OrderBy` FROM `order` WHERE `CTP` = '" + this.textBox1.Text + "';";
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
               // MessageBox.Show("see all the orders button err");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            welocome frn2 = new welocome();
            frn2.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `OrderID`, `CName` AS CustomerName, `CTP` AS Contact_No, `NIC`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount`, `OrderBy` FROM `suppliedorder`";
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
               // MessageBox.Show("see all the orders button err");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {


            button1.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            welocome ff = new welocome();
            ff.Show();
            this.Close();
        }
    }
}
