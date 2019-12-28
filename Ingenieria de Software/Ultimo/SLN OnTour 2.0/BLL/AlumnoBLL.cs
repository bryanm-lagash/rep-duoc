using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class AlumnoBLL
    {

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            var buscado = modelo.alumno.Where(c => c.rutalumno == rutalumno).FirstOrDefault();
            if (buscado == null)
            {
                alumno a = new alumno();
                a.rutalumno = rutalumno;
                a.nombre = nombre;
                a.apaterno = apaterno;
                a.amaterno = amaterno;
                a.direccion = direccion;
                a.curso_idcurso = curso_idcurso;

                modelo.alumno.Add(a);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible agregar");
            }
        }
        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            var buscado = modelo.alumno.Where(c => c.rutalumno == rutalumno).FirstOrDefault();
            if (buscado != null)
            {
                buscado.rutalumno = rutalumno;
                buscado.nombre = nombre;
                buscado.apaterno = apaterno;
                buscado.amaterno = amaterno;
                buscado.direccion = direccion;
                buscado.curso_idcurso = curso_idcurso;

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
            var buscado = modelo.alumno.Where(c => c.rutalumno == rutalumno).FirstOrDefault();
            if (buscado != null)
            {
                modelo.alumno.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible eliminar");
            }
        }

        public List<AlumnoBLL> ListaAlumnos()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<AlumnoBLL> lista = new List<AlumnoBLL>();
            foreach (var item in modelo.alumno)
            {
                AlumnoBLL a = new AlumnoBLL();
                a.rutalumno = item.rutalumno;
                a.nombre = item.nombre;
                a.apaterno = item.apaterno;
                a.amaterno = item.amaterno;
                a.direccion = item.direccion;
                a.curso_idcurso = item.curso_idcurso;
                lista.Add(a);
            }
            return lista;
        }

        public bool BuscarAlumno(string rut)
        {
            OnTourEntities modelo = new OnTourEntities();
            var buscado = modelo.alumno.Where(c => c.rutalumno == rut).FirstOrDefault();
            if(buscado != null)
            {
                return true;
            }
            return false;
        }

        public string rutalumno { get; set; }
        public string nombre { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public string direccion { get; set; }
        public string curso_idcurso { get; set; }

    }
}
