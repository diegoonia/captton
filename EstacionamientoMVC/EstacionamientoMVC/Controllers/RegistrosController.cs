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
    public class RegistrosController : Controller
    {
        private EstacionamientoEntities db = new EstacionamientoEntities();

        //
        // GET: /Registros/

        public ActionResult Index()
        {
            var registros = db.Registros.Include(r => r.Parcela).Include(r => r.Vehiculo);
            return View(registros.ToList());
        }

        // le agregamos un post, porque le agregamos lo de filtro
        // POST
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            var registros = db.Registros.Include(r => r.Parcela).Include(r => r.Vehiculo);

            if (fm["calendario"] == "")
            {
                Session["total"] = '-';
                return View(registros.ToList());
            }

            DateTime calendario = DateTime.Parse(fm["calendario"]);
            registros = db.Registros.Where(r => r.fechaEgreso.Value.Year == calendario.Year
                                            && r.fechaEgreso.Value.Month == calendario.Month
                                            && r.fechaEgreso.Value.Day == calendario.Day);
            double total = 0;
            foreach (Registros item in registros.ToList())
            {
                total += item.monto.Value;
            }

            Session["total"] = total;

            return View(registros);
        }


        //
        // GET: /Registros/Details/5

        public ActionResult Details(string id = null)
        {
            DateTime myDate = DateTime.ParseExact(id, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            Registros registros = db.Registros.FirstOrDefault(f => f.fechaIngreso == myDate);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        //
        // GET: /Registros/Create
        public ActionResult Create()
        {

            List<Vehiculo> listaVehiculos = db.Vehiculo.ToList();
            List<Vehiculo> listaVehiculosNoEstacionados = new List<Vehiculo>();
            bool estaEstacionado;

            foreach (Vehiculo item in listaVehiculos)
            {
                estaEstacionado = false;

                foreach (var itemRegistro in item.Registros)
                {
                    if ( itemRegistro.fechaEgreso == null )
                    {
                        estaEstacionado = true;
                    }
                }

                if ( !estaEstacionado )
                {
                    listaVehiculosNoEstacionados.Add(item);
                }
            }

            List<Parcela> parcelasLibres = db.Parcela.Where(p => p.libre == true).ToList();

            ViewBag.idParcela = new SelectList(parcelasLibres, "idParcela", "idParcela");
            ViewBag.patente = new SelectList(listaVehiculosNoEstacionados, "patente", "patente");
            return View();
        }

        //
        // POST: /Registros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registros registros)
        {
            if (ModelState.IsValid)
            {
                registros.fechaIngreso = DateTime.Now;

                Parcela parcela = db.Parcela.Find(registros.idParcela);
                parcela.libre = false;

                db.Registros.Add(registros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Vehiculo> listaVehiculos = db.Vehiculo.ToList();
            List<Vehiculo> listaVehiculosNoEstacionados = new List<Vehiculo>();
            bool estaEstacionado;

            foreach (Vehiculo item in listaVehiculos)
            {
                estaEstacionado = false;

                foreach (var itemRegistro in item.Registros)
                {
                    if (itemRegistro.fechaEgreso == null)
                    {
                        estaEstacionado = true;
                    }
                }

                if (!estaEstacionado)
                {
                    listaVehiculosNoEstacionados.Add(item);
                }
            }

            ViewBag.idParcela = new SelectList(db.Parcela.Where(p => p.libre == true).ToList(), "idParcela", "idParcela");
            ViewBag.patente = new SelectList(listaVehiculosNoEstacionados, "patente", "patente");
            return View(registros);
        }

        //
        // GET: /Registros/Edit/5
        public ActionResult Edit(string id = null)
        {
            DateTime myDate = DateTime.ParseExact(id, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            Registros registros = db.Registros.FirstOrDefault(f => f.fechaIngreso == myDate);
            if (registros == null)
            {
                return HttpNotFound();
            }

            List<Vehiculo> listaVehiculos = db.Vehiculo.ToList();
            List<Vehiculo> listaVehiculosNoEstacionados = new List<Vehiculo>();
            bool estaEstacionado;

            foreach (Vehiculo item in listaVehiculos)
            {
                estaEstacionado = false;

                foreach (var itemRegistro in item.Registros)
                {
                    if (itemRegistro.fechaEgreso == null)
                    {
                        estaEstacionado = true;
                    }
                }

                if (!estaEstacionado)
                {
                    listaVehiculosNoEstacionados.Add(item);
                }
            }

            ViewBag.idParcela = new SelectList(db.Parcela.Where(p => p.libre == true).ToList(), "idParcela", "idParcela");
            ViewBag.patente = new SelectList(listaVehiculosNoEstacionados, "patente", "patente");

            return View(registros);
        }

        //
        // POST: /Registros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registros registros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idParcela = new SelectList(db.Parcela, "idParcela", "idParcela", registros.idParcela);
            ViewBag.patente = new SelectList(db.Vehiculo, "patente", "marca", registros.patente);
            return View(registros);
        }

        //
        // GET: /Registros/Delete/5
        public ActionResult Delete(string id = null)
        {
            DateTime myDate = DateTime.ParseExact(id, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            Registros registros = db.Registros.FirstOrDefault(f => f.fechaIngreso == myDate);
            if (registros == null)
            {
                return HttpNotFound();
            }

            Session["montoTotal"] = DateTime.Now.Subtract(registros.fechaIngreso).Hours * registros.Vehiculo.TipoDeVehiculo.tarifa;
             
            int cantVecesEstacionoEsteMes = db.Registros.Where(r => r.patente == registros.patente
                                                            && r.fechaEgreso.Value.Year == myDate.Year
                                                            && r.fechaEgreso.Value.Month == myDate.Month).Count();

            if (cantVecesEstacionoEsteMes >= 10)
            {
                double monto = (double)Session["montoTotal"];
                Session["montoTotal"] = monto * 0.85;
            }

            return View(registros);
        }

        //
        // POST: /Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id = null)
        {
            DateTime myDate = DateTime.ParseExact(id, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            Registros registros = db.Registros.FirstOrDefault(f => f.fechaIngreso == myDate);
            if (registros == null)
            {
                return HttpNotFound();
            }

            registros.fechaEgreso = DateTime.Now;

            registros.monto = (float)(DateTime.Now.Subtract(registros.fechaIngreso).Hours * registros.Vehiculo.TipoDeVehiculo.tarifa);

            int cantVecesEstacionoEsteMes = db.Registros.Where(r => r.patente == registros.patente 
                                                            && r.fechaEgreso.Value.Month == myDate.Month).Count();
            
            if( cantVecesEstacionoEsteMes >= 10 )
            {
                registros.monto *= 0.85;
            }

            Parcela parcela = db.Parcela.Find(registros.idParcela);
            parcela.libre = true;

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