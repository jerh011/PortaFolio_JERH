
using PortaFolio_JERH.Models;
using PortaFolio_JERH.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace PortaFolio_JERH.Controllers
{
    public class DatosPersonalesController : Controller
    {
        private readonly IConfiguration _configuration;

        DaPersonalesDatos _Datos = new DaPersonalesDatos();

        public IActionResult Index()
        {
            var lista = _Datos.Listar();
            return View(lista);
        }
        public DatosPersonalesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Mensage()
        {
            return View(new MessageViewModel());
        }

        [HttpPost]
        public IActionResult SendSms(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accountSid = _configuration["Twilio:AccountSid"];
                var authToken = _configuration["Twilio:AuthToken"];

                TwilioClient.Init(accountSid, authToken);

                var messageResource = MessageResource.Create(
                    body: model.Message,
                    // Reemplaza con tu número de Twilio, en este caso, "+1 256 661 4023"
                    from: new Twilio.Types.PhoneNumber("+12566614023"),
                    to: new Twilio.Types.PhoneNumber(model.Numero)
                );

                // Puedes agregar un mensaje de éxito o manejar redireccionamientos según tus necesidades.
                ViewBag.SuccessMessage = "Mensaje enviado con éxito.";
            }
            else
                ViewBag.SuccessMessage = "Algo salio mal.";

            return View("Index", model);
        }
       public IActionResult Proyectos()
        {
            var lista = _Datos.Listar();
            return View(lista);
        }
    }
}
