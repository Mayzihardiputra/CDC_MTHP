using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AkademikADOApp
{
    public partial class Form1 : Form
    {
        string connString = "Data Source=MAYZIHARDIPUTRA\\MAYZIHARDIPUTRA;initial Catalog=DBAkademikADO;Integrated Security=True";
        SqlConnection conn;

        public Form1()
        {
            InitializeComponent(); // Inisialisasi komponen form
        }

        private void btnConnect_Click(object sender, EventArgs e) // Event handler untuk tombol Connect
        {
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                lblStatus.Text = "Status : Database Connected";
                MessageBox.Show("Koneksi ke database berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal : " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e) // Event handler untuk tombol Disconnect
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open) // Cek apakah koneksi sudah terbuka
                {
                    conn.Close();
                    lblStatus.Text = "Status : Database Disconnected";
                    MessageBox.Show("Koneksi ke database ditutup!");
                }
                else
                {
                    MessageBox.Show("Database belum terkoneksi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menutup koneksi : " + ex.Message);
            }
        }
    }
}
