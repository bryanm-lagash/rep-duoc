using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        public EmpleadoViewModel()
        {
            ImagePath = "~/AppFiles/Images/default.png";
        }

        public int EmpleadoId { get; set; }
        [Required]
        [StringLength(11)]
        public string Rut { get; set; }
        [Required]
        [StringLength(40)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(40)]
        public string Apellidos { get; set; }
        [StringLength(10)]
        [Display(Name = "Genero(M/F)")]
        public string Genero { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public int Telefono { get; set; }
        [StringLength(30)]
        public string Profesion { get; set; }
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }
        [Display(Name = "Cargas Familiares")]
        public Nullable<int> CargasFamiliares { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public List<EmpleadoViewModel> ListaEmpleados()
        {
            List<EmpleadoViewModel> lista = new List<EmpleadoViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.Empleado)
            {
                EmpleadoViewModel emp = new EmpleadoViewModel();
                emp.EmpleadoId = item.EmpleadoId;
                emp.Rut = item.Rut;
                emp.Nombres = item.Nombres;
                emp.Apellidos = item.Apellidos;
                emp.Genero = item.Genero;
                emp.FechaNacimiento = item.FechaNacimiento;
                emp.Direccion = item.Direccion;
                emp.Telefono = item.Telefono;
                emp.Profesion = item.Profesion;
                emp.Email = item.Email;
                emp.CargasFamiliares = item.CargasFamiliares;

                lista.Add(emp);
            }
            return lista;
        }
    }
}