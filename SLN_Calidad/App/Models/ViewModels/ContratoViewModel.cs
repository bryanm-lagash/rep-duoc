using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models;

namespace App.Models.ViewModels
{
    public class ContratoViewModel
    {
        [Required]
        [Display(Name = "Numero Contrato")]
        public int ContratoId { get; set; }
        [Required]
        [Display(Name = "Rut Empleado")]
        public int EmpleadoId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Termino")]
        public DateTime FechaTermino { get; set; }
        [Required]
        [Display(Name = "Numero de horas")]
        public int NumeroHoras { get; set; }
        public int ValorHoraId { get; set; }
        public string TipoHora { get; set; }
        public double ValorHora { get; set; }
        public int AfpId { get; set; }
        public int SaludId { get; set; }
        public int BonificacionId { get; set; }
        [Required]
        [Display(Name = "Sueldo Base")]
        public int SueldoBase { get; set; }
        [Required]
        [Display(Name = "Sueldo Liquido")]
        public int SueldoLiquido { get; set; }
        [Required]
        [Display(Name = "Sueldo Bruto")]
        public int SueldoBruto { get; set; }


        public List<ValorHoraViewModel> ValoresHoras()
        {
            List<ValorHoraViewModel> lista = new List<ValorHoraViewModel>();
            var model = new DBEntities();
            foreach(var item in model.ValorHora)
            {
                ValorHoraViewModel v = new ValorHoraViewModel();
                v.ValorHoraId = item.ValorHoraId;
                v.Tipo = item.Tipo;
                v.Valor = item.Valor;
                lista.Add(v);
            }
            return lista;
        }

        //public List<ValorHora>
    } 
}