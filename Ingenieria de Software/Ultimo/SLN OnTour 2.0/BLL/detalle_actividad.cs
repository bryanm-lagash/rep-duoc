//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalle_actividad
    {
        public int cant_actividades { get; set; }
        public int actividad_idactividad { get; set; }
        public int contrato_numcontrato { get; set; }
        public string contrato_idcurso { get; set; }
        public string contrato_codcolegio { get; set; }
        public string contrato_rutejecutivo { get; set; }
        public int contrato_iddestino { get; set; }
        public int contrato_idtipoact { get; set; }
        public int contrato_idmod { get; set; }
        public int contrato_idtipo { get; set; }
    
        public virtual actividad actividad { get; set; }
        public virtual contrato contrato { get; set; }
    }
}
