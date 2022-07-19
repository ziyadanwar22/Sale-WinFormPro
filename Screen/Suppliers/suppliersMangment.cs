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

namespace POSDemo.Screen.Suppliers
{

    public partial class suppliersMangment : Form
    {
        POSTutEntities1 db = new POSTutEntities1();
        string ImagePath = "";
        Main mai;
        int id;
        public suppliersMangment(Main main)
        {
            InitializeComponent();
            checkBox1.Checked = false;
            this.mai = main;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            id = int.Parse(mai.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var res = db.Suppliers.SingleOrDefault(x => x.id == id);
            res.Name = txtName.Text;
            res.Address = txtAddress.Text;
            res.phone = txtPhone.Text;
            res.Compny = txtComp.Text;
            res.image = pictureBox4.ImageLocation;
            res.Notes = txtNotes.Text;
            db.SaveChanges();
            mai.dataGridView1.DataSource = db.Suppliers.ToList();
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
            if (db.Suppliers.Where(x => x.phone == txtPhone.Text && x.id != id).Count() > 0) 
            {
                EP.SetError(txtPhone, "this supllier is already added");
                isVaild = false;
            }
            if (isVaild)
            {
                AddProduct();
                Clear();
                mai.dataGridView1.DataSource = db.Suppliers.ToList();

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
                POSDemo.DB.Supplier s = new DB.Supplier();
                s.Name = txtName.Text;
                s.Address = txtAddress.Text;
                s.Compny = txtComp.Text;
                s.Notes = txtNotes.Text;
                s.email = txtEmail.Text;
                s.phone = txtPhone.Text;
                s.isActive = checkBox1.Checked;
                db.Suppliers.Add(s);
                db.SaveChanges();
                if (ImagePath != "")
                {
                    string newPath = Environment.CurrentDirectory + "\\Image\\Supplier\\" + s.id + ".jpg";
                    File.Copy(ImagePath, newPath);
                    s.image = newPath;
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = dialog.FileName;
                pictureBox4.ImageLocation = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var A = MessageBox.Show("Aer You Sure ?", "DELETE", MessageBoxButtons.YesNo);
            if (A == DialogResult.Yes)
            {
                id = int.Parse(mai.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var res = db.Suppliers.SingleOrDefault(x => x.id == id);
                db.Suppliers.Remove(res);
                db.SaveChanges();
                Clear();
                mai.dataGridView1.DataSource = db.Suppliers.ToList();
            }
        }
    }
}
