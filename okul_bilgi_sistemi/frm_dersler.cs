using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okul_bilgi_sistemi
{
    public partial class frm_dersler : Form
    {
        public frm_dersler()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        DataSet1TableAdapters.tbl_derslerTableAdapter ds = new DataSet1TableAdapters.tbl_derslerTableAdapter();
        private void frm_dersler_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ders_listesi();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            ds.ders_ekle(txt_ad.Text);
            MessageBox.Show("Kayıt Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.ders_listesi();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            ds.ders_sil(byte.Parse(txt_id.Text));
            MessageBox.Show("Kayıt Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.ders_listesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            ds.ders_guncelle(txt_ad.Text,byte.Parse(txt_id.Text));
            MessageBox.Show("Kayıt Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.ders_listesi();
        }
    }
}
