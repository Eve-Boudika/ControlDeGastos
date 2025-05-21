using System.Data.Entity;

namespace ControlDeGastos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }

    }
}