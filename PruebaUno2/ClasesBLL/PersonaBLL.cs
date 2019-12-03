using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesDAL;
using System.Data.SqlClient;


namespace ClasesBLL
{
   public class PersonaBLL
    {
       
        public void Crear()
        {
            PruebaOneEntities modelo = new PruebaOneEntities();

            Persona buscado = modelo.Persona.Where(c => c.Rut == Rut).FirstOrDefault();

            if (buscado == null)
            {
                Persona p = new Persona();
                p.Rut = Rut;
                p.Nombre = Nombre;
                p.Apellidos = Apellidos;
                p.Genero = Genero;
                p.Salario = Salario;
                p.FechaNacimiento = FechaNacimiento;

                modelo.Persona.Add(p);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("Persona ya existe");
            }
        }








        private string rut;
        public string Rut {
            get
            {
                return rut;
            }
            set
            {
                if (!string.IsNullOrEmpty(value)) {
                    //if (Herramientas.validarRut(value))
                    //{
                    //    rut = value;
                    //}
                    //else
                    //{
                    //    throw new Exception("El rut es invalido");
                    //}
                    rut = value;
                }
                else
                {
                    throw new Exception("El rut no puede estar vacio");
                }
            }
        }

        private string nombre;
        public string Nombre {
            get
            {
                return nombre;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception("Nombre no puede estar vacio");
                }
            }
        }

        private string apellidos;
        public string Apellidos {
            get
            {
                return apellidos;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    apellidos = value;
                }
                else
                {
                    throw new Exception("Apellido no puede estar vacio");
                }
            }
        }

        private string genero;
        public string Genero {
            get
            {
                return genero;
            }
            set
            {
                if(!string.IsNullOrEmpty(value.ToString()))
                {
                    genero = value;
                }
                else
                {
                    throw new Exception("Genero no puede estar vacio");
                }
            }
          
        }
        public int Salario { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
    }
}
