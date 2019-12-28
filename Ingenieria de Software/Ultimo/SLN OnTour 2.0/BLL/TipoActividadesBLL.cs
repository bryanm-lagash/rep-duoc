using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoActividadesBLL
    {
        public TipoActividadesBLL()
        {

        }
        public TipoActividadesBLL(int idtipoact, string nombre)
        {
            IdTipoact = idtipoact;
            Nombre = nombre;
        }

        public List<TipoActividadesBLL> ListaActividades()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<TipoActividadesBLL> lista = new List<TipoActividadesBLL>();
            foreach (var item in modelo.actividad)
            {
                lista.Add(new TipoActividadesBLL(item.idactividad, item.nombre));
            }
            return lista;
        }

        public List<TipoActividadesBLL> ListaTipoActividades()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<TipoActividadesBLL> lista = new List<TipoActividadesBLL>();
            foreach (var item in modelo.tipactividad)
            {
                TipoActividadesBLL t = new TipoActividadesBLL();
                t.IdTipoact = item.idtipoact;
                t.Nombre = item.nombre;
                t.Modaporte_Idmod = item.modaporte_idmod;

                lista.Add(t);
            }
            return lista;
        }

        public int IdTipoact { get; set; }
        public string Nombre { get; set; }
        public int Modaporte_Idmod { get; set; }
    }
}
