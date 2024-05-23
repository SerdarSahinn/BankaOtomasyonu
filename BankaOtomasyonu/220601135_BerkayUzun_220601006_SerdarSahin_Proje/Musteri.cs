using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220601135_BerkayUzun_220601006_SerdarSahin_Proje
{
    public abstract class Musteri
    {
        public ulong MusteriNo { get; set; }
        public string sifre { get; set; }

        public Kimlik kimlik;

        public List<Hesap> Hesaplar = new List<Hesap>();
        public Musteri()
        {
            kimlik= new Kimlik();
        }

        public void HesapOlustur(Hesap hesap) 
        {
            Hesaplar.Add(hesap);
        
        }

        public void HesapSil(Hesap hesap) 
        { 
            Hesaplar.Remove(hesap);
        }
        public abstract void HavaleYap(ulong gonderen, ulong alici, int tutar);
    }
}
