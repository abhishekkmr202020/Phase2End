using DataLibrary;
using eKartApplication.Models;
using EntityLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eKartApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IBaseRepo<Users> _repo;

        public HomeController(ILogger<HomeController> logger, IBaseRepo<Users> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
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

        public IActionResult Login(Users obj)
        {
            string userType = "";
            List<Users> users = (List<Users>)_repo.GetAll();
            if (obj.email != null && obj.password != null)
            {
                for(int a=0;a<users.Count;a++)
                {
                    if(users[a].email.Equals(obj.email))
                    {
                        if (users[a].NAME.Equals("1"))
                        {
                            userType = "1";
                        }

                        if (users[a].NAME.Equals("0"))
                        {
                            userType = "0";
                        }
                    }
                }
                 

            if (userType.Equals("1"))
                {
                    return new RedirectToRouteResult(new { Controller = "Items", Action = "Index" });
                }

                else if (userType.Equals("0"))
                {
                    return new RedirectToRouteResult(new { Controller = "Items", Action = "UserItems" });
                }
            }
            return NotFound();
        }
    }
}
