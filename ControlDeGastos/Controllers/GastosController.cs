using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ControlDeGastos.Models;
using ControlDeGastos.ViewModels;

namespace ControlDeGastos.Controllers
{
    public class GastosController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public async Task<ActionResult> Index(int? mes, int? anio)
        {
            var ahora = DateTime.Now;
            int mesSeleccionado = mes ?? ahora.Month;
            int anioSeleccionado = anio ?? ahora.Year;

            DateTime periodoSeleccionado = new DateTime(anioSeleccionado, mesSeleccionado, 1);

            var gastosDelMes = db.Gastos
                .Include(g => g.Categoria)
                //.Where(g => g.Fecha.Month == mesSeleccionado && g.Fecha.Year == anioSeleccionado)
                .Where(g => g.Fecha.Year == periodoSeleccionado.Year && g.Fecha.Month == periodoSeleccionado.Month)
                .OrderByDescending(g => g.Fecha)
                .ToList();

            int totalGastado = gastosDelMes.Sum(g => g.Monto);

            //var presupuesto = await db.Presupuestos
            //    .FirstOrDefaultAsync(p => p.Mes.Month == mesSeleccionado && p.Año == anioSeleccionado);

            var presupuesto = await db.Presupuestos
            .FirstOrDefaultAsync(p => p.Mes.Month == periodoSeleccionado.Month && p.Año.Year == periodoSeleccionado.Year);
            int? montoPresupuesto = presupuesto?.Monto;

            var viewModel = new GastosResumenViewModel
            {
                Gastos = gastosDelMes,
                TotalGastado = totalGastado,
                MontoPresupuesto = montoPresupuesto,
                Periodo = periodoSeleccionado

            };

            return View(viewModel);
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                db.Gastos.Add(gasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Esto es clave para que el dropdown se recargue si hay error
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", gasto.CategoriaId);
            return View(gasto);
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Gasto gasto = db.Gastos.Find(id);
            if (gasto == null) return HttpNotFound();

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", gasto.CategoriaId);
            return View(gasto);
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Monto,Detalle,Fecha,CategoriaID")] Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", gasto.CategoriaId);
            return View(gasto);
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Gasto gasto = db.Gastos.Include(g => g.Categoria).FirstOrDefault(g => g.Id == id);
            if (gasto == null) return HttpNotFound();

            return View(gasto);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gasto gasto = db.Gastos.Find(id);
            db.Gastos.Remove(gasto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GastosDelMes()
        {
            var hoy = DateTime.Today;
            var gastosDelMes = db.Gastos
                .Include(g => g.Categoria)
                .Where(g => g.Fecha.Month == hoy.Month && g.Fecha.Year == hoy.Year)
                .ToList();

            var total = gastosDelMes.Sum(g => g.Monto);

            ViewBag.TotalGastado = total;

            return View(gastosDelMes);
        }
    }
}
