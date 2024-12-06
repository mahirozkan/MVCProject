using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using System.Net;

namespace MVCProject.Controllers
{
    public class BookController : Controller
    {
        #region Kitap Listeleme
        public IActionResult List() // Tüm kitapların listesini döndüren metot
        {
            List<BookViewModel> list = Data.Books // Kitaplar listesini alıp BookViewModel formatında yeni bir liste oluşturuyor
                .Select(o => new BookViewModel
                {
                    Id = o.Id,
                    Title = o.Title,
                    AuthorId = o.AuthorId,
                    AuthorName = Data.Authors
                                   .FirstOrDefault(a => a.Id == o.AuthorId)?.FirstName + " " + Data.Authors
                                   .FirstOrDefault(a => a.Id == o.AuthorId)?.LastName,
                    Genre = o.Genre,
                    PublishDate = o.PublishDate,
                    ISBN = o.ISBN,
                    CopiesAvailable = o.CopiesAvailable
                })
                .OrderBy(b => b.Title) // Kitapları ada göre sıralıyor
                .ToList();

            return View(list);  // Listeyi View'a döndürüyor
        }
        #endregion
        #region Kitap Detayları
        public IActionResult Details(int id) // Belirli bir kitabın detaylarını döndüren metot
        {
            var book = Data.Books.FirstOrDefault(o => o.Id == id);  // Kitap ID'ye göre bulunuyor

            if (book == null)
                return NotFound();

            var author = Data.Authors.FirstOrDefault(a => a.Id == book.AuthorId);  // Kitabın yazarı bulunuyor

            BookViewModel vm = new BookViewModel()  // Kitap detaylarını içeren bir ViewModel oluşturuluyor
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                AuthorName = author != null ? $"{author.FirstName} {author.LastName}" : "Unknown Author",
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable
            };
            return View(vm);  // View'e ViewModel gönderiliyor
        }
        #endregion
        #region Kitap Oluşturma
        public IActionResult Create() // Yeni bir kitap oluşturma sayfasını döndüren metot
        {
            if (Data.Authors == null || !Data.Authors.Any()) // Eğer yazar yoksa bir mesaj döndürüp listeye yönlendiriyor
            {
                TempData["Message"] = "No authors available.";
                return RedirectToAction("List");
            }

            ViewBag.Authors = new SelectList(Data.Authors, "Id", "FullName"); // Yazar listesini ViewBag'e ekliyor
            return View();
        }
        [HttpPost]  
        public IActionResult Create(BookCreateViewModel book) // Yeni kitap oluşturma işlemini gerçekleştiren metot
        {
            if (ModelState.IsValid)
            {
                Book newBook = new Book()  // Yeni kitap nesnesi oluşturuluyor
                {
                    Id = Data.Books.Max(o => o.Id) + 1,  // Yeni ID oluşturuluyor
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    PublishDate = book.PublishDate,
                    ISBN = book.ISBN,
                    CopiesAvailable = book.CopiesAvailable
                };
                 
                Data.Books.Add(newBook); // Yeni kitap listeye ekleniyor
                TempData["Message"] = "New book added successfully.";
                return RedirectToAction("List"); // List sayfasına yönlendirme
            }

            ViewBag.Authors = new SelectList(Data.Authors, "Id", "FullName"); 
            return View(book); // Model hatası durumunda sayfa tekrar yükleniyor
        }
        #endregion
        #region Kitap Düzenleme
        public IActionResult Edit(int id) // Kitap düzenleme sayfasını döndüren metot
        {
            Book? book = Data.Books.FirstOrDefault(o => o.Id == id); // Düzenlenecek kitabı ID'ye göre buluyor

            if (book == null)
                return NotFound();

            BookEditViewModel vm = new BookEditViewModel()  // Kitap bilgilerini ViewModel'e dolduruyor
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable
            };

            ViewBag.Authors = new SelectList(Data.Authors, "Id", "FullName", vm.AuthorId);  // Yazar listesini ViewBag'e ekliyor
            return View(vm);
        }

        [HttpPost] 
        public IActionResult Edit(BookEditViewModel vm) // Kitap düzenleme işlemini gerçekleştiren metot
        {
            Book? book = Data.Books.FirstOrDefault(o => o.Id == vm.Id); // Düzenlenecek kitabı ID'ye göre buluyor

            if (book == null) return NotFound();

            if (ModelState.IsValid) // Kitap bilgileri güncelleniyor
            {
                book.Title = vm.Title;
                book.AuthorId = vm.AuthorId;
                book.Genre = vm.Genre;
                book.PublishDate = vm.PublishDate;
                book.ISBN = vm.ISBN;
                book.CopiesAvailable = vm.CopiesAvailable;

                TempData["Message"] = "Changes saved.";
                return RedirectToAction("List");
            }

            ViewBag.Authors = new SelectList(Data.Authors, "Id", "FullName", vm.AuthorId);
            return View(vm);  // Model hatası durumunda sayfa tekrar yükleniyor
        }
        #endregion
        #region Kitap Silme
        public IActionResult DeleteApproval(int id)  // Kitap silme onay sayfasını döndüren metot
        {
            Book? book = Data.Books.FirstOrDefault(o => o.Id == id);  // Silinecek kitabı ID'ye göre buluyor

            if (book == null)
            {
                return NotFound();
            }

            return View(book);  // Kitap bilgilerini View'e gönderiyor
        }
        [HttpPost]
        public IActionResult Delete(int id) // Kitap silme işlemini gerçekleştiren metot
        {
            Book? book = Data.Books.FirstOrDefault(o => o.Id == id);  // Silinecek kitabı ID'ye göre buluyor

            if (book == null)
            {
                return NotFound();
            }

            Data.Books.Remove(book);  // Kitap listeden kaldırılıyor
            TempData["Message"] = "Book deleted.";
            return RedirectToAction("List");
        }
        #endregion
    }
}
