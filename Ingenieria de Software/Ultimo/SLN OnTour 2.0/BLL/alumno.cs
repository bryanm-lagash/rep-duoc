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
    
    public partial class alumno
    {
        public string rutalumno { get; set; }
        public string nombre { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public string direccion { get; set; }
        public string curso_idcurso { get; set; }
        public string curso_colegio_codcolegio { get; set; }
        public int curso_colegio_idtipo { get; set; }
        public string apoderado_rutapoderado { get; set; }
    
        public virtual apoderado apoderado { get; set; }
        public virtual curso curso { get; set; }
    }
}
