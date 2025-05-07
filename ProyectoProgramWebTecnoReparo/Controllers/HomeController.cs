using Microsoft.AspNetCore.Mvc;
using ProyectoProgramWebTecnoReparo.Models;
using System.Diagnostics;

namespace ProyectoProgramWebTecnoReparo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Product product = new Product()
            {
                Id = 001,
                Name = "Ryzen 5 3600",
                Description = "Procesador AMD de 6 nucleos y 12 hilos a 3.6 ghz",
                Price = 99,
                Stock = 20,
                Available = true
            };
            
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
