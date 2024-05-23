using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _220601135_BerkayUzun_220601006_SerdarSahin_Proje
{
    public class TicariMusteri:Musteri
    {
        public override void HavaleYap(ulong gonderen, ulong alici, int tutar)
        {
            foreach(Hesap h in this.Hesaplar)
            {
                if(h.HesapNo==gonderen)
                {
                    foreach(Hesap a in this.Hesaplar)
                    {
                        h.ParaCek(tutar);
                        a.ParaYatir(tutar);
                    }
                    
                }
            }
        }
    }
}
