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
    public partial class frm_sinavnotlar : Form
    {
        public frm_sinavnotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_notlarTableAdapter ds = new DataSet1TableAdapters.tbl_notlarTableAdapter();
        private void btn_ara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.not_listele(int.Parse(txt_id.Text));
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-323TRBO\\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
        private void frm_sinavnotlar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select* from tbl_dersler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combo_ders.DisplayMember = "ders_ad";
            combo_ders.ValueMember = "ders_id";
            combo_ders.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_sinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_sinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_sinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_proje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            
        }

        private void btn_gucelle_Click(object sender, EventArgs e)
        {
            ds.not_guncelle(byte.Parse(combo_ders.SelectedValue.ToString()), int.Parse(txt_id.Text), byte.Parse(txt_sinav1.Text), byte.Parse(txt_sinav2.Text), byte.Parse(txt_sinav3.Text), byte.Parse(txt_proje.Text), notid);
            MessageBox.Show("Kayıt Güncellendi");
        }
    }
}
