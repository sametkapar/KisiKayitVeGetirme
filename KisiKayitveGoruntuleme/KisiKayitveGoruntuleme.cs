using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KisiKayitveGoruntuleme
{
    public partial class KisiKayitveGoruntuleme : Form
    {
        Kisi k = new Kisi();

        public KisiKayitveGoruntuleme()
        {
            InitializeComponent();
            rb_erkek.Checked = true;
            rb_evli.Checked = true;
            string yol = "C://Kişiler";
            DirectoryInfo di = new DirectoryInfo(yol);
            di.Create();

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {

            k.isim = tb_isim.Text;
            k.soyisim = tb_soyisim.Text;
            k.kimlikNo = tb_kimlikNo.Text;
            k.dogumTarihi = Convert.ToDateTime(dtp_dogumTarihi.Text);
            k.telefonNo = mtb_telefon.Text;
            k.cinsiyet = "Erkek";
            if (!rb_erkek.Checked) { k.cinsiyet = "Kadın"; }
            k.medeniHal = "Evli";
            if (rb_evli.Checked) { k.medeniHal = "Bekar"; }
            k.adres = tb_adres.Text;


            string yoltxt = "C://Kişiler//" + k.kimlikNo + ".txt";
            FileInfo fi = new FileInfo(yoltxt);

            

            StreamWriter sw = new StreamWriter(yoltxt);
            string metin = $"İSİM: {k.isim}\nSOYİSİM: {k.soyisim}\nKİMLİK NO: {k.kimlikNo}\nDOĞUM TARİHİ: {k.dogumTarihi}\nTELEFON NO: {k.telefonNo}\nCİNSİYET: {k.cinsiyet}\nMEDENİ DURUM: {k.medeniHal}\nADRES: {k.adres}";
            sw.WriteLine(metin);
            sw.Close();

        }
    }
}
