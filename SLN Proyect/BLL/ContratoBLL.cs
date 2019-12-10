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

        //public long ContratoId { get; set; }
        //public long EmpleadoId { get; set; }
        //public System.DateTime FechaCreacion { get; set; }
        //public System.DateTime FechaInicio { get; set; }
        //public System.DateTime FechaTermino { get; set; }
        //public int NumeroHoras { get; set; }
        //public int ValorHoraId { get; set; }
        //public int AfpId { get; set; }
        //public int SaludId { get; set; }
        //public int BonificacionID { get; set; }
        //public double SueldoBase { get; set; }
        //public double SueldoLiquido { get; set; }
        //public double SueldoBruto { get; set; }


        private long ContratoId;
        private long EmpleadoId;
        public DateTime FechaCreacion { get; set; }
        private DateTime fechaInicio;
        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }
            set
            {
                if(FechaInicio > DateTime.Now)
                {
                    fechaInicio = value;
                }
                else
                {
                    throw new Exception("Fecha de Inicio no puede ser inferior que fecha actual");
                }
            }
        }

    }
}
