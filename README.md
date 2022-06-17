# LCW_GraduationProject
E-commerce project

**Projeyi ayağa kaldırmak için:**
***1.*** Backend -> API -> appsettings.json -> MsSQL tanımlamasındaki ‘Server’ bilgisini kendi MsSQL server adı ile değiştiriniz.
***2.***	Package Manager Console -> Default Project -> Persistence katmanı seçilir.
***3.***	Add-migration v1.1 veya EntityFramework6\Add-Migration v1.1 komutu girilerek migration oluşturulur.
***4.***	Update-database komutu ile MsSQL’de ‘VestiyerDB’ ve tablolar oluşturulur.
***5.***	API projesi çalıştırıldıktan sonra UI için MVC projesi çalıştırılır.
***Not:*** Proje'ye initial dummy data olarak kategoriler eklenene kadar API projesinde 'Swagger' üzerinden yeni kategori oluşturulup id bilgisi alınmalıdır.
SignUp, Login, Add/Edit/Delete Product, Give Offer/Order, Approve/Reject Offer vb. işlemler Client-side kısımda gerçekleştirilebilmektedir.

**Proje detay ve içerikleri:**
Projenin Database’i PostgreSQL kullanılılarak geliştirilip MsSQL’e geçişi sağlandı. İstenildiğinde ‘Persistence’ katmanında bulunan Configuration ve ServiceRegistiration dosyalarındaki ilgili yorum satırları aktif edilerek kolayca PostgreSQL’de çalışılabilir. Projenin backend’i ‘Web API’ projesi olup, Onion Architecture yapısına uygun olarak dizayn edildi. Generic Repository Design Pattern uygulandı. Projenin UI kısmı ise MVC Projesi olarak geliştirildi.
Kullanılan Teknolojiler:
IDE : Visual Studio 2022
DB:  MsSQL, PostgreSql
Languages: C#, Html, Css, JavaScript
Frameworks: .NET 6, ASP.NetCore, EntityFramework6, EFCore/SqlServer/PostgreSql, JwtBearer, DependencyInjection Abstractions

***DB Tablo ilişkileri:*** Kısaca database yapısını incelemek gerekirse, geleneksel e-ticaret mantığından farklı olarak alıcı-satıcı için kullanıcı ayrımı olmaksızın, bir kullanıcı platform üzerinden hem ürün satışı hemde ürün alma işlemi gerçekleştirebilir. Ayrıca ek olarak IsOfferable olan ürünlere teklif vererek daha sonrasında bu tekliflerin siparişlere dönüşmesi sağlanabilir.
 ![Tables](https://www.linkpicture.com/q/tableRelations.png)
 
***API Controller ve metotları:*** Mevcut entityler için kullanımda olan ve ilerde kullanılabilecek CRUD işlemleri için API metotlarının tanımlanması.
 ![Controller](https://www.linkpicture.com/q/APIControllers.png)
 
***Login/SignUp:*** Kullanıcı ürün detaylarını görmek, ürün işlemleri gerçekleştirmek veya hesabım sayfalarına ulaşmak için Login olması için bu sayfa yönlendirilir. Mevcut bir kullanıcı ise kullanıcı bilgilerini girerek Login olur, değilse SignUp sekmesinden gerekli bilgiler girilerek kullanıcı kaydı oluşturulur. Bu iki işlemde de DataAttributes'ler ile Validation kontrolü yapılıp; başarısız durumda ilgili hata mesajı yazılır, başarılı durumda ise Login olarak AnaSayfaya yönlendirilir. Login işleminde Authorization işlemi için JWT Token alındıktan sonra Client-side'dan yapılan isteklerin Header'ına default olarak bu token bilgisi eklenmektedir.
 ![Login](https://www.linkpicture.com/q/login.png)
 
***Ana ekran:*** Kullanıcı eğer Login ise sağ üstte teklif ve ürün işlemlerini görebilir, değilse "Login/SignUp" sayfasına yönlenmesini sağlayacak linki görür.
Bu kısma ek olarak logo, search, categories ve diğer tab seçenekleri nav-bar olarak tüm sayfalarda ortak olarak görüntülenebilir. Ana sayfanın content'inde ise tüm ürünler listelenmektedir.
 ![Home](https://www.linkpicture.com/q/Home.png)
 
***Ürünlerim:*** Bu sayfada kullanıcı tüm ürünlerinin listesini görüntüleyebilir, dilerse bu ürünlerin detayını görme, güncelleme ve silme işlemlerini gerçekleştirebilir. Ayrıca sol üstte bulunan Add Product ile yeni ürün girişi sayfasına yönlenerek ürün kaydı gerçekleştirebilir.
 ![MyProducts](https://www.linkpicture.com/q/MyProducts.png)
 
***Ürün detayı:*** Login olduktan sonra ana sayfadan istediği ürün kartında View Detail ile ürün detayını görüntüleyebilir. Bu sayfada Give Order butonu ile açılan pop-up'da adres bilgilerini girerek doğrudan sipariş verip ürünü satın alabilirken, eğer ürün IsOfferable ise görünecek olan Give Offer butonu ile üst kısımdan görünen pop-up'dan istediği teklif yüzdesini veya kendi belirlediği teklifi girerek ürün için teklif göndermiş olur. Bu sayfada ayrıca ürüne eğer daha önce teklif verdi ise verdiği bu teklif tutarını ve Give Offer butonu yerinede teklifi geri çekebileceği Withdraw Order butonunu görüntüler.
 ![Detail](https://www.linkpicture.com/q/detailOffer.png)
 
***Tekliflerim:*** Bu kısımda kullanıcı, başkalarının ürünlerine yaptığı teklifleri görüntüler. Eğer teklifi onaylandı ise Give Order butonu gelir ve doğrudan adres bilgileri ile siparişi gerçekleştirir. Withdraw Offer ile teklifi geri çekebilir.
 ![MyOffers](https://www.linkpicture.com/q/myoffers.png)
 
***Diğerlerinin teklifleri:*** Kullanıcının mevcuttaki hangi ürününe, kim tarafından, ne kadarlık bir teklif yapıldığını görüntüleyebildi ve bu teklifi onaylayıp/reddetme işlemlerini gerçekleştirebildiği ekran.
 ![OthersOffers](https://www.linkpicture.com/q/OthersOffers.png)
