using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia05
{
    class Program
    {
        static void Main(string[] args)
        {
            int numerador, denominador;
            string resultado = "";

            try
            {
                Console.WriteLine("Ingrese el numero a dividir");
                numerador = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el divisor");
                denominador = int.Parse(Console.ReadLine());
                ComprobarRango(numerador, denominador);
                resultado = "El resultado de la operacion es: " + (float)(numerador / denominador);
            }
            catch (DivideByZeroException e)
            {
                resultado = e.Message;
            }
            catch (RangoException e)
            {
                resultado = e.Message;
            }
            finally
            {
                Console.WriteLine(resultado);
            }

            
            Console.ReadKey();
        }


        static void ComprobarRango(int num, int den)
        {
            if (num > 100 || den < 0)
            {
                throw new RangoException("Estas fuera del rango permitido crack");
            }
        }
    }
}
