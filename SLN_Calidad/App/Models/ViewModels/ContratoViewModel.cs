﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models;
using System.Web.Mvc;

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
        [Display(Name = "Rut Empleado")]
        public string RutEmpleado { get; set; }
        [Required]
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
        public double NumeroHoras { get; set; }
        public int ValorHoraId { get; set; }
        [Display(Name = "Tipo de hora")]
        public string TipoHora { get; set; }
        [Display(Name = "AFP")]
        public int AfpId { get; set; }
        [Display(Name = "Previsión")]
        public int SaludId { get; set; }
        [Display(Name = "Bonificación")]
        public int BonificacionId { get; set; }
        [Required]
        [Display(Name = "Sueldo Base")]
        public double SueldoBase { get; set; }
        [Required]
        [Display(Name = "Sueldo Bruto")]
        public double SueldoBruto { get; set; }
        [Required]
        [Display(Name = "Sueldo Liquido")]
        public double SueldoLiquido { get; set; }

        [Display(Name = "Dias")]
        public double Indemnizacion { get; set; }

        [Display(Name = "Otros descuentos")]
        public string OtroDescuento { get; set; }
        [Display(Name = "Valor")]
        public double ValorOtroDesc { get; set; }
        [Display(Name = "Total Haberes")]
        public double TotalHaberes { get; set; }
        [Display(Name = "Total Descuentos")]
        public double TotalDescuentos { get; set; }
        [Display(Name = "Valor")]
        public double ValorDiasIndemnizacion { get; set; }

    } 
}