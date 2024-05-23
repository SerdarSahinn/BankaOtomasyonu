using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace _220601135_BerkayUzun_220601006_SerdarSahin_Proje
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void banka��lemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bnkisi.Visible = true;
            MusterGrs.Visible = false;
            MusteriEkllm.Visible= false;

        }

        private void m��teriG�ri�iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bnkisi.Visible = false;
            MusteriEkllm.Visible = false;
            MusterGrs.Visible= true;
        }

        private void m��teriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bnkisi.Visible = false;
            MusteriEkllm.Visible = true;
            MusterGrs.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bnkisi.Visible=false;
            MusterGrs.Visible=false;
            MusteriEkllm.Visible = false;

        }

        public static Banka banka = new Banka();

        public static BireyselMusteri musteri1 = new BireyselMusteri();
        public static TicariMusteri musteri2 = new TicariMusteri();

        public static ulong numara=0;

        public int MusteriNoUret()
        {
            Random random = new Random();
            int No = random.Next(1000, 9999);
            return No;
        }


        private void btnMusteriHesapAc_Click(object sender, EventArgs e)
        {
            if(txtAd.Text=="" || txtSoyad.Text=="" || txtsif.Text=="" || txtTCNo.Text=="")
            { MessageBox.Show("T�m bilgileri girdi�inizden emin olun."); }

            if (rdbtnTicari.Checked != true && rdbtnBireysel.Checked != true)
            {
                MessageBox.Show("L�tfen m��teri t�r�n� se�iniz");
            } 

            if (rdbtnBireysel.Checked==true)
            {
                boxMusteriNo.Items.Clear();
                musteri1.kimlik.Ad=txtAd.Text;
                musteri1.kimlik.Soyad=txtSoyad.Text;
                musteri1.kimlik.TcKimlikNo = Convert.ToUInt64(txtTCNo.Text);
                int no = MusteriNoUret();
                boxMusteriNo.Items.Add(no);
                musteri1.MusteriNo = Convert.ToUInt64(no);
                numara = Convert.ToUInt64(no);
                musteri1.sifre = txtsif.Text;
                banka.Musteriler.Add(musteri1);
                MessageBox.Show("Hesab�n�z olu�turuldu.\nL�tfen hesap numaran�z� kaybetmeyiniz!");
            }
            if (rdbtnTicari.Checked==true)
            {
                boxMusteriNo.Items.Clear();
                musteri2.kimlik.Ad = txtAd.Text;
                musteri2.kimlik.Soyad = txtSoyad.Text;
                musteri2.kimlik.TcKimlikNo = Convert.ToUInt64(txtTCNo.Text);
                int no = MusteriNoUret();
                boxMusteriNo.Items.Add(no);
                musteri2.MusteriNo = Convert.ToUInt64(no);
                numara = Convert.ToUInt64(no);
                musteri2.sifre=txtsif.Text;
                banka.Musteriler.Add(musteri2);
                MessageBox.Show("Hesab�n�z olu�turuldu.\nL�tfen hesap numaran�z� kaybetmeyiniz!");
            }

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            if (kontrol)
            {
                foreach (Musteri m in banka.Musteriler)
                {
                    if (Convert.ToUInt64(txtMusteriNo.Text) == Convert.ToUInt64(m.MusteriNo) && txtSifre.Text == m.sifre)
                    {
                        MessageBox.Show("Giri� ba�ar�l�.\nHo� geldiniz.");
                        this.Hide();
                        Hesap�slerics hesap�slerics = new Hesap�slerics();
                        hesap�slerics.Show();
                        kontrol = false;
                    }
                }
            }
            if(kontrol) { MessageBox.Show("B�yle bir hesap bulunamad�.\nHesap No ve �ifrenizi kontrol ediniz.");  }
            
        }

        public static BireyselMusteri bmusteri = new BireyselMusteri();
        public static TicariMusteri tmusteri = new TicariMusteri();
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
        private void btnGoster_Click(object sender, EventArgs e)
        {
            dtBankaOzet.Rows.Clear();
            dtBankaOzet.ColumnCount = 3;
            dtBankaOzet.Columns[0].Name = "Yap�lan i�lem tutar�";
            dtBankaOzet.Columns[1].Name = "Bankadaki toplam  tutar";
           
            MusteriBul();
            int toptutar = 0;
            if (bmusteri.MusteriNo != 0)
                {
                    foreach (Hesap h in bmusteri.Hesaplar)
                    {
                            foreach (IslemBilgi islem in h.Islemler)
                            {
                                toptutar += islem.Para;
                                dtBankaOzet.Rows.Add(islem.Para, toptutar);
                            }
                    }
            }
           
            
        }
    }
}