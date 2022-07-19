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

namespace POSDemo.Screen
{
    public partial class Regestri : Form
    {
        User us = new User();
        POSTutEntities1 db = new POSTutEntities1();
        Main ma;
        int id;
        public Regestri(Main main)
        {
            InitializeComponent();
            this.ma = main;
            //MessageBox.Show(Environment.CurrentDirectory);
        }
       
         string ImagePath;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Save")
            {
                bool isVaild = true;
                if (textBox1.Text.Trim() == "")
                {
                    EP.SetError(textBox1, "pleas enter the Name");
                    isVaild = false;
                }
                if (textBox3.Text.Trim() == "")
                {
                    EP.SetError(textBox3, "please enter the password");
                    isVaild = false;
                }
                if (isVaild)
                {
                    addUser();
                    clear();
                    ma.dataGridView1.DataSource = db.Users.ToList();
                }
            }
            //if (button1.Text == "update")
            //{
            //    int id = int.Parse(ma.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //    var res = db.Users.SingleOrDefault(x => x.id == id);
            //    res.UserName = textBox1.Text;
            //    res.Password = textBox3.Text;
            //    db.SaveChanges();
            //    ma.dataGridView1.DataSource = db.Users.ToList();
            //}
        }

        private void clear()
        {
            textBox1.Clear();
            textBox3.Clear();
            pictureBox1.ImageLocation = "";
        }

        private void addUser()
        {
            us.UserName = textBox1.Text;
            us.Password = textBox3.Text;
            us.Image = ImagePath;
            db.Users.Add(us);
            db.SaveChanges();
            //string newPath = Environment.CurrentDirectory + "\\Image\\Users\\" + us.id + ".jpg";
            //File.Copy(ImagePath, newPath);
            //us.Image = newPath;
            if (ImagePath != "")
            {
                string newPath = Environment.CurrentDirectory + "\\Image\\Users\\" + us.id + ".jpg";
                File.Copy(ImagePath, newPath);
                us.Image = newPath;
            }
            db.SaveChanges();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                ImagePath = dialog.FileName;
                pictureBox1.ImageLocation = dialog.FileName;
            }
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                button2.BringToFront();
                textBox3.PasswordChar = '\0';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '\0')
            {
                button3.BringToFront();
                textBox3.PasswordChar = '*';
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Regestri_Load(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id = int.Parse(ma.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var res = db.Users.SingleOrDefault(x => x.id == id);
            res.UserName = textBox1.Text;
            res.Password = textBox3.Text;
            res.Image = pictureBox1.ImageLocation;
            db.SaveChanges();
            ma.dataGridView1.DataSource = db.Users.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var A=MessageBox.Show("Aer You Sure ?","DELETE", MessageBoxButtons.YesNo);
            if (A == DialogResult.Yes)
            {
                id = int.Parse(ma.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var res = db.Users.SingleOrDefault(x => x.id == id);
                db.Users.Remove(res);
                db.SaveChanges();
                clear();
                ma.dataGridView1.DataSource = db.Users.ToList();
            }
        }
    }
}
