using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase
{
    class Supervisor
    {

        public string nombre;
        public int sueldo;
        //AGREGACION
        public List<Empleado> listaDeEmpleadosACargo;
        //COMPOSICION
        public Proyecto proy;


        public Supervisor(string name, string nameProy)
        {
            this.nombre = name;
            this.sueldo = 20000;
            this.proy = new Proyecto(nameProy);
            this.listaDeEmpleadosACargo = new List<Empleado>();
        }

        public string Ingresar(TarjetaIdentificacion tar)
        {
            return this.nombre + tar.PermitirAcceso();
        }

        public void AgregarEmpleado(Empleado emp)
        {
            this.listaDeEmpleadosACargo.Add(emp);
        }

        public string HacerTrabajar()
        {
            StringBuilder str = new StringBuilder();

            foreach(Empleado item in listaDeEmpleadosACargo)
            {
                str.AppendLine(item.Trabajar());
            }

            return str.ToString();
        }

        public void Evaluar()
        {
            if(this.proy.EsExitoso(this))
            {
                this.sueldo += 5000;
            }
            else
            {
                this.sueldo -= 5000;
            }
               
        }
    }
}
