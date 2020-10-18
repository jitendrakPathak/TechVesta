using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechVesta.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        // GET: Subscription
        public ActionResult Index(decimal amount, string planName)
        {
            ViewData["Amount"] = amount;
            ViewData["PlanName"] = planName;
            return View();
        }
    }
}