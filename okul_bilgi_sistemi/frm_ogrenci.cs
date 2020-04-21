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
    public partial class frm_ogrenci : Form
    {
        DataSet1TableAdapters.tbl_ogrenciTableAdapter ds = new DataSet1TableAdapters.tbl_ogrenciTableAdapter();
        public frm_ogrenci()
        {
            InitializeComponent();
        }
        public void listele()
        {
            dataGridView1.DataSource = ds.ogrenci_listesi();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void btn_listele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            if (radio_erkek.Checked)
                cinsiyet = "ERKEK";
            if (radio_kız.Checked)
                cinsiyet = "KIZ";
            ds.ogrenci_ekle(txt_ad.Text, txt_soyad.Text, byte.Parse(combo_kulup.SelectedValue.ToString()),cinsiyet);
            MessageBox.Show("Kayıt Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-323TRBO\\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
        private void frm_ogrenci_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select* from tbl_kulupler",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combo_kulup.DisplayMember="kulup_ad";
            combo_kulup.ValueMember = "kulup_id";
            combo_kulup.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string cinsiyet= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (cinsiyet == "ERKEK")
            {
                radio_erkek.Checked = true;
            }
            if (cinsiyet == "KIZ")
            {
                radio_kız.Checked = true;
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            ds.ogrenci_silme(int.Parse(txt_id.Text));
            MessageBox.Show("Kayıt Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            if (radio_erkek.Checked)
                cinsiyet = "ERKEK";
            if (radio_kız.Checked)
                cinsiyet = "KIZ";
            ds.ogrenci_guncelle(txt_ad.Text, txt_soyad.Text, byte.Parse(combo_kulup.SelectedValue.ToString()), cinsiyet, int.Parse(txt_id.Text));
            MessageBox.Show("Kayıt Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void radio_kız_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource=  ds.ogrenci_arama(txt_ara.Text);
        }
    }
}
