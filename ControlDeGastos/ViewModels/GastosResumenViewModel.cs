using System;
using System.Collections.Generic;
using ControlDeGastos.Models;

namespace ControlDeGastos.ViewModels
{
    public class GastosResumenViewModel
    {
        public List<Gasto> Gastos { get; set; }
        public int TotalGastado { get; set; }
        public int? MontoPresupuesto { get; set; }
        public DateTime Periodo { get; set; }
        public string CategoriaSeleccionada { get; set; }
        public int? CategoriaSeleccionadaId { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public int MontoDisponible
        {
            get
            {
                if (MontoPresupuesto.HasValue)
                {
                    return MontoPresupuesto.Value - TotalGastado;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}