using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace chuc_coursework
{
    public partial class Delete3 : Form
    {
        Form3 ssdd;
        public Delete3(Form3 sd)
        {
            InitializeComponent();
            this.ssdd = sd;
        }

        private void Delete3_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            string id = textBox1.Text;
            string MySQL = string.Format("DELETE FROM ReceiptInvoice WHERE (id = {0})", id);
            conn.Open();
            MySqlCommand command = new MySqlCommand(MySQL, conn);
            command.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = String.Empty;
            ssdd.dataGridView1.Rows.Clear();
            ssdd.Koll();
            this.Hide();

        }
    }
}
