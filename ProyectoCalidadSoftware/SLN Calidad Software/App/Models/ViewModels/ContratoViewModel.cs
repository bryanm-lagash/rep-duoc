using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.ViewModels
{
    public class ContratoViewModel
    {
        [Required]
        [Display(Name = "Numero Contrato")]
        public int ContratoId { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Termino")]
        public DateTime FechaTermino { get; set; }
        public int EmpleadoId { get; set; }

    }
}