using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCafetera
{
    class Cafetera
    {
        private int capacidadMaxima;
        private int cantidadActual;


        public Cafetera()
        {
            this.capacidadMaxima = 1000;
            this.cantidadActual = 0;
        }

        public Cafetera(int capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
            this.cantidadActual = capacidadMaxima;
        }

        public Cafetera(int capacidadMaxima, int cantidadActual)
        {
            this.capacidadMaxima = capacidadMaxima;
            if (cantidadActual > capacidadMaxima)
            {
                this.cantidadActual = capacidadMaxima;
            }
            else
            {
                this.cantidadActual = cantidadActual;
            }
        }

        public void LlenarCafetera()
        {
            this.cantidadActual = this.capacidadMaxima;
        }

        public void ServirTaza(int cantidad)
        {
            this.cantidadActual -= cantidad;
            if (this.cantidadActual < 0)
            {
                this.cantidadActual = 0;
            }
        }

        public void VaciarCafetera()
        {
            this.cantidadActual = 0;
        }

        public void AgregarCafe(int cantidad)
        {
            this.cantidadActual += cantidad;
            if( this.cantidadActual > this.capacidadMaxima)
            {
                this.cantidadActual = this.capacidadMaxima;
            }
        }

        public int GetCapacidadMaxima()
        {
            return capacidadMaxima;
        }

        public void setCapacidadMaxima(int capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
        }

        public int GetCantidadActual()
        {
            return cantidadActual;
        }

        public void setCantidadActual(int cantidadActual)
        {
            this.cantidadActual = cantidadActual;
        } 

    }
}
