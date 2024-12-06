using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class AuthorController : Controller
    {
        #region Yazar Listeleme
        public IActionResult List() // Tüm yazarları listeleyen bir sayfayı döndürür
        {
            List<AuthorViewModel> list = Data.Authors // Data.Authors listesinden AuthorViewModel tipine dönüştürülen bir liste oluşturuluyor
                               .Select(o => new AuthorViewModel
                               {
                                   Id = o.Id,
                                   FirstName = o.FirstName,
                                   LastName = o.LastName,
                                   DateOfBirth = o.DateOfBirth,
                               })
                               .ToList();

            return View(list);  // Listeyi View'a gönderir
        }
        #endregion
        #region Yazar Detayları
        public IActionResult Details(int id) // Belirli bir yazarın detaylarını döndürür
        {
            Author? author = Data.Authors.FirstOrDefault(o => o.Id == id); // İlgili yazarı ID'ye göre buluyor

            if (author == null)
                return NotFound(); // Yazar bulunamazsa 404 hatası döner

            AuthorViewModel vm = new AuthorViewModel() // Yazar ve kitap detaylarını içeren bir ViewModel oluşturuluyor
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                Books = Data.Books.Where(o => o.AuthorId == id).ToList()
            };
            return View(vm); // ViewModel'i View'a gönderir
        }
        #endregion
        #region Yazar Oluşturma
        public IActionResult Create() // Yeni bir yazar oluşturma sayfasını döndürür
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(AuthorCreateViewModel author) // Yeni yazar oluşturma işlemini işler
        {
            if (ModelState.IsValid) // Model doğrulama kontrolü yapılıyor
            {
                Author newAuthor = new Author() // Yeni bir Author nesnesi oluşturuluyor
                {
                    Id = Data.Authors.Max(o => o.Id) + 1, // Yeni ID hesaplanıyor
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    DateOfBirth = author.DateOfBirth.Value
                };

                Data.Authors.Add(newAuthor);  // Yeni yazar listeye ekleniyor

                TempData["Message"] = "New author added succesfully."; // Geçici mesaj
                return RedirectToAction("List"); // Liste sayfasına yönlendirme
            }

            ViewBag.Author = new SelectList(Data.Authors, "FirstName", "LastName", "DateOfBirth");
            return View(); // Eğer doğrulama başarısızsa tekrar oluşturma sayfası döndürülür
        }
        #endregion
        #region Yazar Düzenleme
        public IActionResult Edit(int id) // Yazar düzenleme sayfasını döndürür
        {
            Author? author = Data.Authors.FirstOrDefault(o => o.Id == id); // Düzenlenecek yazarı ID'ye göre buluyor

            if (author == null)
                return NotFound();

            AuthorEditViewModel vm = new AuthorEditViewModel()  // Yazar bilgilerini düzenlemek için bir ViewModel oluşturuluyor
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };

            ViewBag.Author = new SelectList(Data.Authors, "FirstName", "LastName", "DateOfBirth");
            return View(vm);
        }

        [HttpPost] 
        public IActionResult Edit(AuthorEditViewModel vm) // Düzenlenen yazarın bilgilerini kaydeder
        {
            Author? author = Data.Authors.FirstOrDefault(o => o.Id == vm.Id);  // Düzenlenecek yazarı ID'ye göre buluyor

            if (author == null) return NotFound(); 

            if (ModelState.IsValid) // Model doğrulama kontrolü yapılıyor
            {
                author.FirstName = vm.FirstName; // Yazar bilgileri güncelleniyor
                author.LastName = vm.LastName;
                author.DateOfBirth = vm.DateOfBirth.Value;

                TempData["Message"] = "Changes saved.";
                return RedirectToAction("List");
            }

            ViewBag.Author = new SelectList(Data.Authors, "FirstName", "LastName", "DateOfBirth");
            return View(vm); // Eğer doğrulama başarısızsa tekrar düzenleme sayfası döndürülür
        }
        #endregion
        #region Yazar Silme
        public IActionResult DeleteApproval(int id) // Yazar silme onay sayfasını döndürür
        {
            Author? author = Data.Authors.FirstOrDefault(o => o.Id == id); // Silinecek yazarı ID'ye göre buluyor

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost] 
        public IActionResult Delete(int id)  // Yazar silme işlemini işler
        {
            Author? author = Data.Authors.FirstOrDefault(o => o.Id == id); // Silinecek yazarı ID'ye göre buluyor

            if (author == null)
            {
                return NotFound();
            }

            Data.Authors.Remove(author); // Yazar liste içerisinden siliniyor
            TempData["Message"] = "Author deleted.";
            return RedirectToAction("List"); // Liste sayfasına yönlendirme
        }
        #endregion
    }
}