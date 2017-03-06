using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projetakibi
{
    class Sınıflar
    {
         int Sinifid;
         public   String Sinifadi;
         public String Derslik;
         public String Alani;
         public String Sinifogretmeni;
         public String Mdyardimcisi;
         Vtislemleri vt;
        public Sınıflar(int sinifid)
        {
            Vtislemleri vt = new Vtislemleri();
            System.Data.OleDb.OleDbDataReader DR=vt.Listegetir("Select * from Siniflar where Sinifid=" + sinifid);
            if (DR.Read())
            {
                this.Alani = DR["alani"].ToString();
                this.Derslik = DR["Derslik"].ToString();
                this.Mdyardimcisi = DR["Mdyardimcisi"].ToString();
                this.Sinifadi = DR["Sinifadi"].ToString();
                this.Sinifid = Convert.ToInt16(DR["Sinifid"]);
                this.Sinifogretmeni = DR["Sinifogretmeni"].ToString();
            }
            vt.Baglantikapat();

        }

        public Sınıflar()
        {

        }
        public static List<Sınıflar> Siniflistesiver()
        {
            Vtislemleri vt = new Vtislemleri();
            Sınıflar S;
            List<Sınıflar> L = new List<Sınıflar>();

            System.Data.OleDb.OleDbDataReader siniflarlistesi = vt.Listegetir("Select * from Siniflar");
            while (siniflarlistesi.Read())
            {
                S = new Sınıflar();
                S.Sinifadi = siniflarlistesi["Sinifadi"].ToString();
                S.Derslik = siniflarlistesi["Derslik"].ToString();
                S.Alani = siniflarlistesi["Alani"].ToString();
                S.Sinifogretmeni = siniflarlistesi["Sinifogretmeni"].ToString();
                S.Mdyardimcisi = siniflarlistesi["Mdyardimcisi"].ToString();
                L.Add(S);
            }
            vt.Baglantikapat();
            return L;
        }
         public bool Kaydet()
        {
            int sonuc;
            string Sqlcumlesi = "insert into Siniflar(Sinifadi,Derslik,Alani,Sinifogretmeni,Mdyardimcisi) values('" + Sinifadi + "','" + Derslik + "','" + Alani + "','" + Sinifogretmeni + "','" + Mdyardimcisi + "')";
            vt = new Vtislemleri();
            sonuc=vt.Kayitgir(Sqlcumlesi);
            return (sonuc>0);
        }
         public bool Guncelle()
        {
            int sonuc;
            vt=new Vtislemleri();
            System.Data.OleDb.OleDbCommand komut=vt.Komutgetir();
            komut.CommandText = "update Siniflar set Sinifadi=@sa, Derslik=@d,Alani=@alani,Sinifogretmeni=@so,Mdyardimcisi=@md";
            komut.Parameters.AddWithValue("sa", Sinifadi);
            komut.Parameters.AddWithValue("d", Derslik);
            komut.Parameters.AddWithValue("alani", Alani);
            komut.Parameters.AddWithValue("so",Sinifogretmeni);
            komut.Parameters.AddWithValue("md", Mdyardimcisi);
            sonuc = vt.Komutcalistir(komut);
            return (sonuc > 0);

        }
         public override string ToString()
         {
             return Sinifadi;
         }
    }
}
