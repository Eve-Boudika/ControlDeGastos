namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ControlDeGastos.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ControlDeGastos.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ControlDeGastos.Models.AppDbContext context)
        {
        //    context.Gastoes.AddOrUpdate(
        //g => g.Id,
        //new Gasto { Monto = 1000, Categoria = "Comida", Fecha = DateTime.Now },
        //new Gasto { Monto = 500, Categoria = "Transporte", Fecha = DateTime.Now });
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //
            //  Example:
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
        }
    }
}
