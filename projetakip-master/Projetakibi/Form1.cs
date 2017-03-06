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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sınıflarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSiniflar frm = new frmSiniflar();
            frm.ShowDialog();
        }

        private void öğrencilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ogrenciler frm = new frm_ogrenciler();
            frm.ShowDialog();
        }
    }
}
