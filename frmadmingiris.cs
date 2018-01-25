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
    public partial class frmadmingiris : DevExpress.XtraEditors.XtraForm
    {

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

        public frmadmingiris()
        {
            InitializeComponent();
        }

        private void frmadmingiris_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Sube/Listele/?isletme_id=" + frmgiris.isletme_id + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            listele = JsonConvert.DeserializeObject<SubeListeleResult>(response.Content);

            foreach (SubeBilgi _gelen in listele.subeBilgi)
            {
                comboBox1.Items.Add(String.Format("{0} | {1}", _gelen.sube_id ,_gelen.adi));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] idler;
            idler = comboBox1.SelectedItem.ToString().Split('|');
            frmgiris.subeid = idler[0];

            this.Hide();
            Form anasayfa = new frmanasayfa();
            anasayfa.Show();

        }
    }
}