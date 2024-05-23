using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _220601135_BerkayUzun_220601006_SerdarSahin_Proje
{
    public class Hesap 
    {
        public List <IslemBilgi> Islemler = new List <IslemBilgi> ();
        public List<IslemBilgi> fatura=new List<IslemBilgi> ();

        public int yatır { get; set; }
        public int cek { get; set; }
        public ulong HesapNo { get; set; }
        public int Para { get; set; }
       
        public Hesap()
        {
            this.Para = 0;
        }


        public void ParaYatir(int yatirilan)
        {
           
            this.Para += yatirilan;
            IslemEkle(yatirilan, "");
        }

        public void ParaCek(int cekilen)
        {
            if ((this.Para - cekilen) >= 0)
            {
                this.Para -= cekilen;
                Hesapİslerics.gunlukcekilen += cekilen;
                IslemEkle(-cekilen, "");
            }
            else
            { MessageBox.Show("Hesabınızda yeterli miktar para yoktur."); }

        }

      
        public void IslemEkle(int x, string alici)
        {
            IslemBilgi islem = new IslemBilgi();
            islem.DateTime =DateTime.Now;
            islem.Para = x;
            Islemler.Add(islem);

        }
       
       
        
    }
}
