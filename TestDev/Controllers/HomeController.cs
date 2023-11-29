using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TestDev.Models;
using TestDev.Models.ViewModels;

namespace TestDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly FacturadorDBContext _DBcontext;

        public HomeController(FacturadorDBContext context)
        {
            _DBcontext = context;
        }

        public IActionResult Index()
        {
            //List<Cliente> list = _DBcontext.Clientes.ToList();
            List<Cliente> list = _DBcontext.Clientes.Include(c => c.FacturaCabeceras).ToList();

            return View(list);
        }


        [HttpGet]
        public IActionResult Cliente_Detalle(int CliId)
        {
            ClienteVM oClienteVM = new ClienteVM() {

                oCliente = new Cliente()
            
            
            };

            if(CliId != 0)
            {
                oClienteVM.oCliente = _DBcontext.Clientes.Find(CliId);
            }

            return View(oClienteVM);
        }


        [HttpPost]
        public IActionResult Cliente_Detalle(ClienteVM oClienteVM)
        {
            if(oClienteVM.oCliente.CliId == 0)
            {
                _DBcontext.Clientes.Add(oClienteVM.oCliente);


            }
            else
            {
                _DBcontext.Clientes.Update(oClienteVM.oCliente);
            }
            _DBcontext.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int CliId)
        {
           Cliente oCliente = _DBcontext.Clientes.Find(CliId);

            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(Cliente oCliente)
        {
            _DBcontext.Clientes.Remove(oCliente);

            _DBcontext.SaveChanges();
            
            return RedirectToAction("Index","Home");
        }




    }


    
}
