using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityEducation
{
    public partial class bbtn : Form
    {
        OgrencilerContext context;
        Ogrenciler ogrenci;
        public bbtn()
        {
            InitializeComponent();
            context = new OgrencilerContext();
            ogrenci = new Ogrenciler();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ogrenci bilgilerini textboxlardan aldım
            ogrenci.Ad = txtBoxAd.Text;
            ogrenci.Soyad = txtBoxSoyad.Text;
            ogrenci.OgrenciNo = txtBoxOkulNo.Text;

            //eğer butonun üzerinde yazan yazı kaydet ise yeni öğrenci ekleme işlemi yaptım
            if (btnKaydet.Text == "Kaydet")
                context.tablo.Add(ogrenci);
            else
            {
                //değil ise güncellenecek öğrenci objesini context'e değiştirildiğini bildirim
                context.Entry(ogrenci).State = EntityState.Modified;

            }


            try
            {
                //bu fantastik bi işlem :D 
                var id = ogrenci.Id;
                //değişiklik yapıldıysa otomatik olarak kendişi güncelledi, ekleme yapıldıysa kaydetti
                context.SaveChanges();
                //gene fantastik ^_^
                if (id == 0)
                    MessageBox.Show("Eklendi");
                else
                    MessageBox.Show("Güncellendi");

                //aşırı fantastik :D 
                btnGoruntule.PerformClick();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AYNI TC  İLE KAYIT YAPILAMAZ");
            }






        }
        private void ClearAll()
        {
            txtBoxAd.Clear();
            txtBoxOkulNo.Clear();
            txtBoxSoyad.Clear();
        }

        private  void btnGoruntule_Click(object sender, EventArgs e)
        {
            
            //listedeki itemları sildim
            listView1.Items.Clear();
            //ogrenciler tablomdan bütün verileri aldım
            List<Ogrenciler> ogr =  context.tablo.ToList();
            //aldığım verilerinden içiersinde forea
            foreach (Ogrenciler item in ogr)
            {
                ListViewItem lst = new ListViewItem();
                lst.Text = item.Id.ToString();
                lst.SubItems.Add(item.Ad);
                lst.SubItems.Add(item.Soyad);
                lst.SubItems.Add(item.OgrenciNo);
                listView1.Items.Add(lst);
            }
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {



            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string id = item.Text;
                Ogrenciler ogr = context.tablo.Find(Convert.ToInt32(id));
                txtBoxAd.Text = ogr.Ad;
                txtBoxSoyad.Text = ogr.Soyad;
                txtBoxOkulNo.Text = ogr.OgrenciNo;
                btnKaydet.Text = "Güncelle";
                ogrenci = ogr;
            }
            else
                MessageBox.Show("Listeden veri seçilmedi!");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string id = item.Text;
                Ogrenciler ogr = context.tablo.Find(Convert.ToInt32(id));
                context.Entry(ogr).State = EntityState.Deleted;
                context.SaveChanges();
                MessageBox.Show("Silindi");
                btnGoruntule.PerformClick();
            }
        }
    }
}
