using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loja.Objeto.DAO;
namespace Loja.Objeto.Models
{
    public class Produto
    {
        private Departamento departamento;
        private int idProduto;
        private int departamentoProduto;
        private string nomeProduto;
        private double precoProduto;
        private int quantidadeProduto;
        private int idProdutoSimilar;
        private Produto produtoSimilar;

        public Produto()
        {

        }
        public  Produto (int idProduto, int departamentoProduto,string nomeProduto,double precoProduto,int quantidadeProduto,int idProdutoSimilar )
        {
            this.idProduto = idProduto;
            this.nomeProduto = nomeProduto;
            this.precoProduto = precoProduto;
            this.quantidadeProduto = quantidadeProduto;
            this.departamentoProduto = departamentoProduto;
            this.idProdutoSimilar = idProdutoSimilar;
        }

        public Departamento Departamento
        {
            get
            {
                if (this.departamento == null)
                {
                    this.departamento = DepartamentoDAO.BuscarPorId(departamentoProduto);
                }

                return departamento;
            }

        }

        public Produto ProdutoSimilar
        {
            get
            {
                if (this.produtoSimilar == null)
                {
                    this.produtoSimilar = ProdutoDAO.BuscarPorId(idProdutoSimilar);
                }

                return produtoSimilar;
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

        public int IdProdutoSimilar
        {
            get { return idProdutoSimilar; }
            set { idProdutoSimilar = value; }
        }
    }
}