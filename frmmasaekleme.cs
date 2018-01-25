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
    public partial class frmmasaekleme : DevExpress.XtraEditors.XtraForm
    {


        public string masasayısı = "";
        public string alanadı = "";

        public class masaekle
        {
            public string token { get; set; }
            public string onay { get; set; }
           

        }


        masaekle eklemasa;


        public frmmasaekleme()
        {
            InitializeComponent();
        }

        private void frmmasaekleme_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = "I0VQZXQueJ0wé8g7ZZNOUgkVagIddZgffCnNda2RIY3t3Q2bsqVywXmnQA14PyREoUQ8VTe9i7G7n2dKosvyDsuIaé8dk8BVHyEiA5GZLWQzQqéYhqQiDeA6kHiVWBZl";
            masasayısı = textBox3.Text;
            alanadı = textBox4.Text;
            

            var client = new RestClient("http://loc.deepram.com/api/Masa/MasaOlustur/?sube_id=" + frmgiris.subeid + "&token=" + t1 + "&masa_sayisi=" + masasayısı + "&alan_adi=" + alanadı);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

             eklemasa = JsonConvert.DeserializeObject<masaekle>(response.Content);

            if (eklemasa.onay.Equals("true"))
            {
                MessageBox.Show("Kayıt işlemi başarılı", "Bilgilendirme");
            }
            else {
                MessageBox.Show("BAŞARISIZ EKLEME", "Bilgilendirme");
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