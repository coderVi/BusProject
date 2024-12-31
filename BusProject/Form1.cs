﻿using Microsoft.VisualBasic;
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

            //Buton rengini sıfırlamak için
            cmbBOtobus.SelectedIndexChanged += ComboTetik;
            cmbSeferKalkis.SelectedIndexChanged += ComboTetik;
            cmbSeferVaris.SelectedIndexChanged += ComboTetik;

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
            lbPlaka.DataSource = bilgi.ToList();
            lbPlaka.DisplayMember = "Plaka";
            lbPlaka.ValueMember = "seferID";

            lbKoltuk.DataSource = bilgi.ToList();
            lbKoltuk.DisplayMember = "Koltuk";
            lbKoltuk.ValueMember = "seferID";

            lbGuzergah.DataSource = bilgi.ToList();
            lbGuzergah.DisplayMember = "Guzergah";
            lbGuzergah.ValueMember = "seferID";

            lbAdSoyad.DataSource = bilgi.ToList();
            lbAdSoyad.DisplayMember = "AdSoyad";
            lbAdSoyad.ValueMember = "seferID";

            lbTutar.DataSource = bilgi.ToList();
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
        void RenkSıfırla()
        {
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;
            button5.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Control;
            button7.BackColor = SystemColors.Control;
            button8.BackColor = SystemColors.Control;
            button9.BackColor = SystemColors.Control;
        }
        void ComboTetik(object sender, EventArgs e)
        {
            RenkSıfırla();
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
            try
            {
                string kisiAdSoyad = Interaction.InputBox("Ad Soyad","Bilet Kes");
                string Ad = kisiAdSoyad.Split(' ')[0].Trim();
                string Soyad = kisiAdSoyad.Split(' ')[1].Trim();
                if (!string.IsNullOrEmpty(kisiAdSoyad))
                {
                    tbl_yolcu yolcu = new tbl_yolcu
                    {
                        yolcuAdi = Ad,
                        yolcuSoyad = Soyad,
                        otobusNo = (int)cmbBOtobus.SelectedValue,
                        koltukNo = button1.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button1.BackColor = Color.Red;
                            try
                            {

                                if (button1.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message +"hata buradan ");
                    }
                    
                }
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button2.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button2.BackColor = Color.Red;
                            try
                            {

                                if (button2.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button3.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button3.BackColor = Color.Red;
                            try
                            {

                                if (button3.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button6.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button6.BackColor = Color.Red;
                            try
                            {

                                if (button6.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button5.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button5.BackColor = Color.Red;
                            try
                            {

                                if (button5.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button4.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button4.BackColor = Color.Red;
                            try
                            {

                                if (button4.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button9.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button9.BackColor = Color.Red;
                            try
                            {

                                if (button9.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button2.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button8.BackColor = Color.Red;
                            try
                            {

                                if (button8.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
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
                        koltukNo = button7.Text
                    };
                    try
                    {
                        tbl_yolcu kontrol = db.tbl_yolcu.Add(yolcu);
                        if (kontrol != null)
                        {
                            db.SaveChanges();
                            tbl_sefer sefer = new tbl_sefer();
                            sefer.otobusID = (int)cmbBOtobus.SelectedValue;
                            sefer.yolcuID = yolcu.YolcuID;
                            string kalkis = cmbSeferKalkis.Text;
                            string varis = cmbSeferVaris.Text;
                            sefer.seferKalkis = kalkis;
                            sefer.seferVaris = varis;
                            sefer.Tutar = 100;
                            sefer.Hasilat += sefer.Tutar;
                            db.tbl_sefer.Add(sefer);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt Başarıyla Eklendi");
                            button7.BackColor = Color.Red;
                            try
                            {

                                if (button7.BackColor != Color.Red)
                                {
                                    Listboxdoldur();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            MessageBox.Show("Bilet Kesilmedi");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "hata buradan ");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
