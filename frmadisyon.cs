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
    
    public partial class frmadisyon : DevExpress.XtraEditors.XtraForm
    {
        public string masaadisyonid = "";
        public static int yenile = 0;
        public class MenuResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string kategoriSayisi { get; set; }
            public List<Menu> menu { get; set; }
        }
        MenuResult menuler;

        public class AdisyonKapat
        {
            public string token { get; set; }
            public bool onay { get; set; }

        }
        AdisyonKapat kapat;

        public class Menu
        {
            public string kategori_adi { get; set; }
            public string kategori_id { get; set; }
            public string urunSayisi { get; set; }
            public List<AltMenu> altMenu { get; set; }

        }

        
        public class AltMenu
        {
            public string urun_id { get; set; }
            public string adi { get; set; }
            public string birim { get; set; }
            public string birim_fiyat { get; set; }
            public string aciklama { get; set; }
        }
        


        public class MasaDetay
        {
            public string id { get; set; }
            public bool aktif { get; set; }
            public string odeme_tipi { get; set; }
            public string kullanici_id { get; set; }
            public string sube_id { get; set; }
            public string adisyon_suresi { get; set; }
            public string adisyonToplamFiyat { get; set; }
            public string token { get; set; }
            public bool onay { get; set; }
            public List<Adisyon> adisyon { get; set; }


        }
        MasaDetay masa;
        MasaDetay masa1;

        public class Adisyon
        {
            public string adi { get; set; }
            public string adet { get; set; }
            public string fiyat { get; set; }
        }

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

        public class AdisyonUrunEkle
        {
        public double toplamUrunFiyati { get; set; }
        public string token { get; set; }
        public bool onay { get; set; }
        }

        AdisyonUrunEkle ekleme;

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

       


        public frmadisyon()
        {
            InitializeComponent();
        }


        //HESAP MAKİNESİ EVENT
        void islem(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    textadet.Text += (1).ToString();
                    break;
                case "btn2":
                    textadet.Text += (2).ToString();
                    break;
                case "btn3":
                    textadet.Text += (3).ToString();
                    break;
                case "btn4":
                    textadet.Text += (4).ToString();
                    break;
                case "btn5":
                    textadet.Text += (5).ToString();
                    break;
                case "btn6":
                    textadet.Text += (6).ToString();
                    break;
                case "btn7":
                    textadet.Text += (7).ToString();
                    break;
                case "btn8":
                    textadet.Text += (8).ToString();
                    break;
                case "btn9":
                    textadet.Text += (9).ToString();
                    break;
                case "btn0":
                    textadet.Text += (0).ToString();
                    break;
                case "btnc":
                    textadet.Text = "";
                    break;
                default:
                    MessageBox.Show("SAYI GİRİNİZ ... ");
                    break;
            }

        }
        private void frmadisyon_Load(object sender, EventArgs e)
        {
           
            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
            btnc.Click += new EventHandler(islem);


            panelurunekle.Visible = false;
            var client = new RestClient("http://loc.deepram.com/api/SubeMasa/MasaDetay/?masa_id=" + frmmekanalan.masagönderid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            masa = JsonConvert.DeserializeObject<MasaDetay>(response.Content);
            masaadisyonid = masa.id;

            lblmasatutar.Text += masa.adisyonToplamFiyat;

            foreach (Adisyon _gelen in masa.adisyon)
            {
                string[] veriler = { _gelen.adi, _gelen.adet,_gelen.fiyat};

                listView1.Items.Add(new ListViewItem(veriler));
                
            }

        }

        private void adisyontutar_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //urun ekle
            panelurunekle.Visible = true;
            var client = new RestClient("http://loc.deepram.com/api/Menu/MenuListele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            
            menuler = JsonConvert.DeserializeObject<MenuResult>(response.Content);

            
            foreach (Menu _kategori in menuler.menu)
            {
                comboBox1.Items.Add(_kategori.kategori_adi);
            }

 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            string sec = "";
            sec = comboBox1.SelectedItem.ToString();
            string kid;
            
            kid = menuler.menu.FirstOrDefault(x => x.kategori_adi.Equals(sec)).kategori_id.ToString();

            var client = new RestClient("http://loc.deepram.com/api/Menu/UrunListele/?sube_id=" + frmgiris.subeid + "&kategori_id=" + kid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            gelenmenu = JsonConvert.DeserializeObject<MenuUrunListele>(response.Content);



            foreach (UrunListesi _gelen in gelenmenu.urunListesi)
            {
                string[] veriler = { _gelen.adi, _gelen.fiyat,_gelen.urun_id};
                listView2.Items.Add(new ListViewItem(veriler));

            }
        }

       

        private void button16_Click(object sender, EventArgs e)
        {
            int sayaclist2;
         
            
            sayaclist2 = listView3.Items.Count;
            for (int i = 0; i < sayaclist2; i++)
            {
                var client = new RestClient("http://loc.deepram.com/api/Adisyon/UrunEkle/?adisyon_id=" + masaadisyonid+ "&urun_id[0]=" + listView3.Items[i].SubItems[3].Text + "&urun_adet[0]=" + listView3.Items[i].SubItems[1].Text   + "&kampanya_id="    + "&token=" + frmgiris.token);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");

                IRestResponse response = client.Execute(request);

                ekleme = JsonConvert.DeserializeObject<AdisyonUrunEkle>(response.Content);

              

            

                if (ekleme.onay == true)
                    {
                        listView1.Items.Clear();
                        var client1 = new RestClient("http://loc.deepram.com/api/SubeMasa/MasaDetay/?masa_id=" + frmmekanalan.masagönderid + "&token=" + frmgiris.oldtoken);
                        var request1 = new RestRequest(Method.POST);
                        request1.AddHeader("cache-control", "no-cache");
                        IRestResponse response1 = client1.Execute(request);

                        masa1 = JsonConvert.DeserializeObject<MasaDetay>(response1.Content);

                        lblmasatutar.Text = masa1.adisyonToplamFiyat;

                        foreach (Adisyon _eklemeden in masa1.adisyon)
                        {
                            string[] veriler1 = { _eklemeden.adi, _eklemeden.adet, _eklemeden.fiyat };

                            listView1.Items.Add(new ListViewItem(veriler1));

                        }


                    }

            }
            


        }

        private void button12_Click(object sender, EventArgs e)
        {
            
        }

        int sayac = 0; 
        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (textadet.Text == "")
            {
                textadet.Text = "1";
            }
            if (listView2.Items.Count>0)
            {
                sayac = listView3.Items.Count;
                listView3.Items.Add(listView2.SelectedItems[0].Text);
                listView3.Items[sayac].SubItems.Add(textadet.Text);
                listView3.Items[sayac].SubItems.Add((Convert.ToDecimal(listView2.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(textadet.Text)).ToString());
                listView3.Items[sayac].SubItems.Add(listView2.SelectedItems[0].SubItems[2].Text);
       
            }
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            int say;
            say = listView2.Items.Count;

            var client = new RestClient("http://loc.deepram.com/api/Menu/Kampanya/Listele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            listele = JsonConvert.DeserializeObject<KampanyaListele>(response.Content);

            foreach (Kampanyalar _liste in listele._kampanyaListe)
            {

                string[] veriler = { _liste.adi ,Convert.ToString( _liste.fiyat), _liste.id };
                listView2.Items.Add(new ListViewItem(veriler));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Adisyon/Kapat/?adisyon_id=" + masaadisyonid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            kapat= JsonConvert.DeserializeObject<AdisyonKapat>(response.Content);

            if (kapat.onay == true)
            {
                MessageBox.Show("MASA BAŞARIYLA KAPATILMIŞTIR...","BİLGİLENDİRME PENCERESİ");
                yenile = 1;
            }
        }
    }
}