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
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace bitirme
{
    public partial class frmyöneticisayfa : DevExpress.XtraEditors.XtraForm
    {
        string APIKEY = "AIzaSyCoYWNsjcH444MS9K50jUwgBUGXO1p_ZsA";

       

        public class SubeEkleResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string sube_id { get; set; }
        }

        SubeEkleResult subeekle;

        public class SubeSilResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
        }

        SubeSilResult subesil;

        public class SubeDuzenleResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string sube_id { get; set; }
        }

        SubeDuzenleResult subedüzenle;
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



        public frmyöneticisayfa()
        {
            InitializeComponent();
        }

        private void frmyöneticisayfa_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            button5.Visible = false;
            //Duzenle(string yonetici_id, string sube_id, string adi, 
            //    string adres, double lat, double lng, string tel, 
            //    string foto_id, string galeri_id, string isletme_id)
            if (frmşubelistele.düzenlenensubeid != null)
            {
                button1.Visible = false;
                button5.Visible = true;
                var client1 = new RestClient("http://loc.deepram.com/api/Sube/Listele/?isletme_id=" + frmgiris.isletme_id + "&token=" + frmgiris.token);
                var request1 = new RestRequest(Method.POST);
                request1.AddHeader("cache-control", "no-cache");
                IRestResponse response1 = client1.Execute(request1);

                listele = JsonConvert.DeserializeObject<SubeListeleResult>(response1.Content);

                frmgiris.token = listele.token;

                foreach (SubeBilgi _gelen in listele.subeBilgi)
                {

                    if (frmşubelistele.düzenlenensubeid == _gelen.sube_id)
                    {
                        textadi.Text = _gelen.adi;
                        texttelno.Text = _gelen.tel;
                        richadres.Text = _gelen.adres;
                        txtx.Text = _gelen.lat;
                        txty.Text = _gelen.lng;
                    }


                   
                    
                }
            }

            var client = new RestClient("http://loc.deepram.com/api/Yonetici/Listele/?isletme_id=" + frmgiris.isletme_id + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            yöneticilistele  = JsonConvert.DeserializeObject<YoneticiListeleResult>(response.Content);

            foreach (YoneticiBilgi _gelen in yöneticilistele.yoneticiBilgi)
            {
                comboBox1.Items.Add(String.Format("{0} | {1} {2}", _gelen.yonetici_id , _gelen.adi ,_gelen.soyadi));
            }


        }

       

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ublic SubeEkleResult Ekle(string adi, string adres, double lat, double lng, string tel, string foto_id, string galeri_id, string isletme_id, string yonetici_id)
            var client = new RestClient("http://loc.deepram.com/apiSube/Ekle/?adi=" + textadi.Text + "&adres=" + richadres.Text + "&tel=" + texttelno.Text + "&lat=" +Convert.ToDouble( txtx.Text)+ "&lng=" + Convert.ToDouble(txty.Text) + "&foto_id=" + frmgiris.subeid + "&yonetici_id=" + frmgiris.yöneticiid  + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            subeekle = JsonConvert.DeserializeObject<SubeEkleResult>(response.Content);
            frmgiris.token = subeekle.token;

            if (subeekle.onay == true)
            {
                MessageBox.Show("KAYIT İŞLEMİ BAŞARILI" , " BİLGİLENDİRME PENCERSİ ");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog f1 = new OpenFileDialog();
            f1.Title = "Resim Seçiniz...";
            f1.Filter = "(*.jpg)|*.jpg|(*.png)|*.png ";

            if (f1.ShowDialog() == DialogResult.OK)
            {
                 
                    //this.pictureBox1.Image = new Bitmap(f1.OpenFile());
   
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form subeler = new frmşubelistele();
            subeler.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Duzenle(string yonetici_id, string sube_id, string adi, 
            //    string adres, double lat, double lng, string tel, 
            //    string foto_id, string galeri_id, string isletme_id)

            var client = new RestClient("http://loc.deepram.com/apiSube/Ekle/?adi=" + textadi.Text + "&isletme_id=" + frmgiris.isletme_id  + "&adres=" + richadres.Text + "&tel=" + texttelno.Text + "&lat=" + Convert.ToDouble(txtx.Text) + "&lng=" + Convert.ToDouble(txty.Text) + "&foto_id=" + frmgiris.subeid + "&yonetici_id=" + frmgiris.yöneticiid + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            subeekle = JsonConvert.DeserializeObject<SubeEkleResult>(response.Content);
            frmgiris.token = subeekle.token;

            if (subeekle.onay == true)
            {
                MessageBox.Show("KAYIT İŞLEMİ BAŞARILI", " BİLGİLENDİRME PENCERSİ ");
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