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
    public partial class Distributors : Form
    {
        string OrderID = "";
        string CName = "";
        string CTP = "";
        string NIC = "";
        string ProductCode = "";
        string ProductName = "";
        string unitePrice = "";
        string Quantity = "";
        string TAmount = "";
        string OrderBy = "";





        public Distributors()
        {
            InitializeComponent();
            datagride();
        }
        void ClearTextBox() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        void cearvariyabal()
        {
            OrderID = "";
            CName = "";
            CTP = "";
            NIC = "";
            ProductCode = "";
            ProductName = "";
            unitePrice = "";
            Quantity = "";
            TAmount = "";
            OrderBy = "";
        }



        void datagride()
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

        private void suppier_Load(object sender, EventArgs e)
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


            dataGridView2.BackgroundColor = Color.FromArgb(157, 161, 163);
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(200, 213, 219);//Rows color
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 196, 71);//select the row
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(81, 92, 158);//title color
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;////titile font
        }

        private void button2_Click(object sender, EventArgs e)
        {
            welocome frn2 = new welocome();
            frn2.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cearvariyabal();
            searchiii();


        }

        void searchiii()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `OrderID`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount` FROM `order`  WHERE `CTP` = '" + this.textBox6.Text + "'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("see all the orders button err");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cearvariyabal();
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `OrderID`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount` FROM `order`  WHERE `CName` = '" + this.textBox2.Text + "'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("see all the orders button err");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cearvariyabal();
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `OrderID`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount` FROM `order`  WHERE `NIC` = '" + this.textBox7.Text + "'";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("see all the orders button err");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query = "SELECT * FROM `order` WHERE `OrderID` = '"+this.textBox1.Text+"' ";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    OrderID = MyReader.GetString("OrderID");
                    CName = MyReader.GetString("CName");
                    CTP = MyReader.GetString("CTP");
                    NIC = MyReader.GetString("NIC");
                    ProductCode = MyReader.GetString("ProductCode");
                    ProductName = MyReader.GetString("ProductName");
                    unitePrice = MyReader.GetString("unitePrice");
                    Quantity = MyReader.GetString("Quantity");
                    TAmount = MyReader.GetString("TAmount");
                    OrderBy = MyReader.GetString("OrderBy");

                    /*
                    label2.Text = OrderID;
                    label3.Text = CName;
                    label4.Text = CTP;
                    label5.Text = NIC;
                    label7.Text = ProductCode;
                    label8.Text = ProductName;
                    label9.Text = unitePrice ;
                    label10.Text = Quantity ;
                    label11.Text = TAmount ;
                    label13.Text = OrderBy ;
                    */


                }
                while (MyReader.Read()) ;
                {

                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("serch by OID");
            }




            
            try
            {
                String MyConnection = "datasource=localhost;Database=m_techno;username=root;password=;";
                string Query = "INSERT INTO `suppliedorder`(`OrderID`, `CName`, `CTP`, `NIC`, `ProductCode`, `ProductName`, `unitePrice`, `Quantity`, `TAmount`, `OrderBy`) VALUES (" +
                    "'"+OrderID+"'," +
                    "'"+CName + "'," +
                    "'"+CTP + "'," +
                    "'"+NIC + "'," +
                    "'"+ProductCode + "'," +
                    "'"+ProductName + "'," +
                    "'"+unitePrice + "'," +
                    "'"+Quantity + "'," +
                    "'"+TAmount + "'," +
                    "'"+OrderBy + "')"; 

                MySqlConnection Myconn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                MySqlDataReader MyReader;
                Myconn.Open();
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {

                }
                Myconn.Close();

                //cear text box after add item.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Order button err");
            }


    
                try
                {
                    String MyConnection = "datasource=localhost;Database=m_techno; username=root;password=; ";
                    string Query = "DELETE FROM `order` WHERE `OrderID`= '" + OrderID + "'";
                    MySqlConnection Myconn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader;
                    Myconn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    MessageBox.Show("Order Delivered ");
                    
                    while (MyReader.Read())
                    {
                    }
                    Myconn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   // MessageBox.Show("No select user");
                }


            datagride();
            ClearTextBox();
            cearvariyabal();
            searchiii();





        }






        private void textBox6_Enter(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            welocome ff = new welocome();
            ff.Show();
            this.Hide();

        }
    }
}
