using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PaisBLL
    {
        override
        public string ToString()
        {
            return Nombre;
        }

        public PaisBLL()
        {

        }

        public PaisBLL(int codpais, string nombre)
        {
            CodPais = codpais;
            Nombre = nombre;
        }

        public List<PaisBLL> ListaPaises()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<PaisBLL> lista = new List<PaisBLL>();
            foreach (var item in modelo.pais)
            {
                lista.Add(new PaisBLL(item.codpais, item.nombre));
            }
            return lista;
        }

        public int CodPais { get; set; }
        public string Nombre { get; set; }


    }
}
