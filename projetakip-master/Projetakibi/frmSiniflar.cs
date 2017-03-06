using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projetakibi
{
    public partial class frmSiniflar : Form
    {
        Sınıflar sf;
        public frmSiniflar()
        {
            InitializeComponent();
            sf=new Sınıflar();
        }
        private void Bilgicek(Sınıflar s)
        {
            textBox1.Text = s.Sinifadi;
            textBox2.Text = s.Derslik;
            textBox3.Text = s.Alani;
            textBox4.Text = s.Sinifogretmeni;
            textBox5.Text = s.Mdyardimcisi;
        }

        private void Sinifdoldur()
        {
            sf.Sinifadi = textBox1.Text;
            sf.Derslik = textBox2.Text;
            sf.Alani = textBox3.Text;
            sf.Sinifogretmeni = textBox4.Text;
            sf.Mdyardimcisi = textBox5.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sinifdoldur();
            if(sf.Kaydet())
                MessageBox.Show("Veriler başarılı bir şekilde kayıt edildi");
        }

        private void frmSiniflar_Load(object sender, EventArgs e)
        {
             listBox1.DataSource = Sınıflar.Siniflistesiver();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sınıflar S = (Sınıflar)listBox1.SelectedItem;
            Bilgicek(S);
        }
    }
}
