using Microsoft.AspNetCore.Mvc;
using ProyectoProgramWebTecnoReparo.Models;
using ProyectoProgramWebTecnoReparo.Models.VMs;

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
        public IActionResult List()
        {
            ListCatVM vm = new ListCatVM()
            {
                Products = _DbContext.Products.ToList(),
                Categories = _DbContext.Categories.ToList(),
            };

            return View(vm);

        }

        [HttpGet]
        public IActionResult SearchList(string cat)
        {
            var prods = from pro in _DbContext.Products select pro;

            if (!string.IsNullOrEmpty(cat))
            {
                prods = prods.Where(res => res._Category.Name.Equals(cat));
            }

            ListCatVM vm = new ListCatVM()
            {
                Products = prods.ToList(),
                Categories = _DbContext.Categories.ToList(),
            };
            return View(vm);
        }
    }
}
