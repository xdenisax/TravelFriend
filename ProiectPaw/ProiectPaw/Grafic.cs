using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPaw
{
    public partial class Grafic : Form
    {
        public Grafic(int v1, int v2, int v3)
        {
            InitializeComponent();

            chart1.Series["Age"].Points.AddXY("18-30 yo", v1);
            chart1.Series["Age"].Points.AddXY("30-50 yo", v2);
            chart1.Series["Age"].Points.AddXY("<50 yo", v3);
        }


        //inchidera formularului
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void Chart1_DoubleClick(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
        }

      
    }
        
}
