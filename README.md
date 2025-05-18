# EngelTanı API – Cerebral Palsy Destek Uygulaması (Backend)

Bu proje, fiziksel engelli bireylerin özellikle Cerebral Palsy (CP) hastalarının günlük yaşamlarını kolaylaştırmak amacıyla geliştirilmiş bir destek platformunun sadece **backend (API)** tarafını içerir.

## 🎯 Proje Amacı

Engelli bireylerin:
- Egzersizlerini takip edebileceği,
- Randevularını yönetebileceği,
- Hatırlatmalar alabileceği,
- Gelişim süreçlerini dijital olarak görebileceği
bir RESTful API sunmaktır.

## 🧱 Kullanılan Teknolojiler

- ASP.NET Core 8 Web API  
- Entity Framework Core  
- PostgreSQL veya SQL Server (seçilebilir)  
- Swagger (OpenAPI)  
- JWT Authentication (isteğe bağlı)  
- Clean Architecture yaklaşımlı katmanlı yapı  

## 🗂️ Katman Yapısı

EngelTaniApi
│
├── Core # Entity, Enum, Interface
├── Application # DTO, Service katmanı
├── Infrastructure # EF Core, Repository, External service
├── Controllers # API controller'ları


## 🚀 Kurulum

```bash
git clone https://github.com/berkayakkocc/EngelTaniApi.git
cd EngelTaniApi
dotnet restore
dotnet run

🛠️ Planlanan Modüller
 Egzersiz Takibi

 Randevu Yönetimi

 Bildirim Sistemi

 Kullanıcı Profili

 Gelişim ve Hedef Takibi

 
 ## 👤 Geliştirici
👨‍💻 İsim: Berkaycan Akkoç (GitHub: berkayakkocc)

♿ Cerebral Palsy hastası olarak, kendi deneyimlerinden yola çıkarak bu sistemi geliştirmektedir.


