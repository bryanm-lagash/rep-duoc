using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ContratoBLL
    {
        public ContratoBLL()
        {

        }

        public ContratoBLL(int numero)
        {
            NumContrato = numero;
        }

        public List<ContratoBLL> ListContratos()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ContratoBLL> lista = new List<ContratoBLL>();
            foreach (var item in modelo.contrato)
            {
                lista.Add(new ContratoBLL(item.numcontrato));
            }
            return lista;
        }

        public List<ContratoBLL> DataGridDepositos()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ContratoBLL> lista = new List<ContratoBLL>();
            foreach (var item in modelo.contrato)
            {
                ContratoBLL c = new ContratoBLL();
                //c.CodColegio = item.curso_colegio_codcolegio;
                //c.NombreColegio = new ColegioBLL().ListaColegios().Where(p => p.CodColegio == item.curso_colegio_codcolegio).FirstOrDefault().Nombre;
                //c.TipoInstitucion = modelo.tipcole.Where(p => p.idtipo == item.curso_colegio_idtipo).FirstOrDefault().nombre;
                c.IdCurso = item.curso_idcurso;
                c.MontoActualCompletado = item.meta;
                c.MontoPorCompletar = item.meta;

                lista.Add(c);

            }
            return lista;
        }

        //Variables externas a la clase
        public string NombreColegio { get; set; }
        public string TipoInstitucion { get; set; }
        public int MontoActualCompletado { get; set; }
        public int MontoPorCompletar { get; set; }
        

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            contrato buscado = modelo.contrato.Where(co => co.numcontrato == NumContrato).FirstOrDefault();
            if (buscado == null)
            {
                contrato c = new contrato();
                c.numcontrato = NumContrato;
                c.fechacreacion = FechaCreacion;
                c.fechatermino = FechaTermino;
                c.duraciondias = DuracionDias;
                c.fechaini = FechaIniViaje;
                c.fechaterm = FechaTerViaje;
                c.fechapagos = FechaPagos;
                c.costototseguros = CostosSeguros;
                c.costototactividades = CostosActividades;
                c.porctotbeneficios = PorcBeneficios;
                c.costoservicios = CostosServicios;
                c.meta = Meta;
                c.tipactividad_idtipoact = IdTipoAct;
                c.curso_idcurso = IdCurso;
                c.ciudad_codciudad = CodCiudad;
                c.usuario_rutusu = RutUsuario;

                modelo.contrato.Add(c);
                modelo.SaveChanges();

            }
            else
            {
                throw new Exception("Contrato ya registrado");
            }
        }

        public void Actualizar()
        {
            OnTourEntities modelo = new OnTourEntities();
            contrato buscado = modelo.contrato.Where(a => a.numcontrato == NumContrato).FirstOrDefault();
            if (buscado != null)
            {
                buscado.numcontrato = NumContrato;
                buscado.fechacreacion = FechaCreacion;
                buscado.fechatermino = FechaTermino;
                buscado.duraciondias = DuracionDias;
                buscado.fechaini = FechaIniViaje;
                buscado.fechaterm = FechaTerViaje;
                buscado.fechapagos = FechaPagos;
                buscado.costototseguros = CostosSeguros;
                buscado.costoservicios = CostosServicios;
                buscado.costototactividades = CostosActividades;
                buscado.porctotbeneficios = PorcBeneficios;
                buscado.meta = Meta;
                buscado.tipactividad_idtipoact = IdTipoAct;
                buscado.curso_idcurso = IdCurso;
                buscado.ciudad_codciudad = CodCiudad;
                buscado.usuario_rutusu = RutUsuario;
                

                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible actualizar");
            }
        }

        public void Eliminar(int num)
        {
            OnTourEntities modelo = new OnTourEntities();
            contrato buscado = modelo.contrato.Where(c => c.numcontrato == num).FirstOrDefault();
            if (buscado != null)
            {
                modelo.contrato.Remove(buscado);
                modelo.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible eliminar");
            } 
        }

        public List<ContratoBLL> ListaContratos()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<ContratoBLL> lista = new List<ContratoBLL>();
            foreach (var item in modelo.contrato)
            {
                ContratoBLL c = new ContratoBLL();
                c.NumContrato = item.numcontrato;
                c.FechaCreacion = item.fechacreacion;
                c.FechaTermino = item.fechatermino;
                c.DuracionDias = item.duraciondias;
                c.FechaIniViaje = item.fechaini;
                c.FechaTerViaje = item.fechaterm;
                c.IdCurso = item.curso_idcurso;
                c.IdTipoAct = item.tipactividad_idtipoact;
                c.FechaPagos = item.fechapagos;
                c.CostosSeguros = item.costototseguros;
                c.CostosActividades = item.costototactividades;
                c.PorcBeneficios = item.porctotbeneficios;
                c.CostosServicios = item.costoservicios;
                c.Meta = item.meta;
                c.CodCiudad = item.ciudad_codciudad;
                c.RutUsuario = item.usuario_rutusu;

                lista.Add(c);
            }
            return lista;
        }

        public bool BuscarContrato(int num)
        {
            OnTourEntities modelo = new OnTourEntities();
            contrato buscado = modelo.contrato.Where(a => a.numcontrato == num).FirstOrDefault();
            if (buscado != null)
            {
                return true;
            }
            return false;
        }

        private int numContrato;
        public int NumContrato
        {
            get
            {
                return numContrato;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    numContrato = value;
                }
                else
                {
                    throw new Exception("Numero Contrato no puede estar vacio");
                }
            }
        }

        private DateTime fechaCreacion;
        public DateTime FechaCreacion
        {
            get
            {
                return fechaCreacion;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    fechaCreacion = value;
                }
                else
                {
                    throw new Exception("Fecha Creacion no puede ser inferior que fecha actual");
                }
            }
        }

        private DateTime fechaTermino;
        public DateTime FechaTermino
        {
            get
            {
                return fechaTermino;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    fechaTermino = value;
                }
                else
                {
                    throw new Exception("Fecha Termino no puede ser inferior que Fecha Creacion");
                }
            }
        }

        private int duracionDias;
        public int DuracionDias
        {
            get
            {
                return duracionDias;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    duracionDias = value;
                }
                else
                {
                    throw new Exception("Duracion no puede estar vacio");
                }
            }
        }

        private DateTime fechaIniViaje;
        public DateTime FechaIniViaje
        {
            get
            {
                return fechaIniViaje;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    fechaIniViaje = value;
                }
                else
                {
                    throw new Exception("Fecha Inicio Viaje no puede ser inferior que Fecha Inicio Contrato");
                }
            }
        }

        private DateTime fechaTerViaje;
        public DateTime FechaTerViaje
        {
            get
            {
                return fechaTerViaje;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    fechaTerViaje = value;
                }
                else
                {
                    throw new Exception("Fecha Termino Viaje no puede ser inferior que Fecha Inicio Viaje");
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
                    throw new Exception("Codigo Curso no puede estar vacio"); 
                }
            }
        }

        private string rutUsuario;
        public string RutUsuario
        {
            get
            {
                return rutUsuario;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    rutUsuario = value;
                }
                else
                {
                    throw new Exception("Rut Ejecutivo no puede estar vacio");
                }
            }
        }

        private int codCiudad;
        public int CodCiudad
        {
            get
            {
                return codCiudad;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    codCiudad = value;
                }
                else
                {
                    throw new Exception("Códico ciudad no puede estar vacio");
                }
            }
        }

        private int idTipoAct;
        public int IdTipoAct
        {
            get
            {
                return idTipoAct;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    idTipoAct = value;
                }
                else
                {
                    throw new Exception("Tipo Actividad no puede estar vacio");
                }
            }
        }

        private string fechaPagos;
        public string FechaPagos
        {
            get
            {
                return fechaPagos;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    fechaPagos = value;
                }
                else
                {
                    throw new Exception("Fecha de pagos no puede estar vacio");
                }
            }
        }

        private int costosSeguros;
        public int CostosSeguros
        {
            get
            {
                return costosSeguros;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    costosSeguros = value;
                }
                else
                {
                    throw new Exception("Costos Seguros no puede estar vacio");
                }

            }
        }

        private int costosActividades;
        public int CostosActividades
        {
            get
            {
                return costosActividades;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    costosActividades = value;
                }
                else
                {
                    throw new Exception("Costos Actividades no puede estar vacio");
                }
            }
        }

        private int porcBeneficios;
        public int PorcBeneficios
        {
            get
            {
                return porcBeneficios;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    porcBeneficios = value;
                }
                else
                {
                    throw new Exception("Porcentaje Beneficios no puede estar vacio");
                }
            }
        }

        private int costosServicios;
        public int CostosServicios
        {
            get
            {
                return costosServicios;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    costosServicios = value;
                }
                else
                {
                    throw new Exception("Costos Servicios no puede estar vacio");
                }
            }
        }

        private int meta;
        public int Meta
        {
            get
            {
                return meta;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    meta = value;
                }
                else
                {
                    throw new Exception("Meta no puede estar vacio");
                }
            }
        }


    }
}
