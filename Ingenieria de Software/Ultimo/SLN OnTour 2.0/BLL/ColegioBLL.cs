using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ColegioBLL
    {
        public ColegioBLL()
        {

        }
    
        public bool BuscarColegio(string cod) 
        {
            OnTourEntities modelo = new OnTourEntities();
            bool encuentro = false;
            colegio buscado = modelo.colegio.Where(c => c.codcolegio == cod).FirstOrDefault();
            if (buscado != null)
            {
                encuentro = true;
            }
            return encuentro;
        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            colegio buscado = modelo.colegio.Where(c => c.codcolegio == CodColegio).FirstOrDefault();

            if (buscado == null)
            {
                colegio c = new colegio();
                c.codcolegio = CodColegio;
                c.nombre = Nombre;
                c.direccion = Direccion;
                c.tipcole_idtipo = tipcole_idtipo;

                modelo.colegio.Add(c);
                modelo.SaveChanges();

            }
            else
            {
                throw new Exception("Colegio ya registrado");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            colegio buscado = modelo.colegio.Where(c => c.codcolegio == CodColegio).FirstOrDefault();
            if (buscado != null)
            {
                buscado.codcolegio = CodColegio;
                buscado.nombre = Nombre;
                buscado.direccion = Direccion;
                buscado.tipcole_idtipo = tipcole_idtipo;

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible Actualizar Colegio");
            }
        }

        public void Eliminar(string codigo)
        {
            OnTourEntities modelo = new OnTourEntities();
            colegio buscado = modelo.colegio.Where(c => c.codcolegio == codigo).FirstOrDefault();
            if (buscado != null)
            {
                modelo.colegio.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible Eliminar Colegio");
            }
        }

        public List<ColegioBLL> DataGridColegio()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ColegioBLL> lista = new List<ColegioBLL>();
            foreach (var item in modelo.colegio)
            {
                ColegioBLL c = new ColegioBLL();
                c.CodColegio = item.codcolegio;
                c.Nombre = item.nombre;
                c.Direccion = item.direccion;
                c.TipoColegio = modelo.tipcole.Where(t => t.idtipo == item.tipcole_idtipo).FirstOrDefault().nombre;
                lista.Add(c);
            }
            return lista;
        }

        public List<ColegioBLL> ListaColegios()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ColegioBLL> lista = new List<ColegioBLL>();
            foreach (var item in modelo.colegio)
            {
                ColegioBLL c = new ColegioBLL();
                c.CodColegio = item.codcolegio;
                c.Nombre = item.nombre;
                c.Direccion = item.direccion;
                c.tipcole_idtipo = item.tipcole_idtipo;
                lista.Add(c);
            }
            return lista;
        }

        public List<ColegioBLL> DataGridConsultaSaldo()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ColegioBLL> lista = new List<ColegioBLL>();
            foreach (var item in modelo.colegio)
            {
                ColegioBLL c = new ColegioBLL();
                c.CodColegio = item.codcolegio;
                c.Nombre = item.nombre;
                c.TipoColegio = modelo.tipcole.Where(p => p.idtipo == item.tipcole_idtipo).FirstOrDefault().nombre;
                c.Curso = modelo.curso.Where(a => a.idcurso == item.codcolegio).FirstOrDefault().idcurso;

                lista.Add(c);

            }
            return lista;
        }


        private string codColegio;
        public string CodColegio
        {
            get
            {
                return codColegio;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    codColegio = value;
                }
                else
                {
                    throw new Exception("Codigo colegio no puede estar vacio");
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
                    throw new Exception("Dirección de colegio no puede estar vacio");
                }
            }
        }

        public int tipcole_idtipo { get; set; }

        public string  TipoColegio { get; set; }

        public string Curso { get; set; }
    }
}
