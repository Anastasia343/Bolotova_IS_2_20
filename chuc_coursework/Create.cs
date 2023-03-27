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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chuc_coursework
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Create_Load(object sender, EventArgs e)
        {
            Soll();
        }
        public void Soll()
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT name FROM Provider";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader[0].ToString());
            
            //foreach (string[] m in gi)
            //{
            //    dataGridView1.Rows.Add(m);
            //}
            conn.Close();
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO ReceiptInvoice (id,date,number,dateShipment,provider,retailSum,incomingSum)values (@id,@date,@number,@dateShipment,@provider,@retailSum,@incomingSum");
            command.Connection = conn;
            command.Parameters.AddWithValue("id", textBox1.Text);
            command.Parameters.AddWithValue("date", textBox2.Text);
            command.Parameters.AddWithValue("number", textBox3.Text);
            command.Parameters.AddWithValue("dateShipment", textBox4.Text);
            command.Parameters.AddWithValue("provider", textBox5.Text);
            command.Parameters.AddWithValue("retailSum", textBox6.Text);
            command.Parameters.AddWithValue("incomingSum", textBox7.Text);
            command.ExecuteNonQuery();
            conn.Close();


        }
    }
}
