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

namespace okul_bilgi_sistemi
{
    public partial class frm_giris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-323TRBO\\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
        public frm_giris()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm_ogrencinotlar frm_ogrencinotlar = new frm_ogrencinotlar();
            frm_ogrencinotlar.id = txt_id.Text;
            frm_ogrencinotlar.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frm_ogretmen frmogretmen = new frm_ogretmen();
            frmogretmen.Show();
        }
    }
}
