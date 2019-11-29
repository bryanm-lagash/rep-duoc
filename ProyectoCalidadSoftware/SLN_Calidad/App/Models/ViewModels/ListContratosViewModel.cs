using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class ListContratosViewModel
    {
        public int ContratoId { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaTermino { get; set; }
        public int EmpleadoId { get; set; }
    }
}