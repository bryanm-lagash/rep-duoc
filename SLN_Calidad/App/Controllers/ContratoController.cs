using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            using (DBEntities db = new DBEntities())
            {
                List<ValorHoraViewModel> lst;
                //lista valor hora lst
                lst = (from l in db.ValorHora
                       select new ValorHoraViewModel
                       {
                           ValorHoraId = l.ValorHoraId,
                           Tipo = l.Tipo,
                           Valor = l.Valor
                       }).ToList();



                // lista viewbag valorHora lst
                List<SelectListItem> cboTipoHora = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Tipo.ToString(),
                        Value = d.ValorHoraId.ToString(),
                        Selected = false
                    };
                });


                //lista afp lst2
                List<AfpContratoViewModel> lst2;
                lst2 = (from l in db.Afp
                        select new AfpContratoViewModel
                        {
                            AfpId = l.AfpId,
                            Nombre = l.Nombre,
                            Valor = l.Valor
                        }).ToList();

                //lista viewbag afp lst2
                List<SelectListItem> cboAfp = lst2.ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Nombre.ToString(),
                        Value = a.AfpId.ToString(),
                        Selected = false
                    };
                });

                //lista bonificacion lst3
                List<BonificacionViewModel> lst3;
                lst3 = (from l in db.Bonificacion
                        select new BonificacionViewModel
                        {
                            BonificacionId = l.BonificacionId,
                            Nombre = l.Nombre,
                            Valor = l.Valor

                        }).ToList();

                //lista viewbag bonificacion lst3
                List<SelectListItem> cboBonificacion = lst3.ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Nombre.ToString(),
                        Value = a.BonificacionId.ToString(),
                        Selected = false
                    };
                });

                //lista salud lst4
                List<SaludContratoViewModel> lst4;
                lst4 = (from l in db.Salud
                        select new SaludContratoViewModel
                        {
                            SaludId = l.SaludId,
                            Nombre = l.Nombre,
                            Valor = l.Valor

                        }).ToList();

                //lista viewbag salud lst4
                List<SelectListItem> cboSalud = lst4.ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Nombre.ToString(),
                        Value = a.Valor.ToString(),
                        Selected = false
                    };
                });

                ViewBag.ValorHora = new SelectList(db.ValorHora, "ValorHoraId", "ValorHora", "ValorHora");
                ViewBag.items2 = cboAfp;
                ViewBag.items3 = cboBonificacion;
                ViewBag.items4 = cboSalud;

            }
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContratoViewModel model)
        {

            using (DBEntities db = new DBEntities())
            {
                var list = new SelectList(db.ValorHora, "ValorHoraId", "Tipo");
                ViewData["ValorHora"] = list;
            }
            return View(model);

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        using (DBEntities db = new DBEntities())
            //        {
            //            var oContrato = new Contrato();
            //            foreach (var item in db.Contrato)
            //            {
            //                oContrato.ContratoId = item.ContratoId + 1;
            //            }
            //            oContrato.EmpleadoId = model.EmpleadoId;
            //            oContrato.FechaCreacion = DateTime.Now;
            //            oContrato.FechaInicio = model.FechaInicio;
            //            oContrato.FechaTermino = model.FechaTermino;
            //            oContrato.NumeroHoras = model.NumeroHoras;
            //            oContrato.ValorHoraId = int.Parse(Request["cboTipoHora"]);
            //            oContrato.BonificacionId = int.Parse(Request["cboBonificacion"]);
            //            oContrato.AfpId = int.Parse(Request["cboAfp"]);
            //            oContrato.SaludId = int.Parse(Request["cboSalud"]);
            //            oContrato.SueldoBruto = model.SueldoBruto;
            //            oContrato.SueldoLiquido = model.SueldoLiquido;

            //            db.Contrato.Add(oContrato);
            //            db.SaveChanges();

            //            return Redirect("/");
            //        }   
            //    }
            //    return View(model);       
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
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