using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechVesta.Web.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using TechVesta.Web.DTO;

namespace TechVesta.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                var message = new MimeMessage();
                message.To.Add(new MailboxAddress("Murph Pathak", "murphamelibre@gmail.com"));
                message.Cc.Add(new MailboxAddress(contactDTO.Name, contactDTO.Email));
                message.From.Add(new MailboxAddress(contactDTO.Name, contactDTO.Email));
                message.Subject = $"Inquiry form {contactDTO.Email}";
                message.Body = new TextPart("html")
                {
                    Text = $"<span>Contact Number</span><p>{contactDTO.Number}</p><br/><span>Service</span><p>{contactDTO.Service}</p><br/><span>Message</span><p>{contactDTO.Comments}</p>"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("murphamelibre@gmail.com", "Murphy@123");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }

        }
        public void SaveContact(JsonResult data)
        {
            var contactFormData = data;
            //ContactDTO.Name = contactFormData.
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
