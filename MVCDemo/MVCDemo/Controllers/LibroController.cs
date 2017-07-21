using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class LibroController : Controller
    {
        private LibrosEntities db = new LibrosEntities();

        //
        // GET: /Libro/

        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Editorial);
            ViewBag.edi = new SelectList(db.Editorial, "idEditorial", "nombre");
            ViewBag.gen = new SelectList(db.Genero, "idGenero", "nombre");
            return View(libro.ToList());
        }

        // le agregamos un post, porque le agregamos lo de filtro
        // POST
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            ViewBag.edi = new SelectList(db.Editorial, "idEditorial", "nombre");
            ViewBag.gen = new SelectList(db.Genero, "idGenero", "nombre");

            if ( Request["btnEdi"] != null )
            {
                string busquedaEditorial = fm["edi"];

                if (busquedaEditorial == "")
                {
                    return View(db.Libro.ToList());
                }

                int idBusqueda = int.Parse(busquedaEditorial);
                return View(db.Libro.Where(l => l.idEditorial == idBusqueda));
            }

            if ( Request["btnGen"] != null )
            {
                string busquedaGenero = fm["gen"];

                if (busquedaGenero == "")
                {
                    return View(db.Libro.ToList());
                }

                int idBusqueda = int.Parse(busquedaGenero);
                Genero gen = db.Genero.Find(idBusqueda);
                return View(gen.Libro.ToList());
            }

            return View(db.Libro.ToList());
        }

        //
        // GET: /Libro/Details/5

        public ActionResult Details(string id = null)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // GET: /Libro/Create

        public ActionResult Create()
        {
            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre");
            return View();
        }

        //
        // POST: /Libro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro libro, FormCollection fm) //fm es una coleccion del formulario
        {           
            
            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre", libro.idEditorial);

            if (ModelState.IsValid)
            {
                if ( db.Libro.SingleOrDefault(l => l.ISBN == libro.ISBN) != null )
                {
                    return View(libro);
                }

                Autor autor = new Autor();
                Genero genero = new Genero();
                string nombreAutor = Request["aut"];
                string nombreGenero = fm["gen"]; //es lo mismo que hacer request

                autor = db.Autor.SingleOrDefault(a => a.nombre == nombreAutor);
                if ( autor == null )
                {
                    autor = new Autor();
                    autor.nombre = nombreAutor;
                    db.Autor.Add(autor);
                }

                genero = db.Genero.SingleOrDefault(g => g.nombre == nombreGenero);
                if ( genero == null )
                {
                    genero = new Genero();
                    genero.nombre = nombreGenero;
                    db.Genero.Add(genero);
                }

                libro.Autor.Add(autor);
                libro.Genero.Add(genero);

                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libro);
        }

        //
        // GET: /Libro/Edit/5

        public ActionResult Edit(string id = null)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre", libro.idEditorial);
            return View(libro);
        }

        //
        // POST: /Libro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre", libro.idEditorial);
            return View(libro);
        }

        //
        // GET: /Libro/Delete/5

        public ActionResult Delete(string id = null)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // POST: /Libro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Libro libro = db.Libro.Find(id);
            libro.Genero.Clear();
            libro.Autor.Clear();
            db.Libro.Remove(libro);
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