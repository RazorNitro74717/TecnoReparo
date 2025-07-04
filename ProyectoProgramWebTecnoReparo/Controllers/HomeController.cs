using Microsoft.AspNetCore.Mvc;
using ProyectoProgramWebTecnoReparo.Helpers;
using ProyectoProgramWebTecnoReparo.Models;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ProyectoProgramWebTecnoReparo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly PwaContext _DbContext;

        public HomeController(ILogger<HomeController> logger, PwaContext context)
        {
            _logger = logger;
            _DbContext = context;
        }

        


        //Funciones secundarias
        private string GetSplashList()
        {
            string[] frases = new[] 
            {
                "¡Bienvenido!",
                "Ahora con más VRAM",
                "No alimentes a los bugs",
                "Funcionara... probablemente",
                "Cargado al azar con cariño"
            };

            Random rnd = new Random();
            return frases[rnd.Next(frases.Length)];
        }

        private void GetCartCount()
        {
            int q;

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Cart");
            if (cart == null)
            {
                q = 0;
            }
            else
            {
                q = cart.Count;
            }
            TempData["Count"] = q;
        }


        //Controller
        public IActionResult Index()
        {
            GetCartCount();
            List<Product> pList = _DbContext.Products.ToList();
            Random RNG = new Random();
            var selec = pList.OrderBy(x => RNG.Next()).Take(3).ToList();
            string splash = GetSplashList();
            ViewBag.SplashText = splash;
            return View(selec);
        }

        public IActionResult Common()
        {
            return View();
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
