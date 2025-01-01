# English

# Bus Project Certification

---

## Bus Project

This project is a system that automates bus operations, manages seat reservations and performs income reporting using C# Windows Forms Application. 

---

## Contents
1. [About the Project](#about-project)
2. [Features](#features)
3. [Installation and Installation](#installation-and-installation)
4. [Code Details](#code-details)
   - [Main Functions](#main-functions)
5. [Database Design](#database-design)
6. [Usage](#usage)
7. [Contribution](#contribution)
8. [Licence](#license)

---

## About the Project

**Bus Project** is a bus status monitoring and revenue calculation system that automates bus ticketing processes. It connects to MSSQL database using Entity Framework and stores and processes data about buses, trips and passengers.

---

## Features

- **Bus Registration**  
  It registers buses with unique license plates and images.  
- **Seat Reservation**  
  Manage seat reservations for specific buses and routes.  
- **Income Tracking**  
  Calculates and displays revenue for a specific bus or all trips.  
- **Expedition Tracking**  
  Displays current and past trip details for specific buses.  
- **Archiving**  
  Stores and manages daily voyage records.
---

## Installation and Installation

### Prerequisites:
1. **Development Environment**:  
   - Visual Studio 2022 or higher  
   - .NET Framework 4.8  
2. **Database**:  
   - Microsoft SQL Server

### Steps:
1. Clone this repository:
   ```bash
   git clone https://github.com/coderVi/BusProject.git
   ```
2. Open the project in Visual Studio.
3. Update the connection string in the `App.config` file.
4. Compile and run the project.
5. Run the Script File inside on Ms SQL server.

---

## Code Details

### Main Functions

#### `Form1_Load`
- Initializes form controls.  
- Populates data from `tbl_cities` and `tbl_bus` tables.

#### `BusRegistration`
- Adds bus records, avoids duplication by license plate.

#### `Fill Listbox`
- Displays expedition details in list boxes.

#### `CheckSeats`
- Checks occupied seats for specific buses and trips.

---

## Database Design

- **tbl_otobus**: The table where bus information is stored.
- **tbl_sefer**: Contains information such as trip information, bus number, departure and destination points.
- **tbl_passenger**: Contains passenger information and reservations.
- **tbl_sefer_rezervasyon**: The table where passengers' seat reservations are made.

---

## Database Design

- **tbl_otobus**: The table where bus information is stored.
- **tbl_sefer**: Contains information such as trip information, bus number, departure and destination points.
- **tbl_passenger**: Contains passenger information and reservations.
- **tbl_sefer_rezervasyon**: The table where passengers' seat reservations are made.

---

## Usage

- **Bus Registration**: You can register by entering the bus information.
- **Seat Reservation**: Seat reservations can be made for the specified bus and route.
- **Revenue Tracking**: Income calculations are made and displayed on a bus basis and in general.
- **Trip Tracking**: Past and current bus trips are displayed.
- **Archiving**: Daily voyage records are stored and can be checked.

---

## Contributing

If you would like to contribute to this project, you can send a pull request or contribute by reporting an issue.

---

## Licence

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

### Thanks

# Türkçe

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

### Teşekkürler

