using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Empleado
/// </summary>
public class Empleado
{
    public string nombre, apellido, area;
    public int dni;

	public Empleado(string nombre, string apellido, string area, int dni)
	{
        this.nombre = nombre;
        this.apellido = apellido;
        this.area = area;
        this.dni = dni;
	}
}