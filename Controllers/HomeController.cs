using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FRUTERIA.Data;
using Microsoft.EntityFrameworkCore;
using FRUTERIA.Models;
using System.Net.Mail;

namespace FRUTERIA.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.FRUTERIA_MAR.ToListAsync());
            //return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CONTACTO()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contacto(string NOMBRE, string APELLIDO, string EMAIL, string TELEFONO, string MENSAJE)
        {
            enviarCorreo(NOMBRE, APELLIDO, EMAIL, TELEFONO, MENSAJE);

            ViewBag.clave = "¡GRACIAS POR CONTACTAR CON NOSOTROS! En breve nos pondremos en contacto contigo.";

            return View();
        }
        public void enviarCorreo(string nombre, string apellido, string email, string telefono, string mensaje)
        {

            string DireccionOrigen = "grymarcelita@gmail.com";

            MailMessage message = new MailMessage();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            string pass =  FRUTERIA.Properties.Resources.Password.ToString();
            smtpClient.Credentials = new System.Net.NetworkCredential() //le pasamos las credenciales
            {
                UserName = DireccionOrigen,

                Password = pass
            };

            //Especifique si el objeto SmtpClient utiliza SSL (Secure Sockets Layer) para cifrar la conexión.
            smtpClient.EnableSsl = true; //Es true si el objeto SmtpClient utiliza SSL; en caso contrario, es false.
            //De manera predeterminada, es false.
            message.From = new MailAddress(DireccionOrigen);
            message.To.Add(new MailAddress(DireccionOrigen));
            message.Subject = nombre + "-" + apellido + " - Telefono: " + telefono;
            message.IsBodyHtml = true;
            message.Body = mensaje + "Email: " + email;

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; //Especifica la forma en que se controlarán
            //los mensajes de correo electrónico salientes.
            smtpClient.Send(message);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
