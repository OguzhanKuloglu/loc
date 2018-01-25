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
    public partial class frmpersonel : DevExpress.XtraEditors.XtraForm
    {
        public static string personelid;

        public class PersonelListele
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public List<PersonelBilgi> personelListe { get; set; }
        }

        public class PersonelBilgi
        {
            public string id { get; set; }
            public string adi { get; set; }
            public string soyadi { get; set; }
            public string dogumTarihi { get; set; }
            public string adres { get; set; }
            public string tel { get; set; }
            public string foto_id { get; set; }
            public string sube_id { get; set; }
            public string girisTarihi { get; set; }
            public string cikisTarihi { get; set; }
            public string gorev { get; set; }
            public string maas { get; set; }
            public string email { get; set; }
            public string sifre { get; set; }

        }

        PersonelListele listele;
      

        public class PersonelKayit
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string id { get; set; }


        }

        PersonelKayit kayıt;

        public class PersonelSil
        {
            public string token { get; set; }
            public bool onay { get; set; }

        }

        PersonelSil sil;

        public class PersonelDuzenle
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string id { get; set; }

        }
        PersonelDuzenle duzenle;


        public frmpersonel()
        {
            InitializeComponent();
        }

        public PersonelListele f1() {

            var client = new RestClient("http://loc.deepram.com/api/Personel/Listele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<PersonelListele>(response.Content);
        }
        

        private void frmpersonel_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            var client = new RestClient("http://loc.deepram.com/api/Personel/Listele/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            listele =  JsonConvert.DeserializeObject<PersonelListele>(response.Content);


            foreach (PersonelBilgi _gelen in listele.personelListe)
            {
                string[] veriler = { _gelen.adi, _gelen.soyadi, _gelen.dogumTarihi.ToString() , _gelen.tel, _gelen.sube_id,_gelen.gorev,_gelen.maas ,_gelen.girisTarihi.ToString() ,_gelen.cikisTarihi.ToString(),_gelen.email,_gelen.adres,_gelen.id,_gelen.sifre};
                list1.Items.Add(new ListViewItem(veriler));
            }



        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //Kayit(string token, string adi, string soyadi, DateTime dogumTarihi, string adres, string tel, string foto_id, string sube_id, string gorev, string maas, DateTime girisTarihi, DateTime cikisTarihi, string email, string sifre)
            var client = new RestClient("http://loc.deepram.com/api/Personel/Kayit?adi=" + textadi.Text + "&soyadi=" + textsoyadi.Text + "&dogumTarihi=" +  dateTimePicker1.Value.ToString() + "&adres=" + richadres.Text + "&tel=" + texttelefon.Text + "&sube_id=" + frmgiris.subeid + "&gorev=" + textgorev.Text + "&girisTarihi=" + dateTimePicker2.Value.ToString()+ "&cikisTarihi=" +  dateTimePicker3.Value.ToString() + "&foto_id=" + "1" + "&maas=" + textmaas.Text + "&email=" + textmail.Text + "&sifre=" + textsifre.Text + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            kayıt = JsonConvert.DeserializeObject<PersonelKayit>(response.Content);

            if (kayıt.onay == true)
            {

                MessageBox.Show("Kayıt Başarıyla Eklendi...", "Bilgilendirme penceresi");
                list1.Items.Clear();
                foreach (PersonelBilgi _gelen in f1().personelListe)
                {
                    string[] veriler = { _gelen.adi, _gelen.soyadi, _gelen.dogumTarihi.ToString(), _gelen.tel, _gelen.sube_id, _gelen.gorev, _gelen.maas, _gelen.girisTarihi.ToString(), _gelen.cikisTarihi.ToString(), _gelen.email, _gelen.adres, _gelen.id, _gelen.sifre };
                    list1.Items.Add(new ListViewItem(veriler));
                }
            }
       }

        private void btndüzenle_Click(object sender, EventArgs e)
        {
            
            personelid = list1.SelectedItems[0].SubItems[11].Text;
            textadi.Text = list1.SelectedItems[0].SubItems[0].Text;
            textsoyadi.Text = list1.SelectedItems[0].SubItems[1].Text;
            dateTimePicker1.Text = list1.SelectedItems[0].SubItems[2].Text;
            texttelefon.Text = list1.SelectedItems[0].SubItems[3].Text;
            textgorev.Text = list1.SelectedItems[0].SubItems[5].Text;
            textmaas.Text = list1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = list1.SelectedItems[0].SubItems[7].Text;
            dateTimePicker3.Text = list1.SelectedItems[0].SubItems[8].Text;
            textmail.Text = list1.SelectedItems[0].SubItems[9].Text;
            textsifre.Text = list1.SelectedItems[0].SubItems[12].Text;
            richadres.Text = list1.SelectedItems[0].SubItems[10].Text;
            btnkaydet.Visible = false;
            btndegis.Visible = true;
        }

        private void btndegis_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://loc.deepram.com/api/Personel/Duzenle/?adi=" + textadi.Text + "&soyadi=" + textsoyadi.Text + "&dogumTarihi=" + dateTimePicker1.Text + "&adres=" + richadres.Text + "&tel=" + texttelefon.Text + "&sube_id=" + frmgiris.subeid + "&gorev=" + textgorev.Text + "&girisTarihi=" + dateTimePicker2.Text + "&cikisTarihi=" + dateTimePicker3.Text + "&foto_id=" + "1" + "&maas=" + textmaas.Text + "&email=" + textmail.Text + "&sifre=" + textsifre.Text + "&personel_id=" + personelid  + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            duzenle = JsonConvert.DeserializeObject<PersonelDuzenle>(response.Content);

            if (duzenle.onay == true)
            {
                MessageBox.Show("Kayıt Başarıyla Düzenlendi...", "Bilgilendirme penceresi");
                btnkaydet.Visible = true;
                btndegis.Visible = false;

                list1.Items.Clear();
               

                foreach (PersonelBilgi _veri in f1().personelListe)
                {
                    string[] veriler = { _veri.adi, _veri.soyadi, _veri.dogumTarihi.ToString(), _veri.tel, _veri.sube_id, _veri.gorev, _veri.maas, _veri.girisTarihi.ToString(), _veri.cikisTarihi.ToString(), _veri.email, _veri.adres, _veri.id, _veri.sifre };
                    list1.Items.Add(new ListViewItem(veriler));
                }
            }
        }

        private void btnkytsil_Click(object sender, EventArgs e)
        {
            personelid = list1.SelectedItems[0].SubItems[11].Text;
            var client = new RestClient("http://loc.deepram.com/api/Personel/Sil/?personel_id=" + personelid + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            sil = JsonConvert.DeserializeObject<PersonelSil>(response.Content);

            if (sil.onay == true)
            {
                list1.Items.Remove(list1.SelectedItems[0]);
                MessageBox.Show("KAYIT BAŞARIYLA SİLİNDİ...", "Bilgilendirme penceresi");
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
