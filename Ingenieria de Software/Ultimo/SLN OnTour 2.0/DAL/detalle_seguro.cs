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
    
    public partial class detalle_seguro
    {
        public int iddetseg { get; set; }
        public int numcontrato { get; set; }
        public int seguro_idseguro { get; set; }
    
        public virtual seguro seguro { get; set; }
    }
}
