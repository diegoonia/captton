using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia05
{
    class RangoException : Exception
    {
        private string miMensaje;

        public RangoException(string mensaje)
        {
            this.miMensaje = mensaje;
        }

        public override string Message
        {
            get
            {
                return base.Message;
            }
        }
    }
}
