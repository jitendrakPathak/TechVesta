using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechVesta.Web.Controllers
{
    public class ServiceController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WebDevelopment()
        {
            return View();
        }

        public IActionResult SoftwareDevelopment()
        {
            return View();
        }

        public IActionResult WebSiteDesign()
        {
            return View();
        }

        public IActionResult Seo()
        {
            return View();
        }
    }
}
