using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chuc_coursework
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string test = dataGridView1[1, i].Value.ToString();
                Regex reg = new Regex($@"{textBox1.Text}", RegexOptions.IgnoreCase);
                MatchCollection matches = reg.Matches(test);
                if (matches.Count > 0)
                {
                    foreach (Match item in matches)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    }
                }
            }
            textBox1.Text = String.Empty;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm2 createForm2 = new CreateForm2();
            createForm2.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteForm2 deleteForm2 = new DeleteForm2();
            deleteForm2.ShowDialog();
        }
    }
}
