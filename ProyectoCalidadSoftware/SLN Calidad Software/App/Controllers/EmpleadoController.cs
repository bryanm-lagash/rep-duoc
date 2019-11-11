using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
using App.Models.ViewModels;

namespace App.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<ListEmpleadosViewModel> lst;
            using (DBEntities db = new DBEntities())
            {
                lst = (from d in db.Empleado
                       select new ListEmpleadosViewModel
                       {
                           EmpleadoId = d.EmpleadoId,
                           Rut = d.Rut,
                           Nombres = d.Nombres,
                           Apellidos = d.Apellidos,
                           Genero = d.Genero,
                           FechaNacimiento = d.FechaNacimiento,
                           Direccion = d.Direccion,
                           Telefono = d.Telefono,
                           Profesion = d.Profesion,
                           Email = d.Email,
                           ImagePath = d.ImagePath,
                           CargasFamiliares = d.CargasFamiliares
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        model.ImagePath = "~/AppFiles/Images/" + fileName;
                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                    }

                    using (DBEntities db = new DBEntities())
                    {
                        var oEmpleado = new Empleado();
                        foreach (var item in db.Empleado)
                        {
                            oEmpleado.EmpleadoId = item.EmpleadoId + 1;
                        }
                        oEmpleado.Rut = model.Rut;
                        oEmpleado.Nombres = model.Nombres;
                        oEmpleado.Apellidos = model.Apellidos;
                        oEmpleado.Genero = model.Genero;
                        oEmpleado.FechaNacimiento = model.FechaNacimiento;
                        oEmpleado.Direccion = model.Direccion;
                        oEmpleado.Telefono = model.Telefono;
                        oEmpleado.Profesion = model.Profesion;
                        oEmpleado.Email = model.Email;
                        oEmpleado.CargasFamiliares = model.CargasFamiliares;
                        oEmpleado.ImagePath = "null";

                        db.Empleado.Add(oEmpleado);
                        db.SaveChanges();
                    }
                    return Redirect("/Empleado");
                }

                return View(model);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int ID)
        {
            EmpleadoViewModel model = new EmpleadoViewModel();
            using (DBEntities db = new DBEntities())
            {
                var oEmpleado = db.Empleado.Find(ID);
                model.EmpleadoId = oEmpleado.EmpleadoId;
                model.Rut = oEmpleado.Rut;
                model.Nombres = oEmpleado.Nombres;
                model.Apellidos = oEmpleado.Apellidos;
                model.Genero = oEmpleado.Genero;
                model.FechaNacimiento = oEmpleado.FechaNacimiento;
                model.Direccion = oEmpleado.Direccion;
                model.Telefono = oEmpleado.Telefono;
                model.Profesion = oEmpleado.Profesion;
                model.Email = oEmpleado.Email;
                model.ImagePath = oEmpleado.ImagePath;
                model.CargasFamiliares = oEmpleado.CargasFamiliares;
            }
            return View(model);
        }

        [HttpPut]
        public ActionResult Editar(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        model.ImagePath = "~/AppFiles/Images/" + fileName;
                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                    }

                    using (DBEntities db = new DBEntities())
                    {
                        var oEmpleado = db.Empleado.Find(model.EmpleadoId);
                        oEmpleado.Rut = model.Rut;
                        oEmpleado.Nombres = model.Nombres;
                        oEmpleado.Apellidos = model.Apellidos;
                        oEmpleado.Genero = model.Genero;
                        oEmpleado.FechaNacimiento = model.FechaNacimiento;
                        oEmpleado.Direccion = model.Direccion;
                        oEmpleado.Telefono = model.Telefono;
                        oEmpleado.Profesion = model.Profesion;
                        oEmpleado.Email = model.Email;
                        oEmpleado.CargasFamiliares = model.CargasFamiliares;
                        oEmpleado.ImagePath = "null";

                        db.Entry(oEmpleado).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Empleado/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBEntities db = new DBEntities())
                    {
                        var oEmpleado = db.Empleado.Find(model.EmpleadoId);
                        db.Empleado.Remove(oEmpleado);
                        db.SaveChanges();
                    }
                    return Redirect("/Empleado/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}