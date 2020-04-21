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
    public partial class frm_kulup : Form
    {
        public frm_kulup()
        {
            InitializeComponent();
        }
        void listele()
        {

            SqlDataAdapter da = new SqlDataAdapter("select* from tbl_kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-323TRBO\\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
        private void frm_kulup_Load(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_kulupler (kulup_ad) values (@ad)", baglanti);
                cmd.Parameters.AddWithValue("@ad", txt_ad.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Geçerli Uzunlukta Bir Ad Giriniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update tbl_kulupler set kulup_ad=@ad where kulup_id=@id", baglanti);
            cmd.Parameters.AddWithValue("@ad", txt_ad.Text);
            cmd.Parameters.AddWithValue("@id", txt_id.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_kulupler where kulup_id=" + txt_id.Text, baglanti);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silinci","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }
    }
}
