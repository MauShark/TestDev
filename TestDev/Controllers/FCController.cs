using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDev.Models;
using TestDev.Controllers;
using TestDev.Models.ViewModels;

namespace TestDev.Controllers
{
    public class FCController : Controller
    {
        private readonly FacturadorDBContext _DBcontext;

        public FCController(FacturadorDBContext context)
        {
            _DBcontext = context;
        }

        public IActionResult IndexFC()
        {
            List<FacturaCabecera> list = _DBcontext.FacturaCabeceras
                .Include(fc => fc.FacturaDetalles)
                .Include(fc => fc.Cli)
                .ToList();

            return View(list);
        }

        [HttpGet]
        public IActionResult Factura_Detalle(int FcID)
        {
            FacturaCabeceraVM oCabeceraVM = new FacturaCabeceraVM()
            {

                oCabecera = new FacturaCabecera()


            };

            if (FcID != 0)
            {
                oCabeceraVM.oCabecera = _DBcontext.FacturaCabeceras.Find(FcID);
            }

            return View(oCabeceraVM);
        }

    }
}
