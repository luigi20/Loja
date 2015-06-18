using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Objeto.BO;
using System.ComponentModel;
using Loja.Objeto.Models;
using System.Data.SqlClient;
using System.Data;

namespace Loja.Objeto.DAO
{
    public class ProdutoDAO
    {
        public static void Insert(Produto produto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Insert into Produto(Departamento_idDepartamento,
                                                        Nome_Produto,
                                                        Preco_Produto,
                                                        Quantidade_Produto,
                                                        idProdutoSimilar) 
                                             values(@Departamento_idDepartamento,
                                                    @Nome_Produto,
                                                    @Preco_Produto,
                                                    @Quantidade_Produto,
                                                    @idProdutoSimilar)";

            comando.Parameters.AddWithValue("@Departamento_idDepartamento", produto.DepartamentoProduto);
            comando.Parameters.AddWithValue("@Nome_Produto", produto.NomeProduto);
            comando.Parameters.AddWithValue("@Preco_Produto", produto.PrecoProduto);
            comando.Parameters.AddWithValue("@Quantidade_Produto", produto.QuantidadeProduto);
            comando.Parameters.AddWithValue("@idProdutoSimilar", produto.IdProdutoSimilar);
            ConexãoBanco.CRUD(comando);
        }

        public static void Update(Produto produto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Update Produto set Departamento_idDepartamento = @Departamento_idDepartamento,
                                                                    Nome_Produto = @Nome_Produto,
                                                                    Preco_Produto = @Preco_Produto,
                                                                    Quantidade_Produto = @Quantidade_Produto,
                                                                    idProdutoSimilar = @idProdutoSimilar 
                                            where idProduto = @idProduto";
            comando.Parameters.AddWithValue("@idProduto", produto.IdProduto);
            comando.Parameters.AddWithValue("@Departamento_idDepartamento", produto.DepartamentoProduto);
            comando.Parameters.AddWithValue("@Nome_Produto", produto.NomeProduto);
            comando.Parameters.AddWithValue("@Preco_Produto", produto.PrecoProduto);
            comando.Parameters.AddWithValue("@Quantidade_Produto", produto.QuantidadeProduto);
            comando.Parameters.AddWithValue("@idProdutoSimilar", produto.IdProdutoSimilar);
            ConexãoBanco.CRUD(comando);
        }

        public static void Delete(Produto produto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete from Produto where idProduto = @idProduto";
            comando.Parameters.AddWithValue("@idProduto", produto.IdProduto);
            ConexãoBanco.CRUD(comando);
        }

        public static Produto BuscarPorId(int idProduto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Produto where idProduto = @idProduto";
            comando.Parameters.AddWithValue("@idProduto", idProduto);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            Produto produto = new Produto();
            int produtoId = dr.GetOrdinal("idProduto");
            int departamentoId = dr.GetOrdinal("Departamento_idDepartamento");
            int nomeProduto = dr.GetOrdinal("Nome_Produto");
            int precoProduto = dr.GetOrdinal("Preco_Produto");
            int quantidadeProduto = dr.GetOrdinal("Quantidade_Produto");
            if (dr.HasRows)
            {
                dr.Read();
                produto.IdProduto = dr.GetInt32(produtoId);
                produto.DepartamentoProduto = dr.GetInt32(departamentoId);
                produto.NomeProduto = dr.GetString(nomeProduto);
                produto.PrecoProduto = dr.GetFloat(precoProduto);
                produto.QuantidadeProduto = dr.GetInt32(quantidadeProduto);

                //preenche o objeto
            }
            else
            {
                produto = null;
            }
            return produto;
        }

