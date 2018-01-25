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
    public partial class frmyönetici : DevExpress.XtraEditors.XtraForm
    {
        public class YoneticiListeleResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public List<YoneticiBilgi> yoneticiBilgi { get; set; }

        }

        public class YoneticiBilgi
        {
            public string yonetici_id { get; set; }
            public string adi { get; set; }
            public string soyadi { get; set; }
            public string dogum_tarihi { get; set; }
            public string kayit_tarihi { get; set; }
            public string email { get; set; }
            public string sifre { get; set; }
            public string tel { get; set; }
            public string adres { get; set; }
            public string foto_url { get; set; }
        }
        YoneticiListeleResult yöneticilistele;

        public class YoneticiDuzenleResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string yonetici_id { get; set; }
        }
        YoneticiDuzenleResult yöneticidüzenle;

        public class YoneticiKayitResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string yonetici_id { get; set; }
        }

        YoneticiKayitResult yöneticikayıt;

        public class SubeListeleResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public List<SubeBilgi> subeBilgi { get; set; }

        }

        public class SubeBilgi
        {
            public string sube_id { get; set; }
            public string adi { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
            public string adres { get; set; }
            public string tel { get; set; }
            public string foto_url { get; set; }
            public string isletme_id { get; set; }
        }


        SubeListeleResult listele;

        public frmyönetici()
        {
            InitializeComponent();
        }

        private void frmyönetici_Load(object sender, EventArgs e)
        {


            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            panel1.Dock = DockStyle.Fill;

            button3.Visible = false;   
            if (frmyöneticilistele.dyöneticiid != null)
            {
                button3.Visible = false;
                var client1 = new RestClient("http://loc.deepram.com/api/Yonetici/Listele/?isletme_id=" + frmgiris.isletme_id + "&token=" + frmgiris.token);
                var request1 = new RestRequest(Method.POST);
                request1.AddHeader("cache-control", "no-cache");
                IRestResponse response1 = client1.Execute(request1);

                yöneticilistele = JsonConvert.DeserializeObject<YoneticiListeleResult>(response1.Content);
                frmgiris.token = yöneticilistele.token;

                foreach (YoneticiBilgi _gelen in yöneticilistele.yoneticiBilgi)
                {
                    txtadi.Text = _gelen.adi;
                    txtsoyadi.Text = _gelen.soyadi;
                    txttelefon.Text = _gelen.tel;
                    richadres.Text = _gelen.adres;
                    datedogm.Text = _gelen.dogum_tarihi;
                    datekayıt.Text = _gelen.kayit_tarihi;
                    
                }
            }

            var client = new RestClient("http://loc.deepram.com/api/Sube/Listele/?isletme_id=" + frmgiris.isletme_id + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            listele = JsonConvert.DeserializeObject<SubeListeleResult>(response.Content);

            foreach (SubeBilgi _gelen in listele.subeBilgi)
            {
                comboBox1.Items.Add(String.Format("{0} | {1}", _gelen.sube_id, _gelen.adi));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form yöneticiler = new frmyöneticilistele();
            yöneticiler.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = true;
           // Duzenle(string sube_id, string yonetici_id, string token
           //, string adi, string soyadi, string kayit_tarihi, string dogum_tarihi,
           //     string email, string sifre, string adres, string tel, string foto_id,
           //     string menu_fiyat, string menu, string urun, string sepet, string fotograf,
           //     string galeri, string personel, string gider, string masa)


             var client = new RestClient("http://loc.deepram.com/api/Yonetici/Duzenle/??sube_id=" + comboBox1.Text
                + "&adi=" + txtadi.Text + "&soyadi=" + txtsoyadi.Text + "&kayit_tarihi=" + datekayıt.Value.ToString()
                + "&dogum_tarihi=" + datedogm.Value.ToString() + "&email=" + txtmail.Text + "&sifre=" + txtsifre.Text
                + "&adres=" + richadres.Text + "&tel=" + txttelefon.Text + "&foto_id=" + "1"
                + "&menu_fiyat=" + checkBox1.Checked.ToString() + "&sepet=" + checkBox2.Checked.ToString() + "&personel" + checkBox5.Checked.ToString()
                + "gider=" + checkBox6.Checked.ToString() + "&masa=" + checkBox4.Checked.ToString()
                + "&token=" + frmgiris.token);

            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            yöneticidüzenle = JsonConvert.DeserializeObject<YoneticiDuzenleResult>(response.Content);
            frmgiris.token = yöneticidüzenle.token;

            if (yöneticidüzenle.onay == true)
            {
                MessageBox.Show("DÜZENLEME BAŞARILI","BİLGİLENDİRME PENCERESİ");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kayit(string sube_id, string token, string adi,
            //    string soyadi, string kayit_tarihi, string dogum_tarihi,
            //    string email, string sifre, string adres, string tel, string foto_id, 
            //    string menu_fiyat, string menu, string urun, string sepet, string fotograf,
            //    string galeri, string personel, string gider, string masa)

            string[] idler;
            idler = comboBox1.SelectedItem.ToString().Split('|');
            frmgiris.subeid = idler[0];

            var client = new RestClient("http://loc.deepram.com/api/Yonetici/Kayit/?sube_id=" + idler[0]
                + "&adi=" + txtadi.Text + "&soyadi=" + txtsoyadi.Text + "&kayit_tarihi=" + datekayıt.Value.ToString()
                + "&dogum_tarihi=" + datedogm.Value.ToString() + "&email=" + txtmail.Text + "&sifre=" + txtsifre.Text
                + "&adres=" + richadres.Text + "&tel=" + txttelefon.Text + "&foto_id=" + "1"
                + "&menu_fiyat=" + checkBox1.Checked.ToString() + "&sepet=" + checkBox2.Checked.ToString() + "&personel" + checkBox5.Checked.ToString()
                + "gider=" + checkBox6.Checked.ToString() + "&masa=" + checkBox4.Checked.ToString() 
                + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            yöneticikayıt = JsonConvert.DeserializeObject<YoneticiKayitResult>(response.Content);
            frmgiris.token = yöneticikayıt.token;

            if (yöneticikayıt.onay == true)
            {
                MessageBox.Show("KAYIT İŞLEMİ BAŞARILI...","BİLGİLENDİRME PENCERESİ ...");
            }
            else
            {
                MessageBox.Show("başarısız", "BİLGİLENDİRME PENCERESİ ...");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form anasayfadön = new frmanasayfa();
            anasayfadön.Show();
        }
    }
}