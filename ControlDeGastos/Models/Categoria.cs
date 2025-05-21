using System.Collections.Generic;

namespace ControlDeGastos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación con gastos
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}