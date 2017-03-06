using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Projetakibi
{
    class Vtislemleri
    {
        String cumle="provider=Microsoft.Jet.Oledb.4.0; DAta Source=projevt.mdb";
        OleDbConnection bag;

        public Vtislemleri()
        {
            bag = new OleDbConnection(cumle);
        }

        public void Baglantikapat()
        {
            if (bag.State == System.Data.ConnectionState.Open) bag.Close();
        }
        public int Kayitgir(String komutcumlesi)
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand(komutcumlesi, bag);
            return komut.ExecuteNonQuery();
            bag.Close();
        }

        public OleDbCommand Komutgetir()
        {
            OleDbCommand k = new OleDbCommand();
            return k;
        }

        public int Komutcalistir(OleDbCommand komut)
        {
            int sonuc;
            komut.Connection = bag;
            bag.Open();
            sonuc=komut.ExecuteNonQuery();
            bag.Close();
            return sonuc;
        }

        public OleDbDataReader Listegetir(String Sql)
        {
            OleDbDataReader sonuc;
            bag.Open();
            OleDbCommand komut = new OleDbCommand(Sql, bag);
            sonuc = komut.ExecuteReader();
            return sonuc;
      
        }
    }
}
