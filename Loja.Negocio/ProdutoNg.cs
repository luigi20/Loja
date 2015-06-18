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
    public class ProdutoNg
    {
        public List<Loja.Objeto.Models.Produto> listarTodosProdutosVendedor(int idVendedor)
        {

            return Loja.Objeto.DAO.ProdutoDAO.listarTodosProdutosVendedor(idVendedor);

        }
        public Loja.Objeto.Models.Produto Obter(int id)
        {
            return Loja.Objeto.DAO.ProdutoDAO.BuscarPorId(id);
        }
        public List<Loja.Objeto.Models.Produto> listarProduto(int idProduto)
        {
            return Loja.Objeto.DAO.ProdutoDAO.listarTodos(idProduto);
        }

        public List<Loja.Objeto.Models.Produto> listarProdutoPorDepartamento(int idDepartamento)
        {
            return Loja.Objeto.DAO.ProdutoDAO.listarProdutosPorDepartamento(idDepartamento);
        }

        public void Insert(Loja.Objeto.Models.Produto produto)
        {
            Loja.Objeto.DAO.ProdutoDAO.Insert(produto);
        }


        public int Insert2(Loja.Objeto.Models.Produto produto)
        {
            ConnectionStringSettingsCollection strConnection = ConfigurationManager.ConnectionStrings;
            SqlConnection conn = new SqlConnection(strConnection["ConnectionString"].ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                Loja.Objeto.BO.ProdutoBO.Gravar(produto);

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

        public void Update(Loja.Objeto.Models.Produto produto)
        {
            Loja.Objeto.BO.ProdutoBO.Gravar(produto);
        }

       

        public void Delete(Loja.Objeto.Models.Produto produto)
        {
            Loja.Objeto.BO.ProdutoBO.Apagar(produto);
        }

    
    }
}