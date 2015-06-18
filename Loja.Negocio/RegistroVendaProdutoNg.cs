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
    public class RegistroVendaProdutoNg
    {
        public List<Loja.Objeto.Models.RegistroVendaProduto> Obter(int id)
        {
            return Loja.Objeto.DAO.RegistroVendaProdutoDAO.BuscarPorId(id);
        }

        public List<double> VendasPorMes(DateTime dataInicio, DateTime dataFim)
        {
            return Loja.Objeto.DAO.RegistroVendaProdutoDAO.VendaPorMes(dataInicio, dataFim);
        }

        public List<Loja.Objeto.Models.RegistroVendaProduto> listarTodos(int id)
        {
            return Loja.Objeto.DAO.RegistroVendaProdutoDAO.listarTodos(id);
        }


        public int Insert2(Loja.Objeto.Models.RegistroVendaProduto registroVendaProduto,Loja.Objeto.Models.RegistroVendaProduto registroProduto)
        {
            ConnectionStringSettingsCollection strConnection = ConfigurationManager.ConnectionStrings;
            SqlConnection conn = new SqlConnection(strConnection["ConnectionString"].ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                Loja.Objeto.BO.RegistroVendaProdutoBO.Gravar2(registroVendaProduto, registroProduto);

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

        public void Update(Loja.Objeto.Models.RegistroVendaProduto registroVendaProduto)
        {
            Loja.Objeto.BO.RegistroVendaProdutoBO.Gravar(registroVendaProduto);

        }
        public void Delete(Loja.Objeto.Models.RegistroVendaProduto registroVendaProduto)
        {
            Loja.Objeto.BO.RegistroVendaProdutoBO.Apagar(registroVendaProduto);
        }
    }

}
