using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TF_Base.Models;
using WebMatrix.WebData;

namespace mvcStore.Controllers
{
    public class AccountController : Controller
    {
        private SistemaVuelosEntities db = new SistemaVuelosEntities();
        //
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool res = WebSecurity.Login(login.UserName, login.Password, login.RememberMe);
                if (res)
                {
                    //Cuando ingresa un usuario, reviso todos los boletos con fecha anterior a hoy y que esté reservado, los cancelo.
                    List<Boleto> listaBoletos = db.Boleto.Where(b => b.Vuelo.fecha < DateTime.Now && b.idEstado == 1).ToList();
                    foreach (Boleto item in listaBoletos)
                    {
                        item.idEstado = 3;
                    }
                    db.SaveChanges();

                    int idUsuario = db.Usuario.SingleOrDefault(u => u.nombre == login.UserName).idUsuario;
                    Empleado emp = db.Empleado.FirstOrDefault(e => e.idUsuario == idUsuario);
                    //Solo si es empleado hace el log
                    if ( emp != null )
                    {
                        string nombreCompleto = db.Usuario.SingleOrDefault(u => u.nombre == login.UserName).nombreCompleto;
                        string Aerolinea = db.Empleado.SingleOrDefault(e => e.idUsuario == idUsuario).AerolineaID;
                        if (Aerolinea != null)
                        {
                            System.IO.StreamWriter file = new System.IO.StreamWriter("C:/Users/Alumno/Desktop/Logs/" + Aerolinea + "log.txt", append: true);
                            file.WriteLine(DateTime.Now.ToString("[yyyy/MM/dd hh:mm:ss]") + " Inicio Sesión - " + nombreCompleto);
                            file.Close();
                        }
                    }

                    return RedirectToAction("Ingreso", "Account");
                }
            }

            ModelState.AddModelError("", "Error al logearse");
            return View(login);
        }

        public ActionResult Ingreso()
        {
            if (Roles.IsUserInRole("Cliente"))
            {
                return RedirectToAction("HistorialCliente", "Boleto");
            }

            if (Roles.IsUserInRole("Encargado"))
            {
                return RedirectToAction("IndexEncargado", "Vuelo");
            }

            if (Roles.IsUserInRole("Empleado"))
            {
                return RedirectToAction("IndexEmpleado", "Vuelo");
            }
            ModelState.AddModelError("", "Error al logearse");
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/Logout
        public ActionResult Logout()
        {
            int usuario = WebSecurity.CurrentUserId;
            Empleado emp = db.Empleado.FirstOrDefault(e => e.idUsuario == usuario);
            //Solo si es empleado hace el log
            if (emp != null)
            {

                string nombreCompleto = db.Usuario.SingleOrDefault(u => u.idUsuario == usuario).nombreCompleto;
                string Aerolinea = db.Empleado.SingleOrDefault(e => e.idUsuario == usuario).AerolineaID;
                if (Aerolinea != null)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter("C:/Users/Alumno/Desktop/Logs/" + Aerolinea + "log.txt", append: true);
                    file.WriteLine(DateTime.Now.ToString("[yyyy/MM/dd hh:mm:ss]") + " Cierre Sesión - " + nombreCompleto);
                    file.Close();
                }
            }
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registro registro)
        {

            if (ModelState.IsValid)
            {
                try
                {   
                    WebSecurity.CreateUserAndAccount(registro.UserName, registro.Password, new { email = registro.UserEmail, nombreCompleto = registro.NombreCompleto, dni = registro.Dni });
                    WebSecurity.Login(registro.UserName, registro.Password);
                    Roles.AddUserToRole(registro.UserName,"Cliente");

                    Cliente cliente = db.Cliente.SingleOrDefault(c => c.dni == registro.Dni);

                    if (cliente == null)
                    {
                        cliente = new Cliente();
                        cliente.dni = registro.Dni;
                        cliente.idUsuario = WebSecurity.GetUserId(registro.UserName);
                        db.Cliente.Add(cliente);
                    }
                    else
                    {
                        cliente.idUsuario = WebSecurity.GetUserId(registro.UserName);
                    }
                    db.SaveChanges();
                    
                    return RedirectToAction("Login", "Account");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
            return View();
        }

    }
}
