using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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