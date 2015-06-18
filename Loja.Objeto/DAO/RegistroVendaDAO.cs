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
    public class RegistroVendaDAO
    {
        public static RegistroVenda BuscarPorId(int idRegistroVenda)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select  Venda_idVenda,
                                            Produto_idProduto,
                                            idRegistroVenda,
                                            Departamento_idDepartamento,
                                            Vendedor_idVendedor,
                                            Valor_Comissao from Registro_Venda 
                                        where idRegistroVenda = @idRegistroVenda";
            comando.Parameters.AddWithValue("@idRegistroVenda", idRegistroVenda);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            RegistroVenda registroVenda = new RegistroVenda();
            int registroVendaId = dr.GetOrdinal("idRegistroVenda");
            int idVenda = dr.GetOrdinal("Venda_idVenda");
            int idProduto = dr.GetOrdinal("Produto_idProduto");
            int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
            int idVendedor = dr.GetOrdinal("Vendedor_idVendedor");
            int valorComissao = dr.GetOrdinal("Valor_Comissao");
            if (dr.HasRows)
            {
                dr.Read();
                registroVenda.IdRegistroVenda = dr.GetInt32(registroVendaId);
                registroVenda.IdVenda = dr.GetInt32(idVenda);

                registroVenda.IdDepartamento = dr.GetInt32(idDepartamento);
                registroVenda.IdVendedor = dr.GetInt32(idVendedor);
                registroVenda.Comissao = dr.GetInt32(valorComissao);
                
                //preenche o objeto
            }
            else
            {
                registroVenda = null;
            }
            return registroVenda;
        }
        public static void Insert(RegistroVenda registroVenda)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Insert into Registro_Venda(Venda_idVenda,
                                                               Departamento_idDepartamento,Vendedor_idVendedor,Valor_Comissao) 
                                           values(@Venda_idVenda,@Departamento_idDepartamento,
                                                   @Vendedor_idVendedor,@Valor_Comissao)";

            comando.Parameters.AddWithValue("@Venda_idVenda", registroVenda.IdVenda);
          
            comando.Parameters.AddWithValue("@Departamento_idDepartamento", registroVenda.IdDepartamento);
            comando.Parameters.AddWithValue("@Vendedor_idVendedor", registroVenda.IdVendedor);
            comando.Parameters.AddWithValue("@Valor_Comissao", registroVenda.Comissao);
            ConexãoBanco.CRUD(comando);
        }

        public static void Update(RegistroVenda registroVenda)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Update Registro_Venda set Venda_idVenda = @Venda_idVenda,
                                                    
                                                     Departamento_idDepartamento = @Departamento_idDepartamento,
                                                     Vendedor_idVendedor = @Vendedor_idVendedor,
                                                     Valor_Comissao = @Valor_Comissao
                                             where idRegistro_Venda = @idRegistroVenda";

            comando.Parameters.AddWithValue("@idRegistroVenda", registroVenda.IdRegistroVenda);
            comando.Parameters.AddWithValue("@Venda_idVenda", registroVenda.IdVenda);
            
            comando.Parameters.AddWithValue("@Departamento_idDepartamento", registroVenda.IdDepartamento);
            comando.Parameters.AddWithValue("@Vendedor_idVendedor", registroVenda.IdVendedor);
            comando.Parameters.AddWithValue("@Valor_Comissao", registroVenda.Comissao);
            ConexãoBanco.CRUD(comando);
        }

        public static void Delete(RegistroVenda registroVenda)
        {
            SqlCommand comando = new SqlCommand();

            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete from Registro_Venda where idRegistro_Venda = @idRegistro_Venda";
            comando.Parameters.AddWithValue("@idVenda", registroVenda.IdRegistroVenda);
            ConexãoBanco.CRUD(comando);


        }

        public static List<RegistroVenda> listarTodos(int registrovendaId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idRegistroVenda,
                                            Venda_idVenda,
                                            Departamento_idDepartamento,
                                            Vendedor_idVendedor,Valor_Comissao
                                        from Registro_Venda where (idRegistroVenda = @idRegistroVenda) or @idRegistroVenda is null";

            if (registrovendaId <= 0)
            {
                comando.Parameters.AddWithValue("@idRegistroVenda", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idRegistroVenda", registrovendaId);
            }

            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<RegistroVenda> listaRegistroVendas = new List<RegistroVenda>();

            if (dr.HasRows)
            {
                int idRegistroVenda = dr.GetOrdinal("idRegistroVenda");
                int idVenda = dr.GetOrdinal("Venda_idVenda");
         
                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int idVendedor = dr.GetOrdinal("Vendedor_idVendedor");
                int valorComissao = dr.GetOrdinal("Valor_Comissao");
                


                while (dr.Read())
                {
                    RegistroVenda registroVenda = new RegistroVenda();
                    registroVenda.IdRegistroVenda = dr.GetInt32(idRegistroVenda);
                 
                    registroVenda.IdDepartamento = dr.GetInt32(idDepartamento);
                    registroVenda.IdVendedor = dr.GetInt32(idVendedor);
                    registroVenda.IdVenda = dr.GetInt32(idVenda);
                    registroVenda.Comissao = dr.GetFloat(valorComissao);
                    listaRegistroVendas.Add(registroVenda);
                }
            }
            else
            {
                listaRegistroVendas = null;
            }
            return listaRegistroVendas;
        }


    }
}
