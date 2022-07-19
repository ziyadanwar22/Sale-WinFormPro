using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo
{
    public partial class Main : Form
    {
        POSTutEntities1 db = new POSTutEntities1();
        int id;
        public Main()
        {
            InitializeComponent();
        }

        private void panalLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.pOSTutDataSet.Users);
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click(object sender, EventArgs e)//user Button in side list
        {
             //dataGridView1.DataSource = db.Users.ToList();
            ////button8.Visible = true;
            //button8.BringToFront();
            // button9.Visible = false;
            Screen.Regestri regestri = new Screen.Regestri(this);
            regestri.button4.Visible = false;
            regestri.Show();

        }

        private void button3_Click(object sender, EventArgs e)//product button in side list
        {
           // dataGridView1.DataSource = db.Products.ToList();
           //// button9.Visible = true;
           // button9.BringToFront();
            // button8.Visible = false;
            Screen.Product.ProductForm product = new Screen.Product.ProductForm(this);
            product.button2.Visible = false;
            product.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Users.Where(x => x.UserName.Contains( txtSearch.Text)).ToList();
            txtSearch.Text = "";
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.Where(x => x.Name.Contains( txtSearch.Text)).ToList();
            txtSearch.Text = "";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.Users.ToList();
            button8.Visible = true;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;


            //button8.BringToFront();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.ToList();
            button8.Visible = false;
            button9.Visible = true;
            button10.Visible = false;
            button11.Visible = false;

            //button9.BringToFront();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                 id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                if (button9.Visible == true)
                {
                    var res = db.Products.SingleOrDefault(x => x.id == id);
                    Screen.Product.ProductForm product = new Screen.Product.ProductForm(this);
                    product.txtBarCode.Text = res.Code;
                    product.txtNotes.Text = res.Notes;
                    product.txtPrice.Text = res.Price.ToString();
                    product.txtProdName.Text = res.Name;
                    product.txtQuantity.Text = res.Quantity.ToString();
                    product.pictureBox4.ImageLocation = res.Image;
                    //dataGridView1.DataSource = db.Products.ToList();
                    product.Show();

                }
                if (button8.Visible == true)
                {
                    var res = db.Users.SingleOrDefault(x => x.id == id);
                    Screen.Regestri regestri = new Screen.Regestri(this);
                    regestri.textBox1.Text = res.UserName;
                    regestri.textBox3.Text = res.Password;
                    regestri.pictureBox1.ImageLocation = res.Image;
                    regestri.button1.Visible = false;
                    regestri.Show();
                }
                if (button10.Visible == true)
                {
                    var res = db.Customers.SingleOrDefault(x => x.id == id);
                    Screen.Customer.CustomerMangment customer = new Screen.Customer.CustomerMangment(this);
                    customer.txtName.Text = res.Name;
                    customer.txtAddress.Text = res.Address;
                    customer.pictureBox4.ImageLocation = res.image;
                    customer.txtComp.Text = res.Compny;
                    customer.txtEmail.Text = res.email;
                    customer.txtPhone.Text = res.phone;
                    customer.txtNotes.Text = res.Notes;
                    customer.checkBox1.Checked = (bool)res.isActive;

                    customer.button2.Visible = false;
                    customer.Show();
                }
                if (button11.Visible == true)
                {
                    var res = db.Suppliers.SingleOrDefault(x => x.id == id);
                    Screen.Suppliers.suppliersMangment suppliers = new Screen.Suppliers.suppliersMangment(this);
                    suppliers.txtName.Text = res.Name;
                    suppliers.txtAddress.Text = res.Address;
                    suppliers.pictureBox4.ImageLocation = res.image;
                    suppliers.txtComp.Text = res.Compny;
                    suppliers.txtEmail.Text = res.email;
                    suppliers.txtPhone.Text = res.phone;
                    suppliers.txtNotes.Text = res.Notes;
                    suppliers.checkBox1.Checked = (bool)res.isActive;

                    suppliers.button2.Visible = false;
                    suppliers.Show();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Screen.Customer.CustomerMangment customer = new Screen.Customer.CustomerMangment(this);
            customer.updateBtn.Visible = false;
            customer.Show();

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customers.ToList();
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = true;
            button11.Visible = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customers.Where(x => x.Name.Contains(txtSearch.Text)).ToList();
            txtSearch.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Screen.Suppliers.suppliersMangment customer = new Screen.Suppliers.suppliersMangment(this);
            customer.updateBtn.Visible = false;
            customer.Show();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Suppliers.ToList();
            button8.Visible = false;
            button9.Visible = false;
            button11.Visible = true;
            button10.Visible = false;
        }



        private void button11_Click(object sender, EventArgs e)
        {
             dataGridView1.DataSource = db.Suppliers.Where(x => x.Name.Contains(txtSearch.Text)).ToList();
            txtSearch.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Screen.Billl.BillsManagment bills = new Screen.Billl.BillsManagment(this);
            //  product.button2.Visible = false;
            bills.Show();
        }
    }
}
