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

namespace POSDemo.Screen.Billl
{
    public partial class BillsManagment : Form
    {
        POSTutEntities1 db = new POSTutEntities1();
        Main mai;

        public BillsManagment(Main main)
        {
            InitializeComponent();
            //comboBox1.DataSource = db.Customers.Where(x => x.isActive == true).ToList();
            //comboBox1.ValueMember = "id";
            //comboBox1.DisplayMember = "Name";
            this.mai = main;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BillsManagment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet2.Customer' table. You can move, or remove it, as needed.
           // this.customerTableAdapter.Fill(this.pOSTutDataSet2.Customer);
            this.customerTableAdapter.FillBy(this.pOSTutDataSet2.Customer);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
          

        }
    }
}
