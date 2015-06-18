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
    public class VendaNg
    {
        public Loja.Objeto.Models.Venda Obter(int id)
        {
            return Loja.Objeto.DAO.VendaDAO.BuscarPorId(id);
        }

        public List<Loja.Objeto.Models.Venda> listarTodos(int idVendedor)
        {
            return Loja.Objeto.DAO.VendaDAO.listarTodos(idVendedor);
        }

        public List<Loja.Objeto.Models.Venda> VendasEfetuadasPorVendedor(int idVendedor, DateTime dataInicio, DateTime dataFim)
        {
            return Loja.Objeto.DAO.VendaDAO.VendasEfetuadasPorVendedor(idVendedor, dataInicio, dataFim);
        }

        public int Insert2(Loja.Objeto.Models.Venda venda)
        {
            ConnectionStringSettingsCollection strConnection = ConfigurationManager.ConnectionStrings;
            SqlConnection conn = new SqlConnection(strConnection["ConnectionString"].ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                Loja.Objeto.BO.VendaBO.Gravar(venda);

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

        public void Update(Loja.Objeto.Models.Venda venda)
        {
            Loja.Objeto.BO.VendaBO.Gravar(venda);

        }
        public void Delete(Loja.Objeto.Models.Venda venda)
        {
            Loja.Objeto.BO.VendaBO.Apagar(venda);
        }
    }
}