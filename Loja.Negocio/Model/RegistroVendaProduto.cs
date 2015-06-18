using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Negocio.Models
{
    public class RegistroVendaProduto
    {
        private int registroVendaIdProduto;

        private int produtoIdProduto;

        private int registroVendaIdRegistroVenda;       

        private double valorUnitario;

        public RegistroVendaProduto(int registroVendaIdProduto,int registroVendaIdRegistroVenda, int produtoIdProduto,double valorUnitario)
        {
            this.produtoIdProduto = produtoIdProduto;
            this.registroVendaIdRegistroVenda = registroVendaIdRegistroVenda;
            this.registroVendaIdProduto = registroVendaIdProduto;
            this.valorUnitario = valorUnitario;

        }

        public double ValorUnitario
        {
            get { return valorUnitario; }
            set { valorUnitario = value; }
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

        public int RegistroVendaIdProduto
        {
            get { return registroVendaIdProduto; }
            set { registroVendaIdProduto = value; }
        }

    }
}