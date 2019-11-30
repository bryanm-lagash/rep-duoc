using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class ListEmpleadosViewModel
    {
        public int EmpleadoId { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Profesion { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> CargasFamiliares { get; set; }
    }
}