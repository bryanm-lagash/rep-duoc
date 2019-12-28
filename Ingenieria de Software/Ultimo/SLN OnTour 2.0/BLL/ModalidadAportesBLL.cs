using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ModalidadAportesBLL
    {
        public ModalidadAportesBLL()
        {

        }
        public ModalidadAportesBLL(int idMod, string nombre)
        {
            IdMod = idMod;
            Nombre = nombre;
        }

        public List<ModalidadAportesBLL> ListaModalidadAportes()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ModalidadAportesBLL> lista = new List<ModalidadAportesBLL>();
            foreach (var item in modelo.modaporte)
            {
                lista.Add(new ModalidadAportesBLL(item.idmod, item.nombre));
            }
            return lista;
        }

        public int IdMod { get; set; }
        public string Nombre { get; set; }

    }
}
