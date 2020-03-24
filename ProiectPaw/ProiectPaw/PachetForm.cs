using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPaw
{
    public partial class PachetForm : Form
    {
        public PachetForm()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Pachet p = new Pachet();
            p.Destinatie = textBox1.Text;
            p.NrZile = int.Parse( textBox2.Text);
            p.Pret = float.Parse(textBox3.Text);
            Boolean yes= p.AdaugaBD();
            if(yes==true)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string pic in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                Image img = Image.FromFile(pic);
                pictureBox1.Image = img;
            }
        }
    }
}
