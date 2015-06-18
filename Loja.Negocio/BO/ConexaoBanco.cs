using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Loja.Negocio.BO
{
    public class ConexãoBanco
    {
        public static SqlConnection Conectar()
        {
            string stringConexao = "Data Source=(LocalDb)\v11.0;"+
                                    "Initial Catalog=aspnet-Loja.Interface-20150510223904;"+
                                    "Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnet-Loja.Interface-20150510223904.mdf";
            SqlConnection conexao = new SqlConnection( stringConexao);
            conexao.Open();
            return conexao;

        }

        public static void CRUD(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            comando.ExecuteNonQuery();
            con.Close();
        }

        public static SqlDataReader Selecionar(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

      
    }
}
