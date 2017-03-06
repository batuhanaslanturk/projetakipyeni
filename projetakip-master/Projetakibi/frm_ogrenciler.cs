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
    public partial class frm_ogrenciler : Form
    {
        public frm_ogrenciler()
        {
            InitializeComponent();
        }

        private void frm_ogrenciler_Load(object sender, EventArgs e)
        {
            List<Ogrenci> OL = Ogrenci.Ogrncilistesiver();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = OL;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            Ogrenci O = new Ogrenci(Convert.ToInt16(dataGridView1.CurrentRow.Cells["Ogrenciid"].Value));
            listBox1.DataSource = O.Projelistesi;
            listBox1.Refresh();
        }
    }
}
