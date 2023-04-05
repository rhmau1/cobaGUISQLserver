﻿using System;
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
                    form3.Show();
                }
            }
        }
                
        private void DeleteData(string ID)
        {
            string connectionString = "Server=DESKTOP-SD43K3H\\SQLEXPRESS;Initial Catalog=DBGURU;Integrated Security=True;";
            string query = "UPDATE TBGURU SET IS_DELETED = 1  WHERE ID = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", ID);
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
