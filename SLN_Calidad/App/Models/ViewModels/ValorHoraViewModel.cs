using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class ValorHoraViewModel
    {
        public int ValorHoraId { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }


        public List<ValorHoraViewModel> ListValorhora()
        {
            List<ValorHoraViewModel> lista = new List<ValorHoraViewModel>();
            DBEntities db = new DBEntities();
            foreach(var item in db.ValorHora)
            {
                ValorHoraViewModel v = new ValorHoraViewModel();
                v.ValorHoraId = item.ValorHoraId;
                v.Tipo = item.Tipo;
                v.Valor = item.Valor;

                lista.Add(v);
            }
            return lista;
        }
    }
}