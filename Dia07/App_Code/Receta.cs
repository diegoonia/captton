using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Receta
/// </summary>
public class Receta
{
    public string nombre, ing1, ing2, ing3, instrucciones; 

	public Receta(string nombre, string ing1, string ing2, string ing3, string instrucciones)
	{
        this.nombre = nombre;
        this.ing1 = ing1;
        this.ing2 = ing2;
        this.ing3 = ing3;
        this.instrucciones = instrucciones;
	}


}