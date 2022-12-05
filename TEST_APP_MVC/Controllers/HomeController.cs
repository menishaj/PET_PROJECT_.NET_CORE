using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_APP_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession session;
        private readonly IHttpContextAccessor accessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this.accessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
