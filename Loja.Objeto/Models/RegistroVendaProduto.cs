using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loja.Objeto.DAO;

namespace Loja.Objeto.Models
{
    public class RegistroVendaProduto
    {
        private Produto produto;

        private int produtoIdProduto;

        private int registroVendaIdVenda;

        private int registroVendaIdRegistroVenda;

        private int idRegistroVendaProduto;

        private double valorUnitario;

        private int quantidadeProduto;

        private double subTotal;

        public RegistroVendaProduto(int registroVendaIdRegistroVenda, int produtoIdProduto,double valorUnitario)
        {
            this.produtoIdProduto = produtoIdProduto;
            this.registroVendaIdRegistroVenda = registroVendaIdRegistroVenda;
       
            this.valorUnitario = valorUnitario;

        }

        public RegistroVendaProduto()
        {

        }

        public Produto Produto
        {
            get
            {
                if (this.produto == null)
                {
                    this.produto = ProdutoDAO.BuscarPorId(produtoIdProduto);
                }

                return produto;
            }

        }

        public double ValorUnitario
        {
            get { return valorUnitario; }
            set { valorUnitario = value; }
        }

        public double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public int RegistroVendaIdRegistroVenda
        {
            get { return registroVendaIdRegistroVenda; }
            set { registroVendaIdRegistroVenda = value; }
        }

        public int ProdutoIdProduto
        {
            get { return produtoIdProduto; }
            set { produtoIdProduto = value; }
        }

        public int IdRegistroVendaProduto
        {
            get { return idRegistroVendaProduto; }
            set { idRegistroVendaProduto = value; }
        }

        public int QuantidadeProduto
        {
            get { return quantidadeProduto; }
            set { quantidadeProduto = value; }
        }
        public int RegistroVendaIdVenda
        {
            get { return registroVendaIdVenda; }
            set { registroVendaIdVenda = value; }
        }

    }
}