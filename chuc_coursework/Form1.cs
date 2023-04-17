﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace chuc_coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            authorization auth = new authorization();
            this.Hide();
            auth.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            this.CenterToScreen();
        }
        private void LoadData() 
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            //MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "SELECT * FROM Provider ORDER BY id";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> list = new List<string[]>();
            while (reader.Read())
            {
                list.Add(new string[10]);
                list[list.Count - 1][0] = reader[0].ToString();
                list[list.Count - 1][1] = reader[1].ToString();
                list[list.Count - 1][2] = reader[2].ToString();
                list[list.Count - 1][3] = reader[3].ToString();
                list[list.Count - 1][4] = reader[4].ToString();
                list[list.Count - 1][5] = reader[5].ToString();
                list[list.Count - 1][6] = reader[6].ToString();
                list[list.Count - 1][7] = reader[7].ToString();
                list[list.Count - 1][8] = reader[8].ToString();
            }
            foreach (string[] s in list)
                dataGridView1.Rows.Add(s);
            conn.Close();
            reader.Close();
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MySqlConnection conn = new MySqlConnection(authorization.connStr);
            //string id = textBox1.Text;
            //string MySQL = string.Format("DELETE FROM Provider WHERE (id = {0})", id);
            //conn.Open();
            //MySqlCommand command = new MySqlCommand(MySQL, conn);
            //command.ExecuteNonQuery();
            //conn.Close();
            //textBox1.Text = String.Empty;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {
                string test = dataGridView1[1, i].Value.ToString();
                Regex reg = new Regex($@"{textBox12.Text}", RegexOptions.IgnoreCase);
                MatchCollection matches = reg.Matches(test);
                if (matches.Count > 0)
                {
                    foreach(Match item in matches) 
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    }
                }
            }
            textBox12.Text = String.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Createe2 createe2 = new Createe2(this);
            //createe2.ShowDialog();
        }
    }
}
