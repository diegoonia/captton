﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Ingrediente
{
    public Ingrediente()
    {
        this.RecetaIngrediente = new HashSet<RecetaIngrediente>();
    }

    public int idIngrediente { get; set; }
    public string nombre { get; set; }

    public virtual ICollection<RecetaIngrediente> RecetaIngrediente { get; set; }
}

public partial class Receta
{
    public Receta()
    {
        this.RecetaIngrediente = new HashSet<RecetaIngrediente>();
    }

    public int idReceta { get; set; }
    public string nombre { get; set; }
    public string instrucciones { get; set; }

    public virtual ICollection<RecetaIngrediente> RecetaIngrediente { get; set; }
}

public partial class RecetaIngrediente
{
    public int idReceta { get; set; }
    public int idIngrediente { get; set; }
    public int cantidad { get; set; }
    public string unidadDeMedida { get; set; }

    public virtual Ingrediente Ingrediente { get; set; }
    public virtual Receta Receta { get; set; }
}