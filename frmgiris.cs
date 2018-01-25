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

   

    

    public partial class frmgiris : DevExpress.XtraEditors.XtraForm
    {
        public static string token = "b4408520077e4471551340f7c7239d427806034ba57f8f8fcb588f6891745d49";
        public static string oldtoken = "";
        public bool onay;
        public static string email = "";
        public static string sifre = "" ;
        public static bool yetkimasa;
        public static string subeid;
        public static string isletme_id;
        public static string yöneticiid;
    



        public class tokenalma
        {
            public string id { get; set; }
            public string name { get; set; }
            public string token { get; set; }
            public string active { get; set; }
            public string date { get; set; }
            

        }

    
        tokenalma baslangıc;
        public class SubeGirisYap
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string sube_id { get; set; }
            public bool menu { get; set; }
            public bool menufiyat { get; set; }
            public bool masa { get; set; }
            public bool galeri { get; set; }
            public bool foto { get; set; }
            public bool gider { get; set; }
            public bool sepet { get; set; }
            public bool personel { get; set; }
            public bool urun { get; set; }
            public string isletme_id { get; set; }
            public string yonetici_id { get; set; }
            public string galeri_id { get; set; }
        }
      


        public SubeGirisYap login;

        public frmgiris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            var client = new RestClient("http://loc.deepram.com/api/Tokens/Add?id="+token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            baslangıc = JsonConvert.DeserializeObject<tokenalma>(response.Content);
            token = baslangıc.token;
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            sifre = textBox2.Text;

            var client = new RestClient("http://loc.deepram.com/api/SubeLoginRegister/Giris?email="+email+"&sifre="+sifre+"&token="+baslangıc.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            login = JsonConvert.DeserializeObject<SubeGirisYap>(response.Content);  
            token = login.token;

            onay = login.onay;
            yetkimasa = login.menu;
            subeid = login.sube_id;
            isletme_id = login.isletme_id;
            yöneticiid = login.yonetici_id;
            
           
            if (login.onay == true)
            {
                if (login.isletme_id != null)
                {
                    this.Hide();
                    Form admingirs = new frmadmingiris();
                    admingirs.Show();
                }
                else
                {
                    this.Hide();
                    Form anasayfa = new frmanasayfa();
                    anasayfa.Show();
                }
               
            }
            else
            {
                MessageBox.Show("GEÇERSİZ KULLANICI GİRİŞİ....","BİLGİLENDİRME PENCERESİ....");
            }

         

        }
    }
}
