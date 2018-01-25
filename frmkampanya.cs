using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RestSharp;
using Newtonsoft.Json;

namespace bitirme
{
    public partial class frmkampanya : DevExpress.XtraEditors.XtraForm
    {
        public string kampid;
        public string kampkategori;
        public string kampkategori2;
        public string menukategoriid;
        public string[][] kategoriid;
        public string[][] menuid;
        public string[] idler;
        public string[] b;

        public int sec;
        public class MenuKategoriListele
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string kategoriSayisi { get; set; }
            public List<KategoriListesi> kategoriListe { get; set; }

        }

        public class KategoriListesi
        {
            public string adi { get; set; }
            public string kategori_id { get; set; }

        }

        MenuKategoriListele gelen;

        public class MenuUrunListele
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string urunSayisi { get; set; }
            public List<UrunListesi> urunListesi { get; set; }
        }

        public class UrunListesi
        {
            public string urun_id { get; set; }
            public string adi { get; set; }
            public string birim { get; set; }
            public string fiyat { get; set; }
            public string aciklama { get; set; }

        }

        MenuUrunListele gelenmenu;

        public class KampanyaBaslat
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string kampanya_id { get; set; }
        }

        KampanyaBaslat ilk;
        public class KampanyaMenuBelirle
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public List<KampanyaMenu> kampanyaMenu { get; set; }
        }

        public class KampanyaMenu
        {
            public string kampanyaMenu_id { get; set; }

        }
        KampanyaMenuBelirle iki;

        public class KampanyaUrunBelirle
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public double toplamFiyat { get; set; }

        }
        KampanyaUrunBelirle uc;

        public class KampanyaListele
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public List<Kampanyalar> _kampanyaListe { get; set; }

        }
        public class Kampanyalar
        {
            public string id { get; set; }
            public string adi { get; set; }
            public double fiyat { get; set; }
            public DateTime basTarih { get; set; }
            public DateTime bitTarih { get; set; }



        }

        KampanyaListele listele;

        public MenuUrunListele f1(string a)
        {
            var client1 = new RestClient("http://loc.deepram.com/api/Menu/UrunListele/?sube_id=" + frmgiris.subeid + "&kategori_id=" + a + "&token=" + frmgiris.oldtoken);
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("cache-control", "no-cache");
            IRestResponse response1 = client1.Execute(request1);

          
            return JsonConvert.DeserializeObject<MenuUrunListele>(response1.Content);
            
        }
        public frmkampanya()
        {
            InitializeComponent();
        }
        

        private void frmkampanya_Load(object sender, EventArgs e)
        {
            p0.Visible = false;
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
          

            var client = new RestClient("http://loc.deepram.com/api/Menu/KategoriListele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            gelen = JsonConvert.DeserializeObject<MenuKategoriListele>(response.Content);

            

            foreach (KategoriListesi _gelen in gelen.kategoriListe)
            {
               
                ckate1.Items.Add(String.Format("{0} | {1}", _gelen.kategori_id , _gelen.adi));
                ckate2.Items.Add(String.Format("{0} | {1}", _gelen.kategori_id, _gelen.adi));
                ckate3.Items.Add(String.Format("{0} | {1}", _gelen.kategori_id, _gelen.adi));
                ckate4.Items.Add(String.Format("{0} | {1}", _gelen.kategori_id, _gelen.adi));
                ckate5.Items.Add(String.Format("{0} | {1}", _gelen.kategori_id, _gelen.adi));


            }

           


        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            string kadi;
            string btarih;
            string starih;

            kadi = textkadi.Text;
            btarih = dateTimePicker1.Value.ToString();
            starih = dateTimePicker1.Value.ToString();
            var client = new RestClient("http://loc.deepram.com/api/Kampanya/Baslat/?adi=" + kadi + "&sube_id=" + frmgiris.subeid + "&basTarih=" + btarih + "&bitTarih=" + starih + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            ilk = JsonConvert.DeserializeObject<KampanyaBaslat>(response.Content);

            if (ilk.onay == true)
            {
                kampid = ilk.kampanya_id;
                MessageBox.Show("KAYIT BAŞARILI...","BİLGİLENDİRME PENCERESİ");
                kampkategori = "";
                kampkategori2 = "";
                menukategoriid = "";
               

            }

        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            if (p0.Visible == false)
            {
                p0.Visible = true;
                sec = 1;
                
            }
            else if (p1.Visible == false)
            {
                p1.Visible = true;
                sec = 2;
            }
            else if (p2.Visible == false)
            {
                p2.Visible = true;
                sec = 3;
            }
            else if (p3.Visible == false)
            {
                p3.Visible = true;
                sec = 4;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            kampkategori = "";
            kampkategori2 = "";
            menukategoriid = "";
            if (p5.Visible == true)
            {
                idler = ckate1.SelectedItem.ToString().Split('|');
                kampkategori +="&kategori_id[0]=" + idler[0];
                kampkategori2 += "&kampanya[0].kategori_id=" + idler[0];

            }
             if (p0.Visible == true)
            {
                idler = ckate2.SelectedItem.ToString().Split('|');
                kampkategori +="&kategori_id[1]=" + idler[0];
                kampkategori2 += "&kampanya[1].kategori_id=" + idler[0];
            }
             if (p1.Visible == true)
            {
                idler = ckate3.SelectedItem.ToString().Split('|');
                kampkategori +="&kategori_id[2]=" + idler[0];
                kampkategori2 += "&kampanya[2].kategori_id=" + idler[0];
            }
             if (p2.Visible == true)
            {
                idler = ckate4.SelectedItem.ToString().Split('|');
                kampkategori +="&kategori_id[3]=" + idler[0];
                kampkategori2 += "&kampanya[3].kategori_id=" + idler[0];
            }
             if (p3.Visible == true)
            {
                idler = ckate5.SelectedItem.ToString().Split('|');      
                kampkategori +="&kategori_id[4]=" + idler[0];
                kampkategori2 += "&kampanya[4].kategori_id=" + idler[0];
            }

          
  
            var client = new RestClient("http://loc.deepram.com/api/Kampanya/MenuBelirle/?kampanya_id=" + kampid + kampkategori + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            iki = JsonConvert.DeserializeObject<KampanyaMenuBelirle>(response.Content);

            if (iki.onay == true)
            {
                MessageBox.Show("KATEGORİLER ONAYLANDI","Bilgilendirme penceresi....");
                if (p5.Visible == true)
                {

                    idler = ckate1.SelectedItem.ToString().Split('|');
                    
                    foreach (UrunListesi _gelen in f1(idler[0]).urunListesi)
                    {
                        string[] veriler = { _gelen.adi, _gelen.fiyat, _gelen.urun_id };
                        menuc1.Items.Add(String.Format("{0} | {1}", _gelen.urun_id, _gelen.adi));
                    }


                }
                if (p0.Visible == true)
                {
                    idler = ckate2.SelectedItem.ToString().Split('|');
                   
                    foreach (UrunListesi _gelen in f1(idler[0]).urunListesi)
                    {
                        string[] veriler = { _gelen.adi, _gelen.fiyat, _gelen.urun_id };
                        menuc2.Items.Add(String.Format("{0} | {1}", _gelen.urun_id, _gelen.adi));
                    }

                   
                }
                if (p1.Visible == true)
                {
                    idler = ckate3.SelectedItem.ToString().Split('|');
                   
                    foreach (UrunListesi _gelen in f1(idler[0]).urunListesi)
                    {
                        string[] veriler = { _gelen.adi, _gelen.fiyat, _gelen.urun_id };
                        menuc3.Items.Add(String.Format("{0} | {1}", _gelen.urun_id, _gelen.adi));
                    }

                }
                if (p2.Visible == true)
                {
                    idler = ckate4.SelectedItem.ToString().Split('|');
                    
                    foreach (UrunListesi _gelen in f1(idler[0]).urunListesi)
                    {
                        string[] veriler = { _gelen.adi, _gelen.fiyat, _gelen.urun_id };
                        menuc4.Items.Add(String.Format("{0} | {1}", _gelen.urun_id, _gelen.adi));
                    }

                  
                }
                if (p3.Visible == true)
                {
                    idler = ckate5.SelectedItem.ToString().Split('|');
                   
                    foreach (UrunListesi _gelen in f1(idler[0]).urunListesi)
                    {
                        string[] veriler = { _gelen.adi, _gelen.fiyat, _gelen.urun_id };
                        menuc5.Items.Add(String.Format("{0} | {1}", _gelen.urun_id, _gelen.adi));
                    }

                    
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (p5.Visible == true)
            {

                idler = menuc1.SelectedItem.ToString().Split('|');
                menukategoriid += "&kampanya[0].urun_id[0]=" + idler[0];
            }
            if (p0.Visible == true)
            {
                idler = menuc2.SelectedItem.ToString().Split('|');
                menukategoriid += "&kampanya[1].urun_id[0]=" + idler[0];
            }
            if (p1.Visible == true)
            {
                idler = menuc3.SelectedItem.ToString().Split('|');
                menukategoriid += "&kampanya[2].urun_id[0]=" + idler[0];
            }
            if (p2.Visible == true)
            {
                idler = menuc4.SelectedItem.ToString().Split('|');

                menukategoriid += "&kampanya[3].urun_id[0]=" + idler[0]; ;
            }
            if (p3.Visible == true)
            {
                idler = menuc5.SelectedItem.ToString().Split('|');
                menukategoriid += "&kampanya[4].urun_id[0]=" + idler[0];
            }
            var client = new RestClient("http://loc.deepram.com/api/Kampanya/MenuBelirle/?kampanya_id=" + kampid + kampkategori2 + menukategoriid + "&kampanyafiyat=" + Convert.ToDouble(texttfiyat.Text) + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            uc = JsonConvert.DeserializeObject<KampanyaUrunBelirle>(response.Content);

            if (uc.onay == true)
            {
                MessageBox.Show("KAMPANYA OLUŞTURMA TAMAMLANDI...", "Bilgilendirme penceresi....");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Kampanya/Listele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            listele = JsonConvert.DeserializeObject<KampanyaListele>(response.Content);

            foreach (Kampanyalar _liste in listele._kampanyaListe)
            {
                string[] veriler = { _liste.adi ,Convert.ToString( _liste.fiyat) ,Convert.ToString( _liste.basTarih) ,Convert.ToString( _liste.bitTarih) };
                listkampanya.Items.Add(new ListViewItem(veriler));
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form anasayfadön = new frmanasayfa();
            anasayfadön.Show();
        }
    }
}