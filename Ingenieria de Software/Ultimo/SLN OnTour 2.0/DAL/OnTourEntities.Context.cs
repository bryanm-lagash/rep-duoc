﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnTourEntities : DbContext
    {
        public OnTourEntities()
            : base("name=OnTourEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actividad> actividad { get; set; }
        public virtual DbSet<alumno> alumno { get; set; }
        public virtual DbSet<beneficio> beneficio { get; set; }
        public virtual DbSet<ciudad> ciudad { get; set; }
        public virtual DbSet<colegio> colegio { get; set; }
        public virtual DbSet<contrato> contrato { get; set; }
        public virtual DbSet<cta_usuario> cta_usuario { get; set; }
        public virtual DbSet<curso> curso { get; set; }
        public virtual DbSet<deposito> deposito { get; set; }
        public virtual DbSet<detalle_actividad> detalle_actividad { get; set; }
        public virtual DbSet<detalle_beneficio> detalle_beneficio { get; set; }
        public virtual DbSet<detalle_seguro> detalle_seguro { get; set; }
        public virtual DbSet<empaseg> empaseg { get; set; }
        public virtual DbSet<info_actividad> info_actividad { get; set; }
        public virtual DbSet<info_beneficio> info_beneficio { get; set; }
        public virtual DbSet<info_seguro> info_seguro { get; set; }
        public virtual DbSet<modaporte> modaporte { get; set; }
        public virtual DbSet<pais> pais { get; set; }
        public virtual DbSet<seguro> seguro { get; set; }
        public virtual DbSet<tasa_interes> tasa_interes { get; set; }
        public virtual DbSet<tipactividad> tipactividad { get; set; }
        public virtual DbSet<tipcole> tipcole { get; set; }
        public virtual DbSet<tipcuenta> tipcuenta { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
