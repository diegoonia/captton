//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstacionamientoMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoDeVehiculo
    {
        public TipoDeVehiculo()
        {
            this.Vehiculo = new HashSet<Vehiculo>();
        }
    
        public int idTipo { get; set; }
        public string nombre { get; set; }
        public double tarifa { get; set; }
    
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}