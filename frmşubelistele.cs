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
    public partial class frmşubelistele : DevExpress.XtraEditors.XtraForm
    {

        public static string düzenlenensubeid;
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

        public class SubeSilResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
        }

        SubeSilResult sil;
        public frmşubelistele()
        {
            InitializeComponent();
        }

        private void frmşubelistele_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Sube/Listele/?isletme_id=" + frmgiris.isletme_id + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            listele = JsonConvert.DeserializeObject<SubeListeleResult>(response.Content);

            frmgiris.token = listele.token;

            foreach (SubeBilgi _gelen in listele.subeBilgi)
            {
                
                    string[] veriler = { _gelen.adi,_gelen.adres, _gelen.tel,_gelen.lat ,_gelen.sube_id  };
                    listView1.Items.Add(new ListViewItem(veriler));              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Sube/Listele/?sube_id_id=" + listView1.SelectedItems[0].SubItems[4].Text + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            sil = JsonConvert.DeserializeObject<SubeSilResult>(response.Content);

            frmgiris.token = sil.token;

            if (sil.onay == true)
            {

                listView1.Items.Remove(listView1.SelectedItems[0]);
                MessageBox.Show("SİLME İŞLEMİ BAŞARILI.... ","BİLGİLENDİRME PENCERESİ ");

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            düzenlenensubeid = listView1.SelectedItems[0].SubItems[4].Text;
            this.Hide();
            Form subeler = new frmyöneticisayfa();
            subeler.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form anasayfadön = new frmyöneticisayfa();
            anasayfadön.Show();
        }
    }
}
