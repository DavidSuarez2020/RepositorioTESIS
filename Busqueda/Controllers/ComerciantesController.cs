using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Busqueda.Models;

namespace Busqueda.Controllers
{
    public class ComerciantesController : Controller
    {
        private ComerciantesDBContext db = new ComerciantesDBContext();

        // GET: Comerciantes
        public ActionResult Index(string cadena)
        {
            var Comerciantes = from cr in db.Comerciantes select cr;
            
            if (!String.IsNullOrEmpty(cadena))
            {
               Comerciantes = Comerciantes.Where(c => c.Nombres.Contains(cadena) || c.Apellidos.Contains(cadena));
            }
            return View(Comerciantes);
            //return View(db.Comerciantes.ToList());
        }

        // GET: Comerciantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciantes comerciantes = db.Comerciantes.Find(id);
            if (comerciantes == null)
            {
                return HttpNotFound();
            }
            return View(comerciantes);
        }

        // GET: Comerciantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comerciantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombres,Apellidos,Cedula,Capacitacion,Institucion")] Comerciantes comerciantes)
        {
            if (ModelState.IsValid)
            {
                db.Comerciantes.Add(comerciantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comerciantes);
        }

        // GET: Comerciantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciantes comerciantes = db.Comerciantes.Find(id);
            if (comerciantes == null)
            {
                return HttpNotFound();
            }
            return View(comerciantes);
        }

        // POST: Comerciantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombres,Apellidos,Cedula,Capacitacion,Institucion")] Comerciantes comerciantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comerciantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comerciantes);
        }

        // GET: Comerciantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciantes comerciantes = db.Comerciantes.Find(id);
            if (comerciantes == null)
            {
                return HttpNotFound();
            }
            return View(comerciantes);
        }

        // POST: Comerciantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comerciantes comerciantes = db.Comerciantes.Find(id);
            db.Comerciantes.Remove(comerciantes);
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
