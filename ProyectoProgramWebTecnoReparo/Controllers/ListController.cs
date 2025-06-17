using Microsoft.AspNetCore.Mvc;
using ProyectoProgramWebTecnoReparo.Models;

namespace ProyectoProgramWebTecnoReparo.Controllers
{
    public class ListController : Controller
    {

        public readonly PwaContext _DbContext;

        public ListController (PwaContext context)
        {
            _DbContext = context;
        }

        [HttpGet]
        public IActionResult List(int Id)
        {
            List<Product> pList = _DbContext.Products.ToList();

            return View(pList);

        }
    }
}
