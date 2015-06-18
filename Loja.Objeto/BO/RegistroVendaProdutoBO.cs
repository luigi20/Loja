using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Loja.Objeto.Models;
using Loja.Objeto.DAO;

namespace Loja.Objeto.BO
{
    public class RegistroVendaProdutoBO
    {
        public static void Gravar(RegistroVendaProduto registroVendaProduto)
        {

          
            if (registroVendaProduto.IdRegistroVendaProduto!= 0)
            {
                //altera

                RegistroVendaProdutoDAO.Update(registroVendaProduto);
            }
            else
            {
                //inserir
                RegistroVendaProdutoDAO.Insert(registroVendaProduto);
            }

        }

        public static void Apagar(RegistroVendaProduto registroVendaProduto)
        {

            RegistroVendaProdutoDAO.Delete(registroVendaProduto);
        }

        public static void Gravar2(RegistroVendaProduto registroVendaProduto, RegistroVendaProduto registroProduto)
        {


            if ((registroVendaProduto.ProdutoIdProduto == registroProduto.ProdutoIdProduto) 
                && (registroVendaProduto.RegistroVendaIdVenda == registroProduto.RegistroVendaIdVenda))
            {
                //altera

                RegistroVendaProdutoDAO.UpdateQuantidadeComprada(registroVendaProduto, registroProduto);
            }
            else
            {
                //inserir
                RegistroVendaProdutoBO.Gravar(registroVendaProduto);
            }

        }
    }
}