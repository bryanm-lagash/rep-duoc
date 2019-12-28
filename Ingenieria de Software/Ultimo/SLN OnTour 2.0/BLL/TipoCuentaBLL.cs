using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoCuentaBLL
    {
        public TipoCuentaBLL()
        {

        }
        public TipoCuentaBLL(int idtipocta,string nombre)
        {
            IdTipoCta = idtipocta;
            Nombre = nombre;
        }

        public List<TipoCuentaBLL> TipoCuenta()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<TipoCuentaBLL> lista = new List<TipoCuentaBLL>();
            foreach (var item in modelo.tipcuenta)
            {
                lista.Add(new TipoCuentaBLL(item.idtipocta, item.nombre));
            }
            return lista;
        }

        public List<TipoCuentaBLL> ListaCuentas()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<TipoCuentaBLL> lista = new List<TipoCuentaBLL>();
            foreach (var item in modelo.tipcuenta)
            {
                TipoCuentaBLL c = new TipoCuentaBLL();
                c.IdTipoCta = item.idtipocta;
                c.Nombre = item.nombre;

                lista.Add(c);
            }
            return lista;
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
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    idTipoCta = value;
                }
                else
                {
                    throw new Exception("ID Tipo Cuenta no puede estar vacio");
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
                    throw new Exception("Tipo Cuenta no puede estar vacio");
                }
            }
        }

    }
}
