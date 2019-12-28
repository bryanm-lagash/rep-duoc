using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DepositoBLL
    {
        public DepositoBLL()
        {

        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            deposito buscado = modelo.deposito.Where(e => e.iddeposito == IdDeposito).FirstOrDefault();
            if (buscado == null)
            {
                deposito d = new deposito();
                d.iddeposito = IdDeposito;
                d.fechadeposito = FechaDeposito;
                d.montodeposito = Monto;
                d.curso_idcurso = IdCurso;
                d.curso_colegio_codcolegio = CodColegio;
                d.curso_colegio_idtipo = IdTipColegio;

                modelo.deposito.Add(d);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("Deposito ya registrado");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            deposito buscado = modelo.deposito.Where(p => p.iddeposito == IdDeposito).FirstOrDefault();
            if (buscado != null)
            {
                buscado.iddeposito = IdDeposito;
                buscado.fechadeposito = FechaDeposito;
                buscado.montodeposito = Monto;
                buscado.curso_idcurso = IdCurso;
                buscado.curso_colegio_codcolegio = CodColegio;
                buscado.curso_colegio_idtipo = IdTipColegio;

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible actualizar");
            }
        }

        public void Eliminar(int id)
        {
            OnTourEntities modelo = new OnTourEntities();
            deposito buscado = modelo.deposito.Where(d => d.iddeposito == id).FirstOrDefault();
            if (buscado != null)
            {
                modelo.deposito.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible eliminar");
            }
        }

        public bool BuscarDeposito(int id)
        {
            OnTourEntities modelo = new OnTourEntities();
            deposito buscado = modelo.deposito.Where(d => d.iddeposito == id).FirstOrDefault();
            if (buscado != null)
            {
                return true;
            }
            return false;
        }

        public List<DepositoBLL> ListaDepositos()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<DepositoBLL> lista = new List<DepositoBLL>();
            foreach (var item in modelo.deposito)
            {
                DepositoBLL d = new DepositoBLL();
                d.IdDeposito = item.iddeposito;
                d.FechaDeposito = item.fechadeposito;
                d.Monto = item.montodeposito;
                d.IdCurso = item.curso_idcurso;
                d.CodColegio = item.curso_colegio_codcolegio;
                d.IdTipColegio = item.curso_colegio_idtipo;
                d.TipoColegio = new TipoColegioBLL().ListaTipoColegio().Where(a => a.IdTipoColegio == item.curso_colegio_idtipo).FirstOrDefault().Nombre;

                lista.Add(d);
            }
            return lista;
        }


        private int idDesposito;
        public int IdDeposito
        {
            get
            {
                return idDesposito;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    idDesposito = value;
                }
                else
                {
                    throw new Exception("Id Deposito no puede estar vacio");
                }
            }
        }

        private DateTime fechaDeposito;
        public DateTime FechaDeposito
        {
            get
            {
                return fechaDeposito;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToLongDateString()))
                {
                    fechaDeposito = value;
                }
                else
                {
                    throw new Exception("Fecha deposito no puede estar vacio");
                }
            }
        }

        private int monto;
        public int Monto
        {
            get
            {
                return monto;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    monto = value;
                }
                else
                {
                    throw new Exception("Monto no puede estar vacio");
                }
            }
        }

        private string idCurso;
        public string IdCurso
        {
            get
            {
                return idCurso;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    idCurso = value;
                }
                else
                {
                    throw new Exception("Id Curso no puede estar vacio");
                }
            }
        }

        private string codColegio;
        public string CodColegio
        {
            get
            {
                return codColegio;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    codColegio = value;
                }
                else
                {
                    throw new Exception("Codigo colegio no puede estar vacio");
                }
            }
        }

        private int idTipColegio;
        public int IdTipColegio
        {
            get
            {
                return idTipColegio;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    idTipColegio = value;
                }
                else
                {
                    throw new Exception("Id Tipo Colegio no puede estar vacio");
                }
            }
        }

        public string TipoColegio { get; set; }


    }
}
