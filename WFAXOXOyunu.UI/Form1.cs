using System.Diagnostics.Eventing.Reader;

namespace WFAXOXOyunu.UI
{
    public partial class Form1 : Form
    {
        bool birinciOyuncununSirasi = true;
        int birinciOyuncununKazanmaSayisi = 0, ikinciOyuncununKazanmaSayisi = 0 ,tiklananButonSayisi=0;

        public Form1()
        {
           InitializeComponent();
           txtBilgilendirme.Text = "Birinci Oyuncunun (X) sýrasý...";
        }

        public void OyunuTemizle()
        {
            Button[] butonlar = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };

            foreach (Button btn in butonlar)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
            txtBilgilendirme.Text = "Birinci Oyuncunun (X) sýrasý...";
        }

        public void BasilanButon(Button button)
        {
            tiklananButonSayisi++;
            button.Enabled = false;
            if (birinciOyuncununSirasi)
            {
                button.Text = "X";
                birinciOyuncununSirasi = false;
                txtBilgilendirme.Text = "Ýkinci Oyuncunun (O) sýrasý...";
            }
            else
            {
                button.Text = "O";
                birinciOyuncununSirasi = true;
                txtBilgilendirme.Text = "Birinci Oyuncunun (X) sýrasý...";
            }
            if (KazananVarMi())
            {
                tiklananButonSayisi = 0;
                if (!birinciOyuncununSirasi)
                {
                    MessageBox.Show("Tebrikler! Birinci Oyuncu(X) Kazandý. ");
                    OyunuTemizle();
                    birinciOyuncununKazanmaSayisi++;
                    lblBirinciOyuncuKazanmaSayisi.Text = birinciOyuncununKazanmaSayisi.ToString();
                }
                else
                {
                    MessageBox.Show("Tebrikler! Ýkinci Oyuncu(O) Kazandý. ");
                    OyunuTemizle();
                    ikinciOyuncununKazanmaSayisi++;
                    lblIkinciOyuncuKazanmaSayisi.Text = ikinciOyuncununKazanmaSayisi.ToString();
                }
            }
            if(tiklananButonSayisi==9&&!KazananVarMi())
            {
                MessageBox.Show("Berabere! Kazanan yok. ");
                OyunuTemizle();
                tiklananButonSayisi = 0;
            }
        }  

        public bool KazananVarMi()
        {

            bool kazananVarMi = false;
            Button[] butonlar = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            for (int i = 0; i < butonlar.Length; i += 3) //SATIR KONTROLU
            {
                if (butonlar[i].Text != "" && butonlar[i].Text == butonlar[i + 1].Text && butonlar[i].Text == butonlar[i + 2].Text)
                {
                    kazananVarMi = true;
                }
            }
            for (int i = 0; i < 3; i++) //SÜTUN KONTROLU
            {
                if (butonlar[i].Text != "" && butonlar[i].Text == butonlar[i + 3].Text && butonlar[i].Text == butonlar[i + 6].Text)
                {
                    kazananVarMi = true;
                }
            }
            if (btn1.Text != "" && btn1.Text == btn5.Text && btn1.Text == btn9.Text) //ÇAPRAZ KONTROL
            {
                kazananVarMi = true;
            }
            else if (btn3.Text != "" && btn3.Text == btn5.Text && btn3.Text == btn7.Text) //ÇAPRAZ KONTROL
            {
                kazananVarMi = true;
            }
            return kazananVarMi;
        }

        public void YeniOyun()
        {
            OyunuTemizle();
            lblBirinciOyuncuKazanmaSayisi.Text = "0";
            lblIkinciOyuncuKazanmaSayisi.Text = "0";
            birinciOyuncununKazanmaSayisi = 0;
            ikinciOyuncununKazanmaSayisi = 0;
        }

        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            YeniOyun();
        }

        #region Butonlarýn clickleri
        private void btn1_Click(object sender, EventArgs e)
        {
            BasilanButon(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            BasilanButon(btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            BasilanButon(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            BasilanButon(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            BasilanButon(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            BasilanButon(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            BasilanButon(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            BasilanButon(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            BasilanButon(btn9);
        }
        #endregion
    }
}
