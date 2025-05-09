using Microsoft.AspNetCore.Mvc;
using ProyectoProgramWebTecnoReparo.Models;

namespace ProyectoProgramWebTecnoReparo.Controllers
{
    public class ContactController : Controller
    {
        // [HttpPost] <- Si lo pongo tira error 405 
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                return View("Success");
            }

            return View(contact);
        }
    }
}