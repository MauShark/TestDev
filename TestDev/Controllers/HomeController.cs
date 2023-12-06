using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TestDev.Models;
using TestDev.Models.ViewModels;
using System.Linq;

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
            string Cuit = oClienteVM.oCliente.Cuit;


            if (oClienteVM.oCliente.CliId == 0)
            {
                var CuitExists = _DBcontext.Clientes.FirstOrDefault(c=>c.Cuit == Cuit);
                if (CuitExists is null) { 

                    _DBcontext.Clientes.Add(oClienteVM.oCliente);
                }else
                {
                    ViewBag.ErrorMessage = "El cuit ingresado ya pertenece a un cliente.";
                    return View("Cliente_Detalle", oClienteVM);
                }

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

            try
            {
                _DBcontext.Database.ExecuteSqlRaw("EXEC FC_Cliente_delete @CliId", new SqlParameter("@CliId", oCliente.CliId));
            }catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el stored procedure: {ex.Message}");
                return RedirectToAction("Eliminar", "Home");
            }


            _DBcontext.Clientes.Remove(oCliente);

            _DBcontext.SaveChanges();
            
            return RedirectToAction("Index","Home");
        }

        [HttpGet]

        
        public IActionResult busqueda(string condition)
        {
            if (condition == null)
            {
                return View("busqueda");
            }

            List<ClienteVM> list = new List<ClienteVM>();

            
            var clientes = _DBcontext.Clientes
                .Where(c => c.RazonSocial.Contains(condition))
                .ToList();

            foreach (var cliente in clientes)
            {
                list.Add(  new ClienteVM { oCliente = cliente });
            }

            return View("Busqueda", list);
        }

        [HttpPost]


        public IActionResult busqueda_deshabilitar(List<int> clientesSeleccionados)
        {
            if (clientesSeleccionados.Count == 0)
            {
                ViewBag.ErrorMessage = "no se seleccionaron clientes";
                return View("busqueda");
            }

            foreach (var clientId in clientesSeleccionados)
            {
                var cliente = _DBcontext.Clientes.Find(clientId);

                if (cliente != null)
                {
                    cliente.Deshabilitado = true;
                    _DBcontext.Clientes.Update(cliente);
                }
            }

            _DBcontext.SaveChanges();
            ViewBag.SuccessMessage = "Clientes deshabilitados correctamente.";

            return View("busqueda");
        }

    }


    
}
