using System;
using System.ComponentModel.DataAnnotations;
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

        public string Detalle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }


        // Relación con Categoría
        [Required]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}