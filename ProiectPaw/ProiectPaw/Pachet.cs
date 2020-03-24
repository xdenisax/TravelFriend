using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace ProiectPaw
{
    public class Pachet
    {        private string destinatie;
        private float pret;
        private int nrZile;


    
        public Pachet()
        {}


        public Boolean AdaugaBD()
        {
            if (destinatie.Length > 1 && pret > 0 && nrZile >0)
            {
                const string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Scoala\facultate\an2\s2\paw\PROIECT\Proiect.mdb";
                OleDbConnection connection = new OleDbConnection(ConnectionString);

                connection.Open();
                OleDbCommand insert = connection.CreateCommand();
                insert.CommandType = CommandType.Text;
                insert.CommandText =  "INSERT INTO pachete (destinatie, nrZile, pret) VALUES('" + this.destinatie + "','" + this.nrZile + "','" + this.pret + "' )";
                insert.ExecuteNonQuery();
                connection.Close();


                MessageBox.Show("The offer was successfully added to DB.");
                return true; 
            }
            else
            {
                MessageBox.Show("The offer could not be added to DB.");
                return false;
            }
        }
        public string Destinatie
        {
            get => destinatie;
            set
            {
                if (value.Length > 1)
                {
                    destinatie = value;
                }
                else
                {
                    MessageBox.Show("Destination must be at least 2 lettters long.");
                }
            }
        }
        public float Pret
        {
            get => pret;
            set
            { 
                if (value > 0)
                {
                    this.pret = value;
                }
                else
                {
                    MessageBox.Show("Price must be positive.");
                }
            }
        }
        public int NrZile
        {
            get => nrZile;
            set
            {
                if (value > 1)
                    this.nrZile = value;
                else
                    MessageBox.Show("The offer must be at least 1 day long.");
            }
        }
            
        
    }
}

