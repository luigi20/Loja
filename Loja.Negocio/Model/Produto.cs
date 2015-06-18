using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Negocio.Models
{
    public class Produto
    {
        private static Produto instance;
        private int idProduto;
        private int departamentoProduto;
        private string nomeProduto;
        private double precoProduto;
        private int quantidadeProduto;

        private Produto()
        {

        }
        public static Produto getInstance
        {
            get
            {
                if (instance == null)
                {

                    instance = new Produto();

                }
                return instance;
            }

        }

        public int IdProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }

        public int DepartamentoProduto
        {
            get { return departamentoProduto; }
            set { departamentoProduto = value; }

        }

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public double PrecoProduto
        {
            get { return precoProduto; }
            set { precoProduto = value; }
        }

        public int QuantidadeProduto
        {
            get { return quantidadeProduto; }
            set { quantidadeProduto = value; }
        }
    }
}