
using PortaFolio_JERH.Models;
using PortaFolio_JERH.Datos;
using Microsoft.AspNetCore.Mvc;

namespace PortaFolio_JERH.Controllers
{
    public class DatosPersonalesController : Controller
    {

       
        DaPersonalesDatos _Datos = new DaPersonalesDatos();

        public IActionResult Index()
        {
            var lista = _Datos.Listar();
            return View(lista);
        }
    }
}