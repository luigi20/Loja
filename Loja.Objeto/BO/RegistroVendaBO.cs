using System.Text;
using System.Threading.Tasks;
using Loja.Objeto.Models;
using Loja.Objeto.DAO;

namespace Loja.Objeto.BO
{
    public class RegistroVendaBO
    {
        public static void Gravar(RegistroVenda registroVenda)
        {


            if (registroVenda.IdRegistroVenda != 0)
            {
                //altera

                RegistroVendaDAO.Update(registroVenda);
            }
            else
            {
                //inserir
                RegistroVendaDAO.Insert(registroVenda);
            }

        }

        public static void Apagar(RegistroVenda registroVenda)
        {

           RegistroVendaDAO.Delete(registroVenda);
        }
    }
}