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
    public partial class DeleteForm2 : Form
    {
        public DeleteForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            string id = textBox1.Text;
            string MySQL = string.Format("DELETE FROM Product WHERE (id = {0})", id);
            conn.Open();
            MySqlCommand command = new MySqlCommand(MySQL, conn);
            command.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = String.Empty;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
