using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Objeto.Models;
using Loja.Objeto.DAO;

namespace Loja.Objeto.BO
{
    public class VendaBO
    {
        public static void Gravar(Venda venda)
        {


            if (venda.IdVenda != 0)
            {
                //altera

                VendaDAO.Update(venda);
            }
            else
            {
                //inserir
                VendaDAO.Insert(venda);
            }

        }

        public static void Apagar(Venda venda)
        {

            VendaDAO.Delete(venda);
        }
    }
}