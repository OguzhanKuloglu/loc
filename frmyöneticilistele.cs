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
using Newtonsoft.Json;
using RestSharp;

namespace bitirme
{
    public partial class frmyöneticilistele : DevExpress.XtraEditors.XtraForm
    {
        public static string dyöneticiid =null;
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

        public class YoneticiSilResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
        }
        YoneticiSilResult yöneticisil;

        public frmyöneticilistele()
        {
            InitializeComponent();
        }

        private void frmyöneticilistele_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Yonetici/Listele/?isletme_id=" + frmgiris.isletme_id + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            yöneticilistele = JsonConvert.DeserializeObject<YoneticiListeleResult>(response.Content);
            frmgiris.token = yöneticilistele.token;

            foreach (YoneticiBilgi _gelen in yöneticilistele.yoneticiBilgi)
            {
                string[] veriler = { _gelen.adi,_gelen.soyadi, _gelen.dogum_tarihi ,_gelen.kayit_tarihi ,_gelen.email,_gelen.sifre ,_gelen.tel,_gelen.adres ,_gelen.yonetici_id};
                listView1.Items.Add(new ListViewItem(veriler));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Yonetici/Sil/?yonetici_id=" + listView1.SelectedItems[0].SubItems[9].Text + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            
            yöneticisil= JsonConvert.DeserializeObject<YoneticiSilResult>(response.Content);

            frmgiris.token = yöneticisil.token;
            if (yöneticisil.onay == true)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                MessageBox.Show(" SİLME İŞLEMİ BAŞARILI.... ", "BİLGİLENDİRME PENCERESİ ");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dyöneticiid = listView1.SelectedItems[0].SubItems[8].Text;
            this.Hide();
            Form yöneticidüzenle = new frmyönetici();
            yöneticidüzenle.Show();

        }


        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form yöneticidüzenle = new frmyönetici();
            yöneticidüzenle.Show();
        }
    }
}