using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loja.Objeto.DAO;

namespace Loja.Objeto.Models
{
    public class RegistroVenda
    {
        private Departamento departamento;

        private Vendedor vendedor;

        private int idRegistroVenda;

        private int idVenda;

        private int idDepartamento;


        private double comissao;

        private int idVendedor;

        public RegistroVenda()
        {

        }
        public RegistroVenda(int idVenda, int idDepartamento,double comissao, int idVendedor)
        {
            this.idVenda = idVenda;
            this.idDepartamento = idDepartamento;
   
            this.comissao = comissao;
            this.idVendedor = idVendedor;
        }

        public Departamento Departamento
        {
            get
            {
                if (this.departamento == null)
                {
                    this.departamento = DepartamentoDAO.BuscarPorId(idDepartamento);
                }

                return departamento;
            }
          
        }

        public Vendedor Vendedor
        {
            get
            {
                if (this.vendedor == null)
                {
                    this.vendedor = VendedorDAO.BuscarPorId(idVendedor);
                }

                return vendedor;
            }
          
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

        public int IdRegistroVenda
        {
            get { return idRegistroVenda; }
            set { idRegistroVenda = value; }
        }

        public int IdDepartamento
        {
            get
            {
                //              if (_departamento == null)
                //                  _departamento = Departamento.DAO.Obter(idDepartamento);

                //            return _departamento;

                return idDepartamento;
            }
            set { idDepartamento = value; }
        }

     
 
        public double Comissao
        {
            get { return comissao; }
            set { comissao = value; }
        }

    }
}