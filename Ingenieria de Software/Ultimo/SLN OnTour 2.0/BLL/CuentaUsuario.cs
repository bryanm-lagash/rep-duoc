using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CuentaUsuario
    {
        public CuentaUsuario()
        {

        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            cta_usuario cuenta = modelo.cta_usuario.Where(cu => cu.usuario_rutusu == Rut).FirstOrDefault();
            if (cuenta == null)
            {
                cta_usuario c = new cta_usuario();
                c.usuario = Usuario;
                c.contraseña = Contraseña;
                c.nombre = Nombre;
                c.usuario_rutusu = Rut;
                c.tipcuenta_idtipocta = IdTipoCta;

                modelo.cta_usuario.Add(c);
                modelo.SaveChanges();

            }
            else
            {
                throw new Exception("Cuenta ya registrada");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            cta_usuario cuenta = modelo.cta_usuario.Where(c => c.usuario == Usuario).FirstOrDefault();
            if (cuenta != null)
            {
                cuenta.usuario = Usuario;
                cuenta.contraseña = Contraseña;
                cuenta.nombre = Nombre;
                cuenta.usuario_rutusu = Rut;
                cuenta.tipcuenta_idtipocta = IdTipoCta;

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible actualizar");
            }
        }

        public void Eliminar()
        {
            OnTourEntities modelo = new OnTourEntities();
            cta_usuario cuenta = modelo.cta_usuario.Where(c => c.usuario == Usuario).FirstOrDefault();
            if (cuenta != null)
            {
                modelo.cta_usuario.Remove(cuenta);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible eliminar");
            }
        }

        public bool BuscarUsuario(string user)
        {
            OnTourEntities modelo = new OnTourEntities();
            cta_usuario cuenta = modelo.cta_usuario.Where(c=> c.usuario == user).FirstOrDefault();
            if (cuenta != null)
            {
                return true;
            }
            return false;
        }

        public List<CuentaUsuario> ListaCuentas()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<CuentaUsuario> lista = new List<CuentaUsuario>();
            foreach (var item in modelo.cta_usuario)
            {
                CuentaUsuario c = new CuentaUsuario();
                c.Usuario = item.usuario;
                c.Contraseña = item.contraseña;
                c.Nombre = item.nombre;
                c.Rut = item.usuario_rutusu;
                c.IdTipoCta = item.tipcuenta_idtipocta;
                c.TipoCuenta = new TipoCuentaBLL().ListaCuentas().Where(e => e.IdTipoCta == item.tipcuenta_idtipocta).FirstOrDefault().Nombre;

                lista.Add(c);
            }
            return lista;
        }

        private string usuario;
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    usuario = value;
                }
                else
                {
                    throw new Exception("Usuario no puede estar vacio");
                }
            }
        }

        private string contraseña;
        public string Contraseña
        {
            get
            {
                return contraseña;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    contraseña = value;
                }
                else
                {
                    throw new Exception("Contreseña no puede estar vacia");
                }
            }
        }

        private string rut;
        public string Rut
        {
            get
            {
                return rut;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    rut = value;
                }
                else
                {
                    throw new Exception("Rut no puede estar vacio");
                }
            }
        }

        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception("Nombre no puede estar vacio");
                }
            }
        }

        private int idTipoCta;
        public int IdTipoCta
        {
            get
            {
                return idTipoCta;
            }
            set
            {
                if(!string.IsNullOrEmpty(value.ToString()))
                {
                    idTipoCta = value;
                }
                else
                {
                    throw new Exception("ID Tipo Cuenta no puede estar vacio");
                }
            }
        }

        public string TipoCuenta { get; set; }
    }
}
