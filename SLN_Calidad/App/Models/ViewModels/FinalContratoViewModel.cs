using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class FinalContratoViewModel
    {
        //Datos Contrato
        public int ContratoId { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaTermino { get; set; }
        public int EmpleadoId { get; set; }

        //Valor Hora
        public int ValorHoraId { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }

        //Descuentos

        public int DescuentoId { get; set; }
        public Nullable<double> Salud { get; set; }
        public Nullable<double> AFP { get; set; }
        public Nullable<double> Otros { get; set; }


    }
}