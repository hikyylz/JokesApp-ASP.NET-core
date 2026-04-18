# JokesApp — ASP.NET Core MVC Uygulaması

JokesApp, ASP.NET Core 8.0 MVC mimarisiyle geliştirilmiş bir şaka (joke) yönetim web uygulamasıdır. Kullanıcılar, şakaları listeleyebilir, arayabilir ve detaylarını görüntüleyebilir. Kayıtlı ve giriş yapmış kullanıcılar ise yeni şaka ekleyebilir, mevcut şakaları düzenleyebilir veya silebilir. Ana sayfada, OpenWeatherMap API'si üzerinden anlık hava durumu bilgisi de gösterilmektedir.

Proje; Entity Framework Core ile SQL Server veritabanı entegrasyonu, ASP.NET Core Identity ile kimlik doğrulama ve Razor Views tabanlı modern bir MVC kullanıcı arayüzü içermektedir.

---

## 🚀 Özellikler

- **Şaka Listeleme** — Tüm şakalar listelenebilir
- **Şaka Arama** — Şaka sorusuna göre arama yapılabilir
- **Şaka Detayı** — Her şaka ayrı detay sayfasında görüntülenir
- **Şaka Ekleme / Düzenleme / Silme** — Yalnızca giriş yapmış kullanıcılar tarafından gerçekleştirilebilir
- **Kullanıcı Kimlik Doğrulama** — ASP.NET Core Identity ile kayıt, giriş ve e-posta onay akışı
- **Hava Durumu Widget'ı** — Ana sayfada OpenWeatherMap API üzerinden anlık hava durumu gösterimi

---

## 🛠️ Teknoloji Yığını

| Katman | Teknoloji |
|---|---|
| Framework | ASP.NET Core 8.0 (MVC) |
| ORM | Entity Framework Core 8.0 |
| Kimlik Doğrulama | ASP.NET Core Identity 8.0 |
| Veritabanı | SQL Server (geliştirmede LocalDB) |
| UI | Razor Views (Cshtml) |
| Dış API | OpenWeatherMap REST API (XML) |
| Dil | C# (.NET 8) |

---

## 📋 Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- SQL Server veya SQL Server Express / LocalDB
- (İsteğe bağlı) Visual Studio 2022+ veya VS Code

---

## ⚙️ Kurulum ve Çalıştırma

### 1. Repoyu klonlayın

```bash
git clone https://github.com/hikyylz/JokesApp-ASP.NET-core.git
cd JokesApp-ASP.NET-core
```

### 2. Bağlantı dizesini ayarlayın

`JokesApp/appsettings.json` dosyasındaki `DefaultConnection` değerini kendi SQL Server örneğinize göre güncelleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=JokesAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

> Hassas bilgileri kaynak koda koymak yerine [User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) veya ortam değişkeni kullanmanız önerilir.

### 3. Bağımlılıkları yükleyin

```bash
cd JokesApp
dotnet restore
```

### 4. Veritabanını oluşturun (migration uygulayın)

```bash
dotnet ef database update
```

Bu komut, `Data/Migrations` klasöründeki tüm migration'ları sırasıyla uygular:
- `00000000000000_CreateIdentitySchema` — ASP.NET Core Identity tablolarını oluşturur
- `20240815114004_initialsetup` — `Joke` tablosunu ve diğer yapıları oluşturur

### 5. Uygulamayı çalıştırın

```bash
dotnet run
```

Uygulama varsayılan olarak `https://localhost:7xxx` veya `http://localhost:5xxx` adresinde çalışır (launch profili `Properties/launchSettings.json` dosyasından yapılandırılır).

---

## 🗂️ Proje Yapısı

```
JokesApp-ASP.NET-core/
├── JokesApp/
│   ├── Controllers/
│   │   ├── HomeController.cs        # Ana sayfa ve hava durumu entegrasyonu
│   │   └── JokesController.cs       # Şaka CRUD ve arama işlemleri
│   ├── Data/
│   │   ├── ApplicationDbContext.cs  # EF Core DbContext (Identity + Joke)
│   │   └── Migrations/              # EF Core migration dosyaları
│   ├── Models/
│   │   ├── Joke.cs                  # Şaka modeli
│   │   └── WeatherForcastModel.cs   # Hava durumu modeli
│   ├── Sevice/
│   │   └── WeatherAPIService.cs     # OpenWeatherMap API servisi
│   ├── Views/
│   │   ├── Home/                    # Ana sayfa görünümleri
│   │   └── Jokes/                   # Şaka CRUD görünümleri
│   ├── Areas/Identity/              # Razor Pages Identity UI
│   ├── appsettings.json             # Uygulama yapılandırması
│   └── Program.cs                   # Uygulama başlangıç noktası
└── JokesApp.sln
```

---

## 🔐 Kimlik Doğrulama Notları

- Kayıt sırasında e-posta onayı gereklidir (`options.SignIn.RequireConfirmedAccount = true`).
- Geliştirme ortamında e-posta onayını atlamak için `appsettings.Development.json` dosyasında ilgili ayarı değiştirip kendi e-posta sağlayıcınızı (SendGrid, SMTP vb.) bağlayabilirsiniz.
- Şaka oluşturma, düzenleme ve silme işlemleri `[Authorize]` niteliği ile korunmaktadır; giriş yapılmadan erişim reddedilir.

---

## 🌤️ Hava Durumu API Notu

`Sevice/WeatherAPIService.cs` dosyasındaki `apikey` ve `selectedCity` değerleri varsayılan olarak London için yapılandırılmıştır. Kendi OpenWeatherMap API anahtarınızı almak için [openweathermap.org](https://openweathermap.org/api) adresini ziyaret edin.

---

## 📄 Lisans

Bu proje açık kaynaklıdır. Katkı sağlamak veya kullanmak için repoyu fork'layabilirsiniz.
