using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cobaGuiSQL
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO TBGURU (NIP, NAMA_GURU, GENDER, MAPEL, TANGGAL_LAHIR, GAJI, IS_DELETED, UPDATED_AT, CREATED_AT) VALUES (@nip, @nama, @jk, @mapel, @tgl, @gaji, 0, @updated, @created)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nip", textBox1.Text);
                cmd.Parameters.AddWithValue("@nama", textBox2.Text);

                if (radioButton1.Checked)
                {
                    cmd.Parameters.AddWithValue("@jk", radioButton1.Text);
                }
                else if (radioButton2.Checked)
                {
                    cmd.Parameters.AddWithValue("@jk", radioButton2.Text);
                }

                cmd.Parameters.AddWithValue("@mapel", textBox3.Text);
                cmd.Parameters.AddWithValue("@tgl", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@gaji", textBox4.Text);
                cmd.Parameters.AddWithValue("@updated", DateTime.Now);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            MessageBox.Show("Berhasil Insert Data");
        }

        
    }
}
