using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {

            Universidad universidad = new Universidad("UnLaM");
            Curso arqDeComp = new Curso("arquitectura de computadoras", 250, "Sklanny");
            Alumno alum1 = new Alumno("Diego Oña", universidad);
            Alumno alum2 = new Alumno("Rodri Mansilla", universidad);
            Alumno alum3 = new Alumno("Gonza Rodeiro", universidad);

            Curso tics = new Curso("Tics", 208, "De Paoli");

            universidad.AñadirCurso(arqDeComp);
            universidad.AñadirCurso(tics);

            tics.AñadirAlumno(alum1);
            arqDeComp.AñadirAlumno(alum1);
            arqDeComp.AñadirAlumno(alum2);
            arqDeComp.AñadirAlumno(alum3);

            Console.WriteLine(universidad.HablanCursos());

            Console.ReadKey();
        }
    }
}
