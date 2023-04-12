using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace cobaGuiSQL
{
    public partial class Form3 : Form
    {
        string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";

        public Form3()
        {
            InitializeComponent();
        }

        public string dataID { get; set; }
        public string dataNIP { get; set; }
        public string dataNAMA { get; set; }
        public string dataGENDER { get; set; }
        public string dataMAPEL { get; set; }
        public string dataTANGGAL { get; set; }
        public string dataGAJI { get; set; }
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = dataNIP;
            textBox2.Text = dataNAMA;
            if (dataGENDER == "L")
            {
                radioButton1.Checked = true;
            }
            else if (dataGENDER == "P")
            {
                radioButton2.Checked = true;
            }
            textBox3.Text = dataMAPEL;
            DateTime result;
            bool isValid = DateTime.TryParse(dataTANGGAL, out result);
            if (isValid)
            {
                dateTimePicker1.Value = result;
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
            }
            textBox4.Text = dataGAJI;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE TBGURU SET NIP = @nip, NAMA_GURU = @nama, GENDER = @jk, MAPEL = @mapel, TANGGAL_LAHIR = @tgl, GAJI = @gaji, UPDATED_AT = GETDATE()  WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", dataID);
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

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            MessageBox.Show("Berhasil Update Data");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
