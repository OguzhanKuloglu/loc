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
using System.Threading;

namespace bitirme
{
    public partial class frmmekanalan : DevExpress.XtraEditors.XtraForm
    {

        public List<alangörüntele> masaidler= new List<alangörüntele>();
        public int masasayısı;
        public static string tutar = "";
        public static string masagönderid = "";
        public static string adisyonmasaid = "";
        public static string önadisyonid = "";
        public static string adikullanıcıid = "";
        public static string alanid;

        public List<MasaOnizleme> masabilgileri = new List<MasaOnizleme>();

        

        public class MasaAc
        {

            public string token { get; set; }
            public bool onay { get; set; }
            public string adisyon_id { get; set; }

        }

        public class MasaGoruntule
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string masa_sayisi { get; set; }
            public List<MasaOnizleme> Onizleme { get; set; }


        }

        MasaGoruntule masagörüntülegelen;

        public class MasaOnizleme
        {
            public string masa_id { get; set; }
            public double adisyon_tutar { get; set; }
            public DateTime date { get; set; }
            public string doluluk { get; set; }
            public string beacon_id { get; set; }


        }
         

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

        public class MasaAcResult
        {

            public string token { get; set; }
            public bool onay { get; set; }
            public string adisyon_id { get; set; }

        }
        MasaAcResult masaacma;

