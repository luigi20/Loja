using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Loja.Objeto.BO;
using System.ComponentModel;
using Loja.Objeto.Models;

namespace Loja.Objeto.DAO
{
    public class RegistroVendaProdutoDAO
    {
        public static List<Loja.Objeto.Models.RegistroVendaProduto> BuscarPorId(int idRegistroVenda)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select  Registro_Venda_Produto.idRegistroVendaProduto,
                                            Registro_Venda_Produto.Produto_idProduto,
                                            Registro_Venda_Produto.Registro_Venda_idRegistroVenda,
                                            Registro_Venda_Produto.Registro_Venda_Venda_idVenda,
                                            Registro_Venda_Produto.Preco_Unitario,
                                            Registro_Venda_Produto.Quantidade_Produto,
                                            Registro_Venda_Produto.Subtotal
                                    from Registro_Venda_Produto 
                                        where Registro_Venda_idRegistroVenda = @Registro_Venda_idRegistroVenda";
            comando.Parameters.AddWithValue("@Registro_Venda_idRegistroVenda", idRegistroVenda);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<RegistroVendaProduto> listaRegistroVendaProduto = new List<RegistroVendaProduto>();

            if (dr.HasRows)
            {
                int registroVendaProdutoId = dr.GetOrdinal("idRegistroVendaProduto");
                int produto_idProduto = dr.GetOrdinal("Produto_idProduto");
                int registro_Venda_idRegistroVenda = dr.GetOrdinal("Registro_Venda_idRegistroVenda");
                int registro_Venda_idVenda = dr.GetOrdinal("Registro_Venda_Venda_idVenda");
                int preco_Unitario = dr.GetOrdinal("Preco_Unitario");
                int quantidade_Produto = dr.GetOrdinal("Quantidade_Produto");
                int subTotal = dr.GetOrdinal("SubTotal");


                while (dr.Read())
                {
                    RegistroVendaProduto registroVendaProduto = new RegistroVendaProduto();
                    registroVendaProduto.IdRegistroVendaProduto = dr.GetInt32(registroVendaProdutoId);
                    registroVendaProduto.ProdutoIdProduto = dr.GetInt32(produto_idProduto);
                    registroVendaProduto.RegistroVendaIdRegistroVenda = dr.GetInt32(registro_Venda_idRegistroVenda);
                    registroVendaProduto.RegistroVendaIdVenda = dr.GetInt32(registro_Venda_idVenda);
                    registroVendaProduto.ValorUnitario = dr.GetFloat(preco_Unitario);
                    registroVendaProduto.QuantidadeProduto = dr.GetInt32(quantidade_Produto);
                    registroVendaProduto.SubTotal = dr.GetFloat(subTotal);
                    listaRegistroVendaProduto.Add(registroVendaProduto);
                }
            }
            else
            {
                listaRegistroVendaProduto = null;
            }
            return listaRegistroVendaProduto;
        }

        public static void Insert(RegistroVendaProduto registroVendaProduto)
        {
            
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Insert into  Registro_Venda_Produto(Produto_idProduto,
                                                                        Registro_Venda_idRegistroVenda,
                                                                        Registro_Venda_Venda_idVenda,
                                                                        Preco_Unitario,
                                                                        Quantidade_Produto,SubTotal) 
                                            values(@Produto_idProduto,@Registro_Venda_idRegistroVenda,@Registro_Venda_Venda_idVenda,
                                                   @Preco_Unitario,@Quantidade_Produto,@SubTotal)";

            comando.Parameters.AddWithValue("@Produto_idProduto", registroVendaProduto.ProdutoIdProduto);
            comando.Parameters.AddWithValue("@Registro_Venda_idRegistroVenda", registroVendaProduto.RegistroVendaIdRegistroVenda);
            comando.Parameters.AddWithValue("@Registro_Venda_Venda_idVenda", registroVendaProduto.RegistroVendaIdVenda);
            comando.Parameters.AddWithValue("@Preco_Unitario", registroVendaProduto.ValorUnitario);
            comando.Parameters.AddWithValue("@Quantidade_Produto", registroVendaProduto.QuantidadeProduto);
            comando.Parameters.AddWithValue("@SubTotal", registroVendaProduto.SubTotal);
            ConexãoBanco.CRUD(comando);
        }

        public static void Update(RegistroVendaProduto registroVendaProduto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Update Registro_Venda_Produto set Produto_idProduto = @Produto_idProduto,
                                                     Registro_Venda_idRegistroVenda = @Registro_Venda_idRegistroVenda,  
                                                     Registro_Venda_idVenda = @Registro_Venda_idVenda,
                                                     Preco_Unitario = @Preco_Unitario,
                                                     Quantidade_Produto = @Quantidade_Produto,
                                                     SubTotal = @SubTotal
                                             where idRegistroVendaProduto = @idRegistroVendaProduto";

            comando.Parameters.AddWithValue("@idRegistroVendaProduto", registroVendaProduto.IdRegistroVendaProduto);
            comando.Parameters.AddWithValue("@Registro_Venda_idRegistroVenda", registroVendaProduto.RegistroVendaIdRegistroVenda);
            comando.Parameters.AddWithValue("@Registro_Venda_idVenda", registroVendaProduto.RegistroVendaIdVenda);
            comando.Parameters.AddWithValue("@Produto_idProduto", registroVendaProduto.ProdutoIdProduto);
            comando.Parameters.AddWithValue("@Preco_Unitario", registroVendaProduto.ValorUnitario);
            comando.Parameters.AddWithValue("@Quantidade_Produto", registroVendaProduto.QuantidadeProduto);
            comando.Parameters.AddWithValue("@SubTotal", registroVendaProduto.SubTotal);
            ConexãoBanco.CRUD(comando);
        }

