using Finanzas.Controllers;
using Finanzas.Models;
using Finanzas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace FinanzasTest
{
    [TestFixture]
    public class Tests
    {

        // 
        [Test]
        public void RegistrarCuentaPropiaSoles()
        {
            var repo = new Mock<IHomeRepositorio>();
            repo.Setup(o => o.SaveCuenta(
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "BCP DEBITO",
                    IdCategoria = 1,
                    IdMoneda = 1,
                    Saldo = 500,
                    Limite = 0
                }));

            var controller = new HomeController(repo.Object);
            var view = controller.Registrar(new Cuenta()) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void RegistrarCuentaCreditoDolares()
        {
            var repo = new Mock<IHomeRepositorio>();
            repo.Setup(o => o.SaveCuenta(
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "BCP Credito",
                    IdCategoria = 2,
                    IdMoneda = 2,
                    Saldo = 0,
                    Limite = 500
                }));

            var controller = new HomeController(repo.Object);
            var view = controller.Registrar(new Cuenta()) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        // 
        [Test]
        public void RegistrarGastoPropia()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "BCP DEBITO",
                    IdCategoria = 1,
                    IdMoneda = 1,
                    Saldo = 500,
                    Limite = 0
                });
            repo.Setup(o => o.SaveTransaccion(
                new Transaccion()
                {
                    Id = 1,
                    Descripcion = "Perdi",
                    Fecha = System.DateTime.Now,
                    IdCuenta = 1,
                    IdTipo = 2,
                    Monto = 100
                }));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            {
                Id = 1,
                Descripcion = "Perdi",
                Fecha = System.DateTime.Now,
                IdCuenta = 1,
                IdTipo = 2,
                Monto = 100
            }) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        // 

        [Test]
        public void RegistrarGastoPropiaSaldoLimite()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "BCP DEBITO",
                    IdCategoria = 1,
                    IdMoneda = 1,
                    Saldo = 500,
                    Limite = 0
                });
            repo.Setup(o => o.SaveTransaccion(
                new Transaccion()
                {
                    Id = 1,
                    Descripcion = "Perdi",
                    Fecha = System.DateTime.Now,
                    IdCuenta = 1,
                    IdTipo = 2,
                    Monto = 800
                }));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            {
                Id = 1,
                Descripcion = "Perdi",
                Fecha = System.DateTime.Now,
                IdCuenta = 1,
                IdTipo = 2,
                Monto = 800
            }) as ViewResult;

            Assert.AreEqual("Crear", view.ViewName);
        }

        [Test]
        public void RegistrarGastoCreditoLimite()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "BCP Credito",
                    IdCategoria = 2,
                    IdMoneda = 1,
                    Saldo = 500,
                    Limite = 0
                });
            repo.Setup(o => o.SaveTransaccion(
                new Transaccion()
                {
                    Id = 1,
                    Descripcion = "Perdi",
                    Fecha = System.DateTime.Now,
                    IdCuenta = 1,
                    IdTipo = 2,
                    Monto = 800
                }));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            {
                Id = 1,
                Descripcion = "Perdi",
                Fecha = System.DateTime.Now,
                IdCuenta = 1,
                IdTipo = 2,
                Monto = 800
            }) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        // 
        [Test]
        public void RegistrarIngreso()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "BCP Debito",
                    IdCategoria = 1,
                    IdMoneda = 1,
                    Saldo = 500,
                    Limite = 0
                });
            repo.Setup(o => o.SaveTransaccion(
                new Transaccion()
                {
                    Id = 1,
                    Descripcion = "Gane",
                    Fecha = System.DateTime.Now,
                    IdCuenta = 1,
                    IdTipo = 1,
                    Monto = 800
                }));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            {
                Id = 1,
                Descripcion = "Gane",
                Fecha = System.DateTime.Now,
                IdCuenta = 1,
                IdTipo = 1,
                Monto = 800
            }) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        // 
        [Test]
        public void VistaSaldoDOLARSOLES()
        {
            var repo = new Mock<IHomeRepositorio>();
            repo.Setup(o => o.GetCuentas()).Returns(new List<Cuenta>());
            repo.Setup(o => o.GetSaldo(1)).Returns(100m);
            repo.Setup(o => o.GetSaldo(2)).Returns(500m);

            var saldoSoles = repo.Object.GetSaldo(1);
            var saldoDolares = repo.Object.GetSaldo(2);

            var controller = new HomeController(repo.Object);
            var view = controller.Index() as ViewResult;

            Assert.AreEqual(100, saldoSoles);
            Assert.AreEqual(500, saldoDolares);
            Assert.AreEqual("Index", view.ViewName);
        }

        // 
        [Test]
        public void TotalSoles()
        {
            var repo = new Mock<IHomeRepositorio>();
            repo.Setup(o => o.GetCuentas()).Returns(new List<Cuenta>());
            repo.Setup(o => o.GetSaldo(1)).Returns(100m);
            repo.Setup(o => o.GetSaldo(2)).Returns(100m);

            var saldoSoles = repo.Object.GetSaldo(1);
            var saldoDolares = repo.Object.GetSaldo(2) * 3.88m;

            var controller = new HomeController(repo.Object);
            var view = controller.Index() as ViewResult;
            
            Assert.AreEqual(488, saldoSoles + saldoDolares);
            Assert.AreEqual("Index", view.ViewName);
        }        
    }
}