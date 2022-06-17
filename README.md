# LCW_GraduationProject
E-commerce project
Projeyi ayağa kaldırmak için:
1-	Backend API  appsettings.json MsSQL tanımlamasındaki ‘Server’ bilgisini kendi MsSQL server adı ile değiştiriniz.
2-	Package Manager Console  Default Project  Persistence katmanı seçilir.
3-	Add-migration v1.1 veya EntityFramework6\Add-Migration v1.1 komutu girilerek migration oluşturulur.
4-	Update-database komutu ile MsSQL’de ‘VestiyerDB’ ve tablolar oluşturulur.
5-	API projesi çalıştırıldıktan sonra UI için MVC projesi çalıştırılır.
Proje detay ve içerikleri: Projenin Database’i PostgreSQL kullanılılarak geliştirilip MsSQL’e geçişi sağlandı. İstenildiğinde ‘Persistence’ katmanında bulunan Configuration ve ServiceRegistiration dosyalarındaki ilgili yorum satırları aktif edilerek kolayca PostgreSQL’de çalışılabilir. Projenin backend’i ‘Web API’ projesi olup, Onion Architecture yapısına uygun olarak dizayn edildi. Generic Repository Design Pattern uygulandı. Projenin UI kısmı ise MVC Projesi olarak geliştirildi.
Kullanılan Teknolojiiler:
IDE : Visual Studio 2022
DB:  MsSQL, PostgreSql
Languages: C#, Html, Css, JavaScript
Frameworks: .NET 6, ASP.NetCore, EntityFramework6, EFCore/SqlServer/PostgreSql, JwtBearer, DependencyInjection Abstractions

DB Tablo ilişkileri:
 
API Controller ve metotları:
 
