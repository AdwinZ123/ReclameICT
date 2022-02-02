using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;
using Opdracht_Programmeren.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;

namespace Opdracht_Programmeren.Controllers
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

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactAsync([Bind("Firstname", "LastName", "Mail", "Text", "PhoneNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                var fullName = $"{contact.Firstname} {contact.LastName}";

                var sender = new SmtpSender(() => new SmtpClient("localhost")
                {
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Port = 25
                });

                StringBuilder template = new();
                template.AppendLine("Hey @Model.Name,");
                template.AppendLine("<p>Bedankt voor je bericht! We zullen zo snel mogelijk reageren.</p>");
                template.AppendLine("- Hoornbeeck ICT");

                Email.DefaultSender = sender;
                Email.DefaultRenderer = new RazorRenderer();

                var email = await Email
                    .From("info@hoornbeeck.nl")
                    .To(contact.Mail)
                    .Subject("Bedankt voor je bericht!")
                    .UsingTemplate(template.ToString(), new { Name = fullName })
                    .SendAsync();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}