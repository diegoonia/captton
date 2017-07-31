//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aerolineas
    {
        public Aerolineas()
        {
            this.Conexiones = new HashSet<Conexiones>();
            this.Empleado = new HashSet<Empleado>();
            this.Encargado = new HashSet<Encargado>();
        }
    
        public string AerolineaID { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }

        public string Informacion
        {
            get
            {
                return AerolineaID + "\t-  " + Nombre;
            }
        }
        public virtual ICollection<Conexiones> Conexiones { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Encargado> Encargado { get; set; }
    }
}
