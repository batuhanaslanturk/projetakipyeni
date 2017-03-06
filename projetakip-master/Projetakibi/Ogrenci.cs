using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projetakibi
{
    class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public String Ad { get; set; }
        public String Soyad { get; set; }
        public int Okulno { get; set; }
        public String Sinifadi{
            get { return Sinif.Sinifadi; }
            set { Sinif.Sinifadi = value; }
        }
       Sınıflar Sinif;
       Vtislemleri vt;
       public List<Proje> Projelistesi;
    
        public Ogrenci() { }
        public Ogrenci(int ogrid)
        {
            vt = new Vtislemleri();
            System.Data.OleDb.OleDbDataReader DR = vt.Listegetir("Select * from Ogrenciler where Ogrenciid=" + ogrid);
            if (DR.Read())
            {
                this.Ad = DR["Ad"].ToString();
                this.Soyad = DR["Soyad"].ToString();
                this.Okulno = Convert.ToInt16(DR["Okulno"]);
                this.Ogrenciid = Convert.ToInt16(DR["Ogrenciid"]);
                Sınıflar S = new Sınıflar(Convert.ToInt16(DR["Sinifno"]));
                this.Sinif = S; 
            }
            vt.Baglantikapat();
            Projelistesiolustur();
            
        }

        private void Projelistesiolustur()
        {
            Projelistesi = new List<Proje>();
            System.Data.OleDb.OleDbDataReader DR = vt.Listegetir("Select projeno from Ogrenciproje where Orencino=" +this.Ogrenciid);
           while (DR.Read())
            {
                Proje P = new Proje(Convert.ToInt16(DR["projeno"]));
                Projelistesi.Add(P);
            }

        }
        public static List<Ogrenci> Ogrncilistesiver()
        {
            Vtislemleri vt = new Vtislemleri();
            Ogrenci S;
            List<Ogrenci> L = new List<Ogrenci>();

            System.Data.OleDb.OleDbDataReader Ogrencilistesi = vt.Listegetir("Select * from Ogrenciler");
            while (Ogrencilistesi.Read())
            {
                S = new Ogrenci();
                S.Ad = Ogrencilistesi["Ad"].ToString();
                S.Soyad= Ogrencilistesi["Soyad"].ToString();
                S.Okulno =Convert.ToInt16( Ogrencilistesi["Okulno"]);
                S.Ogrenciid= Convert.ToInt16(Ogrencilistesi["Ogrenciid"]);

                Sınıflar os = new Sınıflar(Convert.ToInt16(Ogrencilistesi["Sinifno"]));
               S.Sinif = os;
                L.Add(S);
            }
            vt.Baglantikapat();
            return L;
        }
    }
}
