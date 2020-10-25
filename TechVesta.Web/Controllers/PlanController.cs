using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechVesta.Web.Controllers
{
    public class PlanController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WebsitePlan()
        {

            return View();
        }

        public IActionResult HostingPlan()
        {
            return View();
        }

        public IActionResult SeoPlan()
        {
            return View();
        }

        public IActionResult SupportPlan()
        {
            return View();
        }
    }
}
