using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Loja.Negocio;
using System.ComponentModel;

namespace Loja.Fachada.Fachada
{
    [DataObject(true)]
    public class VendaFachada
    {
        private static Loja.Negocio.VendaNg vendaNg = new Negocio.VendaNg();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.Venda Obter(int id)
        {
            return vendaNg.Obter(id);
        }

  

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Venda> VendasEfetuadasPorVendedor(int idVendedor, DateTime dataInicio, DateTime dataFim)
        {
            return vendaNg.VendasEfetuadasPorVendedor(idVendedor, dataInicio, dataFim);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(Loja.Objeto.Models.Venda venda)
        {
            
            int inserir = vendaNg.Insert2(venda);
            return inserir;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(DateTime data,double valor,List<Loja.Objeto.Models.Produto> listaProduto)
        {
            Loja.Objeto.Models.Venda venda = new Objeto.Models.Venda();

            venda.DataVenda = data;

            venda.ValorTotal = valor;
            venda.ListaProduto = listaProduto;
            
            int inserir = vendaNg.Insert2(venda);
            return inserir;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Loja.Objeto.Models.Venda venda)
        {
            vendaNg.Update(venda);
        }



        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Loja.Objeto.Models.Venda venda)
        {
            vendaNg.Delete(venda);
        }        

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Venda> listarTodos(int idVenda)
        {
            return vendaNg.listarTodos(idVenda);

        }


    }
}