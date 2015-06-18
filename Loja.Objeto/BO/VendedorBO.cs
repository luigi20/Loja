using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Objeto.Models;
using Loja.Objeto.DAO;

namespace Loja.Objeto.BO
{
    public class VendedorBO
    {
        public static void Gravar(Vendedor vendedor)
        {


            if (vendedor.IdVendedor != 0)
            {
                //altera

                VendedorDAO.Update(vendedor);
            }
            else
            {
                //inserir
                VendedorDAO.Insert(vendedor);
            }

        }

        public static void Apagar(Vendedor vendedor)
        {

            VendedorDAO.Delete(vendedor);
        }
    }
}
