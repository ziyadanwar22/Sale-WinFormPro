using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screen.Customer
{
    public partial class CustomerMangment : Form
    {
        POSTutEntities1 db = new POSTutEntities1();
        string ImagePath = "";
        Main mai;
        int id;
        public CustomerMangment(Main main)
        {
            InitializeComponent();
            checkBox1.Checked = false;
            this.mai = main;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isVaild = true;
            if (txtName.Text.Trim() == "")
            {
                EP.SetError(txtName, "pleas enter the Name");
                isVaild = false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                EP.SetError(txtAddress, "please enter the Address ");
                isVaild = false;
            }
            if (txtPhone.Text.Trim() == "")
            {
                EP.SetError(txtPhone, "please enter the Phone");
                isVaild = false;
            }
            if (txtComp.Text.Trim() == "")
            {
                EP.SetError(txtComp, "please enter the Phone");
                isVaild = false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                EP.SetError(txtEmail, "please enter the Phone");
                isVaild = false;
            }
            if (isVaild)
            {
                AddProduct();
                Clear();
                mai.dataGridView1.DataSource = db.Customers.ToList();

            }
        }
        private void Clear()
        {
            txtName.Clear();
            txtNotes.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtComp.Clear();
            pictureBox4.ImageLocation = "";
            checkBox1.Checked = false;
        }
        private void AddProduct()
        {
            try
            {

                //int pyt;
                // decimal price;
               // int.TryParse(txtPhone.Text, out pyt);
                //decimal.TryParse(txtPrice.Text, out price);
                POSDemo.DB.Customer c = new DB.Customer();
                c.Name = txtName.Text;
                c.Address = txtAddress.Text;
                c.Compny = txtComp.Text;
                c.Notes = txtNotes.Text;
                c.email = txtEmail.Text;
                c.phone = txtPhone.Text;
                c.isActive = checkBox1.Checked;
                db.Customers.Add(c);
                db.SaveChanges();
                if (ImagePath != "")
                {
                    string newPath = Environment.CurrentDirectory + "\\Image\\Customer\\" + c.id + ".jpg";
                    File.Copy(ImagePath, newPath);
                    c.image = newPath;
                }
                db.SaveChanges();
                //MessageBox.Show("Saved");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            id = int.Parse(mai.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var res = db.Customers.SingleOrDefault(x => x.id == id);
            res.Name = txtName.Text;
            res.Address = txtAddress.Text;
            res.phone = txtPhone.Text;
            res.Compny = txtComp.Text;
            res.image = pictureBox4.ImageLocation;
            res.Notes = txtNotes.Text;
            db.SaveChanges();
            mai.dataGridView1.DataSource = db.Customers.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var A = MessageBox.Show("Aer You Sure ?", "DELETE", MessageBoxButtons.YesNo);
            if (A == DialogResult.Yes)
            {
                id = int.Parse(mai.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var res = db.Customers.SingleOrDefault(x => x.id == id);
                db.Customers.Remove(res);
                db.SaveChanges();
                Clear();
                mai.dataGridView1.DataSource = db.Suppliers.ToList();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtComp_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
