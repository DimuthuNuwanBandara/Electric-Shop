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
    public partial class welocome : Form
    {
        public static string usertype1; 
        public welocome()
        {
            InitializeComponent();
            
            validattion(usertype1);
        }

        public void validattion(String UserType)
        {
            usertype1 = UserType;
            if (usertype1 == "Manager")
            {
                bill.Enabled = true;
                orders.Enabled = true;
                report.Enabled = true;
                Magagestock.Enabled = true;
                OrderDetails.Enabled = true;
                income.Enabled = true;
                usDetail.Enabled = true;
                notifi.Enabled = true;
                allItems.Enabled = true;
                suplier.Enabled = false;
            }
            else if (usertype1 == "Cashier")
            {
                bill.Enabled = true;
                orders.Enabled = true;
                report.Enabled = false;
                Magagestock.Enabled = false;
                OrderDetails.Enabled = false;
                income.Enabled = false;
                usDetail.Enabled = false;
                notifi.Enabled = true;
                allItems.Enabled = true;
                suplier.Enabled = false;
            }
            else if (usertype1 == "DeliveryShop")
            {
                bill.Enabled = false;
                orders.Enabled = false;
                report.Enabled = false;
                Magagestock.Enabled = false;
                OrderDetails.Enabled = true;
                income.Enabled = false;
                usDetail.Enabled = false;
                notifi.Enabled = false;
                allItems.Enabled = true;
                suplier.Enabled = true;
            }
            else
            {
                bill.Enabled = false;
                orders.Enabled = false;
                report.Enabled = false;
                Magagestock.Enabled = false;
                OrderDetails.Enabled = false;
                income.Enabled = false;
                usDetail.Enabled = false;
                notifi.Enabled = false;
                allItems.Enabled = false;
                suplier.Enabled = false;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sales frn2 = new Sales();
            frn2.Show();
            this.Hide();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order frn2 = new Order();
            frn2.validattion1(usertype1);
            frn2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderDetails frn2 = new OrderDetails();
            frn2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports frn2 = new Reports();
            frn2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nortification frn2 = new Nortification();
            frn2.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AllItems frn2 = new AllItems();
            frn2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            users frn2 = new users();
            frn2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Income frn2 = new Income();
            frn2.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Distributors frn2 = new Distributors();
            frn2.Show();
            this.Hide();
        }

        private void welocome_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(90, 95, 97);
            bill.TabStop = false;
            bill.FlatStyle = FlatStyle.Flat;
            bill.FlatAppearance.BorderSize = 0;
            
            notifi.TabStop = false;
            notifi.FlatStyle = FlatStyle.Flat;
            notifi.FlatAppearance.BorderSize = 0;

            allItems.TabStop = false;
            allItems.FlatStyle = FlatStyle.Flat;
            allItems.FlatAppearance.BorderSize = 0;

            orders.TabStop = false;
            orders.FlatStyle = FlatStyle.Flat;
            orders.FlatAppearance.BorderSize = 0;

            suplier.TabStop = false;
            suplier.FlatStyle = FlatStyle.Flat;
            suplier.FlatAppearance.BorderSize = 0;

            OrderDetails.TabStop = false;
            OrderDetails.FlatStyle = FlatStyle.Flat;
            OrderDetails.FlatAppearance.BorderSize = 0;

            Magagestock.TabStop = false;
            Magagestock.FlatStyle = FlatStyle.Flat;
            Magagestock.FlatAppearance.BorderSize = 0;


            report.TabStop = false;
            report.FlatStyle = FlatStyle.Flat;
            report.FlatAppearance.BorderSize = 0;


            usDetail.TabStop = false;
            usDetail.FlatStyle = FlatStyle.Flat;
            usDetail.FlatAppearance.BorderSize = 0;


            income.TabStop = false;
            income.FlatStyle = FlatStyle.Flat;
            income.FlatAppearance.BorderSize = 0;




        }

        private void label1_Click(object sender, EventArgs e)
        {
            login frn2 = new login();
            frn2.Show();
            this.Close();

        }

        private void Magagestock_CLICK(object sender, EventArgs e)
        {
            ManageStock frn2 = new ManageStock();
            frn2.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
