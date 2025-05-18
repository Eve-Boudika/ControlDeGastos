using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            var lista = db.Gastos.Include(g => g.Categoria).ToList(); // Incluyo la categoría para evitar lazy loading
            return View(lista);
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
        public ActionResult Edit([Bind(Include = "Id,Monto,Detalle,Fecha,CategoriaId")] Gasto gasto)
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
    }
}
