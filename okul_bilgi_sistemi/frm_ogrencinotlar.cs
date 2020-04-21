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
    public partial class frm_ogrencinotlar : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-323TRBO\\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
        public string id;
        public frm_ogrencinotlar()
        {
            InitializeComponent();
        }

        private void frm_ogrencinotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select ogr_ad,ogr_soyad from tbl_ogrenciler where ogr_id=" + id, baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ders_ad,sinav1,sinav2,sinav3,ortalama,durum from tbl_notlar inner join tbl_dersler on tbl_notlar.ders_id=tbl_dersler.ders_id where ogr_id='" + id.ToString() + "'", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
