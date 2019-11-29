using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class Class1
    {
        //public ActionResult Index()
        //{
        //    List<ListContratosViewModel> lst;
        //    using (DBEntities db = new DBEntities())
        //    {
        //        lst = (from d in db.Contrato
        //               select new ListContratosViewModel
        //               {
        //                   ContratoId = d.ContratoId,
        //                   FechaCreacion = d.FechaCreacion,
        //                   FechaInicio = d.FechaInicio,
        //                   FechaTermino = d.FechaTermino,
        //                   EmpleadoId = d.EmpleadoId
        //               }).ToList();
        //    }

        //    List<SelectListItem> items = lst.ConvertAll(d =>
        //    {
        //        return new SelectListItem()
        //        {
        //            Text = d.EmpleadoId.ToString(),
        //            Value = d.ContratoId.ToString(),
        //            Selected = false
        //        };


        //    });
        //    ViewBag.items = items;

        //    return View(lst);
        //}
    }
}