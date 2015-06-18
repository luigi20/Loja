using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Negocio.Models
{
    public class Vendedor
    {
        private int idVendedor;
        private int departamentoVendedor;
        private int chefeDepartamentoVendedor;
        private string nomeVendedor;
        private string rgVendedor;
        private string cpfVendedor;
        private DateTime dataAdmissaoVendedor;
        private string situacaoVendedor;

        public Vendedor(int idVendedor, int departamentoVendedor, int chefeDepartamentoVendedor, string nomeVendedor,
                        string rgVendedor, string cpfVendedor, DateTime dataAdmissaoVendedor,string situacaoVendedor)
        {
            this.idVendedor = idVendedor;
            this.departamentoVendedor = departamentoVendedor;
            this.chefeDepartamentoVendedor = chefeDepartamentoVendedor;
            this.nomeVendedor = nomeVendedor;
            this.rgVendedor = rgVendedor;
            this.cpfVendedor = cpfVendedor;
            this.dataAdmissaoVendedor = dataAdmissaoVendedor;
            this.situacaoVendedor = situacaoVendedor;
        }
        public string SituacaoVendedor
        {
            get { return situacaoVendedor; }
            set { situacaoVendedor = value; }
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

        public int ChefeDepartamentoVendedor
        {
            get { return chefeDepartamentoVendedor; }
            set { chefeDepartamentoVendedor = value; }
        }

        public string NomeVendedor
        {
            get { return nomeVendedor; }
            set { nomeVendedor = value; }
        }

        public string RgVendedor
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