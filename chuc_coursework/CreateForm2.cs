﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chuc_coursework
{
    public partial class CreateForm2 : Form
    {
        public CreateForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO Product (name, articleMumber, price, remains, tax, provider) values (@name, @articleMumber, @price, @remains, @tax, @provider)");
            command.Connection = conn;
            command.Parameters.AddWithValue("name", textBox1.Text);
            command.Parameters.AddWithValue("articleMumber", textBox2.Text);
            command.Parameters.AddWithValue("price", textBox3.Text);
            command.Parameters.AddWithValue("remains", textBox4.Text);
            command.Parameters.AddWithValue("tax", textBox5.Text);
            command.Parameters.AddWithValue("provider", textBox6.Text);
            command.ExecuteNonQuery();
            conn.Close();
            this.Hide();
        }
    }
}
