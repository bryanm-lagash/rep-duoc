//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sueldo
    {
        public int ValorHoraId { get; set; }
        public int ContratoId { get; set; }
        public int DescuentoId { get; set; }
        public int BonificacionId { get; set; }
        public int NumeroHoras { get; set; }
    
        public virtual Bonificacion Bonificacion { get; set; }
        public virtual Contrato Contrato { get; set; }
        public virtual Descuento Descuento { get; set; }
        public virtual ValorHora ValorHora { get; set; }
    }
}
