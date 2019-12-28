using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {
        public UsuarioBLL()
        {

        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            usuario buscado = modelo.usuario.Where(a => a.rutusu == Rut).FirstOrDefault();
            if (buscado == null)
            {
                usuario u = new usuario();
                u.rutusu = Rut;
                u.nombre = Nombre;
                u.apaterno = Apaterno;
                u.amaterno = Amaterno;
                u.direccion = Direccion;
                u.email = Email;

                modelo.usuario.Add(u);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario ya registrado");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            usuario buscado = modelo.usuario.Where(a => a.rutusu == Rut).FirstOrDefault();
            if (buscado != null)
            {
                buscado.rutusu = Rut;
                buscado.nombre = Nombre;
                buscado.apaterno = Apaterno;
                buscado.amaterno = Amaterno;
                buscado.direccion = Direccion;
                buscado.email = Email;

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible actualizar");
            }
        }

        public void Eliminar()
        {
            OnTourEntities modelo = new OnTourEntities();
            var buscado = modelo.usuario.Where(u => u.rutusu == Rut).FirstOrDefault();
            if (buscado != null)
            {
                modelo.usuario.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible eliminar");
            }
        }

        public bool BuscarUsuario(string rut)
        {
            OnTourEntities modelo = new OnTourEntities();
            var buscado = modelo.usuario.Where(u => u.rutusu == rut).FirstOrDefault();
            if (buscado != null)
            {
                return true;
            }
            return false;
        }
        

        public List<UsuarioBLL> ListaUsuarios()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<UsuarioBLL> lista = new List<UsuarioBLL>();
            foreach (var item in modelo.usuario)
            {
                UsuarioBLL u = new UsuarioBLL();
                u.Rut = item.rutusu;
                u.Nombre = item.nombre;
                u.Apaterno = item.apaterno;
                u.Amaterno = item.amaterno;
                u.Direccion = item.direccion;
                u.Email = item.email;

                lista.Add(u);
            }
            return lista;
        }

        private string rut;
        public string Rut
        {
            get
            {
                return rut;
            }
            set
            {
                if (Herramientas.validarRut(value))
                {
                    rut = value;
                }
                else
                {
                    throw new Exception("El rut no es válido");
                }
            }
        }

        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;

            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception("Nombre no puede estar vacio");
                }
            }
            
        }

        private string apaterno;
        public string Apaterno
        {
            get
            {
                return apaterno;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    apaterno = value;
                }
                else
                {
                    throw new Exception("Apellido Paterno no puede estar vacío");
                }
            }
        }

        private string amaterno;
        public string Amaterno
        {
            get
            {
                return amaterno;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    amaterno = value;
                }
                else
                {
                    throw new Exception("Apellido Materno no puede estar vacío");
                }
            }
        }

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

    }
}
