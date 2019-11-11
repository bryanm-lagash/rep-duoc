using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
using App.Models.ViewModels;

namespace App.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            List<ListContratosViewModel> lst;
            using (DBEntities db = new DBEntities())
            {
                lst = (from d in db.Contrato
                       select new ListContratosViewModel
                       {
                           ContratoId = d.ContratoId,
                           FechaCreacion = d.FechaCreacion,
                           FechaInicio = d.FechaInicio,
                           FechaTermino = d.FechaTermino,
                           EmpleadoId = d.EmpleadoId
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContratoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBEntities db = new DBEntities())
                    {
                        var oContrato = new Contrato();
                        foreach (var item in db.Contrato)
                        {
                            oContrato.ContratoId = item.ContratoId + 1;
                        }
                        oContrato.FechaCreacion = DateTime.Now;
                        oContrato.FechaInicio = model.FechaInicio;
                        oContrato.FechaTermino = model.FechaTermino;
                        oContrato.EmpleadoId = model.EmpleadoId;

                        db.Contrato.Add(oContrato);
                        db.SaveChanges();
                    }
                    return Redirect("/");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int ID)
        {

            ContratoViewModel model = new ContratoViewModel();
            using (DBEntities db = new DBEntities())
            {
                var oContrato = db.Contrato.Find(ID);
                model.ContratoId = oContrato.ContratoId;
                model.FechaCreacion = oContrato.FechaCreacion;
                model.FechaInicio = oContrato.FechaInicio;
                model.FechaTermino = oContrato.FechaTermino;
                model.EmpleadoId = oContrato.EmpleadoId;
            }
            return View(model);
        }

        [HttpPut]
        public ActionResult Editar(ContratoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBEntities db = new DBEntities())
                    {
                        var oContrato = db.Contrato.Find(model.ContratoId);
                        oContrato.ContratoId = model.ContratoId;
                        oContrato.FechaCreacion = model.FechaCreacion;
                        oContrato.FechaInicio = model.FechaInicio;
                        oContrato.FechaTermino = model.FechaTermino;
                        oContrato.EmpleadoId = model.EmpleadoId;

                        db.Entry(oContrato).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Detalles()
        {
            using (DBEntities db = new DBEntities())
            {
                return View(db.Contrato);
            }
            
        }



    }//Clase
}//namespace