
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
    public partial class Sales : Form
    {
        string billno;
        double purchesPrice;
        double maxN;
        double discount = 0;

        public Sales()
        {
            InitializeComponent();
            genarrateInvoiceNumber();
            comboBox1.Focus();
            FillComboName();
            FillCombocode();
            deletebilltable();
            AllItemsgide();
        }


        void invoiccesaves()
        { 
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT MAX(no) FROM `bill`;";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                if (MyReader.Read())
                {
                    maxN= MyReader.GetDouble("MAX(no)");
                }
                while (MyReader.Read()) ;
                {
                }
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("max piesces err");
            }

            try
            {
                String MyConnection = "datasource=localhost;Database=m_techno; username=root;password=; ";
                string Query = "INSERT INTO `invoice`(`InvoiceNo`, `Pieces`, `SubBalance`, `Discount`, `TotalBalance`) VALUES " +
                    "('" + this.InvoiceNotxt.Text + "'," +
                    "'" + maxN+ "'," +
                    "'" + this.Stotaltxt.Text + "'," +
                    "'" + this.Discounttxt.Text + "'," +
                    "'" + this.Ftotaltxt.Text + "');";
                MySqlConnection Myconn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                MySqlDataReader MyReader;
                Myconn.Open();
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                }
                Myconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("invoice table create err");
            }
        }



        void updateaftersalesitem()
        {

            try
            {
                String MyConnection = "datasource=localhost;Database=m_techno; username=root;password=; ";
                double updateQuentity = Convert.ToDouble(this.textBox2.Text) - Convert.ToDouble(this.buyquantity.Text);
                string Query = "UPDATE `products` SET `Quantity`='"+ updateQuentity + "' WHERE `ProductCode`='"+this.textBox5.Text+"';";
                MySqlConnection Myconn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                MySqlDataReader MyReader;
                Myconn.Open();
                MyReader = MyCommand.ExecuteReader();
                DataGrideSee();
                while (MyReader.Read())
                {
                }
                Myconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("item quentity UPdate eorr");
            }
        }
        void deletebilltable()
        {
            try
            {
                string MyConnection1 = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query1 = "drop table if exists `maaya`.`bill` ";
    

                MySqlConnection MyConn1 = new MySqlConnection(MyConnection1);
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, MyConn1);
                MySqlDataReader MyReader1;
                MyConn1.Open();
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("bill table drop");
            }
            try
            {
                string MyConnection1 = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query1 = "CREATE TABLE `bill` ("+
                                 " `no` int(11) NOT NULL,"+
                                 " `Invoice_No` int(11) NOT NULL,"+
                                 " `ProductCode` varchar(10) NOT NULL,"+
                                 " `ProductName` varchar(25) NOT NULL,"+
                                 " `SalesPrice` double NOT NULL,"+
                                 " `quantity` int(11) NOT NULL,"+
                                 " `TAmount` double NOT NULL"+
                                ") ENGINE = InnoDB DEFAULT CHARSET = latin1;"+

                                "INSERT INTO `bill` (`no`) VALUES"+
                                "(0); ";

                MySqlConnection MyConn1 = new MySqlConnection(MyConnection1);
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, MyConn1);
                MySqlDataReader MyReader1;
                MyConn1.Open();
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("bill table clear");
            }
        }



        void TotalAmount()
        {
            try
            {
                string MyConnection1 = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=;";
                string Query1 = "SELECT SUM(`TAmount`) AS SubAmount  FROM `bill`";
                MySqlConnection MyConn1 = new MySqlConnection(MyConnection1);
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, MyConn1);
                MySqlDataReader MyReader1;
                MyConn1.Open();
                MyReader1 = MyCommand1.ExecuteReader();
                discount = Convert.ToDouble(Discounttxt.Text);
                while (MyReader1.Read())
                {
                    double subt = MyReader1.GetDouble("SubAmount");
                    Stotaltxt.Text = Convert.ToString(subt);

                    double totalAm = subt - (subt * discount / 100);
                    Ftotaltxt.Text = Convert.ToString(totalAm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("total ammount err");
            }
        }


        void DataGrideSee()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT  `ProductCode`AS 'P_Code', `ProductName`AS 'P_Name' ,`SalesPrice` AS 'UnitPice',`quantity`, `TAmount`As 'Total'  FROM `bill`  ";
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
             //   MessageBox.Show("data gride eerr");
            }
        }

        void genarrateInvoiceNumber()
        {
            {

                try
                {
                    string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=; ";
                    string Query = "SELECT MAX(InvoiceNo) as ID FROM sales";
                    MySqlConnection MyConn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    if (MyReader.Read())
                    {
                        String ID = MyReader.GetString("ID");
                        int IDnum = Convert.ToInt32(ID);
                        InvoiceNotxt.Text = Convert.ToString(IDnum + 1);

                    }

                    MyConn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   // MessageBox.Show("invoice number create err");
                }
            }

        }

        void billNO()
        {
                try
                {
                    string MyConnection = "datasource=localhost; Database=m_techno ;port=3306; username=root;password=; ";
                    string Query = "SELECT MAX(no) as ID FROM bill";
                    MySqlConnection MyConn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    if (MyReader.Read())
                    {
                        String ID = MyReader.GetString("ID");
                        int IDnum = Convert.ToInt32(ID);
                        billno = Convert.ToString(IDnum + 1);

                    }

                    MyConn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   // MessageBox.Show("bil numbe fill");
                }
          

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
                comboBox3.Items.Clear();
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    String ID = MyReader.GetString("ProductCode");
                    comboBox1.Items.Add(ID);
                    comboBox3.Items.Add(ID);
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
                comboBox3.Items.Clear();
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    String ID = MyReader.GetString("ProductName");
                    comboBox2.Items.Add(ID);
                    comboBox3.Items.Add(ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              //  MessageBox.Show("search auto name");
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
                    textBox5.Text = MyReader.GetString("ProductCode");
                    comboBox1.Text = MyReader.GetString("ProductCode");

                    comboBox2.Text = MyReader.GetString("ProductName");
                    textBox4.Text = MyReader.GetString("ProductName");

                    textBox3.Text = MyReader.GetString("GroupName");

                    textBox2.Text = MyReader.GetString("Quantity");

                    textBox1.Text = MyReader.GetString("SalesPrice");
                    unitrPrice.Text = MyReader.GetString("SalesPrice");

                    purchesPrice = MyReader.GetDouble("PurchasePrice");

                }
                while (MyReader.Read()) ;
                {

                }

                MyConn.Close();

                try
                {
                    string MyConnection1 = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                    string Query1 = "SELECT `ProductCode`, `ProductName`, `GroupName`,  `SalesPrice`, `Quantity` FROM `products` WHERE ProductCode ='" + this.comboBox1.Text + "' OR ProductName = '" + this.comboBox2.Text + "'";
                    MySqlConnection MyConn1 = new MySqlConnection(MyConnection1);
                    MySqlCommand MyCommand1 = new MySqlCommand(Query1, MyConn1);
                    MySqlDataReader MyReader1;
                    MyConn1.Open();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand1;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("serch by ID");
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            TypeProductCode();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            //ClearTextBox();
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            //ClearTextBox();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            TypeProductCode();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
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

        private void textBox7_Enter(object sender, EventArgs e)
        {
            Tamount.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            billNO();

            if (Convert.ToInt32(textBox2.Text) >= Convert.ToInt32(buyquantity.Text))
            {
                try
                {
                    //bil table
                    String MyConnection = "datasource=localhost;Database=m_techno;username=root;password=;";
                    string Query = "INSERT INTO `bill`(`no`, `Invoice_No`, `ProductCode`, `ProductName`, `SalesPrice`, `TAmount`,`quantity`) " +
                        "VALUES ('" + billno + "'," +
                        "'" + this.InvoiceNotxt.Text + "'," +
                        "'" + this.comboBox1.Text + "'," +
                        "'" + this.comboBox2.Text + "'," +
                        "'" + this.unitrPrice.Text + "'," +
                        "'" + this.Tamount.Text + "'," +
                        "'" + this.buyquantity.Text + "')";

                    MySqlConnection Myconn = new MySqlConnection(MyConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader;
                    Myconn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {

                    }
                    Myconn.Close();
                    comboBox1.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Add button fist try");
                }

                //sales table
                try
                {

                    String MyConnection = "datasource=localhost;Database=m_techno;username=root;password=;";
                    string Query = "INSERT INTO `sales`(`InvoiceNo`, `no`, `ProductCode`, `ProductName`, `PurchasePrice`, `SalesPrice`, `quantity`, `TAmount`) VALUES" +
                        "('" + this.InvoiceNotxt.Text + "'," +
                        "'" + billno + "'," +
                        "'" + this.comboBox1.Text + "'," +
                        "'" + this.comboBox2.Text + "'," +
                        "'" + purchesPrice + "'," +
                        "'" + this.unitrPrice.Text + "'," +
                        "'" + this.buyquantity.Text + "'," +
                        "'" + this.Tamount.Text + "')";

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
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Add button second  try");
                }
                
                updateaftersalesitem();
                //ClearTextBox();
                FillComboName();
                TotalAmount();
                ClearTextBox();
                
            }
            else
            {
                MessageBox.Show("Quantity is not Enough");
            }

                DataGrideSee();

            }

        private void Discounttxt_Leave(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void Discounttxt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                Ftotaltxt.Focus();
            }
        }

        private void Sales_Load(object sender, EventArgs e)
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
            invoiccesaves();
            deletebilltable();
            DataGrideSee();
            genarrateInvoiceNumber();
            MessageBox.Show(" Bill Printed ");
            Discounttxt.Text = "";
            Stotaltxt.Text = "";
            Ftotaltxt.Text = "";
            comboBox1.Focus();

            Sales ff = new Sales();
            this.Hide();
            ff.Show();

        }

        private void Discounttxt_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            welocome frn2 = new welocome();
            frn2.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Ftotaltxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Discounttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllItemsgide();
        }

        void AllItemsgide()
        {
            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `ProductCode`, `ProductName`, `GroupName`,  `SalesPrice`, `Quantity` FROM `products`";
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
                //MessageBox.Show("see all the orders button err");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "";
                if (comboBox4.SelectedIndex == 1)
                {
                    a =  "`ProductName` ";
                }
                else
                {
                    a = "`ProductCode`";
                }

                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `ProductCode`, `ProductName`, `GroupName`,  `SalesPrice`, `Quantity` FROM `products` WHERE "+a+" = '"+comboBox3.Text+"'";
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
                //MessageBox.Show("see all the orders button err");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 1)
            {
                FillComboName();
            }
            else
            {
                FillCombocode();

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            welocome ff = new welocome();
            ff.Show();
            this.Close();
        }
    }
}
