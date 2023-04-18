using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace cobaGuiSQL
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;");
        string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";
        int itemsPerPage = 9;
             
    public Form1()
        {
            InitializeComponent();
        }

        private void tampilData()
        {
            string query = "EXEC tampilData";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            dtgv1.AutoGenerateColumns = false;
            dtgv1.DataSource = dt;

            conn.Close();
        }

        private void jumlahTotalData()
        {
            try
            {
                conn.Open();
                string sql = "SELECT TOTAL_GURU FROM TOTALGURU";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) label2.Text = reader["TOTAL_GURU"].ToString();
            }
            catch (Exception)
            {
                label2.Text = "Error";
            }
            finally
            {
                conn.Close();
            }
        }

        private void tampilDataPagination(int page = 1)
        {
            int startIndex = (page - 1) * itemsPerPage;

            //membuat query untuk mengambil data pada halaman yang ditentukan
            string query = $"SELECT * FROM TBGURU WHERE IS_DELETED = 'false' ORDER BY CREATED_AT DESC OFFSET {startIndex} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            dtgv1.AutoGenerateColumns = false;
            dtgv1.DataSource = dt;

            conn.Close();

            jumlahTotalData();
        }

        private void indexPagination()
        {
            int jumlahGuru = 0;
            string query = "SELECT TOTAL_GURU FROM TOTALGURU";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())jumlahGuru = Convert.ToInt32(reader["TOTAL_GURU"]);
            reader.Close();
            conn.Close();

            double totalPages = Math.Ceiling(Convert.ToDouble(jumlahGuru) / Convert.ToDouble(itemsPerPage));

            comboBox2.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                comboBox2.Items.Add(i);
            }

            label13.Text = totalPages.ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilDataPagination(Convert.ToInt32(comboBox2.SelectedItem));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                tampilDataPagination(1);
                indexPagination();                                                

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
                        string ID = dtgv1.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        DeleteData(ID);

                        MessageBox.Show("Data berhasil dihapus");

                        //RefreshDataGridView();
                        tampilDataPagination();
                        indexPagination();
                    }
                }
                else if (dtgv1.Columns[e.ColumnIndex].Name == "btnUpdate")
                {
                    string ID = dtgv1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    string NIP = dtgv1.Rows[e.RowIndex].Cells["NIP"].Value.ToString();
                    string NAMA_GURU = dtgv1.Rows[e.RowIndex].Cells["NAMA_GURU"].Value.ToString();
                    string GENDER = dtgv1.Rows[e.RowIndex].Cells["GENDER"].Value.ToString();
                    string MAPEL = dtgv1.Rows[e.RowIndex].Cells["MAPEL"].Value.ToString();
                    string TANGGAL_LAHIR = dtgv1.Rows[e.RowIndex].Cells["TANGGAL_LAHIR"].Value.ToString();                    
                    string GAJI = dtgv1.Rows[e.RowIndex].Cells["GAJI"].Value.ToString();

                    Form3 form3 = new Form3();
                    form3.dataID = ID;
                    form3.dataNIP = NIP;
                    form3.dataNAMA = NAMA_GURU;
                    form3.dataGENDER = GENDER;
                    form3.dataMAPEL = MAPEL;
                    form3.dataTANGGAL = TANGGAL_LAHIR;
                    form3.dataGAJI = GAJI;
                    form3.ShowDialog();
                    //RefreshDataGridView();
                    tampilDataPagination();
                    indexPagination();
                }
            }
        }
                
        private void DeleteData(string ID)
        {
            string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";
            string query = "UPDATE TBGURU SET IS_DELETED = 1, UPDATED_AT = GETDATE()  WHERE ID = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        private void Insert_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            //RefreshDataGridView();
            tampilDataPagination();
            indexPagination();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            //RefreshDataGridView();
            tampilDataPagination();
            indexPagination();
        }        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string keyword = textBox1.Text;

                conn.Open();
                // query data dari database
                string query = "SELECT * FROM TBGURU WHERE IS_DELETED = 'false' AND (NIP LIKE '%' + @keyword + '%' OR NAMA_GURU LIKE '%' + @keyword + '%' OR GENDER LIKE '%' + @keyword + '%' OR MAPEL LIKE '%' + @keyword + '%' OR GAJI LIKE '%' + @keyword + '%') ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", keyword);

                // mengisi DataGridView dengan data terbaru dari database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dtgv1.AutoGenerateColumns = false;
                dtgv1.DataSource = table;
                int jumlah = dtgv1.RowCount;

                label2.Text = jumlah.ToString();
            }
        }
       
    }
}
