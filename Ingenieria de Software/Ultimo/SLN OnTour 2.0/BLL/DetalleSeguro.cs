using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DetalleSeguro
    {
        public DetalleSeguro()
        {

        }

        public void Agregar()
        {
            OnTourEntities modelo = new OnTourEntities();
            detalle_seguro d = new detalle_seguro();
            d.iddetseg = IdDetSeg;
            d.seguro_idseguro = IdSeguro;
            d.numcontrato = NumContrato;

            modelo.detalle_seguro.Add(d);
            modelo.SaveChanges();

        }

        public List<DetalleSeguro> ListaDetalles()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<DetalleSeguro> lista = new List<DetalleSeguro>();
            foreach (var item in modelo.detalle_seguro)
            {
                DetalleSeguro d = new DetalleSeguro();
                d.IdDetSeg = item.iddetseg;
                d.IdSeguro = item.seguro_idseguro;
                d.NumContrato = item.numcontrato;

                lista.Add(d);
            }
            return lista;
        }

        public List<DetalleSeguro> DataGridSeguro()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<DetalleSeguro> lista = new List<DetalleSeguro>();
            foreach (var item in modelo.detalle_seguro)
            {
                DetalleSeguro d = new DetalleSeguro();
                d.NumContrato = item.numcontrato;
                d.Nombre = new SeguroBLL().ListaSeguros().Where(c => c.IdSeguro == item.seguro_idseguro).FirstOrDefault().Nombre;
                d.Costo = new SeguroBLL().ListaSeguros().Where(c => c.IdSeguro == item.seguro_idseguro).FirstOrDefault().Costo;

                lista.Add(d);
            }
            return lista;
        }

        public int IdDetSeg { get; set; }

        public int IdSeguro { get; set; }

        public int NumContrato { get; set; }

        public string Nombre { get; set; }

        public int Costo { get; set; }

    }
}
