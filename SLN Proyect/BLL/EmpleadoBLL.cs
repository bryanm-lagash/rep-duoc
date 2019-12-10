using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EmpleadoBLL 
    {
        public void Agregar()
        {
            DBEntities db = new DBEntities();
            var buscado = db.Empleado.Where(e => e.Rut == Rut).FirstOrDefault();
            if(buscado == null)
            {
                Empleado e = new Empleado();
                e.Rut = Rut;
                e.Nombres = Nombres;
                e.Apellidos = Apellidos;
                e.Genero = Genero;
                e.FechaNacimiento = FechaNacimiento;
                e.Direccion = Direccion;
                e.Telefono = Telefono;
                e.Profesion = Profesion;
                e.Email = Email;
                e.ImagePath = ImagePath;
                e.CargasFamiliares = CargasFamiliares;

                db.Empleado.Add(e);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Empleado ya registrado");
            }
        }

        public void Actualizar()
        {
            DBEntities db = new DBEntities();
            var buscado = db.Empleado.Where(e => e.Rut == Rut).FirstOrDefault();
            if(buscado != null)
            {
                buscado.Rut = Rut;
                buscado.Nombres = Nombres;
                buscado.Apellidos = Apellidos;
                buscado.Genero = Genero;
                buscado.FechaNacimiento = FechaNacimiento;
                buscado.Direccion = Direccion;
                buscado.Telefono = Telefono;
                buscado.Profesion = Profesion;
                buscado.Email = Email;
                buscado.CargasFamiliares = CargasFamiliares;

                db.SaveChanges();
            }
            else {
                throw new Exception("No es posible actualizar");
            }
            
        }

        public void Eliminar()
        {
            DBEntities db = new DBEntities();
            var empleado = db.Empleado.Where(e => e.Rut == Rut).FirstOrDefault();
            if(empleado != null)
            {
                db.Empleado.Remove(empleado);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible eliminar");
            }
        }
        public bool BuscarEmpleado(string rut)
        {
            DBEntities db = new DBEntities();
            var empleado = db.Empleado.Where(e => e.Rut == rut).FirstOrDefault();
            if(empleado != null)
            {
                return true;
            }
            return false;
        }
        public List<EmpleadoBLL> ListaEmpleados()
        {
            DBEntities db = new DBEntities();
            List<EmpleadoBLL> lista = new List<EmpleadoBLL>();
            foreach(var item in db.Empleado)
            {
                EmpleadoBLL e = new EmpleadoBLL();
                e.Rut = item.Rut;
                e.nombres = item.Nombres;
                e.Apellidos = item.Apellidos;
                e.Genero = item.Genero;
                e.FechaNacimiento = item.FechaNacimiento;
                e.Direccion = item.Direccion;
                e.Telefono = item.Telefono;
                e.Profesion = item.Profesion;
                e.Email = item.Email;
                e.ImagePath = item.ImagePath;
                e.CargasFamiliares = item.CargasFamiliares;

                lista.Add(e);
            }
            return lista;
        }

        public long EmpleadoId { get; set; }
        private string rut;
        public string Rut
        {
            get
            {
                return rut;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (Funciones.validarRut(value))
                    {
                        rut = value;
                    }
                    else
                    {
                        throw new Exception("El rut no es válido");
                    }
                }
                else
                {
                    throw new Exception("Rut no puede estar vacio");
                }
            }

        }
        private string nombres;
        public string Nombres
        {
            get
            {
                return nombres;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombres = value;
                }
                else
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
            }
        }
        private string apellidos;
        public string Apellidos
        {
            get
            {
                return apellidos;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    apellidos = value;
                }
                else
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
            }
        }
        public string Genero { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        private string direccion;
        public string Direccion
        {
            get
            {
                return direccion;


            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccion = value;
                }
                else
                {
                    throw new Exception("Direccion no puede estar vacio");
                }
            }
        }
        private string telefono;
        public string Telefono
        {
            get
            {
                return telefono;

            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    telefono = value;
                }
                else
                {
                    throw new Exception("Telefono no puede estar vacio");
                }
            }
        }
        public string Profesion { get; set; }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    email = value;
                }
                else
                {
                    throw new Exception("Email no puede estar vacio");
                }
            }
        }
        public string ImagePath { get; set; }
        public int CargasFamiliares { get; set; }
    }
}
