using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Negocio.Models
{
    public class RegistroVenda
    {

        private int idVenda;

        private int idDepartamento;

        private int idProduto;

        private double comissao;

        private int idVendedor;

        public RegistroVenda(int idVenda, int idDepartamento, int idProduto, double comissao, int idVendedor)
        {
            this.idVenda = idVenda;
            this.idDepartamento = idDepartamento;
            this.idProduto = idProduto;
            this.comissao = comissao;
            this.idVendedor = idVendedor;
        }

        public int IdVendedor
        {
            get { return idVendedor; }
            set { idVendedor = value; }
        }

        public int IdVenda
        {
            get { return idVenda; }
            set { idVenda = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

        public int IdProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }
        public double Comissao
        {
            get { return comissao; }
            set { comissao = value; }
        }

    }
}