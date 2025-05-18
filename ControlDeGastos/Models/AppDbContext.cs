using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlDeGastos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Gasto> Gastos { get; set; }

    }
}