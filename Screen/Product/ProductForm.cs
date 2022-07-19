using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screen.Product
{
   
    public partial class ProductForm : Form
    {
        POSTutEntities1 db = new POSTutEntities1();
        string ImagePath ="";
        Main mai;
        int id;

        public ProductForm(Main main)
        {
            InitializeComponent();
            this.mai = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isVaild = true;
            if (txtBarCode.Text.Trim() == "" )
            {
                EP.SetError(txtBarCode, "pleas enter the Barcode");
                isVaild = false;
            }
             if (txtProdName.Text.Trim() == "")
            {
                EP.SetError(txtProdName, "please enter the product Name");
                isVaild = false;
            }
             if (txtPrice.Text.Trim() == "")
            {
                EP.SetError(txtPrice, "please enter the product Price");
                isVaild = false;
            }
            if (comboBox1.SelectedValue ==null)
            {
                EP.SetError(txtPrice, "please select the catagory of the product");
                isVaild = false;
            }

            if (isVaild)
            {
                AddProduct();
                Clear();
                mai.dataGridView1.DataSource = db.Products.ToList();
                
            }
        }

        private void Clear()
        {
            txtBarCode.Clear();
            txtNotes.Clear();
            txtPrice.Clear();
            txtProdName.Clear();
            txtQuantity.Clear();
            pictureBox4.ImageLocation = "";
        }

        private void AddProduct()
        {
            try
            {
               
                    int pyt;
                    decimal price;
                    int.TryParse(txtQuantity.Text, out pyt);
                    decimal.TryParse(txtPrice.Text, out price);
                    POSDemo.DB.Product p = new DB.Product();
                    p.Name = txtProdName.Text;
                    p.Price = price;/*decimal.Parse(txtPrice.Text);*/
                    p.Quantity = pyt; /*int.Parse(txtPrice.Text);*/
                    p.Notes = txtNotes.Text;
                    p.Code = txtBarCode.Text;
                    p.CategroyId = int.Parse(comboBox1.SelectedValue.ToString());
                    db.Products.Add(p);                   
                    db.SaveChanges();
                    if (ImagePath != "")
                    {
                        string newPath = Environment.CurrentDirectory + "\\Image\\Products\\" + p.id + ".jpg";
                        File.Copy(ImagePath, newPath);
                        p.Image = newPath;
                    }
                    db.SaveChanges();
                    //MessageBox.Show("Saved");
                   
               
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBarCode_Validating(object sender, CancelEventArgs e)
        {
         
        }

        private void txtProdName_Validating(object sender, CancelEventArgs e)
        {
         
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = dialog.FileName;
                pictureBox4.ImageLocation = dialog.FileName;
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet1.Categores' table. You can move, or remove it, as needed.
            this.categoresTableAdapter.Fill(this.pOSTutDataSet1.Categores);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = int.Parse(mai.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var res = db.Products.SingleOrDefault(x => x.id == id);
            res.Name = txtProdName.Text;
            res.Code = txtBarCode.Text;
            res.Quantity = int.Parse(txtQuantity.Text);
            res.Price = int.Parse(txtBarCode.Text);
            res.Image = pictureBox4.ImageLocation;
            res.Notes = txtNotes.Text;
            res.CategroyId = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            mai.dataGridView1.DataSource = db.Products.ToList();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            var A = MessageBox.Show("Aer You Sure ?", "DELETE", MessageBoxButtons.YesNo);
            if (A == DialogResult.Yes)
            {
                id = int.Parse(mai.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var res = db.Products.SingleOrDefault(x => x.id == id);
                db.Products.Remove(res);
                db.SaveChanges();
                Clear();
                mai.dataGridView1.DataSource = db.Users.ToList();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
