using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using TechVesta.Web.DTO;
using TechVesta.Web.StripePayment;


namespace TechVesta.Web.Controllers
{

    public class SubscriptionController : Controller
    {

        // GET: Subscription
        public ActionResult Index(decimal amount, string planName)
        {
            ViewData["Amount"] = amount;
            ViewData["PlanName"] = planName;
            ViewData["Pk"] = StripeKey.PublishableKey;
            return View();
        }

        public ActionResult Checkout()
        {
            var domain = "http://localhost:5001";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = 1000,
                      Currency = "nzd",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = "Techvesta Product",
                      },
                    },
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/Subscription/PaymentCompleted?isSuccessful=true",
                CancelUrl = domain + "/Subscription/PaymentCompleted?isSuccessful=false",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Json(new { id = session.Id });
            
        }

        public ActionResult PaymentCompleted(bool isSuccessful)
        {
            if (isSuccessful)
            {
                return RedirectPreserveMethod("~/Home/Index"); ;
            }
            else
            {

            }
            ViewData["isSuccess"] = isSuccessful;
            return View();
        }

    }
}