using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.ViewModels
{
    public class SueldoViewModel
    {
        public int ValorHoraId { get; set; }
        public int ContratoId { get; set; }
        public int DescuentoId { get; set; }
        public int BonificacionId { get; set; }
        [Display(Name = "Numero de horas")]
        public int NumeroHoras { get; set; }

    }
}