using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstacionamientoMVC.Models;

namespace EstacionamientoMVC.Controllers
{
    public class VehiculoController : Controller
    {
        private EstacionamientoEntities db = new EstacionamientoEntities();

        //
        // GET: /Vehiculo/

        public ActionResult Index()
        {
            var vehiculo = db.Vehiculo.Include(v => v.TipoDeVehiculo);
            ViewBag.pat = new SelectList(db.Vehiculo, "patente", "patente");
            return View(vehiculo.ToList());
        }

        // le agregamos un post, porque le agregamos lo de filtro
        // POST
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            ViewBag.pat = new SelectList(db.Vehiculo, "patente", "patente");

            string busquedaVehiculo = fm["pat"];

            if( fm["btnFiltro"] != null )
            {
                if (busquedaVehiculo == "")
                {
                    return View(db.Vehiculo.Include(v => v.TipoDeVehiculo).ToList());
                }
                return View(db.Vehiculo.Where(v => v.patente == busquedaVehiculo));
            }
            else
            {
                string busquedaEstacionado = fm["est"];

                switch (busquedaEstacionado)
                {
                    case "estacionados":
                        return View(db.Vehiculo.Where(v => v.Registros.Where(r => r.patente == v.patente && r.fechaEgreso == null).Count() > 0).ToList());

                    case "noestacionados":
                        return View(db.Vehiculo.Where(v => v.Registros.Where(r => r.patente == v.patente && r.fechaEgreso == null).Count() == 0).ToList());

                    default:
                        return View(db.Vehiculo.Include(v => v.TipoDeVehiculo).ToList());
                }
            }
        }

        //
        // GET: /Vehiculo/Details/5

        public ActionResult Details(string id = null)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Create

        public ActionResult Create()
        {
            ViewBag.idTipo = new SelectList(db.TipoDeVehiculo, "idTipo", "nombre");
            return View();
        }

        //
        // POST: /Vehiculo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipo = new SelectList(db.TipoDeVehiculo, "idTipo", "nombre", vehiculo.idTipo);
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Edit/5

        public ActionResult Edit(string id = null)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo = new SelectList(db.TipoDeVehiculo, "idTipo", "nombre", vehiculo.idTipo);
            return View(vehiculo);
        }

        //
        // POST: /Vehiculo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(db.TipoDeVehiculo, "idTipo", "nombre", vehiculo.idTipo);
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Delete/5

        public ActionResult Delete(string id = null)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }
        
        //
        // POST: /Vehiculo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);

            Registros reg = db.Registros.FirstOrDefault(r => r.fechaEgreso == null && r.patente == vehiculo.patente);

            if( reg != null )
            {
                reg.Parcela.libre = true;
            }

            db.Vehiculo.Remove(vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}