        public class AdisyonOnSiparisListele
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public List<OnSiparis> siparisler { get; set; }
            public List<kullanıcıSiparis> kSiparis { get; set; }

        }

        public class OnSiparis
        {
            public string adisyon_id { get; set; }
            public string kullanici_id { get; set; }
            public string adi { get; set; }
            public DateTime date { get; set; }


        }
        AdisyonOnSiparisListele önsiparis;

        public class kullanıcıSiparis
        {
            public string masa_id { get; set; }
            public string alan_adi { get; set; }
            public string kullanici_adi { get; set; }
        }
      


        public frmmekanalan()
        {
            InitializeComponent();
        }

       

        private void frmmekanalan_Load(object sender, EventArgs e)
        {
            
            
            
           
            this.WindowState = FormWindowState.Maximized;
            buttonadekle.Dock = DockStyle.Bottom;

            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Right;
            listönsiparis.Dock = DockStyle.Fill;

            listbekleyen.Visible = false;

            timer1.Enabled = true;
            timer1.Interval = 30000;
           

            var client = new RestClient("http://loc.deepram.com/api/Masa/Alanlar/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            gelen = JsonConvert.DeserializeObject<alan>(response.Content);

            foreach (alangörüntele _alan in gelen.AlanListe)
            {
                menuStrip1.Items.Add(_alan.alan_adi).Name = _alan.alan_id;
                
                
                masaidler.Add(new alangörüntele { alan_adi= _alan.alan_adi, alan_id = _alan.alan_id });
            }


            var client1 = new RestClient("http://loc.deepram.com/api/Adisyon/OnSiparisListele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken + "&kullanici_id=");
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("cache-control", "no-cache");

            IRestResponse response1 = client1.Execute(request1);

            önsiparis = JsonConvert.DeserializeObject<AdisyonOnSiparisListele>(response1.Content);
            
            foreach (OnSiparis _gelen in önsiparis.siparisler)
            {
                string[] veriler = { _gelen.adisyon_id ,Convert.ToString( _gelen.date), _gelen.kullanici_id , _gelen.adi };
                listönsiparis.Items.Add(new ListViewItem(veriler));


            }

            


        }   



        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            panel1.Controls.Clear();

            var client = new RestClient("http://loc.deepram.com/api/Masa/Goruntule/?sube_id=" + frmgiris.subeid + "&alan_id=" + e.ClickedItem.Name  + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            alanid = e.ClickedItem.Name;

            masagörüntülegelen = JsonConvert.DeserializeObject<MasaGoruntule>(response.Content);

            masasayısı = Int32.Parse(masagörüntülegelen.masa_sayisi);

          

            
         
            
            int dongu2 = (masasayısı / 7)+1;
            int j = 0;
            int i = 0;
                for (int k = 0; k < masasayısı; k++)
                {
                
                
                if (j>=6)
                {
                    i++;
                    j = 0;
                }
                    
                
                    Button btn = new Button();// Button nesnesi oluşturuldu 
                    
                    btn.Name = masagörüntülegelen.Onizleme[k].masa_id;
                    DateTime baslangıc = masagörüntülegelen.Onizleme[k].date;
                    DateTime now = Convert.ToDateTime(DateTime.Now);
                    TimeSpan masasüre = now - baslangıc;
                    btn.Text = "Masa Numara :" + masagörüntülegelen.Onizleme[k].masa_id + "\n" + " Masa süresi :" + masasüre;// butonun üzernde yazacaklar belirlendi.
                    btn.Size = new Size(150, 150); // butonun en ve boy değerleri verildi.
                    //btn.BackgroundImage = Image.FromFile(@"");
                    //button1.BackgroundImage = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
                if (masagörüntülegelen.Onizleme[k].beacon_id != "")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else if (masagörüntülegelen.Onizleme.FirstOrDefault(x => x.masa_id.Equals(btn.Name)).doluluk.ToString() == "0")
                    {
                        btn.BackColor = Color.Aqua;
                        
                    }
                    else
                    {
                         btn.BackColor = Color.Red;
                    }
                    btn.Location = new Point(170 * j, 170 * i); // butonun bulunacağı kordinatlar verildi.
                    
                    panel1.Controls.Add(btn); // bu button nesnesi panel ismindeki panel nesnesinin içine eklendi.                      
                    j++;
                    btn.Click += new EventHandler(dinamikMetod);

            }

          
            

    }
        

     



        public void dinamikMetod(object sender, EventArgs e)
        {
            
            Button dinamikButon = (sender as Button);
           

            tutar = masagörüntülegelen.Onizleme.FirstOrDefault(x => x.masa_id.Equals(dinamikButon.Name)).adisyon_tutar.ToString();
            

            masagönderid = dinamikButon.Name;

            if (dinamikButon.BackColor != Color.Red)
            {
                var client = new RestClient("http://loc.deepram.com/api/SubeMasa/MasaAc/?masa_id=" + frmmekanalan.masagönderid + "&token=" + frmgiris.token + "&date=" + DateTime.Now.ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                IRestResponse response = client.Execute(request);

                masaacma = JsonConvert.DeserializeObject<MasaAcResult>(response.Content);
            }
            


            if (masagörüntülegelen.Onizleme.FirstOrDefault(x => x.masa_id.Equals(masagönderid)).doluluk.ToString() == "0")
            {
                if (masaacma.onay.ToString() == "True")
                {
                
                    MessageBox.Show("Adisyon Açma işlemi başarılı", "Bilgilendirme");
                    dinamikButon.BackColor = Color.Red;
                    panel1.Controls.Clear();

                    var client = new RestClient("http://loc.deepram.com/api/Masa/Goruntule/?sube_id=" + frmgiris.subeid + "&alan_id=" + alanid + "&token=" + frmgiris.oldtoken);
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    IRestResponse response = client.Execute(request);

                    masagörüntülegelen = JsonConvert.DeserializeObject<MasaGoruntule>(response.Content);

                    masasayısı = Int32.Parse(masagörüntülegelen.masa_sayisi);

                    //foreach (MasaOnizleme _masa in masagörüntülegelen.Onizleme)
                    //{
                    //    masabilgileri.Add(new MasaOnizleme { masa_id = _masa.masa_id, adisyon_tutar = _masa.adisyon_tutar, beacon_id = _masa.beacon_id, date = _masa.date, doluluk = _masa.doluluk });
                    //}




                    int dongu2 = (masasayısı / 7) + 1;
                    int j = 0;
                    int i = 0;
                    for (int k = 0; k < masasayısı; k++)
                    {


                        if (j >= 6)
                        {
                            i++;
                            j = 0;
                        }


                        Button btn = new Button();// Button nesnesi oluşturuldu 

                        btn.Name = masagörüntülegelen.Onizleme[k].masa_id;
                        DateTime baslangıc = masagörüntülegelen.Onizleme[k].date;
                        DateTime now = Convert.ToDateTime(DateTime.Now);
                        TimeSpan masasüre = now - baslangıc;


                        btn.Text = "Masa Numara :" + masagörüntülegelen.Onizleme[k].masa_id + "\n" + " Masa süresi :" + masasüre.Minutes.ToString(); ;// butonun üzernde yazacaklar belirlendi.
                        btn.Size = new Size(150, 150); 

                        if (masagörüntülegelen.Onizleme[k].beacon_id != "")
                        {
                            btn.BackColor = Color.Green;
                        }
                        else if (masagörüntülegelen.Onizleme.FirstOrDefault(x => x.masa_id.Equals(btn.Name)).doluluk.ToString() == "0")
                        {
                            btn.BackColor = Color.Aqua;

                        }
                        else
                        {
                            btn.BackColor = Color.Red;
                        }
                        btn.Location = new Point(170 * j, 170 * i); // butonun bulunacağı kordinatlar verildi.

                        panel1.Controls.Add(btn); // bu button nesnesi panel ismindeki panel nesnesinin içine eklendi.                      
                        j++;
                        btn.Click += new EventHandler(dinamikMetod);

                    }
                }
            }
            else
            {
                
                Form adisyongoster = new frmadisyon();
                adisyongoster.Show();
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form anasayfadön = new frmanasayfa();
            anasayfadön.Show();
        }

        private void buttonadekle_Click(object sender, EventArgs e)
        {
            adikullanıcıid = listönsiparis.SelectedItems[0].SubItems[2].Text;
            önadisyonid = listönsiparis.SelectedItems[0].Text;
            Form önadisyonekleme = new frmonsiparisekle();
            önadisyonekleme.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form anasayfadön = new frmanasayfa();
            anasayfadön.Show();
        }

        private void listönsiparis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private  void timer1_Tick(object sender, EventArgs e)
        {
            var client1 = new RestClient("http://loc.deepram.com/api/Adisyon/OnSiparisListele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken+ "&kullanici_id=");
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("cache-control", "no-cache");

            IRestResponse response1 = client1.Execute(request1);

            önsiparis = JsonConvert.DeserializeObject<AdisyonOnSiparisListele>(response1.Content);
            if (önsiparis.onay == true)
            {
                foreach (kullanıcıSiparis _gelen in önsiparis.kSiparis)
                {

                    string[] veriler = { _gelen.alan_adi, _gelen.masa_id, _gelen.kullanici_adi };
                    listbekleyen.Items.Add(new ListViewItem(veriler));
                }        
            }
            int a;
            a = listbekleyen.Items.Count;
            if (a > 0)
            {
                MessageBox.Show("MASA NUMARISI : "+listbekleyen.Items[0].SubItems[1].Text, "Yeni Bir Sipariş İsteği Alındı");
                timer1.Enabled = false;
            }


            

        }
    }
}


