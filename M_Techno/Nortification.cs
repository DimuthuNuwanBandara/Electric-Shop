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
    public partial class Nortification : Form
    {
        public Nortification()
        {
            InitializeComponent();

            try
            {
                string MyConnection = "datasource=localhost; Database=m_techno;port=3306; username=root;password=;";
                string Query = "SELECT `ProductCode`,`ProductName`,`Quantity` FROM `products` WHERE `Quantity`<`ReOrderLevel`";
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

        private void button1_Click(object sender, EventArgs e)
        {
            welocome frn2 = new welocome();
            frn2.Show();
            this.Close();
        }

        private void Nortification_Load(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
