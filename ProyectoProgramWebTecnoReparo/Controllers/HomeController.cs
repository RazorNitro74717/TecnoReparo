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

        public List<Product> GetProducts() 
        {
            return new List<Product>
        {
            new Product()
                {
                    Id = 101,
                    Name = "Ryzen 5 3600",
                    Description = "Procesador AMD de 6 nucleos y 12 hilos a 3.6 ghz",
                    Price = 99,
                    Stock = 20,
                    Available = true,
                    Image = "/img/Ryzen_5_3600.png"
                },
            new Product()
                {
                    Id = 201,
                    Name = "Asus B550 PRIME M-A",
                    Description = "Motherboard Asus para procesadores AM4 de AMD",
                    Price = 59,
                    Stock = 50,
                    Available = true,
                    Image = "/img/asus_prime_b550_m-a.png"
                },
            new Product()
                {
                    Id = 301,
                    Name = "Kingston Fury 16GB DDR4 ",
                    Description = "Memoria RAM de 16GB DDR4 a 3200mhz",
                    Price = 19,
                    Stock = 90,
                    Available = true,
                    Image = "/img/kingston_fury.png"
                }

        };
    }

        public IActionResult Index()
        {
            var a = GetProducts().ToList();
            return View(a);
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
