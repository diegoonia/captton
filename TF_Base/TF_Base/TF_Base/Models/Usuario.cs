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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Cliente = new HashSet<Cliente>();
            this.Empleado = new HashSet<Empleado>();
            this.Empleado1 = new HashSet<Empleado>();
            this.Encargado = new HashSet<Encargado>();
        }
    
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string nombreCompleto { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Empleado> Empleado1 { get; set; }
        public virtual ICollection<Encargado> Encargado { get; set; }
    }
}
