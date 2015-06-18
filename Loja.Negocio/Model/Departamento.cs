using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Negocio.Models
{
    public class Departamento
    {
        private static Departamento instance;
        private int idDepartamento;
        private string nomeDepartamento;
        private string siglaDepartamento;
        private double comissaoDepartamento;

        
        private Departamento()
        {

        }

        public static Departamento getInstance
        {
            get
            {
                if (instance == null)
                {

                    instance = new Departamento();

                }
                return instance;
            }

        }
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

        public string NomeDepartamento
        {
            get { return nomeDepartamento; }
            set { nomeDepartamento = value; }
        }

        public string SiglaDepartamento
        {
            get { return siglaDepartamento; }
            set { siglaDepartamento = value; }
        }

        public double ComissaoDepartamento
        {
            get { return comissaoDepartamento; }
            set { comissaoDepartamento = value; }
        }



    }
}