using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPaw
{
    public partial class ShowOffers : Form
    {
        public ShowOffers()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowOffers_Load(object sender, EventArgs e)
        {
            const string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Scoala\facultate\an2\s2\paw\PROIECT\Proiect.mdb";
            OleDbConnection connection = new OleDbConnection(ConnectionString);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            DataTable dt = new DataTable();
            OleDbCommand SelectValues = connection.CreateCommand();
            SelectValues.CommandType = CommandType.Text;
            SelectValues.CommandText = "SELECT * FROM pachete;";
            SelectValues.ExecuteNonQuery();
            OleDbDataAdapter adapter = new OleDbDataAdapter(SelectValues);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                populate(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            connection.Close();
        }

        private void populate(string id, string destinatie, string nrdezile, string pret)
        {
            ListViewItem rand = new ListViewItem();
            rand.Text = id;
            rand.SubItems.Add(destinatie);
            rand.SubItems.Add(nrdezile);
            rand.SubItems.Add(pret);
            listView1.Items.Add(rand);
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
    }
}
