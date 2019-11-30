using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class ListContratosViewModel
    {
        public int ContratoId { get; set; }
        public string RutEmpleado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public int NumeroHoras { get; set; }
        public string TipoHora { get; set; }
        public string AfpNombre { get; set; }
        public string  NombreSalud { get; set; }
        public string NombreBonif { get; set; }
        public double SueldoBase { get; set; }
        public double SueldoBruto { get; set; }
        public double SueldoLiquido { get; set; }
    }
}