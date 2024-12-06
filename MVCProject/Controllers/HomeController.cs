using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) // Logger'ý dependency injection yoluyla alýyoruz
        {
            _logger = logger;
        }

        public IActionResult Index()  // Ana sayfa için View döndüren metot
        {
            return View();
        }

        public IActionResult About()  // Hakkýnda sayfasý için View döndüren metot
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] 
        public IActionResult Error()  // Hata durumunda hata bilgilerini döndüren metot
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
