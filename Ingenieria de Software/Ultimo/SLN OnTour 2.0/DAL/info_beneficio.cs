//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class info_beneficio
    {
        public int cant_beneficio { get; set; }
        public int contrato_numcontrato { get; set; }
        public int beneficio_idbenefico { get; set; }
    
        public virtual beneficio beneficio { get; set; }
        public virtual contrato contrato { get; set; }
    }
}
