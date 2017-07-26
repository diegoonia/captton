using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;

namespace TF_Base.Controllers
{
    public class ClienteController : Controller
    {
        private SistemaVuelosEntities db = new SistemaVuelosEntities();

        //
        // GET: /Cliente/
        [Authorize(Roles = "Empleado")]
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Usuario);
            return View(cliente.ToList());
        }

        //
        // GET: /Alta/Create
        [Authorize(Roles = "Empleado")]
        public ActionResult Alta()
        {
            return View();
        }

        //
        // POST: /Alta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Empleado")]
        public ActionResult Alta(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if ( db.Cliente.Where(c => c.dni == cliente.dni).Count() <= 0 ) //Si no existe el cliente
                {
                    cliente.idUsuario = null; //le pongo usuario en nulo y lo agrego a la BD
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }

            return View(cliente);
        }
    }
}