using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chuc_coursework
{
    public partial class Delete1 : Form
    {
        Form1 qq;
        public Delete1(Form1 rr)
        {
            InitializeComponent();
            this.qq = rr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            string id = textBox1.Text;
            string MySQL = string.Format("DELETE FROM Provider WHERE (id = {0})", id);
            conn.Open();
            MySqlCommand command = new MySqlCommand(MySQL, conn);
            command.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = String.Empty;
            qq.dataGridView1.Rows.Clear();
            qq.LoadData();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Delete1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
