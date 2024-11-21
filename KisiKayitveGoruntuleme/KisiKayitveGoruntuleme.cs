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
            string kisiyol = "C://Kişiler";
            DirectoryInfo di2 = new DirectoryInfo(kisiyol);
            List<string> kisiliste = new List<string>();
            FileInfo[] dosyalar = di2.GetFiles();
            foreach (FileInfo item in dosyalar)
            {
                kisiliste.Add(item.Name);
            }
            foreach (string item in kisiliste)
            {
                lb_kisiler.Items.Add(item.Remove(item.Length - 4, 4));
            }
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

            if (tb_isim.Text != "")
            {
                string yoltxt = "C://Kişiler//" + k.kimlikNo + ".txt";
                FileInfo fi = new FileInfo(yoltxt);

                StreamWriter sw = new StreamWriter(yoltxt);
                string metin = $"İSİM: {k.isim}\nSOYİSİM: {k.soyisim}\nKİMLİK NO: {k.kimlikNo}\nDOĞUM TARİHİ: {k.dogumTarihi.ToShortDateString()}\nTELEFON NO: {k.telefonNo}\nCİNSİYET: {k.cinsiyet}\nMEDENİ DURUM: {k.medeniHal}\nADRES: {k.adres}";
                sw.WriteLine(metin);
                sw.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Tüm alanları doldurunuz", "HATA");
            }
        }
        private void lb_kisiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yol = "C://Kişiler";
            DirectoryInfo di = new DirectoryInfo(yol);
            List<string> kisiliste = new List<string>();
            FileInfo[] dosyalar = di.GetFiles();
            foreach (FileInfo fi in dosyalar)
            {
                kisiliste.Add(fi.Name);
            }
            string kisiyol = "C://Kişiler//" + kisiliste[lb_kisiler.SelectedIndex];
            StreamReader sr = new StreamReader(kisiyol);
            lbl_kisibilgiekran.Text = sr.ReadToEnd();
        }
        private void btn_kisiBilgiGetir_Click(object sender, EventArgs e)
        {
            string kisiyol = "C://Kişiler";
            DirectoryInfo di2 = new DirectoryInfo(kisiyol);
            List<string> kisiliste = new List<string>();
            FileInfo[] dosyalar = di2.GetFiles();
            lb_kisiler.Items.Clear();
            foreach (FileInfo item in dosyalar)
            {
                kisiliste.Add(item.Name);
            }
            foreach (string item in kisiliste)
            {
                lb_kisiler.Items.Add(item.Remove(item.Length - 4, 4));
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string kisiyol = "C://Kişiler//" + lb_kisiler.SelectedItem.ToString() + ".txt";
            FileInfo fi2 = new FileInfo(kisiyol);
            fi2.Delete();
        }
    }
}
