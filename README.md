
# Otobüs Projesi Belgelendirme

---

## Otobüs Projesi

Bu proje, C# Windows Forms Uygulaması kullanarak otobüs operasyonlarını otomatikleştiren, koltuk rezervasyonlarını yöneten ve gelir raporlamalarını gerçekleştiren bir sistemdir. 

---

## İçindekiler
1. [Proje Hakkında](#proje-hakkında)
2. [Özellikler](#özellikler)
3. [Kurulum ve Kurulum](#kurulum-ve-kurulum)
4. [Kod Detayları](#kod-detayları)
   - [Ana Fonksiyonlar](#ana-fonksiyonlar)
5. [Veritabanı Tasarımı](#veritabanı-tasarımı)
6. [Kullanım](#kullanım)
7. [Katkı Sağlama](#katkı-sağlama)
8. [Lisans](#lisans)

---

## Proje Hakkında

**Otobüs Projesi**, otobüs biletleme işlemlerini otomatikleştiren, otobüs durumu izleme ve gelir hesaplama sistemidir. Entity Framework kullanarak MSSQL veritabanına bağlanır ve otobüsler, seferler ve yolcular hakkında veri depolar ve işler.

---

## Özellikler

- **Otobüs Kayıt**  
  Otobüsleri benzersiz plaka ve görsellerle kayıt altına alır.  
- **Koltuğu Rezervasyon**  
  Belirli otobüsler ve güzergahlar için koltuk rezervasyonlarını yönetin.  
- **Gelir Takibi**  
  Belirli bir otobüs veya tüm seferler için geliri hesaplar ve görüntüler.  
- **Sefer İzleme**  
  Belirli otobüsler için mevcut ve geçmiş sefer detaylarını görüntüler.  
- **Arşivleme**  
  Günlük sefer kayıtlarını saklar ve yönetir.

---

## Kurulum ve Kurulum

### Ön Koşullar:
1. **Geliştirme Ortamı**:  
   - Visual Studio 2022 veya daha üst sürümleri  
   - .NET Framework 4.8  
2. **Veritabanı**:  
   - Microsoft SQL Server

### Adımlar:
1. Bu repository’i clonelayın:
   ```bash
   git clone https://github.com/coderVi/BusProject.git
   ```
2. Visual Studio’da projeyi açın.
3. `App.config` dosyasındaki bağlantı dizesini güncelleyin.
4. Projeyi derleyin ve çalıştırın.
5. İçinde olan Script Dosyasını Ms SQL server da çalıştırın.

---

## Kod Detayları

### Ana Fonksiyonlar

#### `Form1_Load`
- Form kontrollerini başlatır.  
- `tbl_sehirler` ve `tbl_otobus` tablosundan verileri doldurur.

#### `OtobusKayit`
- Otobüs kayıtlarını ekler, plakaya göre tekrarlardan kaçınır.

#### `Listboxdoldur`
- Sefer detaylarını liste kutularında görüntüler.

#### `KoltuklariKontrolEt`
- Belirli otobüsler ve seferler için dolu koltukları kontrol eder.

---

## Veritabanı Tasarımı

- **tbl_otobus**: Otobüslerin bilgilerinin depolandığı tablo.
- **tbl_sefer**: Sefer bilgileri ve otobüs numarası, kalkış-varış noktaları gibi bilgiler içerir.
- **tbl_yolcu**: Yolcu bilgileri ve rezervasyonları içerir.
- **tbl_sefer_rezervasyon**: Yolcuların koltuk rezervasyonlarının yapıldığı tablo.

---

## Kullanım

- **Otobüs Kayıt**: Otobüs bilgilerini girerek kayıt altına alabilirsiniz.
- **Koltuğu Rezervasyon**: Belirtilen otobüs ve güzergah için koltuk rezervasyonu yapılabilir.
- **Gelir Takibi**: Otobüs bazında ve genel olarak gelir hesaplamaları yapılır ve gösterilir.
- **Sefer İzleme**: Otobüslerin geçmiş ve mevcut seferleri görüntülenir.
- **Arşivleme**: Günlük sefer kayıtları saklanır ve kontrol edilebilir.

---

## Katkı Sağlama

Bu projeye katkıda bulunmak isterseniz, pull request gönderebilir veya issue bildirerek katkıda bulunabilirsiniz.

---

## Lisans

Bu proje, [MIT Lisansı](https://opensource.org/licenses/MIT) altında lisanslanmıştır.
