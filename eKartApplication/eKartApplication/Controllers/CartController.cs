using DataLibrary;
using EntityLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKartApplication.Controllers
{
    public class CartController : Controller
    {
        IBaseRepo<Cart> _repo;
        public CartController(IBaseRepo<Cart> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            //https://learningprogramming.net/net/asp-net-core-mvc/build-shopping-cart-with-session-in-asp-net-core-mvc/
            //https://www.youtube.com/watch?v=rvxQAoIgpkw&list=PL2UwEEhB4YafVIdKCBRjTyryET2EHgryp&index=6
            //List<Items> ils = new List<Items>();
            //ils.Add(ItemsController.i);
            List<Cart> ils = new List<Cart>();
            ils.Add(new Cart { objItems=ItemsController.i });
            return View(ils);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Order(int id)
        {
            if (ModelState.IsValid && ItemsController.i.ID==id)
            {
                var obj = new Cart() {NAME= ItemsController.i.NAME };
                _repo.Add(obj);
                List<Cart> ils = new List<Cart>();
                ils.Add(obj);
                return View(ils);
            }
            return BadRequest();
        }

    }
}
