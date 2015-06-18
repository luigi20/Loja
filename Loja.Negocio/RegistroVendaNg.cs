using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Loja.Negocio
{
    public class RegistroVendaNg
    {
        public Loja.Objeto.Models.RegistroVenda Obter(int id)
        {
            return Loja.Objeto.DAO.RegistroVendaDAO.BuscarPorId(id);
        }

        public List<Loja.Objeto.Models.RegistroVenda> listarTodos(int idRegistroVenda)
        {
            return Loja.Objeto.DAO.RegistroVendaDAO.listarTodos(idRegistroVenda);
        }





        public int Insert2(Loja.Objeto.Models.RegistroVenda registroVenda)
        {
            ConnectionStringSettingsCollection strConnection = ConfigurationManager.ConnectionStrings;
            SqlConnection conn = new SqlConnection(strConnection["ConnectionString"].ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                Loja.Objeto.BO.RegistroVendaBO.Gravar(registroVenda);

                // regra de negócio
                // atualizações, deleções, inserções

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

            return 1;
        }

        public void Update(Loja.Objeto.Models.RegistroVenda registroVenda)
        {
            Loja.Objeto.BO.RegistroVendaBO.Gravar(registroVenda);

        }
        public void Delete(Loja.Objeto.Models.RegistroVenda registroVenda)
        {
            Loja.Objeto.BO.RegistroVendaBO.Apagar(registroVenda);
        }
    }

}
