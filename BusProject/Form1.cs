using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BusesDBEntities db = new BusesDBEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            gbAracTakip.Visible = false;
            gbBiletSecim.Visible = false;
            gbKontrol.Visible = false;

            var sehirList = db.tbl_sehirler.Select(x => new
            {
                x.SehirID,
                x.SehirAdi,
            }).ToList();

            cmbSeferKalkis.DataSource = sehirList;
            cmbSeferKalkis.DisplayMember = "SehirAdi";
            cmbSeferKalkis.ValueMember = "SehirID";

            var sehirList1 = db.tbl_sehirler.Select(x => new
            {
                x.SehirID,
                x.SehirAdi,
            }).ToList();
            cmbSeferVaris.DataSource = sehirList1;
            cmbSeferVaris.DisplayMember = "SehirAdi";
            cmbSeferVaris.ValueMember = "SehirID";

            //ResimVeAd() hata attığı için bunu ekledim.
            cmbBOtobus.DataSource = null;
            cmbBOtobus.DisplayMember = "Plaka";
            cmbBOtobus.ValueMember = "otobusID";
            cmbBOtobus.SelectedIndex = -1;

            //Buton rengini sıfırla ve kontrol et
            cmbBOtobus.SelectedIndexChanged += ComboTetik;
            cmbSeferKalkis.SelectedIndexChanged += ComboTetik;
            cmbSeferVaris.SelectedIndexChanged += ComboTetik;

            cmbOtobus.Items.Clear();
            var list = db.tbl_otobus.
                Select(s => new
                {
                    id = s.otobusID,
                    plaka = s.plaka,
                }).ToList();
            cmbOtobus.DataSource = list;
            cmbOtobus.DisplayMember = "plaka";
            cmbOtobus.ValueMember = "id";
        }
        void OtobusKayit()
        {
            try
            {

                tbl_otobus otobus = new tbl_otobus();
                otobus.otobusAdi = "Vi Bus";
                otobus.plaka = "34 Vİ 1907";
                otobus.resim = @"C:\Users\mrasm\OneDrive\Desktop\EF_DBFirst_Bus\Otobus1.jpg";


                /* OtobusKayit() Fonksiyonu içinde Başında "Marked" Bulunan kontroller plaka kontrolü yapıyor SİLME!!! */

                /*Marked*/
                var kontrol = db.tbl_otobus.FirstOrDefault(x => x.plaka == otobus.plaka);
                if (kontrol == null)
                {
                    db.tbl_otobus.Add(otobus);
                }


                tbl_otobus otobus1 = new tbl_otobus();
                otobus1.otobusAdi = "Kraken Turizm";
                otobus1.plaka = "35 KT 2096";
                otobus1.resim = @"C:\Users\mrasm\OneDrive\Desktop\EF_DBFirst_Bus\Otobus2.png";

                /*Marked*/
                kontrol = db.tbl_otobus.FirstOrDefault(x => x.plaka == otobus1.plaka);
                if (kontrol == null)
                {
                    db.tbl_otobus.Add(otobus1);
                }


                tbl_otobus otobus2 = new tbl_otobus();
                otobus2.otobusAdi = "Uzay Turizm";
                otobus2.plaka = "35 UT 0209";
                otobus2.resim = @"C:\Users\mrasm\OneDrive\Desktop\EF_DBFirst_Bus\Otobus3.jpg";

                /*Marked*/
                kontrol = db.tbl_otobus.FirstOrDefault(x => x.plaka == otobus2.plaka);
                if (kontrol == null)
                {
                    db.tbl_otobus.Add(otobus2);
                }


                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Listboxdoldur()
        {
            var bilgi = db.tbl_sefer
                                .Select(x => new
                                {
                                    x.seferID,
                                    Plaka = x.tbl_otobus.plaka,
                                    Koltuk = x.tbl_yolcu.koltukNo,
                                    Guzergah = x.seferKalkis + " -> " + x.seferVaris,
                                    AdSoyad = x.tbl_yolcu.yolcuAdi + " " + x.tbl_yolcu.yolcuSoyad,
                                    x.Tutar,

                                });
            //Reverse Methodu linq querylerini dönüştüremediği için AsEnumerable kullanılmıştır
            var tersBilgi = bilgi.AsEnumerable().Reverse().ToList();
            lbPlaka.DataSource = tersBilgi;
            lbPlaka.DisplayMember = "Plaka";
            lbPlaka.ValueMember = "seferID";

            lbKoltuk.DataSource = tersBilgi;
            lbKoltuk.DisplayMember = "Koltuk";
            lbKoltuk.ValueMember = "seferID";

            lbGuzergah.DataSource = tersBilgi;
            lbGuzergah.DisplayMember = "Guzergah";
            lbGuzergah.ValueMember = "seferID";

            lbAdSoyad.DataSource = tersBilgi;
            lbAdSoyad.DisplayMember = "AdSoyad";
            lbAdSoyad.ValueMember = "seferID";

            lbTutar.DataSource = tersBilgi;
            lbTutar.DisplayMember = "Tutar";
            lbTutar.ValueMember = "seferID";
        }
        void otobusYazdir()
        {
            //Bu blok Otobüs plakalarını combobox'ta görüntüleme içindir!
            try
            {
                var list = db.tbl_otobus.Select(x => new
                {
                    x.otobusID,
                    x.plaka,
                }).ToList();
                cmbBOtobus.DataSource = list;
                cmbBOtobus.DisplayMember = "Plaka";
                cmbBOtobus.ValueMember = "otobusID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Hata otobüs yazdır fonksiyon");
            }
        }
        void ResimVeAd()
        {
            try
            {
                //Otobüs seçimi değiştikçe label ve PicBox ı changed yapmak için
                var otobusBilgi = db.tbl_otobus
                    .Where(x => x.otobusID == (int)cmbBOtobus.SelectedValue)
                    .Select(x => new { x.resim, x.otobusAdi })
                    .FirstOrDefault();
                pcOtoresim.Image = Image.FromFile(otobusBilgi.resim);
                lblOtoAd.Text = otobusBilgi.otobusAdi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ComboTetik(object sender, EventArgs e)
        {
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (var button in buttons)
            {
                button.BackColor = SystemColors.Control;
            }
            KoltuklariKontrolEt();
        }
        private void KoltuklariKontrolEt()
        {
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (var button in buttons)
            {
                DoluKoltuk(button);
            }
        }
        private void DoluKoltuk(Button btn)
        {
            var koltukNo = btn.Text;
            var otobusNo = (int)cmbBOtobus.SelectedValue;
            var seferKalkis = cmbSeferKalkis.Text;
            var seferVaris = cmbSeferVaris.Text;

            var list = db.tbl_sefer
                .Where(x => x.tbl_yolcu.koltukNo == koltukNo && x.otobusID == otobusNo && x.seferKalkis == seferKalkis && x.seferVaris == seferVaris)
                .ToList();

            if (list.Any())
            {
                btn.BackColor = Color.Red;
            }
        }
        void BiletKesKontrol(Button btn)
        {
            if (btn.BackColor == Color.Red)
            {
                MessageBox.Show("Bu koltuk zaten dolu. Bilet kesme işlemi yapılamaz.");
                return;
            }

            try
            {
                string kisiAdSoyad = Interaction.InputBox("Ad Soyad", "Bilet Kes");
                string Ad = kisiAdSoyad.Split(' ')[0].Trim();
                string Soyad = kisiAdSoyad.Split(' ')[1].Trim();
                if (!string.IsNullOrEmpty(kisiAdSoyad))
                {
                    tbl_yolcu yolcu = new tbl_yolcu
                    {
                        yolcuAdi = Ad,
                        yolcuSoyad = Soyad,
                        otobusNo = (int)cmbBOtobus.SelectedValue,
                        koltukNo = btn.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer
                            {
                                otobusID = (int)cmbBOtobus.SelectedValue,
                                yolcuID = yolcu.YolcuID,
                                seferKalkis = cmbSeferKalkis.Text,
                                seferVaris = cmbSeferVaris.Text,
                                Tutar = 100,
                            };
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();
                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            btn.BackColor = Color.Red;
                            Listboxdoldur();
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnBiletKes_Click(object sender, EventArgs e)
        {
            gbBiletSecim.Visible = true;
            OtobusKayit();
            otobusYazdir();
        }
        private void cmbBOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResimVeAd();
        }
        private void btnKontrol_Click(object sender, EventArgs e)
        {
            gbKontrol.Visible = true;
            Listboxdoldur();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            BiletKesKontrol(sender as Button);
        }
        private void cmbOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOtobus.SelectedValue != null && int.TryParse(cmbOtobus.SelectedValue.ToString(), out int secim))
                {
                    var hasilatList = db.tbl_sefer
                                        .Where(x => x.otobusID == secim)
                                        .GroupBy(x => x.otobusID)
                                        .Select(g => new
                                        {
                                            otobusID = g.Key,
                                            toplamHasilat = g.Sum(x => x.Tutar)
                                        }).FirstOrDefault();

                    if (hasilatList != null)
                    {
                        txtHasilat.Text = hasilatList.toplamHasilat.ToString();
                    }
                    else
                    {
                        txtHasilat.Text = "No Result Found";
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private void btnAracTakip_Click(object sender, EventArgs e)
        {
            gbAracTakip.Visible = true;

            try
            {
                var list = db.tbl_otobus.Select(x => new
                {
                    x.otobusID,
                    x.plaka,
                }).ToList();
                cmbAotobus.DataSource = list;
                cmbAotobus.DisplayMember = "Plaka";
                cmbAotobus.ValueMember = "otobusID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Hata otobüs yazdır fonksiyon");
            }
        }
        private void cmbAotobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAotobus.SelectedValue != null)
                {
                    if (int.TryParse(cmbAotobus.SelectedValue.ToString(), out int selectedOtobusID))
                    {
                        var seferListesi = db.tbl_sefer
                            .Where(x => x.otobusID == selectedOtobusID)
                            .OrderByDescending(x => x.seferID)
                            .ToList();

                        if (seferListesi.Any())
                        {
                            var sonSefer = seferListesi.First();

                            var kisiSayisi = db.tbl_sefer
                                .Where(y => y.otobusID == selectedOtobusID && y.seferKalkis == sonSefer.seferKalkis && y.seferVaris == sonSefer.seferVaris)
                                .Count();

                            txtKisiSayisi.Text = kisiSayisi.ToString();
                            txtSefer.Text = sonSefer.seferKalkis + " -> " + sonSefer.seferVaris;
                        }
                        else
                        {
                            txtSefer.Text = "Sefer bulunamadı.";
                            txtKisiSayisi.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sefer bilgisi getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnHareket_Click(object sender, EventArgs e)
        {
            if (cmbAotobus.SelectedValue != null && int.TryParse(cmbAotobus.SelectedValue.ToString(), out int secim))
            {
                int yolcuBasinaHasilat = 100;
                if (int.TryParse(txtKisiSayisi.Text, out int kisiSayisi) && kisiSayisi > 0)
                {
                    var hasilatList = (from sefer in db.tbl_sefer
                                       join otobus in db.tbl_otobus on sefer.otobusID equals otobus.otobusID
                                       where sefer.otobusID == secim
                                       group sefer by new { otobus.plaka } into g
                                       select new
                                       {
                                           plaka = g.Key.plaka,
                                           tarih = DateTime.Now,
                                           toplamHasilat = kisiSayisi * yolcuBasinaHasilat
                                       }).ToList();

                    if (hasilatList != null && hasilatList.Any())
                    {
                        foreach (var item in hasilatList)
                        {
                            var yeniKayit = new kayit
                            {
                                plaka = item.plaka,
                                tarih = item.tarih,
                                hasilat = item.toplamHasilat
                            };
                            db.kayits.Add(yeniKayit);
                        }
                        db.SaveChanges();

                        DisplayKayitData();
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir kişi sayısı giriniz.");
                }
            }
        }


        private void DisplayKayitData()
        {
            var kayitList = db.kayits.Select(k => new
            {
                k.ID,
                k.plaka,
                k.tarih,
                k.hasilat
            }).ToList();

            var tersList = kayitList.AsEnumerable().Reverse().ToList();

            lbAPlaka.DataSource = tersList;
            lbAPlaka.DisplayMember = "plaka";
            lbAPlaka.ValueMember = "ID";

            lbAHasilat.DataSource = tersList;
            lbAHasilat.DisplayMember = "hasilat";
            lbAHasilat.ValueMember = "ID";

            lbTarih.DataSource = tersList;
            lbTarih.DisplayMember = "tarih";
            lbTarih.ValueMember = "ID";
        }

        private void btnAracDurum_Click(object sender, EventArgs e)
        {
            if (lbAPlaka.SelectedItem != null && lbTarih.SelectedItem != null && lbAHasilat.SelectedItem != null)
            {
                var selectedPlaka = ((dynamic)lbAPlaka.SelectedItem).plaka.ToString();
                var selectedTarih = ((dynamic)lbTarih.SelectedItem).tarih.ToString();
                var selectedHasilat = ((dynamic)lbAHasilat.SelectedItem).hasilat.ToString();

                GunlukArsiv ga = new GunlukArsiv();
                ga.plaka = selectedPlaka;

                if (DateTime.TryParse(selectedTarih, out DateTime tarih))
                {
                    ga.tarih = tarih;
                }
                else
                {
                    MessageBox.Show("Geçerli bir tarih değeri seçiniz.");
                    return;
                }

                if (decimal.TryParse(selectedHasilat, out decimal hasilat))
                {
                    ga.hasilat = hasilat;

                    db.GunlukArsivs.Add(ga);
                    db.SaveChanges();

                    MessageBox.Show("Veriler Kaydedildi!");
                }
                else
                {
                    MessageBox.Show("Geçerli bir hasılat değeri seçiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm gerekli alanları seçiniz.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var List = db.GunlukArsivs.Select(x => new
            {
                x.ID,
                arşiv = x.plaka + " " + x.tarih + " " + x.hasilat
            }).ToList();

            var tersList = List.AsEnumerable().Reverse().ToList();

            lbGunlukKayit.DataSource = tersList;
            lbGunlukKayit.DisplayMember = "arşiv";
            lbGunlukKayit.ValueMember = "ID";
        }



    }
}
