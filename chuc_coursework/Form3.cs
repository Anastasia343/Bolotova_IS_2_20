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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            authorization aut = new authorization();
            this.Hide();
            aut.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Koll();
        }
        private void Koll()
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
    }
}
