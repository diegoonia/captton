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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Boleto = new HashSet<Boleto>();
        }
    
        public int dni { get; set; }
        public Nullable<int> idUsuario { get; set; }
    
        public virtual ICollection<Boleto> Boleto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
