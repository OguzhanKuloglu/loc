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
    public partial class frmanasayfa : DevExpress.XtraEditors.XtraForm 
    {


        public class GunlukKazancResult
        {

            public string token { get; set; }
            public bool onay { get; set; }
            public double gunlukKazanc { get; set; }
        }
        GunlukKazancResult kazanc;

        public class SubeTakipciResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string toplamTakipciSayisi { get; set; }
        }

        SubeTakipciResult takip;

        public class SubeCheckinResult
        {
            public string token { get; set; }
            public bool onay { get; set; }
            public string toplamCheckinSayisi { get; set; }
        }

        SubeCheckinResult check;

        public frmanasayfa()
        {
            InitializeComponent();
        }

        private void frmanasayfa_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.Location = Screen.PrimaryScreen.Bounds.Location;

            if (frmgiris.yöneticiid == null)
            {
                button7.Visible = false;
                button10.Visible = true;
            }

            textBox2.Text = "5";

            var client = new RestClient("http://loc.deepram.com/api/SubeDashboard/Kazanc/?sube_id=" + frmgiris.subeid + "&token=" + frmgiris.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

           kazanc = JsonConvert.DeserializeObject<GunlukKazancResult>(response.Content);

            textBox1.Text = kazanc.gunlukKazanc.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {


            this.Hide();
            Form masaekle = new frmmasaekleme();
            masaekle.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            this.Hide();
            Form mekanalanları = new frmmekanalan();
            mekanalanları.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menuler = new frmmenu();
            menuler.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form personel = new frmpersonel();
            personel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form kampanya    = new frmkampanya();
            kampanya.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form subeayarları = new frmyöneticisayfa();
            subeayarları.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
         
        }

        private void frmanasayfa_KeyDown(object sender, KeyEventArgs e)
        {
          

                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = false;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form anasayfadön = new frmyönetici();
            anasayfadön.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
