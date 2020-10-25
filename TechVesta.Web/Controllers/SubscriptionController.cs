using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using Stripe;
using Stripe.Checkout;
using TechVesta.Web.DTO;
using TechVesta.Web.Helper;
using System.Text.Json;

namespace TechVesta.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        public ActionResult Index(decimal amount, string planName)
        {
            ViewData["Amount"] = amount;
            ViewData["PlanName"] = planName;
            ViewData["Pk"] = StripeKey.PublishableKey;
            return View();
        }

        public ActionResult Checkout()
        {
            CheckoutDTO data = JsonSerializer.Deserialize<CheckoutDTO>(Request.Form["data"][0]);
            if (data.Amount > 0)
            {
                MimeMessage message = new MimeMessage();
                message.To.Add(new MailboxAddress("Murph Pathak", "murphamelibre@gmail.com"));
                message.Cc.Add(new MailboxAddress(data.FullName, data.Email));
                message.From.Add(new MailboxAddress(data.FullName, data.Email));
                message.Subject = $"Payment initiated by {data.Email}";
                message.Body = new TextPart("html")
                {
                    Text = $"<span>Plan</span><p>{data.Service}</p>br/><span>Amount</span><p>{data.Amount}</p><br/><span>Contact Number</span><p>{data.Number}</p><br/><span>Address</span><p>{data.Address}, {data.City}, {data.State}, {data.Country}</p>"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("murphamelibre@gmail.com", "Murphy@123");
                    client.Send(message);
                    client.Disconnect(true);
                }

                var domain = Request.Host;
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
                      UnitAmount = (long?)data.Amount,
                      Currency = "nzd",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = data.Service,
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
            return null;
        }

        public ActionResult PaymentCompleted(bool isSuccessful)
        {
            ViewData["isSuccess"] = isSuccessful;
            return View();
        }
    }
}