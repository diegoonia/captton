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
    public class VueloController : Controller
    {
        private SistemaVuelosEntities db = new SistemaVuelosEntities();

        //
        // GET: /Vuelo/IndexEncargado
        [Authorize(Roles = "Encargado")]
        public ActionResult IndexEncargado()
        {
            var vuelo = db.Vuelo.Include(v => v.Conexiones);
            ViewBag.filtroAero = new SelectList(db.Aerolineas, "AerolineaID", "Info");

            int usuario = WebSecurity.CurrentUserId; //Guardo el id del usuario actual
            Session["aeroEncargado"] = db.Encargado.First(e => e.idUsuario == usuario).AerolineaID.ToString(); //Busco la aerolinea a la cual pertenece

            return View(vuelo.ToList());
        }

        [HttpPost]
        [Authorize(Roles = "Encargado")]
        public ActionResult IndexEncargado(FormCollection fm)
        {
            var vuelo = db.Vuelo.Include(v => v.Conexiones);
            ViewBag.filtroAero = new SelectList(db.Aerolineas, "AerolineaID", "Info");
            string aeroSeleccionada = fm["filtroAero"];

            int usuario = WebSecurity.CurrentUserId;
            Session["aeroEncargado"] = db.Encargado.SingleOrDefault(e => e.idUsuario == usuario).AerolineaID.ToString();

            if ( aeroSeleccionada != "" ) //Si eligió una aerolínea le hago filtro
            {
                vuelo = db.Vuelo.Where(v => v.AerolineaID == aeroSeleccionada);
            } //Si no eligió ninguna me salteo el filtro, y devuelvo todas
            
            return View(vuelo.ToList());
        }

        //
        // GET: /Vuelo/IndexEmpleado
        [Authorize(Roles = "Empleado")]
        public ActionResult IndexEmpleado()
        {
            var vuelo = db.Vuelo.Include(v => v.Conexiones);
            ViewBag.filtroAero = new SelectList(db.Aerolineas, "AerolineaID", "Info");

            int usuario = WebSecurity.CurrentUserId;

            //En aeroEmpleado pongo la aerolinea que le corresponde, para que de la vista
            //Aparezcan o desaparezcan los botones "Reservar" segun corresponda
            if (db.Empleado.SingleOrDefault(e => e.idUsuario == usuario).AerolineaID == null)
            {
                Session["aeroEmpleado"] = "Agencia"; //Si es de agencia me deja reservar en todos
            }
            else
            { //Si no solo me deja mi aerolinea
                Session["aeroEmpleado"] = db.Empleado.SingleOrDefault(e => e.idUsuario == usuario).AerolineaID.ToString();
            }

            return View(vuelo.ToList());
        }

        //
        // POST: /Vuelo/IndexEmpleado
        [HttpPost]
        [Authorize(Roles = "Empleado")]
        public ActionResult IndexEmpleado(FormCollection fm)
        {
            var vuelo = db.Vuelo.Include(v => v.Conexiones);
            ViewBag.filtroAero = new SelectList(db.Aerolineas, "AerolineaID", "Info");

            string aeroSeleccionada = fm["filtroAero"];

            int usuario = WebSecurity.CurrentUserId;

            if (db.Empleado.SingleOrDefault(e => e.idUsuario == usuario).AerolineaID == null)
            {
                Session["aeroEmpleado"] = "Agencia";
            }
            else
            {
                Session["aeroEmpleado"] = db.Empleado.SingleOrDefault(e => e.idUsuario == usuario).AerolineaID.ToString();
            }

            if (aeroSeleccionada != "") //Si eligió una aerolínea le hago filtro
            {
                vuelo = db.Vuelo.Where(v => v.AerolineaID == aeroSeleccionada);
            } //Si no eligió ninguna me salteo el filtro, y devuelvo todas

            return View(vuelo.ToList());
        }

        [Authorize(Roles = "Encargado")]
        public ActionResult Create()
        {
            int usuario = WebSecurity.CurrentUserId;
            List<Conexiones> listaConexiones= db.Conexiones.Where(c => c.AerolineaID == db.Encargado.FirstOrDefault(e => e.idUsuario == usuario).AerolineaID).ToList();

            ViewBag.ConexionID = new SelectList(listaConexiones, "ConexionID", "Info");
            return View();
        }

        //
        // POST: /Vuelo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Encargado")]
        public ActionResult Create(Vuelo vuelo)
        {
            int usuario = WebSecurity.CurrentUserId;
            List<Conexiones> listaConexiones= db.Conexiones.Where(c => c.AerolineaID == db.Encargado.FirstOrDefault(e => e.idUsuario == usuario).AerolineaID).ToList();

            if (ModelState.IsValid)
            {
                vuelo.cantOcupados = 0;
                vuelo.AerolineaID = db.Encargado.SingleOrDefault(e => e.idUsuario == WebSecurity.CurrentUserId).AerolineaID;

                //Verifico que no haya ningún vuelo que tenga la misma conexion y misma fecha
                if ( db.Vuelo.Where(v => v.ConexionID == vuelo.ConexionID && v.fecha == vuelo.fecha).Count() > 0)
                {
                    ModelState.AddModelError("", "Ya existe un vuelo en esa fecha");
                    return View(); //Si lo hay, vuelve al index y no guarda ese vuelo
                }

                db.Vuelo.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("IndexEncargado");
            }

            ViewBag.ConexionID = new SelectList(listaConexiones, "ConexionID", "Info");
            return View(vuelo);
        }

        //
        // GET: /Vuelo/Delete/5
        [Authorize(Roles = "Encargado")]
        public ActionResult Delete(int id = 0)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            if (vuelo == null)
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        //
        // POST: /Vuelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Encargado")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            db.Vuelo.Remove(vuelo);
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