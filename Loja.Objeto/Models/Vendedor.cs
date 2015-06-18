using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loja.Objeto.DAO;
namespace Loja.Objeto.Models
{
    public class Vendedor
    {
        private int idVendedor;
        private int departamentoVendedor;
        private string nomeVendedor;
        private int rgVendedor;
        private string cpfVendedor;
        private DateTime dataAdmissaoVendedor;
        private string situacaoVendedor;
        private string nivelEscolaridade;
        private Departamento departamento;
        public Vendedor()
        {

        }

        public Vendedor(int idVendedor, int departamentoVendedor,  string nomeVendedor,
                        int rgVendedor, string cpfVendedor, DateTime dataAdmissaoVendedor,string situacaoVendedor,string nivelEscolaridade)
        {
            this.idVendedor = idVendedor;
            this.departamentoVendedor = departamentoVendedor;
        
            this.nomeVendedor = nomeVendedor;
            this.rgVendedor = rgVendedor;
            this.cpfVendedor = cpfVendedor;
            this.dataAdmissaoVendedor = dataAdmissaoVendedor;
            this.situacaoVendedor = situacaoVendedor;
            this.nivelEscolaridade = nivelEscolaridade;
        }

        public Departamento Departamento
        {
            get
            {
                if (this.departamento== null)
                {
                    this.departamento = DepartamentoDAO.BuscarPorId(departamentoVendedor);
                }

                return departamento;
            }
        }
        public string SituacaoVendedor
        {
            get { return situacaoVendedor; }
            set { situacaoVendedor = value; }
        }

        public string NivelEscolaridade
        {
            get { return nivelEscolaridade; }
            set { nivelEscolaridade = value; }
        }

        public int IdVendedor
        {
            get { return idVendedor; }
            set { idVendedor = value; }
        }

        public int DepartamentoVendedor
        {
            get { return departamentoVendedor; }
            set { departamentoVendedor = value; }
        }

       

        public string NomeVendedor
        {
            get { return nomeVendedor; }
            set { nomeVendedor = value; }
        }

        public int RgVendedor
        {
            get { return rgVendedor; }
            set { rgVendedor = value; }
        }

        public string CpfVendedor
        {
            get { return cpfVendedor; }
            set { cpfVendedor = value; }
        }

        public DateTime DataAdmissaoVendedor
        {
            get { return dataAdmissaoVendedor; }
            set { dataAdmissaoVendedor = value; }
        }
    }
}