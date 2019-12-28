using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ActividadBLL
    {

        public ActividadBLL()
        {

        }

        public ActividadBLL(int idactividad, string nombre)
        {
            IdActividad = idactividad;
            Nombre = nombre;
        }

        public List<ActividadBLL> ListaActividad()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ActividadBLL> lista = new List<ActividadBLL>();
            foreach (var item in modelo.actividad)
            {
                lista.Add(new ActividadBLL(item.idactividad, item.nombre));
            }
            return lista;
        }



        private int idActividad;
        public int IdActividad
        {
            get
            {
                return idActividad;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    idActividad = value;
                }
                else
                {
                    throw new Exception("ID Actividad no puede estar vacio");
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
                    throw new Exception("Nombre Actividad no puede estar vacio");
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


    }
}
