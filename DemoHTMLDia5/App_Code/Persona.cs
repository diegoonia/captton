using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Persona
/// </summary>
public class Persona
{
    private string nombre;

	public Persona(string nombre)
	{
        this.nombre = nombre;
	}

    //PROPIEDAD (ES UN GET Y UN SET DE VARIABLES O ATRIBUTOS)
    public string Nombre
    {
        get
        {
            return this.nombre;
        }
        set
        {
            this.nombre = value;
        }
    }
}