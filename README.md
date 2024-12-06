# Kütüphane Yönetim Sistemi - ASP.NET Core MVC Projesi

## Proje Tanımı
Bu proje, bir ASP.NET Core MVC uygulamasıdır ve bir kütüphanenin kitap ve yazar işlemlerini yönetmek için kapsamlı bir sistem sunmaktadır. Proje, birden fazla model, view, controller ve viewmodel içermektedir ve Nesne Yönelimli Programlama (OOP) prensiplerine dayalı olarak geliştirilmiştir.

## Proje Gereksinimleri

### Model Yapıları

#### Kitap Modeli (Book):
- **Id**: Benzersiz kimlik (int)
- **Title**: Kitap adı (string)
- **AuthorId**: Yazar kimliği, Author modeline referans (int)
- **Genre**: Kitap türü (string)
- **PublishDate**: Yayın tarihi (DateTime)
- **ISBN**: ISBN numarası (string)
- **CopiesAvailable**: Mevcut kopya sayısı (int)

#### Yazar Modeli (Author):
- **Id**: Benzersiz kimlik (int)
- **FirstName**: Yazarın adı (string)
- **LastName**: Yazarın soyadı (string)
- **DateOfBirth**: Yazarın doğum tarihi (DateTime)

### ViewModel Yapıları

#### Kitap ViewModel:
Kitapların detaylarını ve ilgili bilgileri gösterecek ViewModel.

#### Yazar ViewModel:
Yazar detaylarını ve yazarların listeleneceği sayfalar için kullanılacak ViewModel.

### Controller Yapıları

#### BookController:
Kitaplarla ilgili işlemleri yöneten controller, aşağıdaki aksiyon metodlarına sahip olacaktır:
- **List**: Kitapların listesini gösterir.
- **Details**: Belirli bir kitabın detaylarını gösterir.
- **Create**: Yeni bir kitap eklemek için form sağlar.
- **Edit**: Var olan bir kitabı düzenlemek için form sağlar.
- **Delete**: Kitabı silmek için bir onay sayfası sağlar.

### View Yapıları

#### Kitap Views:
- **List**: Kitapların listesini görüntüleyen bir view.
- **Details**: Kitap detaylarını görüntüleyen bir view.
- **Create**: Yeni kitap eklemek için form içeren bir view.
- **Edit**: Var olan kitapları düzenlemek için form içeren bir view.

#### Yazar Views:
- **List**: Yazarların listesini görüntüleyen bir view.
- **Details**: Yazar detaylarını görüntüleyen bir view.
- **Create**: Yeni yazar eklemek için form içeren bir view.
- **Edit**: Var olan yazarları düzenlemek için form içeren bir view.

### Program.cs Konfigürasyonu
- MVC servisleri yapılandırılmıştır.
- wwwroot klasöründeki statik dosyaların kullanımı sağlanmıştır.
- Routing konfigürasyonu, isteklerin doğru controller ve aksiyon metodlarına yönlendirilmesini sağlar.
- Varsayılan routing yapılandırması eklenmiştir (Ana Sayfa - Hakkında).

## Notlar
- Projeye Layout ve en az bir PartialView eklenmiştir.
- Sayfanın alt kısmında sabitlenmiş bir footer bulunmaktadır.
- Footer, proje haklarına dair notunu içermektedir.
- Proje içerisinde ana sayfa ve hakkında sayfası bulunmaktadır.
