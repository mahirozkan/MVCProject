using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) // Logger'� dependency injection yoluyla al�yoruz
        {
            _logger = logger;
        }

        public IActionResult Index()  // Ana sayfa i�in View d�nd�ren metot
        {
            return View();
        }

        public IActionResult About()  // Hakk�nda sayfas� i�in View d�nd�ren metot
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] 
        public IActionResult Error()  // Hata durumunda hata bilgilerini d�nd�ren metot
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
