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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cobaGuiSQL
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM TBGURU WHERE IS_DELETED = 'false'; ", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dtgv1.AutoGenerateColumns = false;
                dtgv1.DataSource = dtbl;

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.HeaderText = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                dtgv1.Columns.Add(btnDelete);

                dtgv1.CellContentClick += dataGridView1_CellContentClick;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (dtgv1.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    if (MessageBox.Show(string.Format("Apakah anda yakin ingin menghapus data?"),"Konfirmasi",  MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string NIP = dtgv1.Rows[e.RowIndex].Cells["NIP"].Value.ToString();

                        DeleteData(NIP);

                        MessageBox.Show("Data berhasil dihapus");
                    }
                }
            }
        }

        private void DeleteData(string NIP)
        {
            string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";
            string query = "UPDATE TBGURU SET IS_DELETED = 1  WHERE NIP = @nip";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nip", NIP);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        private void Insert_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM TBGURU WHERE IS_DELETED = 'false';", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dtgv1.AutoGenerateColumns = false;
                dtgv1.DataSource = dtbl;
            }
        }

    }
}
