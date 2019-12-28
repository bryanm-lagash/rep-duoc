using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CiudadBLL
    {
        public CiudadBLL()
        {

        }

        public CiudadBLL(int codciudad, string nombre)
        {
            CodCiudad = codciudad;
            Nombre = nombre;
        }

        public List<CiudadBLL> ListaCiudades()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<CiudadBLL> lista = new List<CiudadBLL>();
            foreach (var item in modelo.ciudad)
            {
                lista.Add(new CiudadBLL(item.codciudad, item.nombre));
            }
            return lista;
        }

        public List<CiudadBLL> Lista()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<CiudadBLL> lista = new List<CiudadBLL>();
            foreach (var item in modelo.ciudad)
            {
                CiudadBLL c = new CiudadBLL();
                c.CodCiudad = item.codciudad;
                c.Nombre = item.nombre;
                c.CodPais = item.pais_codpais;

                lista.Add(c);
            }
            return lista;
        }

        public int CodCiudad { get; set; }
        public string Nombre { get; set; }

        public int CodPais { get; set; }

    }
}
