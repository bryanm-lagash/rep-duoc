using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class BonificacionViewModel
    {
        public int BonificacionId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }

        public List<BonificacionViewModel> ListBonificacion()
        {
            List<BonificacionViewModel> lista = new List<BonificacionViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.Bonificacion)
            {
                BonificacionViewModel b = new BonificacionViewModel();
                b.BonificacionId = item.BonificacionId;
                b.Nombre = item.Nombre;
                b.Descripcion = item.Descripcion;
                b.Valor = item.Valor;

                lista.Add(b);
            }
            return lista;
        }
    }
}