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
    public class RegistroVendaFachada
    {
           private static Loja.Negocio.RegistroVendaNg registroVendaNg = new Negocio.RegistroVendaNg();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.RegistroVenda Obter(int id)
        {
            return registroVendaNg.Obter(id);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(Loja.Objeto.Models.RegistroVenda registroVenda)
        {

            int inserir = registroVendaNg.Insert2(registroVenda);
            return inserir;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(int idVendedor, List<Loja.Objeto.Models.Produto> listaProduto,double valorComissao)
        {
            Loja.Objeto.Models.RegistroVenda registroVenda = new Loja.Objeto.Models.RegistroVenda();


            for (int i = listaProduto.Count - 1; i == listaProduto.Count - 1; i++)
            {
                registroVenda.IdDepartamento = listaProduto[i].DepartamentoProduto;

            }
            registroVenda.IdVendedor = idVendedor;
            registroVenda.Comissao = Loja.Objeto.DAO.DepartamentoDAO.ValorComissao(registroVenda.IdDepartamento, valorComissao);
            List<Loja.Objeto.Models.Venda> listaVenda = Loja.Objeto.DAO.VendaDAO.listarTodos(0);
            for (int i = listaVenda.Count-1; i == listaVenda.Count-1; i++)
            {
                registroVenda.IdVenda = listaVenda[i].IdVenda;
                
            }
          


            int inserir = registroVendaNg.Insert2(registroVenda);
            return inserir;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Loja.Objeto.Models.RegistroVenda registroVenda)
        {
            registroVendaNg.Update(registroVenda);
        }



        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Loja.Objeto.Models.RegistroVenda registroVenda)
        {
            registroVendaNg.Delete(registroVenda);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.RegistroVenda> listarTodos(int idRegistroVenda)
        {
            return registroVendaNg.listarTodos(idRegistroVenda);

        }

        


    }
   }