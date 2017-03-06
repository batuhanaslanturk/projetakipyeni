using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projetakibi
{
    class Proje
    {
        int Projeid;
        public String Projeadi;
        String Aciklama;
        DateTime baslamaarihi;
        int Durum;
        DateTime Bitistarihi;
        String Dersadi;

        public Proje() { }
        public Proje(int projeid)
        {
            Vtislemleri vt = new Vtislemleri();
            System.Data.OleDb.OleDbDataReader DR = vt.Listegetir("Select * from Projeler where Projeid=" + projeid);
            if (DR.Read())
            {
                this.Projeadi = DR["Projeadi"].ToString();
                this.Aciklama = DR["Aciklama"].ToString();
                this.Durum = Convert.ToInt16(DR["Durum"]);
            }
            vt.Baglantikapat();
        }
        public override string ToString()
        {
            return this.Projeadi;
        }
    }
}
