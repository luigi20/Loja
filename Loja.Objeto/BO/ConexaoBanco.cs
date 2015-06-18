using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Loja.Objeto.BO
{
    public class ConexãoBanco
    {
       /* public static SqlConnection Conectar()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conexao = new SqlConnection(stringConexao);
             conexao.Open();
            return conexao;

        }
        */

        public static void CRUD(SqlCommand comando)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conexao = new SqlConnection(stringConexao);
            try
            {                
                conexao.Open();              
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {

                conexao.Close();
            }
        }

        public static SqlDataReader Selecionar(SqlCommand comando)
        {

            string stringConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conexao = new SqlConnection(stringConexao);
            try
            {
                conexao.Open();
                comando.Connection = conexao;
            }
            catch
            {
                throw;
            }
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
            
            return dr;
        }


    }
}
