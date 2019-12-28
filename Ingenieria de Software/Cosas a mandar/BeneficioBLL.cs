using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BeneficioBLL
    {
        public BeneficioBLL()
        {

        }
        
        public BeneficioBLL(int idbeneficio, string nombre)
        {
            IdBeneficio = idbeneficio;
            Nombre = nombre;
        }

        public List<BeneficioBLL> ComboBeneficios()
        {
            OnTourEntities modelo = new OnTourEntities();
            List<BeneficioBLL> lista = new List<BeneficioBLL>();
            foreach (var item in modelo.beneficio)
            {
                lista.Add(new BeneficioBLL(item.idbenefico, item.nombre));
            }
            return lista;
        }



        private int idBeneficio;
        public int IdBeneficio
        {
            get
            {
                return idBeneficio;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    idBeneficio = value;
                }
                else
                {
                    throw new Exception("Id Beneficio no puede estar vacio");
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
                    throw new Exception("Nombre Beneficio no puede estar vacio");
                }
            }
        }

        private int porcBeneficio;
        public int PorcBeneficio
        {
            get
            {
                return porcBeneficio;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    porcBeneficio = value;
                }
                else
                {
                    throw new Exception("Porcentaje Beneficio no pude estar vacio");
                }
            }
        }

    }
}
