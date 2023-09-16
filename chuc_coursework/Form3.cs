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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Koll();
        }
        public void Koll()
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT * FROM ReceiptInvoice ORDER BY id";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> hy = new List<string[]>();
            while (reader.Read())
            {
                hy.Add(new string[9]);
                hy[hy.Count - 1][0] = reader[0].ToString();
                hy[hy.Count - 1][1] = reader[1].ToString();
                hy[hy.Count - 1][2] = reader[2].ToString();
                hy[hy.Count - 1][3] = reader[3].ToString();
                hy[hy.Count - 1][4] = reader[4].ToString();
                hy[hy.Count - 1][5] = reader[5].ToString();
                hy[hy.Count - 1][6] = reader[6].ToString();
                hy[hy.Count - 1][7] = reader[7].ToString();
                hy[hy.Count - 1][8] = reader[8].ToString();
            }
            foreach (string[] d in hy)
            {
                dataGridView1.Rows.Add(d);
            }
            conn.Close();
            reader.Close();

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create v = new Create();
            v.ShowDialog();
            dataGridView1.Rows.Clear();
            Koll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete3 delete3 = new Delete3(this);
            delete3.ShowDialog();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }
    }
}
