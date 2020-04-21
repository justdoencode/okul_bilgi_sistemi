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
    public partial class frm_ogretmen : Form
    {
        public frm_ogretmen()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_kulup frmkulup = new frm_kulup();
            frmkulup.Show();
        }

        private void btn_dersler_Click(object sender, EventArgs e)
        {
            frm_dersler frmdersler = new frm_dersler();
            frmdersler.Show();
        }

        private void btn_ogrenci_Click(object sender, EventArgs e)
        {
            frm_ogrenci frmogrenci = new frm_ogrenci();
            frmogrenci.Show();
        }

        private void btn_not_Click(object sender, EventArgs e)
        {
            frm_sinavnotlar frmsinavnotlar = new frm_sinavnotlar();
            frmsinavnotlar.Show();
        }
    }
}
