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
            Toll();
            Po();
        }
        public void Toll()
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT name FROM Provider";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader[0].ToString());
            conn.Close();
            reader.Close();
        }
        public void Po()
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT name FROM Product";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox2.Items.Add(reader[0].ToString());
            conn.Close();
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO ReceiptInvoice (date,number,dateShipment,provider,retailSum,incomingSum) values (@date,@number,@dateShipment,@provider,@retailSum,@incomingSum)");
            command.Connection = conn;
            //command.Parameters.AddWithValue("id", textBox2.Text);
            command.Parameters.AddWithValue("date", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("number", textBox3.Text);
            command.Parameters.AddWithValue("dateShipment", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("provider", comboBox1.SelectedItem);
            command.Parameters.AddWithValue("retailSum", textBox6.Text);
            command.Parameters.AddWithValue("incomingSum", textBox4.Text);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add($"номер: {textBox1.Text}, контрагент: {comboBox1.Text}, название: {comboBox2.Text}, количество: {textBox3.Text}");
        }
        
        private void label16_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pz = Convert.ToInt32(textBox4.Text);
            int nds = Convert.ToInt32(textBox8.Text);
            int naz = Convert.ToInt32(textBox5.Text);
            
            decimal vsego = Convert.ToInt32(textBox6.Text) * (pz + nds + naz);
            label16.Text = Convert.ToString(vsego);
        }
    }
}
