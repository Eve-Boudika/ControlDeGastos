using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ControlDeGastos.Models;

namespace ControlDeGastos.Controllers
{
    public class PresupuestosController : Controller
    {
        private AppDbContext db = new AppDbContext();


        // GET: Presupuestos
        public ActionResult Index()
        {
            var presupuestos = db.Presupuestos.OrderByDescending(p => p.Año).ThenByDescending(p => p.Mes).ToList();
            return View(presupuestos);
        }

        // GET: Presupuestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presupuestos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Mes, int Año, int Monto) // Recibimos Mes y Año como int
        {
            if (ModelState.IsValid)
            {
                // Construir los objetos DateTime correctamente
                DateTime mesDateTime = new DateTime(Año, Mes, 1); // El día 1 es arbitrario, pero importante para que la fecha sea válida.

                // Evitar duplicados
                bool existe = db.Presupuestos.Any(p => p.Mes == mesDateTime && p.Año == mesDateTime); // Comparar con mesDateTime
                if (existe)
                {
                    ModelState.AddModelError("", "Ya existe un presupuesto para ese mes y año.");
                    return View(new Presupuesto { Mes = mesDateTime, Año = mesDateTime, Monto = Monto }); // Pasar los valores correctos a la vista
                }

                var presupuesto = new Presupuesto
                {
                    Mes = mesDateTime,
                    Año = mesDateTime, // Guardamos la misma fecha en ambos campos.  Si solo quieres el año en Año, puedes usar Año (int).
                    Monto = Monto
                };

                db.Presupuestos.Add(presupuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Si el ModelState no es válido, reconstruimos un objeto Presupuesto para la vista.
            return View(new Presupuesto { Mes = new DateTime(Año, Mes, 1), Año = new DateTime(Año, Mes, 1), Monto = Monto });
        }

        // GET: Presupuestos/Edit/5
        public ActionResult Edit(int id)
        {
            var presupuesto = db.Presupuestos.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: Presupuestos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mes,Año,Monto")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presupuesto);
        }

        // GET: Presupuestos/Delete/5
        public ActionResult Delete(int id)
        {
            var presupuesto = db.Presupuestos.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: Presupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var presupuesto = db.Presupuestos.Find(id);
            db.Presupuestos.Remove(presupuesto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}