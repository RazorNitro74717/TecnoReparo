using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramWebTecnoReparo.Helpers;
using ProyectoProgramWebTecnoReparo.Models;
using ProyectoProgramWebTecnoReparo.Models.VMs;

namespace ProyectoProgramWebTecnoReparo.Controllers
{
    public class ListController : Controller
    {
        public List<Product> products = new List<Product>();
        public List<Item> items = new List<Item>();
        public decimal total = 0;
        int count = 0;
            

        public readonly PwaContext _DbContext;

        public ListController (PwaContext context)
        {
            _DbContext = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            GetCartCount();

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
            GetCartCount();

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

        public IActionResult Kart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Cart");
            if (cart == null)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(cart);
            }
            
        }

        [HttpGet]
        public IActionResult Cart(int id)
        {
            var product = _DbContext.Products.Find(id);
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    product = product,
                    quantity = 1
                });

                TempData["Count"] = CountItems(cart);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        product = product,
                        quantity = 1
                    });
                }
                else
                {
                    var newCantidad = cart[index].quantity + 1;
                    cart[index].quantity = newCantidad;
                }

                TempData["Count"] = CountItems(cart);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", cart);
            }

            return RedirectToAction("Kart");
        }

        [HttpGet]
        public IActionResult Xtract(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Cart");

            int index = Exists(cart, id);
            cart.RemoveAt(index);

            TempData["Count"] = CountItems(cart);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", cart);
            return RedirectToAction("Kart");
        }



        public int CountItems(List<Item> items)
        {
            int q = items.Count();
            return q;
        }

        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
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

    }

}
