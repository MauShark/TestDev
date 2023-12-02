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
        public IActionResult Factura_Cabecera(int FcID)
        {
            FacturaCabeceraVM oCabeceraVM = new FacturaCabeceraVM()
            {

                 oCabecera = new FacturaCabecera()


            };

            if (FcID != 0)
            {
                oCabeceraVM.oCabecera = _DBcontext.FacturaCabeceras.Find(FcID);
            }
            else
            {
                oCabeceraVM.oCabecera.FcId = _DBcontext.FacturaCabeceras.Max(i => i.FcId) + 1;
            }
            

            return View(oCabeceraVM);
        }

        [HttpPost]
        public IActionResult Factura_Cabecera(FacturaCabeceraVM oCabeceraVM)
        {
            
            int id = oCabeceraVM.oCabecera.FcId;

            FacturaCabecera exists = _DBcontext.FacturaCabeceras.Find(id);

            if (exists == null)
            {
                oCabeceraVM.oCabecera.FcId = 0;
                _DBcontext.FacturaCabeceras.Add(oCabeceraVM.oCabecera);

            }
            else
            {
                _DBcontext.Entry(exists).CurrentValues.SetValues(oCabeceraVM.oCabecera);
                // _DBcontext.FacturaCabeceras.Update(oCabeceraVM.oCabecera);
            }
            _DBcontext.SaveChanges();


            return RedirectToAction("IndexFC","FC");

        }

        [HttpGet]
        public IActionResult Factura_Eliminar(int FcID)
        {
            FacturaCabecera oFacturaCabecera = _DBcontext.FacturaCabeceras.Find(FcID);
                //.Include(fc => fc.Cli);

            return View(oFacturaCabecera);
        }

        [HttpPost]

        public IActionResult Factura_Eliminar(FacturaCabecera oFacturaCabecera)
        {
            _DBcontext.FacturaCabeceras.Remove(oFacturaCabecera);

            _DBcontext.SaveChanges();

            return RedirectToAction("IndexFC", "FC");
        }


    }
}
