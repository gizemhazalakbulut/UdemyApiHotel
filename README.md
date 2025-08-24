# 🏨 Hotel Reservation — RESTful API

Kurumsal otel rezervasyonları için **REST ilkeleri** ile tasarlanmış, tamamen **stateless** çalışan bir .NET Web API.  
Frontend ↔ Backend iletişimi **HTTP/JSON** çağrılarıyla yürür.

---

## ⚡ Neden Bu Proje?
- **Tam REST**: `GET / POST / PUT / PATCH / DELETE` ile kaynak odaklı uçlar  
- **Durumsuz mimari**: Her istek bağımsızdır; durum istemcide/jetonda tutulur  
- **Kurumsal mimari**: Çok katmanlı yapı, gevşek bağlılık, test edilebilirlik  
- **Kimlik & Yetki**: ASP.NET Identity + isteğe bağlı **JWT**  
- **Canlı dokümantasyon**: Swagger UI  
- **Haritalama**: AutoMapper ile DTO ⇄ Entity dönüşümü  
- **Doğrulama**: FluentValidation  
- **Bildirim**: MailKit ile SMTP üzerinden e-posta  
- **Dosya işlemleri**: Yükleme/indirme uçları  
- **Repository deseni**: Veri erişimi soyutlanmış

---

## 🧭 Mimari Yerleşim (6 Katman)
- **APILayer** → HTTP uçları, filtreler, middleware’ler
- **BusinessLayer** → İş kuralları, servisler, doğrulama akışı
- **DataAccessLayer** → EF Core, repository & unit of work
- **EntityLayer** → POCO varlıklar (AppUser, Room, Booking, …)
- **PresentationLayer** → (Varsa) Razor/UI; API ile konuşur
- **Infrastructure / Common** → Ortak yardımcılar, JWT, e-posta, dosya


- **Bağımlılık yönü**: API → Business → DataAccess → Entity  
- UI’dan veritabanına **doğrudan erişim yok**; tüm çağrılar Business üzerinden geçer.

---

## 🧱 Alan Modeli (Örnek Varlıklar)
- `AppUser` / `AppRole` — kullanıcı ve rol yönetimi  
- `Room` — oda (tip, kapasite, fiyat)  
- `Booking` — rezervasyon (giriş/çıkış, kişi sayısı, durum)  
- `Guest` — misafir profili  
- `Service` — otel hizmetleri  
- `WorkLocation` — otel/lokasyon  
- `Contact`, `MessageCategory`, `SendMessage`, `Subscribe`, `Testimonial` …

> İlişkiler ve dönüşümler **AutoMapper profilleri** ile yönetilir.

---

## 🔐 Güvenlik
- ASP.NET **Identity** ile kullanıcı/rol tabanlı yetki  
- Uç düzeyde **[Authorize] / [AllowAnonymous]** kullanımı  
- İsteğe bağlı **JWT** (Bearer) kimlik doğrulaması  
  - `Authorization: Bearer <token>`

---

## 📘 Dokümantasyon & Test
- **Swagger UI**: `/swagger` üzerinden canlı keşif  
- **Postman**: CRUD akışlarını hızla denemek için koleksiyon oluşturulabilir

---

## 🧪 Doğrulama & Dönüşüm
- **FluentValidation**: DTO kuralları (tarih aralığı, kapasite, e-posta formatı, vb.)  
- **AutoMapper**: Entity ⇄ DTO eşlemeleri

---

## ✉️ Bildirim / Mail
- **MailKit + SMTP**: Rezervasyon durum değişince bilgilendirme e-postası gönderimi

---

## 📦 Dosya İşlemleri
- API üzerinden **görsel/PDF yükleme** ve **indirme** uçları  
- İçerik türü ve boyut kontrolleriyle güvenli aktarım

---

## 🧰 Kullanılan Teknolojiler
- **.NET (ASP.NET Core Web API)**  
- **Entity Framework Core** (Code-First, Migrations)  
- **ASP.NET Identity**, **JWT** (opsiyonel)  
- **AutoMapper**, **FluentValidation**, **MailKit**  
- **Swagger / Swashbuckle**

## 🛡️ Yönetim (Admin) Özeti

- Personel, roller, lokasyonlar, hizmetler, odalar, misafirler için **CRUD**
- Rezervasyon akışı: **Pending → Approved / Rejected** _(e-posta bildirimi)_
- Mesaj yönetimi, dosya yükleme/indirme, profil güncellemeleri

## 👤 Kullanıcı Yüzü Özeti

- Odalar, hizmetler, yorumlar ve tanıtım içerikleri
- Rezervasyon formu: **ad-soyad, tarih aralığı, yetişkin/çocuk sayısı, oda sayısı, not**
- Bülten aboneliği ve iletişim formu


