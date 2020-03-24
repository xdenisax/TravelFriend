using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ProiectPaw
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "admin" && textBox2.Text == "admin") || (textBox2.Text == "denisa" && textBox2.Text == "andreea"))
            {
                PachetForm form = new PachetForm();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username/password.");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "admin" && textBox2.Text == "admin") || (textBox1.Text == "denisa" && textBox2.Text == "andreea"))
            {
                ShowTravellers form = new ShowTravellers();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username/password.");
            }

        }
    }
}
