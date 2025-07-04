using Microsoft.AspNetCore.Mvc;
using ProyectoProgramWebTecnoReparo.Helpers;
using ProyectoProgramWebTecnoReparo.Models;
using System.Diagnostics;

namespace ProyectoProgramWebTecnoReparo.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }
        [HttpGet]

        [HttpPost]  
        public IActionResult Contact(Contact contact)
        {
            GetCartCount();
            if (ModelState.IsValid)
            {
                TempData["ShowToast"] = true;
                return RedirectToAction("Index", "Home");
            }

            return View(contact);
        }

        //Funciones secundarias

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}