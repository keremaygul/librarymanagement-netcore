# 📚 Kütüphane Yönetim Sistemi

Modern bir kütüphane için tasarlanmış, kapsamlı bir yönetim sistemi. ASP.NET Core 8.0 kullanılarak geliştirilmiş bu proje, Clean Architecture prensiplerine uygun olarak yapılandırılmıştır.

## 🚀 Özellikler

### 📖 Kitap Yönetimi
- Kitap ekleme, düzenleme ve silme işlemleri
- Detaylı kitap bilgileri (ISBN, yazar, yayınevi, vb.)
- Kopya sayısı ve mevcut kopya takibi
- Gelişmiş kitap arama ve filtreleme

### 👥 Üye Yönetimi
- Üye kaydı ve profil yönetimi
- Aktif/Pasif üye durumu takibi
- Üye geçmişi ve ödünç alma kayıtları
- Detaylı üye arama

### 📅 Ödünç İşlemleri
- Kolay ödünç verme ve iade işlemleri
- Otomatik son teslim tarihi hesaplama
- Süre uzatma özelliği
- Gecikmiş kitap takibi
- Mevcut kopya kontrolü

## 🛠 Kullanılan Teknolojiler

### Backend
- **.NET 8.0**: En güncel .NET sürümü
- **Entity Framework Core**: ORM ve veritabanı işlemleri
- **SQLite**: Veritabanı
- **AutoMapper**: Nesne dönüşümleri
- **Repository Pattern**: Veri erişim katmanı
- **Unit of Work Pattern**: Transaction yönetimi

### Frontend
- **Bootstrap 5**: Modern ve responsive tasarım
- **jQuery**: DOM manipülasyonu ve AJAX işlemleri
- **Select2**: Gelişmiş arama ve seçim kutuları
- **DataTables**: Dinamik tablo yönetimi
- **SweetAlert2**: Kullanıcı bildirimleri
- **Font Awesome**: İkonlar

## 🏗 Mimari Yapı

### Clean Architecture
Proje, Clean Architecture prensiplerine uygun olarak üç katmanlı bir yapıda geliştirilmiştir:

#### Core Katmanı
- Domain Entities
- Interfaces
- Business Rules
- DTOs

#### Infrastructure Katmanı
- DbContext
- Repositories
- Unit of Work
- External Service Implementations

#### Web Katmanı
- Controllers
- Views
- ViewModels
- Filters
- Middleware

## 📐 Tasarım Desenleri

- **Repository Pattern**: Veri erişim katmanının soyutlanması
- **Unit of Work**: Transaction yönetimi
- **Dependency Injection**: Loosely coupled yapı
- **MVC Pattern**: Sunum katmanı organizasyonu

## 🔍 Kod Kalitesi

- SOLID prensiplerine uygun tasarım
- Asenkron programlama yaklaşımı
- Clean Code prensipleri
- Dependency Injection kullanımı
- Extension metodları
- Global exception handling

## 📊 Veritabanı Yapısı

### Tablolar
- **Books**: Kitap bilgileri
- **Members**: Üye bilgileri
- **BookLoans**: Ödünç kayıtları
- **BaseEntity**: Ortak alanlar (Id, CreatedAt, UpdatedAt)

## 🚦 API Endpoints

### Kitaplar
- `GET /api/Books/Search`: Kitap arama
- `POST /Books/Create`: Yeni kitap ekleme
- `PUT /Books/Edit/{id}`: Kitap güncelleme
- `DELETE /Books/Delete/{id}`: Kitap silme

### Üyeler
- `GET /api/Members/Search`: Üye arama
- `POST /Members/Create`: Yeni üye ekleme
- `PUT /Members/Edit/{id}`: Üye güncelleme
- `DELETE /Members/Delete/{id}`: Üye silme

### Ödünç İşlemleri
- `POST /BookLoans/Create`: Ödünç verme
- `POST /BookLoans/Return/{id}`: İade alma
- `POST /BookLoans/Extend/{id}`: Süre uzatma

## 🔧 Kurulum

1. Repoyu klonlayın:
```bash
git clone https://github.com/kullaniciadi/LibraryManagement.git
```

2. Proje dizinine gidin:
```bash
cd LibraryManagement
```

3. Bağımlılıkları yükleyin:
```bash
dotnet restore
```

4. Veritabanını oluşturun:
```bash
dotnet ef database update --project src/LibraryManagement.Infrastructure --startup-project src/LibraryManagement.Web
```

5. Projeyi çalıştırın:
```bash
cd src/LibraryManagement.Web
dotnet run
```

## 🌟 Geliştirilebilir Özellikler

Proje, aşağıdaki özelliklerle daha da geliştirilebilir:

### 📱 Kullanıcı Deneyimi
- Kitap rezervasyon sistemi
- Mobil uyumlu arayüz geliştirmeleri
- Çoklu dil desteği
- Barkod/QR kod entegrasyonu

### 📊 Raporlama ve Analiz
- Detaylı raporlama modülü
- İstatistiksel analizler
- Grafik ve dashboard'lar
- Excel/PDF export özellikleri

### 🔔 Bildirim Sistemi
- E-posta bildirimleri
- SMS entegrasyonu
- Tarayıcı bildirimleri
- Hatırlatma sistemi

### 🔐 Güvenlik ve Yetkilendirme
- Rol tabanlı yetkilendirme
- OAuth2 entegrasyonu
- İki faktörlü doğrulama
- Detaylı log sistemi 