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
    public partial class frmmenu : DevExpress.XtraEditors.XtraForm
    {

        public static string düzenlenen = "";
        public static string did = "";

        public class MenuKategoriListele
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string kategoriSayisi { get; set; }
            public List<KategoriListesi> kategoriListe { get; set; }

        }

        public class KategoriListesi
        {
            public string adi { get; set; }
            public string kategori_id { get; set; }

        }
        
        MenuKategoriListele gelen;

        public class MenuKategoriEkle
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string kategori_id { get; set; }
        }
        MenuKategoriEkle ekle;

        public class MenuKategoriSil
        {
            public string token { get; set; }
            public bool onay { get; set; }
        }

        MenuKategoriSil sil;

        public class MenuKategoriDuzenle
        {
            public string token { get; set; }
            public bool onay { get; set; }
        }

        MenuKategoriDuzenle düzenle; 

        public frmmenu()
        {
            InitializeComponent();
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            var client = new RestClient("http://loc.deepram.com/api/Menu/KategoriListele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            gelen = JsonConvert.DeserializeObject<MenuKategoriListele>(response.Content);

    

            foreach (KategoriListesi _gelen in gelen.kategoriListe)
            {
                string[] veriler = { _gelen.adi, _gelen.kategori_id };
                listView.Items.Add(new ListViewItem(veriler));
                
            }



        }



        void b_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var client = new RestClient("http://loc.deepram.com/api/Menu/KategoriEkle/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken + "&adi=" + textBox1.Text + "&foto_id=" + 1);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            ekle = JsonConvert.DeserializeObject<MenuKategoriEkle>(response.Content);

            
            if(ekle.onay == true)
            {
                listView.Items.Add(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Başarısız ", "Bilgilendirme Ekranı");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string kid;
            düzenlenen = listView.SelectedItems[0].Text;
            kid = gelen.kategoriListe.FirstOrDefault(x => x.adi.Equals(düzenlenen)).kategori_id.ToString();
            var client = new RestClient("http://loc.deepram.com/api/Menu/KategoriSil/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.oldtoken + "&kategori_id=" + kid);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            
            IRestResponse response = client.Execute(request);

            sil = JsonConvert.DeserializeObject<MenuKategoriSil>(response.Content);

            if (sil.onay == true)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Başarısız ", "Bilgilendirme Ekranı");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            düzenlenen = listView.SelectedItems[0].Text;
            string kid;
            kid = gelen.kategoriListe.FirstOrDefault(x => x.adi.Equals(düzenlenen)).kategori_id.ToString();
            var client = new RestClient("http://loc.deepram.com/api/Menu/KategoriDuzenle/?sube_id=" + frmgiris.subeid + "&token=" + "9OLMQiR7ITInUVZMpql0Go0Pk1MyQFFUAPlOJdVé4hy0EfrueHrOfn2UZ6mZWdrCNznFvLDLVm6j1éKFKcUJZ20YXQzN27nb1vnQ3léSDf44rTeZvhO5IioW9PseW0UZ" + "&foto_id=" + 1 +"&adi=" + düzenlenen + "&kategori_id=" + kid );
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            düzenle = JsonConvert.DeserializeObject<MenuKategoriDuzenle>(response.Content);
            did = kid;

            if (düzenle.onay == true)
            {
                this.Hide();
                Form menuduzenle = new frmmenudüzenle();
                menuduzenle.Show();
            }
            else
            {
                MessageBox.Show("Başarısız ", "Bilgilendirme Ekranı");
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