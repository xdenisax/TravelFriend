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
    public class Turist
    {
        private string nume;
        private string prenume;
        private string telefon;
        private int varsta;

        public Turist()
        {}

        public Turist(string nume, string prenume, string telefon, int varsta)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.telefon = telefon;
            this.varsta = varsta;
        }

        public Boolean AduagaBD()
        {
            if (this.nume.Length > 2 && this.prenume.Length > 2 && this.telefon.Length == 10)
            {
                const string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Scoala\facultate\an2\s2\paw\PROIECT\Proiect.mdb";
                OleDbConnection connection = new OleDbConnection(ConnectionString);

                connection.Open();
                OleDbCommand Insert = connection.CreateCommand();
                Insert.CommandType = CommandType.Text;
                Insert.CommandText = "INSERT INTO turisti (nume, prenume, telefon, varsta) VALUES('" + this.Nume + "','" + this.Prenume + "','" + this.Telefon + "','" + this.varsta+"' )";
                Insert.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("The traveller was successfully added to DB.");
                return true;
            }
            else
            {
                MessageBox.Show("The traveller was not added to DB.");
                return false;
            }
        }


        public string Nume
        {
            get => nume;
            set
            {
                if (value.Length > 1)
                {
                    this.nume = value;
                }
                else
                {
                    MessageBox.Show("Last name must be longer than 2 letters.");
                }
            }
        }

        public string Prenume
        {
            get => prenume;
            set
            {
                if (value.Length > 1)
                {
                    this.prenume = value;
                }
                else
                {
                    MessageBox.Show("First name must be longer than 2 letters.");
                }
            }
        }
        public string Telefon
        {
            get => telefon;
            set
            {
                if (value.Length == 10)
                {
                    this.telefon = value;
                }
                else
                {
                    MessageBox.Show("Phone number must be 10 characters long.");
                }
            }

        }

        public int Varsta
        {
            get => varsta;
            set
            {
                if (value > 18)
                    this.varsta = value;
                else
                    MessageBox.Show("The traveller must be at least 18 years old.");
            }
           
        }
    }
}
