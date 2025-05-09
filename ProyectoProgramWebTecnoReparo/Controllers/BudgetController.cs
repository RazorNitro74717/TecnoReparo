using Microsoft.AspNetCore.Mvc;
using ProyectoProgramWebTecnoReparo.Models;

namespace ProyectoProgramWebTecnoReparo.Controllers
{
    public class BudgetController : Controller
    {
        public IActionResult Budget()
        {
            Contact contact = new Contact()
            {
                Name = ""
            };
            return View();
        }
    }
}
