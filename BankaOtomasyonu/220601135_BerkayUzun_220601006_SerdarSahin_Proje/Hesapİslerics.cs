using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _220601135_BerkayUzun_220601006_SerdarSahin_Proje
{
    public partial class Hesapİslerics : Form
    {
       

        public static BireyselMusteri bmusteri = new BireyselMusteri();
        public static TicariMusteri tmusteri = new TicariMusteri();

        public static int MusteriNo;

        public void MusteriBul()
        {
            foreach (Musteri m in frmMain.banka.Musteriler)
            {
                if (m.MusteriNo == frmMain.numara)
                {
                    if (m is BireyselMusteri)
                    {
                        bmusteri = (BireyselMusteri)m;
                    }
                    else if (m is TicariMusteri)
                    {
                        tmusteri = (TicariMusteri)m;
                    }
                }
            }
        }

        public int HesapNoOlustur()
        {
            Random random = new Random();
            int hesapno = random.Next(1000, 9999);
            return hesapno;
        }


        public Hesapİslerics()
        {
            InitializeComponent();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }
      
        private void Hesapİslerics_Load(object sender, EventArgs e)
        {

            


        }

        private void btnHesapAc_Click(object sender, EventArgs e)
        {
            MusteriBul();
            boxHesapNo.Items.Clear();
            Hesap ekhesap = new Hesap();
            ekhesap.HesapNo = Convert.ToUInt64(HesapNoOlustur());
            boxHesapNo.Items.Add(ekhesap.HesapNo);
            if (bmusteri.MusteriNo!=0) { bmusteri.HesapOlustur(ekhesap); }
            else if(tmusteri.MusteriNo!=0) { tmusteri.HesapOlustur(ekhesap); }
            MessageBox.Show("Hesap açma işlemi başarılı!");
        }

        private void txtSilinecekNo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            frmMain frmMain= new frmMain();
            frmMain.Show();
            this.Hide();
        }

        private void btnTutarGoster_Click(object sender, EventArgs e)
        {
            boxTutar1.Items.Clear();
            MusteriBul();
            if (bmusteri.MusteriNo != 0)
            { foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if(Convert.ToUInt64(txtHesapNoCek.Text) == h.HesapNo)
                    { boxTutar1.Items.Add(h.Para); }
                }
            }
            else if (tmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (Convert.ToUInt64(txtHesapNoCek.Text) == h.HesapNo)
                    { boxTutar1.Items.Add(h.Para); }
                }
            }

        }

        private void btnTutarGosterYatirilacak_Click(object sender, EventArgs e)
        {
            boxTutar2.Items.Clear();
            MusteriBul();
            if (bmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (Convert.ToUInt64(txtHesapNoYatir.Text) == h.HesapNo)
                    { boxTutar2.Items.Add(h.Para);
                    }

                }
            }
            else if (tmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (Convert.ToUInt64(txtHesapNoYatir.Text) == h.HesapNo)
                    { boxTutar2.Items.Add(h.Para);
                    }
                }
            }
        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            MusteriBul();
            if (bmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (Convert.ToUInt64(txtHesapNoYatir.Text) == h.HesapNo)
                    {
                        h.ParaYatir(Convert.ToInt32(txtYatir.Text));
                        
                        MessageBox.Show(txtYatir.Text + " tl hesabınıza yatırılmıştır.");
                    }
                }
            }
            else if (tmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (Convert.ToUInt64(txtHesapNoYatir.Text) == h.HesapNo)
                    {
                        h.ParaYatir(Convert.ToInt32(txtYatir.Text));
                        MessageBox.Show(txtYatir.Text + " tl hesabınıza yatırılmıştır.");
                        txtYatir.Clear();
                    }
                }
            }
        }

        public static int gunlukcekilen = 0;

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            MusteriBul();
            gunlukcekilen += Convert.ToInt32(txtCek.Text);
            if (gunlukcekilen <= 750)
            {
                if (bmusteri.MusteriNo != 0)
                {
                    foreach (Hesap h in bmusteri.Hesaplar)
                    {
                        if (Convert.ToUInt64(txtHesapNoCek.Text) == h.HesapNo)
                        {
                            h.ParaCek(Convert.ToInt32(txtCek.Text));
                        }
                    }
                    MessageBox.Show(Convert.ToString(txtCek.Text) + "tl hesabınızdan çekilmiştir.");
                }
                else if (tmusteri.MusteriNo != 0)
                {
                    foreach (Hesap h in bmusteri.Hesaplar)
                    {
                        if (Convert.ToUInt64(txtHesapNoCek.Text) == h.HesapNo)
                        {
                            h.ParaCek(Convert.ToInt32(txtCek.Text));
                        }
                    }
                    MessageBox.Show(Convert.ToString(txtCek.Text) + "tl hesabınızdan çekilmiştir.");
                }

            }
            else if(gunlukcekilen> 750) 
            { MessageBox.Show("Günlük 750 tlden fazla para çekemezsiniz!"); }
            txtCek.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtSilinecekNo.Clear();
            MusteriBul();
            foreach(Musteri m in frmMain.banka.Musteriler)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (Convert.ToString(h.HesapNo) == Convert.ToString(txtSilinecekNo.Text)) ;
                    {
                        tmusteri.HesapSil(h);
                        MessageBox.Show("Hesap silme işlemi başarılı.");
                    }
                }
            }
        }

        private void btnHavale_Click(object sender, EventArgs e)
        {
            string havalealan = Convert.ToString(txtHavaleAlici.Text);
            MusteriBul();
            if (bmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (h.HesapNo == Convert.ToUInt64(txtHavaleGonderici.Text)) ;
                    {
                        bmusteri.HavaleYap(h.HesapNo, Convert.ToUInt64(txtHavaleAlici.Text), Convert.ToInt32(txtHavaleUcret.Text));
                    }
                }
                MessageBox.Show(Convert.ToString(txtHavaleUcret.Text) + "tl alıcıya gönderilmiştir.");
            }
            else if (tmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    if (h.HesapNo == Convert.ToUInt64(txtHavaleGonderici.Text)) ;
                    {
                        bmusteri.HavaleYap(h.HesapNo, Convert.ToUInt64(txtHavaleAlici.Text), Convert.ToInt32(txtHavaleUcret.Text));
                    }
                }
                MessageBox.Show(Convert.ToString(txtHavaleUcret.Text) + "tl alıcıya gönderilmiştir.");

            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dtHesapOzet.Rows.Clear();
            DateTime baslangic = dateBaslangic.Value;
            DateTime bitis = dateBitis.Value;
            dtHesapOzet.ClearSelection();
            dtHesapOzet.ColumnCount = 4;
            dtHesapOzet.Columns[0].Name = "HESAP NO";
            dtHesapOzet.Columns[1].Name = "TARIH";
            dtHesapOzet.Columns[2].Name = "TUTAR";
            dtHesapOzet.Columns[3].Name = "ALICI";
            
            MusteriBul();
            
            if (bmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    foreach(IslemBilgi islem in h.Islemler)
                    {
                        if (islem.DateTime >= baslangic && islem.DateTime <= bitis)
                        {
                            if (islem.Para > 0)
                            {
                                dtHesapOzet.Rows.Add(h.HesapNo, islem.DateTime, islem.Para, "");
                            }
                            else
                            {
                                dtHesapOzet.Rows.Add(h.HesapNo, islem.DateTime, islem.Para, "");
                            }
                        }
                      
                    }
                }
                

            }
            else if (tmusteri.MusteriNo != 0)
            {
                foreach (Hesap h in bmusteri.Hesaplar)
                {
                    foreach (IslemBilgi islem in h.Islemler)
                    {
                        if (islem.DateTime >= baslangic && islem.DateTime <= bitis)
                        {
                            if (islem.Para > 0)
                            {
                                dtHesapOzet.Rows.Add(h.HesapNo, islem.DateTime,  islem.Para, "havalealan");
                            }
                            else
                            {
                                dtHesapOzet.Rows.Add(h.HesapNo, islem.DateTime, islem.Para, "havalealan");
                            }
                        }
                       
                    }
                }
            }
        }
        
        


        private void tabPage4_Click(object sender, EventArgs e)
        {
            
           
         
             
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
