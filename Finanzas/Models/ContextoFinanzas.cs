﻿using Finanzas.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Models
{
    public class ContextoFinanzas : DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transaccion> Transaccions { get; set; }

        public ContextoFinanzas(DbContextOptions<ContextoFinanzas> o) : base(o) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CuentaMap());
            modelBuilder.ApplyConfiguration(new TransaccionMap());
        }
    }
}