        public static List<Produto> listarTodos(int produtoId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idProduto,Nome_Produto,Departamento_idDepartamento,Preco_Produto,
                                           Quantidade_Produto,idProdutoSimilar
                                    from Produto
                                    where(idProduto = @idProduto) or @idProduto is null";
            if (produtoId <= 0)
            {
                comando.Parameters.AddWithValue("@idProduto", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idProduto", produtoId);
            }
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Produto> listaProdutos = new List<Produto>();

            if (dr.HasRows)
            {
                int idProduto = dr.GetOrdinal("idProduto");
                int nomeProduto = dr.GetOrdinal("Nome_Produto");
                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int precoProduto = dr.GetOrdinal("Preco_Produto");
                int idProdutoSimilar = dr.GetOrdinal("idProdutoSimilar");
                int quantidadeProduto = dr.GetOrdinal("Quantidade_Produto");

                while (dr.Read())
                {
                    Produto produto = new Produto();
                    produto.IdProduto = dr.GetInt32(idProduto);
                    produto.DepartamentoProduto = dr.GetInt32(idDepartamento);
                    produto.NomeProduto = dr.GetString(nomeProduto);
                    produto.PrecoProduto = dr.GetFloat(precoProduto);
                    produto.QuantidadeProduto = dr.GetInt32(quantidadeProduto);
                    produto.IdProdutoSimilar = dr.GetValue(idProdutoSimilar) == DBNull.Value ? -1 : dr.GetInt32(idProdutoSimilar);
                    listaProdutos.Add(produto);
                }
            }
            else
            {
                listaProdutos = null;
            }
            return listaProdutos;
        }

        public static List<Produto> listarTodosProdutosVendedor(int vendedorId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select Produto.idProduto,
                                           Produto.Nome_Produto,
                                           Produto.Departamento_idDepartamento,
                                           Produto.Preco_Produto,
                                           Produto.Quantidade_Produto,
                                           Produto.idProdutoSimilar
                                    from Vendedor inner join Departamento on Vendedor.Departamento_idDepartamento = Departamento.idDepartamento
                                         inner join Produto on Produto.Departamento_idDepartamento = Departamento.idDepartamento
                                      where Vendedor.idVendedor = @vendedorId";

            if (vendedorId <= 0)
            {
                comando.Parameters.AddWithValue("@vendedorId", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@vendedorId", vendedorId);
            }
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Produto> listaProdutos = new List<Produto>();

            if (dr.HasRows)
            {
                int idProduto = dr.GetOrdinal("idProduto");
                int nomeProduto = dr.GetOrdinal("Nome_Produto");
                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int precoProduto = dr.GetOrdinal("Preco_Produto");
                int idProdutoSimilar = dr.GetOrdinal("idProdutoSimilar");
                int quantidadeProduto = dr.GetOrdinal("Quantidade_Produto");

                while (dr.Read())
                {
                    Produto produto = new Produto();
                    produto.IdProduto = dr.GetInt32(idProduto);
                    produto.DepartamentoProduto = dr.GetInt32(idDepartamento);
                    produto.NomeProduto = dr.GetString(nomeProduto);
                    produto.PrecoProduto = dr.GetFloat(precoProduto);
                    produto.QuantidadeProduto = dr.GetInt32(quantidadeProduto);
                    produto.IdProdutoSimilar = dr.GetValue(idProdutoSimilar) == DBNull.Value ? -1 : dr.GetInt32(idProdutoSimilar);
                    listaProdutos.Add(produto);
                }
            }
            else
            {
                listaProdutos = null;
            }
            return listaProdutos;
        }

        public static List<Loja.Objeto.Models.Produto> DepartamentoPorProduto(int idDepartamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"select Produto.idProduto,
                                           Produto.Nome_Produto,
                                           Produto.Preco_Produto,
                                            Produto.Quantidade_Produto,
                                           Produto.Departamento_idDepartamento
                                     from Produto
                                   where Produto.Departamento_idDepartamento = @idDepartamento or @idDepartamento is null ";

            if (idDepartamento <= 0)
            {
                comando.Parameters.AddWithValue("@idDepartamento", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idDepartamento", idDepartamento);
            }
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Loja.Objeto.Models.Produto> listaProduto = new List<Loja.Objeto.Models.Produto>();

            if (dr.HasRows)
            {

                int idProduto = dr.GetOrdinal("idProduto");
                int nomeProduto = dr.GetOrdinal("Nome_Produto");
                int precoProduto = dr.GetOrdinal("Preco_Produto");
                int quantidadeProduto = dr.GetOrdinal("Quantidade_Produto");
                int departamentoId = dr.GetOrdinal("Departamento_idDepartamento");
                while (dr.Read())
                {
                    Produto produto = new Produto();
                    produto.IdProduto = dr.GetInt32(idProduto);
                    produto.NomeProduto = dr.GetString(nomeProduto);
                    produto.PrecoProduto = dr.GetFloat(precoProduto);
                    produto.QuantidadeProduto = dr.GetInt32(quantidadeProduto);
                    produto.DepartamentoProduto = dr.GetInt32(departamentoId);
                    listaProduto.Add(produto);
                }
                //preenche o objeto
            }
            else
            {
                listaProduto = null;
            }
            return listaProduto;

        }
        public static List<Produto> listarProdutosPorDepartamento(int departamentoId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select Produto.idProduto,
                                           Produto.Nome_Produto,
                                           Produto.Departamento_idDepartamento,
                                           Produto.Preco_Produto,
                                           Produto.Quantidade_Produto,
                                           Produto.idProdutoSimilar
                                    from Produto
                                    where  Produto.Departamento_idDepartamento = @idDepartamento";
            comando.Parameters.AddWithValue("@idDepartamento", departamentoId);

            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Produto> listaProdutos = new List<Produto>();

            if (dr.HasRows)
            {
                int idProduto = dr.GetOrdinal("idProduto");
                int nomeProduto = dr.GetOrdinal("Nome_Produto");
                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int precoProduto = dr.GetOrdinal("Preco_Produto");
                int idProdutoSimilar = dr.GetOrdinal("idProdutoSimilar");
                int quantidadeProduto = dr.GetOrdinal("Quantidade_Produto");

                while (dr.Read())
                {
                    Produto produto = new Produto();
                    produto.IdProduto = dr.GetInt32(idProduto);
                    produto.DepartamentoProduto = dr.GetInt32(idDepartamento);
                    produto.NomeProduto = dr.GetString(nomeProduto);
                    produto.PrecoProduto = dr.GetFloat(precoProduto);
                    produto.QuantidadeProduto = dr.GetInt32(quantidadeProduto);
                    produto.IdProdutoSimilar = dr.GetValue(idProdutoSimilar) == DBNull.Value ? -1 : dr.GetInt32(idProdutoSimilar);
                    listaProdutos.Add(produto);
                }
            }
            else
            {
                listaProdutos = null;
            }
            return listaProdutos;
        }

        public static void AtualizarEstoque(Produto produto, int quantidade)
        {

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            produto.QuantidadeProduto = produto.QuantidadeProduto - quantidade;

            comando.CommandText = @"Update Produto set Quantidade_Produto = @Quantidade_Produto
                                                   where idProduto = @idProduto";

            comando.Parameters.AddWithValue("@idProduto", produto.IdProduto);

            comando.Parameters.AddWithValue("@Quantidade_Produto", produto.QuantidadeProduto );
            ConexãoBanco.CRUD(comando);
        }

    }
}