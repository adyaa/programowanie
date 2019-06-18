﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //przycisk polaczenia z baza danych
        {
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
                MySqlConnection myConn = new MySqlConnection(myConnection); //pozwala na nawiązanie połączenia z BD
                MySqlCommand SelectCommand = new MySqlCommand(" select * from database.edata where username='" + this.username_txt.Text + "'and password = '" + this.password_txt.Text + "' ;", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct.");
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password. Try again.");
                }
                else
                {
                    MessageBox.Show("Username and password is not correct. Try again.");
                }
                myConn.Close(); //zamkniecie polaczenia
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
