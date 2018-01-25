using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;


namespace bitirme
{

    public class gelenkullanıcıgırıs
    {
        public string token { get; set; }
        public string onay { get; set; }
        public string menu { get; set; }
        public string menufiyat { get; set; }
        public string galeri { get; set; }
        public string foto { get; set; }
        public string gider { get; set; }
        public string sepet { get; set; }
        public string personel { get; set; }
        public string urun { get; set; }
    }



    public partial class frmgiris : DevExpress.XtraEditors.XtraForm
    {
        string token = "b4408520077e4471551340f7c7239d427806034ba57f8f8fcb588f6891745d49";
        string onay = "";
        public string email = "";
        public string sifre = "";
        public static string yetkimasa = "";



        public class tokenalma
        {
            public string id { get; set; }
            public string name { get; set; }
            public string token { get; set; }
            public string active { get; set; }
            public string date { get; set; }

        }


        tokenalma baslangıc;


        public gelenkullanıcıgırıs girisveri;

        public frmgiris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Tokens/Add?id=" + token + "&name=");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            baslangıc = JsonConvert.DeserializeObject<tokenalma>(response.Content);
            token = baslangıc.token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            sifre = textBox2.Text;

            var client = new RestClient("http://loc.deepram.com/api/SubeLoginRegister/Giris?email=" + email + "&sifre=" + sifre + "&token=" + baslangıc.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            girisveri = JsonConvert.DeserializeObject<gelenkullanıcıgırıs>(response.Content);
            token = girisveri.token;

            onay = girisveri.onay;
            yetkimasa = girisveri.menu;

            if (onay.Equals("true"))
            {



                this.Hide();
                Form anasayfa = new frmanasayfa();
                anasayfa.Show();
            }



        }
    }
}
