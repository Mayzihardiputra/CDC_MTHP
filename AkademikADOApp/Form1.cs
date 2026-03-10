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

namespace AkademikADOApp // Namespace untuk aplikasi Akademik ADO.NET
{
    public partial class Form1 : Form // Kelas Form1 yang merupakan form utama aplikasi
    {
        string connString = "Data Source=MAYZIHARDIPUTRA\\MAYZIHARDIPUTRA;initial Catalog=DBAkademikADO;Integrated Security=True";
        SqlConnection conn;

        public Form1() // Konstruktor untuk Form1
        {
            InitializeComponent(); // Inisialisasi komponen form
        }

        private void btnConnect_Click(object sender, EventArgs e) // Event handler untuk tombol Connect
        {
            try
            {
                conn = new SqlConnection(connString); // Membuat objek SqlConnection dengan connection string yang telah ditentukan
                conn.Open();

                lblStatus.Text = "Status : Database Connected"; // Update label status untuk menunjukkan bahwa koneksi berhasil
                MessageBox.Show("Koneksi ke database berhasil!"); // Tampilkan pesan bahwa koneksi berhasil
            }
            catch (Exception ex) // Tangkap dan tampilkan pesan kesalahan jika koneksi gagal
            {
                MessageBox.Show("Koneksi gagal : " + ex.Message); // Tampilkan pesan kesalahan jika koneksi gagal
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e) // Event handler untuk tombol Disconnect
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open) // Cek apakah koneksi sudah terbuka
                {
                    conn.Close(); // Tutup koneksi ke database
                    lblStatus.Text = "Status : Database Disconnected"; // Update label status untuk menunjukkan bahwa koneksi telah ditutup
                    MessageBox.Show("Koneksi ke database ditutup!"); // Tampilkan pesan bahwa koneksi telah ditutup
                }
                else 
                {
                    MessageBox.Show("Database belum terkoneksi."); // Tampilkan pesan bahwa koneksi belum terbuka jika mencoba menutup koneksi yang belum terbuka
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menutup koneksi : " + ex.Message);
            }
        }
    }
}
