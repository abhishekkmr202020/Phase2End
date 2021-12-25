using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLibrary;
using EntityLibrary;

namespace eKartApplication.Controllers
{
    public class ItemsController : BaseController<Items>
    {
        IBaseRepo<Items> _repo;
        public static Items i;
        public ItemsController(IBaseRepo<Items> repo) : base(repo)
        {
            _repo = repo;
        }

        public IActionResult Buy(int id)
        {
             i = _repo.Get(id);
            return new RedirectToRouteResult(new { Controller = "Cart", Action = "Index" });
        }

        public IActionResult UserItems()
        {
            return View(_repo.GetAll());
        }
    }
}
