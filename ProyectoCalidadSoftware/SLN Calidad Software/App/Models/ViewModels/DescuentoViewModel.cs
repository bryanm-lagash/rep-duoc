using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class DescuentoViewModel
    {
        public int DescuentoId { get; set; }
        public Nullable<double> Salud { get; set; }
        public Nullable<double> AFP { get; set; }
        public Nullable<double> Otros { get; set; }

        public List<DescuentoViewModel> ListDescuento()
        {
            List<DescuentoViewModel> lista = new List<DescuentoViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.Descuento)
            {
                DescuentoViewModel d = new DescuentoViewModel();
                d.DescuentoId = item.DescuentoId;
                d.Salud = item.Salud;
                d.AFP = item.AFP;
                d.Otros = item.Otros;

                lista.Add(d);
            }
            return lista;
        }

    }
}