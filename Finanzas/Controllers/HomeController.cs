using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Finanzas.Models;
using Microsoft.AspNetCore.Authorization;
using Finanzas.Repositorio;

namespace Finanzas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepositorio context;
        public HomeController(IHomeRepositorio context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var cuentas = context.GetCuentas();
            ViewBag.Dolares = context.GetSaldo(2);
            ViewBag.Soles = context.GetSaldo(1);
            ViewBag.Total = (ViewBag.Dolares * 3.88m) + ViewBag.Soles;

            return View("Index", cuentas);
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View("Registrar", new Cuenta());
        }

        [HttpPost]
        public ActionResult Registrar(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                if (cuenta.IdCategoria == 2)
                {
                    cuenta.Limite = cuenta.Saldo;
                    cuenta.Saldo = 0;
                }
                if (cuenta.Saldo != 0 && cuenta.IdCategoria != 2)
                {
                    cuenta.Limite = 0;
                    cuenta.Transaccions = new List<Transaccion>
                    {
                        new Transaccion
                        {
                            Fecha = DateTime.Now,
                            IdTipo = 1,
                            Monto = cuenta.Saldo,
                            Descripcion = "Monto Inicial"
                        }
                    };
                }
                context.SaveCuenta(cuenta);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Registrar", cuenta);
            }
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
