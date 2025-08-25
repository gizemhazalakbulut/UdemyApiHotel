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

## Görseller

<img width="1775" height="934" alt="api" src="https://github.com/user-attachments/assets/567af2f3-57e3-42b9-8cde-2b8d568f6b7a" />

<img width="613" height="563" alt="giriş yap" src="https://github.com/user-attachments/assets/13daa734-676d-4941-bccc-8d7d9b7f99b6" />

<img width="1849" height="914" alt="Dashboard1" src="https://github.com/user-attachments/assets/8ccfec5a-5f64-416c-9bdf-a7119711e6b5" />

<img width="1886" height="845" alt="personeller" src="https://github.com/user-attachments/assets/962c5efb-bee8-411b-8d59-614b5b508346" />

<img width="1880" height="843" alt="giden mesajlar" src="https://github.com/user-attachments/assets/8ccfe73d-6b54-41a4-bbed-cd76e10a9088" />

<img width="1883" height="831" alt="roller" src="https://github.com/user-attachments/assets/5a16bf7c-f875-49f8-90b7-cc2e2af363f1" />

<img width="1870" height="859" alt="ayarlar" src="https://github.com/user-attachments/assets/9dba8a15-42cb-45d0-80ad-8b4d8c1a2be3" />

<img width="1849" height="923" alt="otel1" src="https://github.com/user-attachments/assets/12995c46-49a5-4ed2-9cb6-fa4908f3819a" />

<img width="1408" height="929" alt="otel2" src="https://github.com/user-attachments/assets/12da6b9c-1d78-4032-9f9e-c7656a02c906" />

<img width="1162" height="942" alt="otel3" src="https://github.com/user-attachments/assets/91ee2a6a-4dba-4c14-8f3d-ec065442d745" />

<img width="1289" height="904" alt="otel4" src="https://github.com/user-attachments/assets/5ab33e0c-3c1f-4487-8557-d9cb17cbd112" />

<img width="1620" height="906" alt="rezervasyon yap" src="https://github.com/user-attachments/assets/b1395326-7d56-4015-94ae-828b854fcf2c" />

<img width="985" height="917" alt="iletisim" src="https://github.com/user-attachments/assets/50231f24-24fc-45aa-a22d-facddcfababf" />






