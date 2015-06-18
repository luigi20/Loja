using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Negocio;

namespace Loja.Fachada.Fachada
{
    [DataObject(true)]
    public class VendedorFachada
    {
        private static Loja.Negocio.VendedorNg VendedorNg = new Negocio.VendedorNg();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.Vendedor Obter(int id)
        {
            return VendedorNg.Obter(id);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(Loja.Objeto.Models.Vendedor vendedor)
        {

            int inserir = VendedorNg.Insert2(vendedor);
            return inserir;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(string nomeVendedor, string cpf, int rg, 
                                 DateTime data,int departamentoVendedor,string nivelEscolaridade,string situacao)
        {
            Loja.Objeto.Models.Vendedor vendedor = new Objeto.Models.Vendedor();
            vendedor.NomeVendedor = nomeVendedor;
           
            vendedor.CpfVendedor = cpf;
            vendedor.RgVendedor = rg;
            vendedor.DataAdmissaoVendedor = data;
            vendedor.DepartamentoVendedor = departamentoVendedor;
            vendedor.NivelEscolaridade = nivelEscolaridade;
            vendedor.SituacaoVendedor = situacao;
            int inserir = VendedorNg.Insert2(vendedor);
            return inserir;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Loja.Objeto.Models.Vendedor vendedor)
        {
            VendedorNg.Update(vendedor);
        }

   

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Loja.Objeto.Models.Vendedor vendedor)
        {
            VendedorNg.Delete(vendedor);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.Vendedor listarVendedor(int idVendedor)
        {
            return VendedorNg.listarVendedor(idVendedor);

        }

       
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Vendedor> listarPossiveisChefes()
        {
            return VendedorNg.listarPossiveisChefes();

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Vendedor> listarTodosChefes()
        {
            return VendedorNg.listarTodosChefes();

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Vendedor> listarTodos(int idChefe)
        {
            return VendedorNg.listarTodos(idChefe);

        }

        
    }
}