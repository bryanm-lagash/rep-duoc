using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class AseguradoraBLL
    {
        public AseguradoraBLL()
        {

        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            empaseg buscado = modelo.empaseg.Where(e => e.rutemp == RutEmp).FirstOrDefault();

            if (buscado == null)
            {
                empaseg e = new empaseg();
                e.rutemp = RutEmp;
                e.nombre = Nombre;
                e.direccion = Direccion;
                e.telefono = Telefono;

                modelo.empaseg.Add(e);
                modelo.SaveChanges();

            }
            else
            {
                throw new Exception("Empleado ya registrado");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            empaseg emp = modelo.empaseg.Where(m => m.rutemp == RutEmp).FirstOrDefault();
            if (emp != null)
            {
                emp.rutemp = RutEmp;
                emp.nombre = Nombre;
                emp.telefono = Telefono;
                emp.direccion = Direccion;

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible actualizar");
            }
        }

        public void Eliminar(string rut)
        {
            OnTourEntities modelo = new OnTourEntities();
            empaseg buscado = modelo.empaseg.Where(e => e.rutemp == rut).FirstOrDefault();
            if (buscado != null)
            {
                modelo.empaseg.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("Empleado no registrado");
            }
        }

        public bool BuscarAseguradora(string rut)
        {
            OnTourEntities modelo = new OnTourEntities();
            empaseg buscado = modelo.empaseg.Where(e => e.rutemp == rut).FirstOrDefault();
            if (buscado != null)
            {
                return true;
            }
            return false;
        }

        public List<AseguradoraBLL> ListaAseguradora()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<AseguradoraBLL> lista = new List<AseguradoraBLL>();
            foreach (var item in modelo.empaseg)
            {
                AseguradoraBLL a = new AseguradoraBLL();
                a.RutEmp = item.rutemp;
                a.Nombre = item.nombre;
                a.Direccion = item.direccion;
                a.Telefono = item.telefono;
                lista.Add(a);
            }
            return lista;
            
        }


        private string rutEmp;
        public string RutEmp
        {
            get
            {
                return rutEmp;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    rutEmp = value;
                }
                else
                {
                    throw new Exception("Rut Aseguradora no puede estar vacio");
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
        private int telefono;
        public int Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    telefono = value;
                }
                else
                {
                    throw new Exception("Telefono no puede estar vacio");
                }
            }
        }
    }
}
