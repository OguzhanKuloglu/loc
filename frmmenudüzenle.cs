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
    public partial class frmmenudüzenle : DevExpress.XtraEditors.XtraForm
    {

        public static string sid;
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

        public class MenuUrunEkle
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string urun_id { get; set; }
        }

        MenuUrunEkle ekle;

        public class MenuUrunSil
        {
            public string token { get; set; }
            public bool onay { get; set; }
        }
        MenuUrunSil sil;

        public class MenuUrunDuzenle
        {
            public string token { get; set; }
            public bool onay { get; set; }
        }

        MenuUrunDuzenle duzenle;

        public frmmenudüzenle()
        {
            InitializeComponent();
        }

        private void frmmenudüzenle_Load(object sender, EventArgs e)
        {
            label4.Text = frmmenu.düzenlenen;

            var client = new RestClient("http://loc.deepram.com/api/Menu/UrunListele/?sube_id=" + frmgiris.subeid + "&kategori_id=" + frmmenu.did + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            gelenmenu = JsonConvert.DeserializeObject<MenuUrunListele>(response.Content);



            foreach (UrunListesi _gelen in gelenmenu.urunListesi)
            {
                string[] veriler = { _gelen.adi,_gelen.birim,_gelen.fiyat,_gelen.aciklama , _gelen.urun_id };
                listView1.Items.Add(new ListViewItem(veriler));

            }

           


        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Menu/UrunEkle/?sube_id=" + frmgiris.subeid + "&fiyat=" + Convert.ToDouble(textfiyat.Text) + "&birim=" + Convert.ToDouble(textporsiyon.Text) + "&adi=" + textadi.Text + "&token=" + frmgiris.oldtoken + "&kategori_id=" + frmmenu.did + "&aciklama=" + richTextacıklama.Text);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            ekle = JsonConvert.DeserializeObject<MenuUrunEkle>(response.Content);



            if (ekle.onay == true)
            {
                string[] veriler = { textadi.Text, textporsiyon.Text, textfiyat.Text, richTextacıklama.Text ,ekle.urun_id };
                listView1.Items.Add(new ListViewItem(veriler));
            }
            else
            {
                MessageBox.Show("BAŞARISIZ EKLEME İŞLEMİ ", "Bilgilendirme Ekranı");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string silid;
            silid = listView1.SelectedItems[0].Text;
            string mid;
            mid = gelenmenu.urunListesi.FirstOrDefault(x => x.adi.Equals(silid)).urun_id.ToString();

            var client = new RestClient("http://loc.deepram.com/api/Menu/UrunSil/?sube_id=" + frmgiris.subeid + "&urun_id=" + mid  + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            sil = JsonConvert.DeserializeObject<MenuUrunSil>(response.Content);

            if (sil.onay == true)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("BAŞARISIZ SİLME İŞLEMİ ", "BİLGİLENDİRME EKRANI");
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            
            string secilen;
            secilen= listView1.SelectedItems[0].Text;
            sid = gelenmenu.urunListesi.FirstOrDefault(x => x.adi.Equals(secilen)).urun_id.ToString();
            string sadi;
            string sbirim;
            string sfiyat;
            string sacıklama;
            sadi = gelenmenu.urunListesi.FirstOrDefault(x => x.adi.Equals(secilen)).adi.ToString();
            sbirim = gelenmenu.urunListesi.FirstOrDefault(x => x.adi.Equals(secilen)).birim.ToString();
            sfiyat = gelenmenu.urunListesi.FirstOrDefault(x => x.adi.Equals(secilen)).fiyat.ToString();
            sacıklama = gelenmenu.urunListesi.FirstOrDefault(x => x.adi.Equals(secilen)).aciklama.ToString();
            
            textadi.Text = sadi;
            textporsiyon.Text = sbirim;
            textfiyat.Text = sfiyat;
            richTextacıklama.Text = sacıklama;

            button1.Visible = false;
            button4.Visible = true;

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Menu/UrunDuzenle/?sube_id=" + frmgiris.subeid + "&fiyat=" + Convert.ToDouble(textfiyat.Text) + "&birim=" + Convert.ToDouble(textporsiyon.Text) + "&adi=" + textadi.Text + "&token=" + frmgiris.oldtoken + "&kategori_id=" + frmmenu.did + "&aciklama=" + richTextacıklama.Text + "&urun_id=" + sid);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            duzenle = JsonConvert.DeserializeObject<MenuUrunDuzenle>(response.Content);

            if (duzenle.onay == true)
            {
                string[] veriler = { textadi.Text, textporsiyon.Text, textfiyat.Text, richTextacıklama.Text };
                listView1.Items.Add(new ListViewItem(veriler));
            }

            else
            {
                MessageBox.Show("Kaydetme İşlemi Başarısız ", "Bilgilendirme Ekranı ");
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