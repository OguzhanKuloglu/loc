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
    public partial class frmonsiparisekle : DevExpress.XtraEditors.XtraForm
    {
        public class alangörüntele
        {

            public string alan_adi { get; set; }
            public string alan_id { get; set; }
        }

        public class alan
        {
            public string token { get; set; }
            public string onay { get; set; }
            public List<alangörüntele> AlanListe { get; set; }

        }

        alan gelen;

        public class MasaGoruntule
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string masa_sayisi { get; set; }
            public List<MasaOnizleme> Onizleme { get; set; }


        }

    

        public class MasaOnizleme
        {
            public string masa_id { get; set; }
            public double adisyon_tutar { get; set; }
            public DateTime date { get; set; }
            public string doluluk { get; set; }
            public string beacon_id { get; set; }


        }

        MasaGoruntule masagörüntülegelen;

        public class AdisyonMasaTasi
        {
            public string token { get; set; }
            public bool onay { get; set; }

        }
        AdisyonMasaTasi ekleme;

        public frmonsiparisekle()
        {
            InitializeComponent();
        }

        private void frmonsiparisekle_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Masa/Alanlar/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            gelen = JsonConvert.DeserializeObject<alan>(response.Content);

            foreach (alangörüntele _alan in gelen.AlanListe)
            {
                comboBox1.Items.Add(String.Format("{0} | {1}", _alan.alan_id,_alan.alan_adi));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int masanumara=1;
            string[] alanid;
            string galanid;
            alanid = comboBox1.SelectedItem.ToString().Split('|');
            galanid= alanid[0];

            var client = new RestClient("http://loc.deepram.com/api/Masa/Goruntule/?sube_id=" + frmgiris.subeid + "&alan_id=" + galanid  + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            masagörüntülegelen = JsonConvert.DeserializeObject<MasaGoruntule>(response.Content);

            foreach (MasaOnizleme _gelen in masagörüntülegelen.Onizleme)
            {
                if (_gelen.doluluk == "0")
                {
                    string[] veriler = { masanumara.ToString(), _gelen.masa_id};
                    listView1.Items.Add(new ListViewItem(veriler));
                }
               
                masanumara++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string secmasaid;
            secmasaid = listView1.SelectedItems[0].SubItems[1].Text;
            var client = new RestClient("http://loc.deepram.com/api/Adisyon/Onayla/?adisyon_id=" + frmmekanalan.önadisyonid + "&sube_id=" + frmgiris.subeid + "&masa_id=" + secmasaid + "&token=" + frmgiris.oldtoken + "&kullanici_id=" + frmmekanalan.adikullanıcıid);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            ekleme = JsonConvert.DeserializeObject<AdisyonMasaTasi>(response.Content);

            if (ekleme.onay == true)
            {
                MessageBox.Show("MASAYA TAŞIMA İŞLEMİ BAŞARILIDIR...","BİLGİLENDİRME PENCERESİ...");
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