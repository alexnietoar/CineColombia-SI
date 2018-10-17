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
    public class HorariosController : Controller
    {
        private CineColEntities db = new CineColEntities();

        // GET: Horarios
        public ActionResult Index()
        {
            var horarios = db.Horarios.Include(h => h.Acomodador).Include(h => h.Peliculas).Include(h => h.Salas);
            return View(horarios.ToList());
        }

        // GET: Horarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            ViewBag.id_acomodador = new SelectList(db.Acomodador, "id_acomodador", "Nombre");
            ViewBag.Titulo = new SelectList(db.Peliculas, "Titulo", "Genero");
            ViewBag.NumeroSala = new SelectList(db.Salas, "NumeroSala", "Comfort");
            return View();
        }

        // POST: Horarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fecha,NumeroSala,Titulo,id_acomodador,id_horario")] Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_acomodador = new SelectList(db.Acomodador, "id_acomodador", "Nombre", horarios.id_acomodador);
            ViewBag.Titulo = new SelectList(db.Peliculas, "Titulo", "Genero", horarios.Titulo);
            ViewBag.NumeroSala = new SelectList(db.Salas, "NumeroSala", "Comfort", horarios.NumeroSala);
            return View(horarios);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_acomodador = new SelectList(db.Acomodador, "id_acomodador", "Nombre", horarios.id_acomodador);
            ViewBag.Titulo = new SelectList(db.Peliculas, "Titulo", "Genero", horarios.Titulo);
            ViewBag.NumeroSala = new SelectList(db.Salas, "NumeroSala", "Comfort", horarios.NumeroSala);
            return View(horarios);
        }

        // POST: Horarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fecha,NumeroSala,Titulo,id_acomodador,id_horario")] Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_acomodador = new SelectList(db.Acomodador, "id_acomodador", "Nombre", horarios.id_acomodador);
            ViewBag.Titulo = new SelectList(db.Peliculas, "Titulo", "Genero", horarios.Titulo);
            ViewBag.NumeroSala = new SelectList(db.Salas, "NumeroSala", "Comfort", horarios.NumeroSala);
            return View(horarios);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Horarios horarios = db.Horarios.Find(id);
            db.Horarios.Remove(horarios);
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
