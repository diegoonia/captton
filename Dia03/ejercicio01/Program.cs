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
            Profesor prof = new Profesor("Sklanny");
            Profesor prof2 = new Profesor("De Paoli");
            Profesor prof3 = new Profesor("Jair");
          
            Curso arqDeComp = new Curso("Arquitectura de computadoras", 250, prof);
            Curso tics = new Curso("TICS", 250, prof2);
            
            Alumno alum1 = new Alumno("Diego Oña", universidad);
            Alumno alum2 = new Alumno("Rodri Mansilla", universidad);
            Alumno alum3 = new Alumno("Gonza Rodeiro", universidad);

            arqDeComp.AñadirProfesor(prof3);

            prof3.AñadirCurso(arqDeComp);
            prof.AñadirCurso(arqDeComp);
            prof2.AñadirCurso(tics);

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
