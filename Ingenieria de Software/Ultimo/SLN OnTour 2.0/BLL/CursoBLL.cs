using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CursoBLL
    {
        public CursoBLL()
        {

        }

        public CursoBLL(string idcurso)
        {
            IdCurso = idcurso;
        }

        public List<CursoBLL> ComboCurso()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<CursoBLL> lista = new List<CursoBLL>();
            foreach (var item in modelo.curso)
            {
                lista.Add(new CursoBLL(item.idcurso));
            }
            return lista;
        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            curso buscado = modelo.curso.Where(c=> c.idcurso == IdCurso).FirstOrDefault();

            if (buscado == null)
            {
                curso c = new curso();
                c.idcurso = IdCurso;
                c.numalumnos = NumAlumnos;
                c.colegio_codcolegio = CodColegio;

                modelo.curso.Add(c);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("Curso ya registrado");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            curso buscado = modelo.curso.Where(c => c.idcurso == IdCurso).FirstOrDefault();

            if (buscado != null)
            {
                buscado.idcurso = IdCurso;
                buscado.numalumnos = NumAlumnos;
                buscado.colegio_codcolegio = CodColegio;

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible Actualizar");
            }
        }

        public void Eliminar(string id)
        {
            OnTourEntities modelo = new OnTourEntities();
            curso buscado = modelo.curso.Where(c => c.idcurso == id).FirstOrDefault();
            if (buscado != null)
            {
                modelo.curso.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible Eliminar");
            }
        }

        public List<CursoBLL> ListaCursos()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<CursoBLL> lista = new List<CursoBLL>();
            foreach (var item in modelo.curso)
            {
                CursoBLL c = new CursoBLL();
                c.IdCurso = item.idcurso;
                c.NumAlumnos = item.numalumnos;
                c.CodColegio = item.colegio_codcolegio;

                lista.Add(c);
            }
            return lista;
        }

        public List<CursoBLL> DataGridCurso()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<CursoBLL> lista = new List<CursoBLL>();
            foreach (var item in modelo.curso)
            {
                CursoBLL c = new CursoBLL();
                c.IdCurso = item.idcurso;
                c.NumAlumnos = item.numalumnos;
                c.NombreColegio = modelo.colegio.Where(co => co.codcolegio == item.colegio_codcolegio).FirstOrDefault().nombre;

                lista.Add(c);
            }
            return lista;
        }

        public bool BuscarCurso(string id)
        {
            OnTourEntities modelo = new OnTourEntities();
            curso buscado = modelo.curso.Where(c => c.idcurso == id).FirstOrDefault();
            if (buscado != null)
            {
                return true;
            }
            return false;
        }

        private string idCurso;
        public string IdCurso
        {
            get
            {
                return idCurso;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    idCurso = value;
                }
                else
                {
                    throw new Exception("Codigo Curso no puede estar vacio");
                }
            }
        }

        private int numAlumnos;
        public int NumAlumnos
        {
            get
            {
                return numAlumnos;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    numAlumnos = value;
                }
                else
                {
                    throw new Exception("Cantidad Alumnos no puede estar vacio");
                }
            }
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
                    throw new Exception("Codigo Colegio no puede estar vacio");
                }
            }
        }


        public string NombreColegio { get; set; }
        public string TipoColegio { get; set; }

    }
}
