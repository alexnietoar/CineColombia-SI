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
    public class AcomodadorsController : Controller
    {
        private CineColEntities db = new CineColEntities();

        // GET: Acomodadors
        public ActionResult Index()
        {
            return View(db.Acomodador.ToList());
        }

        // GET: Acomodadors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acomodador acomodador = db.Acomodador.Find(id);
            if (acomodador == null)
            {
                return HttpNotFound();
            }
            return View(acomodador);
        }

        // GET: Acomodadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acomodadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_acomodador,Nombre,Apelllido,Cedula,Tipo_contrato,Telefono")] Acomodador acomodador)
        {
            if (ModelState.IsValid)
            {
                db.Acomodador.Add(acomodador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acomodador);
        }

        // GET: Acomodadors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acomodador acomodador = db.Acomodador.Find(id);
            if (acomodador == null)
            {
                return HttpNotFound();
            }
            return View(acomodador);
        }

        // POST: Acomodadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_acomodador,Nombre,Apelllido,Cedula,Tipo_contrato,Telefono")] Acomodador acomodador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acomodador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acomodador);
        }

        // GET: Acomodadors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acomodador acomodador = db.Acomodador.Find(id);
            if (acomodador == null)
            {
                return HttpNotFound();
            }
            return View(acomodador);
        }

        // POST: Acomodadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Acomodador acomodador = db.Acomodador.Find(id);
            db.Acomodador.Remove(acomodador);
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
