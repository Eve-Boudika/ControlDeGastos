using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("Presupuestos")]
    public class Presupuesto
    {
        public int Id { get; set; }
        public DateTime Año { get; set; }
        public DateTime Mes { get; set; }
        public int Monto { get; set; }
       
    }
}