using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoColegioBLL
    {

        public TipoColegioBLL()
        {

        }

    
        public TipoColegioBLL(int idTipo, string nombre)
        {
            IdTipoColegio = idTipo;
            Nombre = nombre;
        }

        public List<TipoColegioBLL> ListaTipoColegio()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<TipoColegioBLL> lista = new List<TipoColegioBLL>();
            foreach (var item in modelo.tipcole)
            {
                lista.Add(new TipoColegioBLL(item.idtipo, item.nombre));
            }
            return lista;
        }

        public int IdTipoColegio { get; set; }
        public string Nombre { get; set; }
    }
}
