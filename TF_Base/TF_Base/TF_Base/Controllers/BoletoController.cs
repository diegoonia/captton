using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using TF_Base.Models;

namespace TF_Base.Controllers
{
    public class BoletoController : Controller
    {
        private SistemaVuelosEntities db = new SistemaVuelosEntities();

        //
        // GET: /Boleto/
        [Authorize (Roles="Empleado")]
        public ActionResult IndexEmpleado()
        {
            int usuario = WebSecurity.CurrentUserId;
            Empleado emp = db.Empleado.FirstOrDefault(e => e.idUsuario == usuario);

            ViewBag.filtroIDVuelo = new SelectList(db.Vuelo, "idVuelo", "idVuelo");

            var boletos = db.Boleto.ToList();

            if ( emp.AerolineaID != null )
            {
                boletos = db.Boleto.Where(b => b.Vuelo.AerolineaID == emp.AerolineaID).ToList();
                var filtroBoleto = db.Vuelo.Where(v => v.AerolineaID == emp.AerolineaID);
                ViewBag.filtroIDVuelo = new SelectList(filtroBoleto, "idVuelo", "idVuelo");
            }
            
            return View(boletos);
        }


        [Authorize(Roles = "Empleado")]
        [HttpPost]
        public ActionResult IndexEmpleado(FormCollection fm)
        {
            int usuario = WebSecurity.CurrentUserId;
            Empleado emp = db.Empleado.FirstOrDefault(e => e.idUsuario == usuario);
            ViewBag.filtroIDVuelo = new SelectList(db.Vuelo, "idVuelo", "idVuelo");
            var boletos = db.Boleto.ToList();
            
            if (emp.AerolineaID != null)
            { //Si pertenece a una aerolínea, en el viewbag pongo boletos de vuelos de su aerolinea y cargo la lista con boletos de su aerolínea
                boletos = db.Boleto.Where(b => b.Vuelo.AerolineaID == emp.AerolineaID).ToList();
                var filtroBoleto = db.Vuelo.Where(v => v.AerolineaID == emp.AerolineaID);
                ViewBag.filtroIDVuelo = new SelectList(filtroBoleto, "idVuelo", "idVuelo");
            }
           
            if (fm["filtroIDVuelo"] != "") //Si eligió un vuelo del filtro
            {
                int idVueloSeleccionado = int.Parse(fm["filtroIDVuelo"]);
                boletos = db.Boleto.Where(b => b.idVuelo == idVueloSeleccionado).ToList();
            }
            
            return View(boletos);
        }

        //
        // GET: /Boleto/
        [Authorize(Roles = "Cliente")]
        public ActionResult HistorialCliente()
        {
            int usuario = WebSecurity.CurrentUserId;
            Cliente cliente = db.Cliente.FirstOrDefault(c => c.idUsuario == usuario);

            var boletos = db.Boleto.Where(b => b.dni == cliente.dni && b.Vuelo.fecha < DateTime.Now).ToList();

            return View(boletos);
        }

        [Authorize(Roles = "Cliente")]
        public ActionResult VuelosActivos()
        {
            int usuario = WebSecurity.CurrentUserId;
            Cliente cliente = db.Cliente.FirstOrDefault(c => c.idUsuario == usuario);

            var boletos = db.Boleto.Where(b => b.dni == cliente.dni && b.Vuelo.fecha >= DateTime.Now && (b.idEstado==1 || b.idEstado==2)).ToList();

            return View(boletos);
        }

        // GET: /Boleto/Reservar
        [Authorize(Roles = "Empleado")]
        public ActionResult Reservar(int id = 0)
        {
            Vuelo vuelo = db.Vuelo.FirstOrDefault(v => v.idVuelo == id);

            ViewBag.dni = new SelectList(db.Cliente, "dni", "dni");
            return View(vuelo);
        }

        //
        // POST: /Boleto/Reservar
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Empleado")]
        public ActionResult Reservar(Vuelo vuelo)
        {
            Boleto boleto = new Boleto();

            if (ModelState.IsValid)
            {
                boleto.idVuelo = vuelo.idVuelo;
                boleto.idEstado = 1;
                boleto.dni = int.Parse(Request["dni"]);

                Vuelo vuelo2 = db.Vuelo.First(v => v.idVuelo == vuelo.idVuelo);
                vuelo2.cantOcupados++;

                db.Boleto.Add(boleto);
                db.SaveChanges();

                return RedirectToAction("../Vuelo/IndexEmpleado");
            }

            ViewBag.dni = new SelectList(db.Cliente, "dni", "dni", boleto.dni);
            return View(boleto);
        }

        //
        // GET: /Boleto/Cancelar/5
        [Authorize(Roles = "Empleado")]
        public ActionResult Cancelar(int id = 0)
        {
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }

            return View(boleto);
        }

        //
        // POST: /Boleto/Cancelar/5

        [HttpPost, ActionName("Cancelar")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Empleado")]
        public ActionResult CancelarConfirmado(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            boleto.idEstado = 3;
            boleto.Vuelo.cantOcupados--;
            db.SaveChanges();
            return RedirectToAction("IndexEmpleado");
        }


        //
        // GET: /Boleto/Details/5
        [Authorize(Roles = "Empleado")]
        public ActionResult Confirmar(int id = 0)
        {
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }
            return View(boleto);
        }

        [HttpPost, ActionName("Confirmar")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Empleado")]
        public ActionResult ConfirmarConfirmado(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            boleto.idEstado = 2;
            db.SaveChanges();
            return RedirectToAction("IndexEmpleado");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



    }
}