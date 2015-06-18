using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Objeto.Models;
using Loja.Objeto.DAO;

namespace Loja.Objeto.BO
{
    public class ProdutoBO
    {
        public static void Gravar(Produto produto)
        {


            if (produto.IdProduto != 0)
            {
                //altera

                ProdutoDAO.Update(produto);
            }
            else
            {
                //inserir
                ProdutoDAO.Insert(produto);
            }

        }

        public static void Apagar(Produto produto)
        {

            ProdutoDAO.Delete(produto);
        }
    }
}