        public static void Delete(RegistroVendaProduto registroVendaProduto)
        {
            SqlCommand comando = new SqlCommand();

            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete from Registro_Venda_Produto where idRegistroVendaProduto = @idRegistroVendaProduto";
            comando.Parameters.AddWithValue("@idVenda", registroVendaProduto.IdRegistroVendaProduto);
            ConexãoBanco.CRUD(comando);


        }

        public static List<RegistroVendaProduto> listarTodos(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idRegistroVendaProduto,
                                            Produto_idProduto,
                                            Registro_Venda_idRegistroVenda,
                                             Registro_Venda_Venda_idVenda,
                                            Preco_Unitario,
                                            Quantidade_Produto,
                                            SubTotal from Registro_Venda_Produto 
                                    where ((idRegistroVendaProduto = @idRegistroVendaProduto)
                            or (@idRegistroVendaProduto is null)) order by  idRegistroVendaProduto";


            if (id <= 0)
            {
                comando.Parameters.AddWithValue("@idRegistroVendaProduto", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idRegistroVendaProduto", id);
            }
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<RegistroVendaProduto> listaRegistroVendaProduto = new List<RegistroVendaProduto>();

            if (dr.HasRows)
            {
                int idRegistroVendaProduto = dr.GetOrdinal("idRegistroVendaProduto");
                int produto_idProduto = dr.GetOrdinal("Produto_idProduto");
                int registro_Venda_idRegistroVenda = dr.GetOrdinal("Registro_Venda_idRegistroVenda");
                int registro_Venda_idVenda = dr.GetOrdinal("Registro_Venda_Venda_idVenda");
                int preco_Unitario = dr.GetOrdinal("Preco_Unitario");
                int quantidade_Produto = dr.GetOrdinal("Quantidade_Produto");
                int subTotal = dr.GetOrdinal("SubTotal");


                while (dr.Read())
                {
                    RegistroVendaProduto registroVendaProduto = new RegistroVendaProduto();
                    registroVendaProduto.IdRegistroVendaProduto = dr.GetInt32(idRegistroVendaProduto);
                    registroVendaProduto.ProdutoIdProduto = dr.GetInt32(produto_idProduto);
                    registroVendaProduto.RegistroVendaIdRegistroVenda = dr.GetInt32(registro_Venda_idRegistroVenda);
                    registroVendaProduto.RegistroVendaIdVenda = dr.GetInt32(registro_Venda_idVenda);
                    registroVendaProduto.ValorUnitario = dr.GetFloat(preco_Unitario);
                    registroVendaProduto.QuantidadeProduto = dr.GetInt32(quantidade_Produto);
                    registroVendaProduto.SubTotal = dr.GetFloat(subTotal);
                    listaRegistroVendaProduto.Add(registroVendaProduto);
                }
            }
            else
            {
                listaRegistroVendaProduto = null;
            }
            return listaRegistroVendaProduto;
        }

        public static List<double> VendaPorMes (DateTime dataInicio, DateTime dataFim)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"(select Sum(SubTotal) as 'Total de Vendas' 
                                            from Registro_Venda_Produto,
                                                 Registro_Venda,Venda
                                      where (((Registro_Venda_Produto.Registro_Venda_idRegistroVenda = Registro_Venda.idRegistroVenda)
                                      and (Registro_Venda.idRegistroVenda = Venda.idVenda)) and ((Venda.Data_Venda >= @dataInicio) 
                                      and (Venda.Data_Venda <= @dataFim))) 
                                    group by Registro_Venda.Departamento_idDepartamento ) order by [Total de Vendas] desc";

            comando.Parameters.AddWithValue("@dataInicio", dataInicio);
            comando.Parameters.AddWithValue("@dataFim", dataFim);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<double> listaRegistroValores = new List<double>();

            if (dr.HasRows)
            {
                int total = dr.GetOrdinal("Total de Vendas");
               


                while (dr.Read())
                {
                    double valorPorMes = dr.GetDouble(total);
                    listaRegistroValores.Add(valorPorMes);
                }
            }
            else
            {
                listaRegistroValores = null;
            }
            return listaRegistroValores;
        }

        public static void UpdateQuantidadeComprada(RegistroVendaProduto registroVendaProduto, RegistroVendaProduto registroProduto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Update Registro_Venda_Produto set 
                                                     Quantidade_Produto = @Quantidade_Produto,
                                                     SubTotal = @SubTotal
                                             where idRegistroVendaProduto = @idRegistroVendaProduto";
            int quantidade = registroVendaProduto.QuantidadeProduto + registroProduto.QuantidadeProduto;
            comando.Parameters.AddWithValue("@idRegistroVendaProduto", registroProduto.IdRegistroVendaProduto);
            
            comando.Parameters.AddWithValue("@Quantidade_Produto", quantidade);
            comando.Parameters.AddWithValue("@SubTotal", registroVendaProduto.ValorUnitario * quantidade);
            ConexãoBanco.CRUD(comando);
        }
    }
}