using Finanzas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finanzas.Repositorio
{
    public interface IHomeRepositorio
    {
        List<Cuenta> GetCuentas();
        decimal GetSaldo(int tipo);
        void SaveCuenta(Cuenta cuenta);
    }

    public class HomeRepositorio : IHomeRepositorio
    {
        private readonly ContextoFinanzas contexto;

        public HomeRepositorio(ContextoFinanzas contexto)
        {
            this.contexto = contexto;
        }

        public List<Cuenta> GetCuentas()
        {
            return contexto.Cuentas.ToList();
        }

        public decimal GetSaldo(int tipo)
        {
            var saldo = contexto.Cuentas
                .Where(o => o.IdMoneda == tipo)
                .ToList();
            return saldo.Sum(o => o.Saldo);
        }

        public void SaveCuenta(Cuenta cuenta)
        {
            contexto.Cuentas.Add(cuenta);
            contexto.SaveChanges();
        }
    }
}
