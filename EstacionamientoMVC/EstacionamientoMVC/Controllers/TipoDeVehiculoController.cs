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
    public class TipoDeVehiculoController : Controller
    {
        private EstacionamientoEntities db = new EstacionamientoEntities();

        //
        // GET: /TipoDeVehiculo/

        public ActionResult Index()
        {
            return View(db.TipoDeVehiculo.ToList());
        }

        //
        // GET: /TipoDeVehiculo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoDeVehiculo tipodevehiculo = db.TipoDeVehiculo.Find(id);
            if (tipodevehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipodevehiculo);
        }

        //
        // POST: /TipoDeVehiculo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeVehiculo tipodevehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodevehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodevehiculo);
        }

    }
}