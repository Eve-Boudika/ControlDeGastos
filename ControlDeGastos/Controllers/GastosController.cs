using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlDeGastos.Models;

namespace ControlDeGastos.Controllers
{
    public class GastosController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var lista = db.Gastos.ToList();
            return View(lista);
        }
    }
}