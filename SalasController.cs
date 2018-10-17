using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class SalasController : Controller
    {
        private CineColEntities db = new CineColEntities();

        // GET: Salas
        public ActionResult Index()
        {
            return View(db.Salas.ToList());
        }

        // GET: Salas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salas salas = db.Salas.Find(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            return View(salas);
        }

        // GET: Salas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroSala,Capacidad,Comfort,NivelSonido,CalidadProyeccion")] Salas salas)
        {
            if (ModelState.IsValid)
            {
                db.Salas.Add(salas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salas);
        }

        // GET: Salas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salas salas = db.Salas.Find(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            return View(salas);
        }

        // POST: Salas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroSala,Capacidad,Comfort,NivelSonido,CalidadProyeccion")] Salas salas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salas);
        }

        // GET: Salas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salas salas = db.Salas.Find(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            return View(salas);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salas salas = db.Salas.Find(id);
            db.Salas.Remove(salas);
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
