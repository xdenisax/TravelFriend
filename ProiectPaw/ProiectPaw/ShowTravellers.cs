using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPaw
{
    public partial class ShowTravellers : Form
    {
        public ShowTravellers()
        {
            InitializeComponent();
        }
        int v18_30 = 0;
        int v30_50 = 0;
        int v50_ = 0;
        List<Turist> turisti = new List<Turist>();

        private void ShowTravellers_Load(object sender, EventArgs e)
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
                SelectValues.CommandText = "SELECT * FROM turisti;";
                SelectValues.ExecuteNonQuery();
                OleDbDataAdapter adapter = new OleDbDataAdapter(SelectValues);
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    populate(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
               
                    turisti.Add(new Turist(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse( dr[4].ToString())));
                }
            //goleste fisierul 
            System.IO.File.WriteAllText(@"D:\Scoala\facultate\an2\s2\paw\PROIECT\ProiectPaw\ProiectPaw\turisti.txt", "");

            //adauga in fisier elementele noi
            WriteToFile();

                DataTable dt2 = new DataTable();
                OleDbCommand count = connection.CreateCommand();
                count.CommandType = CommandType.Text;
                count.CommandText = "Select count(varsta), varsta FROM turisti GROUP BY varsta;";
                count.ExecuteNonQuery();
                OleDbDataAdapter adapt = new OleDbDataAdapter(count);
                adapt.Fill(dt2);

               

                foreach(DataRow dr in dt2.Rows)
                {
                    if (int.Parse(dr[1].ToString()) > 17 && int.Parse(dr[1].ToString()) < 31)
                        v18_30 += int.Parse(dr[0].ToString());
                    if (int.Parse(dr[1].ToString()) > 30 && int.Parse(dr[1].ToString()) < 51)
                        v30_50 += int.Parse(dr[0].ToString()); ;
                    if (int.Parse(dr[1].ToString()) > 50 )
                        v50_+= int.Parse(dr[0].ToString()); ;

                }

                connection.Close();
        }

       
        private void populate(string id, string nume, string prenume, string telefon, string varsta)
        {
            ListViewItem rand = new ListViewItem();
            rand.Text = id;
            rand.SubItems.Add(nume);
            rand.SubItems.Add(prenume);
            rand.SubItems.Add(telefon);
            rand.SubItems.Add(varsta);
            listView1.Items.Add(rand);
        }

        
        public void WriteToFile ( )
        {
            foreach (Turist t in turisti)
            {
                string line =  t.Nume+ " "+ t.Prenume + " " + t.Telefon + " " + t.Varsta ;
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"D:\Scoala\facultate\an2\s2\paw\PROIECT\ProiectPaw\ProiectPaw\turisti.txt", true))
                {
                    file.WriteLine(line);
                }
                
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     


        //pentru miscarea formularului 

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

        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafic form = new Grafic(v18_30, v30_50, v50_);
            form.ShowDialog();
        }
    }
}
