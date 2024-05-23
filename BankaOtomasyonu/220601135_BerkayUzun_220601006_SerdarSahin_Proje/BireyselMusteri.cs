using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220601135_BerkayUzun_220601006_SerdarSahin_Proje
{
    public class BireyselMusteri :Musteri
    {
        public override void HavaleYap(ulong gonderen, ulong alici, int tutar)
        {
            foreach (Hesap h in this.Hesaplar)
            {
                if (h.HesapNo == gonderen)
                {
                    foreach (Hesap a in this.Hesaplar)
                    {
                        if (a.HesapNo == alici)
                        {
                            a.ParaYatir(tutar);
                            h.ParaCek(tutar + (tutar*2/100));
                            h.IslemEkle(-(tutar * 102 / 100), Convert.ToString(a.HesapNo));
                        }
                    }

                }
            }
        }
    }
}
