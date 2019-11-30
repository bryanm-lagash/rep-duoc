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
        [Display(Name = "Tipo de hora")]
        public string TipoHora { get; set; }
        [Display(Name = "Valor")]
        public double ValorHora { get; set; }
        [Display(Name = "AFP")]
        public int AfpId { get; set; }
        public int SaludId { get; set; }
        [Display(Name = "Bonificación")]
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
        [Display(Name = "Valor")]
        public int ValorBonificacion { get; set; }
        [Display(Name = "Indemnización")]
        public int Indemnizacion { get; set; }
        [Display(Name = "Valor")]
        public double ValorAfp { get; set; }
        [Display(Name = "Valor")]
        public double ValorSalud { get; set; }

        [Display(Name = "Otro")]
        public string Otro { get; set; }
        [Display(Name = "Valor")]
        public string ValorOtro { get; set; }
        [Display(Name = "Total Haberes")]
        public int TotalHaberes { get; set; }
        [Display(Name = "Total Descuentos")]
        public int TotalDescuentos { get; set; }

        

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