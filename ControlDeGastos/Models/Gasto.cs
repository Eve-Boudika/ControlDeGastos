using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeGastos.Models
{
    [Table("Gastos")]
    public class Gasto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Monto { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}