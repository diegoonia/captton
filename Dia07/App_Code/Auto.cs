using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Auto
/// </summary>
public class Auto
{
    public string patente;
    public DateTime horaEntrada;

	public Auto(string patente)
	{
        this.patente = patente;
        this.horaEntrada = DateTime.Now;
	}
}