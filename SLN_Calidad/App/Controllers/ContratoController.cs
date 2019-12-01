using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        #region Listas

        public static List<ValorHoraViewModel> ListaValorHora()
        {
            List<ValorHoraViewModel> lista = new List<ValorHoraViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.ValorHora)
            {
                ValorHoraViewModel v = new ValorHoraViewModel();
                v.ValorHoraId = item.ValorHoraId;
                v.Tipo = item.Tipo;
                v.Valor = item.Valor;

                lista.Add(v);
            }
            return lista;
        }

        public static List<BonificacionViewModel> ListaBonificacion()
        {
            List<BonificacionViewModel> lista = new List<BonificacionViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.Bonificacion)
            {
                BonificacionViewModel b = new BonificacionViewModel();
                b.BonificacionId = item.BonificacionId;
                b.Nombre = item.Nombre;
                b.Valor = item.Valor;

                lista.Add(b);
            }
            return lista;
        }

        public static List<AfpContratoViewModel> ListaAfp()
        {
            List<AfpContratoViewModel> lista = new List<AfpContratoViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.Afp)
            {
                AfpContratoViewModel a = new AfpContratoViewModel();
                a.AfpId = item.AfpId;
                a.Nombre = item.Nombre;
                a.Valor = item.Valor;

                lista.Add(a);
            }
            return lista;
        }

        public static List<SaludContratoViewModel> ListaSalud()
        {
            List<SaludContratoViewModel> lista = new List<SaludContratoViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.Salud)
            {
                SaludContratoViewModel s = new SaludContratoViewModel();
                s.SaludId = item.SaludId;
                s.Nombre = item.Nombre;
                s.Valor = item.Valor;

                lista.Add(s);
            }
            return lista;
        }


        #endregion Listas
        // GET: Contrato
        public ActionResult Index()
        {
            List<ListContratosViewModel> lst = new List<ListContratosViewModel>();
            DBEntities db = new DBEntities();
            foreach (var item in db.Contrato)
            {
                ListContratosViewModel c = new ListContratosViewModel();
                c.ContratoId = item.ContratoId;
                c.RutEmpleado = db.Empleado.Where(e => e.EmpleadoId == item.EmpleadoId).FirstOrDefault().Rut;
                c.FechaCreacion = item.FechaCreacion;
                c.FechaInicio = item.FechaInicio;
                c.NumeroHoras = item.NumeroHoras;
                c.TipoHora = db.ValorHora.Where(v => v.ValorHoraId == item.ValorHoraId).FirstOrDefault().Tipo;
                c.AfpNombre = db.Afp.Where(a => a.AfpId == item.AfpId).FirstOrDefault().Nombre;
                c.NombreSalud = db.Salud.Where(s => s.SaludId == item.SaludId).FirstOrDefault().Nombre;
                c.NombreBonif = db.Bonificacion.Where(b => b.BonificacionId == item.BonificacionId).FirstOrDefault().Nombre;
                c.SueldoBase = item.SueldoBase;
                c.SueldoBruto = item.SueldoBruto;
                c.SueldoLiquido = item.SueldoLiquido;

                lst.Add(c);
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            List<SelectListItem> cboTipoHora = ListaValorHora().ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Tipo.ToString(),
                    Value = d.ValorHoraId.ToString(),
                    Selected = false
                };
            });


            List<SelectListItem> cboAfp = ListaAfp().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre.ToString(),
                    Value = a.AfpId.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> cboBonificacion = ListaBonificacion().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre.ToString(),
                    Value = a.BonificacionId.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> cboSalud = ListaSalud().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre.ToString(),
                    Value = a.SaludId.ToString(),
                    Selected = false
                };
            });

            ViewBag.cboTipoHora = cboTipoHora;
            ViewBag.cboAfp = cboAfp;
            ViewBag.cboBonificacion = cboBonificacion;
            ViewBag.cboSalud = cboSalud;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContratoViewModel model, int cboTipoHora, int cboBonificacion, int cboAfp, int cboSalud)
        {
            try
            {
                using (DBEntities db = new DBEntities())
                {
                    var oContrato = new Contrato();
                    var empleado = db.Empleado.Where(e => e.Rut == model.RutEmpleado).FirstOrDefault().EmpleadoId;

                    oContrato.ContratoId = model.ContratoId;
                    oContrato.EmpleadoId = empleado;
                    oContrato.FechaCreacion = model.FechaCreacion;
                    oContrato.FechaInicio = model.FechaInicio;
                    oContrato.FechaTermino = model.FechaTermino;
                    oContrato.NumeroHoras = Convert.ToInt32(model.NumeroHoras);
                    oContrato.ValorHoraId = cboTipoHora;
                    oContrato.AfpId = cboAfp;
                    oContrato.SaludId = cboSalud;
                    oContrato.BonificacionId = cboBonificacion;
                    oContrato.SueldoBase = model.TotalHaberes;
                    oContrato.SueldoBruto = model.SueldoBruto;
                    oContrato.SueldoLiquido = model.SueldoLiquido;

                    db.Contrato.Add(oContrato);
                    db.SaveChanges();

                    return Redirect("/Contrato/Index");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Editar(int ID)
        {

            ContratoViewModel model = new ContratoViewModel();
            using (DBEntities db = new DBEntities())
            {
                List<SelectListItem> cboTipoHora = ListaValorHora().ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Tipo.ToString(),
                        Value = d.ValorHoraId.ToString(),
                        Selected = false
                    };
                });


                List<SelectListItem> cboAfp = ListaAfp().ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Nombre.ToString(),
                        Value = a.AfpId.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> cboBonificacion = ListaBonificacion().ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Nombre.ToString(),
                        Value = a.BonificacionId.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> cboSalud = ListaSalud().ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Nombre.ToString(),
                        Value = a.SaludId.ToString(),
                        Selected = false
                    };
                });

                ViewBag.cboTipoHora = cboTipoHora;
                ViewBag.cboAfp = cboAfp;
                ViewBag.cboBonificacion = cboBonificacion;
                ViewBag.cboSalud = cboSalud;

                var oContrato = db.Contrato.Find(ID);
                model.ContratoId = oContrato.ContratoId;
                model.RutEmpleado = db.Empleado.Where(e => e.EmpleadoId == oContrato.EmpleadoId).FirstOrDefault().Rut;
                model.FechaCreacion = oContrato.FechaCreacion;
                model.FechaInicio = oContrato.FechaInicio;
                model.FechaTermino = oContrato.FechaTermino;
                model.NumeroHoras = oContrato.NumeroHoras;
                model.ValorHoraId = oContrato.ValorHoraId;
                model.BonificacionId = oContrato.BonificacionId;
                model.SueldoBase = oContrato.SueldoBase;
                model.SueldoBruto = oContrato.SueldoBruto;
                model.SueldoLiquido = oContrato.SueldoLiquido;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ContratoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBEntities db = new DBEntities())
                    {
                        var oContrato = db.Contrato.Where(c => c.ContratoId == model.ContratoId).FirstOrDefault();
                        oContrato.ContratoId = model.ContratoId;
                        oContrato.EmpleadoId = db.Empleado.Where(e => e.Rut == model.RutEmpleado).FirstOrDefault().EmpleadoId;
                        oContrato.FechaCreacion = model.FechaCreacion;
                        oContrato.FechaInicio = model.FechaInicio;
                        oContrato.FechaTermino = model.FechaTermino;
                        oContrato.NumeroHoras = Convert.ToInt32(model.NumeroHoras);
                        oContrato.ValorHoraId = model.ValorHoraId;
                        oContrato.BonificacionId = model.BonificacionId;
                        oContrato.SueldoBase = model.SueldoBase;
                        oContrato.SueldoBruto = model.SueldoBruto;
                        oContrato.SueldoLiquido = model.SueldoLiquido;

                        db.Entry(oContrato).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Contrato/Index");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                using (DBEntities db = new DBEntities())
                {
                    var contrato = db.Contrato.Where(c => c.ContratoId == id).FirstOrDefault();
                    db.Contrato.Remove(contrato);
                    db.SaveChanges();
                }
                return Redirect("/Contrato/Index");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // url(/Contrato/CalcularSueldo)
        public ActionResult CalcularSueldo(ContratoViewModel model, int cboTipoHora, int cboBonificacion)
        {
            DBEntities db = new DBEntities();
            //Valor de las horas trabajadas
            double valorHora = db.ValorHora.Where(h => h.ValorHoraId == cboTipoHora).FirstOrDefault().Valor;
            double numHoras = model.NumeroHoras;

            //Valor bonificacion
            double valorBonificacion = db.Bonificacion.Where(b => b.BonificacionId == cboBonificacion).FirstOrDefault().Valor;

            //Valor AFP
            double valorAfp = 0.1;

            //Valor Salud
            double valorSalud = 0.07;

            //Otros descuentos 
            double otrosDesct = model.ValorOtroDesc;

            //Dias Indemnización
            double diasIndem = model.Indemnizacion;
            double valorDiasIndem = model.ValorDiasIndemnizacion;

            //Totales
            double totalHaberes = valorBonificacion + (diasIndem * valorDiasIndem);
            double totalDescuentos = valorAfp + valorSalud;
            //Sueldos
            double sueldoBase = numHoras * valorHora;
            double sueldoBruto = sueldoBase + totalHaberes;
            double sueldoLiquido = (sueldoBruto * totalDescuentos) / 100;

            return View();
        }

        [HttpGet]
        public ActionResult Prueba(ContratoViewModel model)
        {

            ViewBag.RutEmpleado = "20512884-0";

            return Redirect("/Contrato/Crear");
        }

    }//Clase
}//namespace