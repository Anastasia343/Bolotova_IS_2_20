using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chuc_coursework
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            authorization auth = new authorization();
            this.Hide();
            auth.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Soll();
        }
        public void Soll() 
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT * FROM Product ORDER BY id";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> gi = new List<string[]>();
            while (reader.Read()) 
            {
                gi.Add(new string[7]);
                gi[gi.Count - 1][0] = reader[0].ToString();
                gi[gi.Count - 1][1] = reader[1].ToString();
                gi[gi.Count - 1][2] = reader[2].ToString();
                gi[gi.Count - 1][3] = reader[3].ToString();
                gi[gi.Count - 1][4] = reader[4].ToString();
                gi[gi.Count - 1][5] = reader[5].ToString();
                gi[gi.Count - 1][6] = reader[6].ToString();

            }
            foreach (string[] m in gi) 
            {
                dataGridView1.Rows.Add(m);
            }
            conn.Close();
            reader.Close();
        }
    }
}
