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
    public class RegistroVendaProdutoFachada
    {
        private static Loja.Negocio.RegistroVendaProdutoNg registroVendaProdutoNg = new Negocio.RegistroVendaProdutoNg();
       
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.RegistroVendaProduto> Obter(int id)
        {
            return registroVendaProdutoNg.Obter(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<double> VendaPorMes(DateTime dataInicio, DateTime dataFim)
        {
            return registroVendaProdutoNg.VendasPorMes(dataInicio, dataFim);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(Loja.Objeto.Models.RegistroVendaProduto registroVendaProduto, Loja.Objeto.Models.RegistroVendaProduto registroProduto)
        {

            int inserir = registroVendaProdutoNg.Insert2(registroVendaProduto,registroProduto);
            return inserir;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(List<Loja.Objeto.Models.Produto> listaProduto)
        {
            Loja.Objeto.Models.RegistroVendaProduto registroVendaProduto = new Loja.Objeto.Models.RegistroVendaProduto();
            List<Loja.Objeto.Models.RegistroVenda> listaRegistroVenda = new List<Objeto.Models.RegistroVenda>();

            List<Loja.Objeto.Models.RegistroVendaProduto> listaRegistroVendaProduto = new List<Objeto.Models.RegistroVendaProduto>();
            listaRegistroVenda = Loja.Fachada.Fachada.RegistroVendaFachada.listarTodos(0);
            Loja.Objeto.Models.RegistroVendaProduto registroProduto = new Objeto.Models.RegistroVendaProduto();
            for (int i = listaRegistroVenda.Count - 1; i == listaRegistroVenda.Count - 1; i++)
            {
                registroVendaProduto.RegistroVendaIdRegistroVenda = listaRegistroVenda[i].IdRegistroVenda;
                registroVendaProduto.RegistroVendaIdVenda = listaRegistroVenda[i].IdVenda;
            }

            foreach (Loja.Objeto.Models.Produto produto in listaProduto)
            {

                listaRegistroVendaProduto = Loja.Fachada.Fachada.RegistroVendaProdutoFachada.listarTodos(0);
                if (listaRegistroVendaProduto != null)
                {
                    for (int i = listaRegistroVendaProduto.Count - 1; i == listaRegistroVendaProduto.Count - 1; i++)
                    {
                        registroProduto = listaRegistroVendaProduto[i];
                    }
                }
                registroVendaProduto.ProdutoIdProduto= produto.IdProduto;
                registroVendaProduto.ValorUnitario = produto.PrecoProduto;
                registroVendaProduto.QuantidadeProduto = 1;
                registroVendaProduto.SubTotal = produto.PrecoProduto;
                registroVendaProdutoNg.Insert2(registroVendaProduto,registroProduto);
                Loja.Objeto.DAO.ProdutoDAO.AtualizarEstoque(produto, 1);

            }
           
            
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Loja.Objeto.Models.RegistroVendaProduto registroVendaProduto)
        {
            registroVendaProdutoNg.Update(registroVendaProduto);
        }



        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Loja.Objeto.Models.RegistroVendaProduto registroVendaProduto)
        {
            registroVendaProdutoNg.Delete(registroVendaProduto);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.RegistroVendaProduto> listarTodos(int id)
        {
            return registroVendaProdutoNg.listarTodos(id);

        }


    }
}