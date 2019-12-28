using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SeguroBLL
    {

        public SeguroBLL()
        {

        }

        public SeguroBLL(int idseguro, string nombre)
        {
            IdSeguro = idseguro;
            Nombre = nombre;
        }

        public List<SeguroBLL> ComboSeguros()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<SeguroBLL> lista = new List<SeguroBLL>();
            foreach (var item in modelo.seguro)
            {
                lista.Add(new SeguroBLL(item.idseguro, item.nombre));
            }
            return lista;
        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            seguro buscado = modelo.seguro.Where(a => a.idseguro == IdSeguro).FirstOrDefault();
            if (buscado == null)
            {
                seguro s = new seguro();
                s.idseguro = IdSeguro;
                s.nombre = Nombre;
                s.descripcion = Descripcion;
                s.costo = Costo;
                s.empaseg_rutemp = RutEmp;

                modelo.seguro.Add(s);
                modelo.SaveChanges();

            }
            else
            {
                throw new Exception("Seguro ya registrado");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            seguro buscado = modelo.seguro.Where(a => a.idseguro == IdSeguro).FirstOrDefault();
            if (buscado != null)
            {
                buscado.idseguro = IdSeguro;
                buscado.nombre = Nombre;
                buscado.descripcion = Descripcion;
                buscado.costo = Costo;
                buscado.empaseg_rutemp = RutEmp;

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible actualizar");
            }
        }

        public void Eliminar(int id)
        {
            OnTourEntities modelo = new OnTourEntities();
            seguro buscado = modelo.seguro.Where(a => a.idseguro == id).FirstOrDefault();
            if (buscado != null)
            {
                modelo.seguro.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible eliminar");
            }
        }

        public List<SeguroBLL> ListaSeguros()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<SeguroBLL> lista = new List<SeguroBLL>();
            foreach (var item in modelo.seguro)
            {
                SeguroBLL s = new SeguroBLL();
                s.IdSeguro = item.idseguro;
                s.Nombre = item.nombre;
                s.Descripcion = item.descripcion;
                s.Costo = item.costo;
                s.RutEmp = item.empaseg_rutemp;
                

                lista.Add(s);
            }
            return lista;
        }

        public bool BuscarSeguro(int id)
        {
            OnTourEntities modelo = new OnTourEntities();
            seguro buscado = modelo.seguro.Where(s => s.idseguro == id).FirstOrDefault();
            if (buscado != null)
            {
                return true;
            }
            return false;
        }

        private int idSeguro;
        public int IdSeguro
        {
            get
            {
                return idSeguro;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    idSeguro = value;
                }
                else
                {
                    throw new Exception("Código Seguro no puede estar vacio");
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

        private int costo;
        public int Costo
        {
            get
            {
                return costo;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    costo = value;
                }
                else
                {
                    throw new Exception("Costo no puede estar vacio");
                }
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    descripcion = value;
                }
                else
                {
                    throw new Exception("Descripcion no puede estar vacio");
                }
            }
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
                    throw new Exception("Rut Empresa Aseguradora no puede estar vacio");
                }
            }
        }
    }
}
