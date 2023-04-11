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

namespace cobaGuiSQL
{
    public partial class Form4 : Form
    {
        string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM TBGURU WHERE IS_DELETED = 'True'; ", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dtgv1.AutoGenerateColumns = false;
                dtgv1.DataSource = dtbl;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (MessageBox.Show(string.Format("Apakah anda yakin ingin menghapus data?"), "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int jumlahTrash = dtgv1.Rows.Count;
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM TBGURU WHERE IS_DELETED='True';";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        refresh();
                        int sisatrash = dtgv1.Rows.Count;
                        int berhasil = jumlahTrash - sisatrash;
                        MessageBox.Show($"{"Data Gagal Dihapus Tersisa "}{sisatrash} \nData Berhasil Dihapus {berhasil} ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (MessageBox.Show(string.Format("Apakah anda yakin ingin mengembalikan data?"), "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int jumlahTrash = dtgv1.Rows.Count;
                    try
                    {
                    conn.Open();
                    string query = "UPDATE TBGURU SET IS_DELETED = 'False', IS_DELETED_AT = NULL  WHERE NIP NOT IN (SELECT NIP FROM TBGURU WHERE IS_DELETED = 'False' )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    refresh();
                    int sisatrash = dtgv1.Rows.Count;
                    int berhasil = jumlahTrash - sisatrash;
                    MessageBox.Show($"{"Data Gagal Direstore Tersisa "}{sisatrash} \nData Berhasil Direstore {berhasil} ");                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public void refresh()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM TBGURU WHERE IS_DELETED = 'True'; ", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dtgv1.AutoGenerateColumns = false;
                dtgv1.DataSource = dtbl;

            }
        }        
    }
}
