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
    public class VendaDAO
    {
       

        public static Venda BuscarPorId(int idVenda)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idVenda,Data_Venda,Valor_Total from Vendedor 
                                        where idVenda = @idVenda";
            comando.Parameters.AddWithValue("@idVendedor", idVenda);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            Venda venda = new Venda();
            int dataVenda = dr.GetOrdinal("Data_Venda");
            int valorTotal = dr.GetOrdinal("Valor_Total");
            int vendaId = dr.GetOrdinal("idVenda");
            if (dr.HasRows)
            {
                dr.Read();
                venda.DataVenda = dr.GetDateTime(dataVenda);
                venda.ValorTotal = dr.GetDouble(valorTotal);
                venda.IdVenda = dr.GetInt32(vendaId);
                //preenche o objeto
            }
            else
            {
                venda = null;
            }
            return venda;
        }
        public static void Insert(Venda venda)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Insert into Venda(Data_Venda,Valor_Total) values(@dataVenda,@valorTotal)";
            comando.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
            comando.Parameters.AddWithValue("@valorTotal", venda.ValorTotal);
            ConexãoBanco.CRUD(comando);

        }

        public static void Update(Venda venda)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Update Venda set Data_Venda = @dataVenda,
                                                     Valor_Total = @valorTotal,      
                                             where idVenda = @idVenda";

            comando.Parameters.AddWithValue("@idVenda", venda.IdVenda);
            comando.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
            comando.Parameters.AddWithValue("@valorTotal", venda.ValorTotal);
            ConexãoBanco.CRUD(comando);
        }

        public static void Delete(Venda venda)
        {
            SqlCommand comando = new SqlCommand();

            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete from Venda where idVenda = @idVenda";
            comando.Parameters.AddWithValue("@idVenda", venda.IdVenda);
            ConexãoBanco.CRUD(comando);


        }

        public static List<Venda> listarTodos(int vendaId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idVenda,
                                           Data_Venda,
                                           Valor_Total
                                    from Venda
                                    where (idVenda = @idVenda) or @idVenda is null";

            if (vendaId <= 0)
            {
                comando.Parameters.AddWithValue("@idVenda", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idVenda", vendaId);
            }

            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Venda> listaVendas = new List<Venda>();

            if (dr.HasRows)
            {
                int idVenda = dr.GetOrdinal("idVenda");
                int dataVenda = dr.GetOrdinal("Data_Venda");
                int valorVenda = dr.GetOrdinal("Valor_Total");


                while (dr.Read())
                {
                    Venda venda = new Venda();
                    venda.IdVenda = dr.GetInt32(idVenda);
                    venda.DataVenda = dr.GetDateTime(dataVenda);
                    venda.ValorTotal = dr.GetFloat(valorVenda);



                    listaVendas.Add(venda);
                }
            }
            else
            {
                listaVendas = null;
            }
            return listaVendas;
        }

        public static List<Loja.Objeto.Models.Venda> VendasEfetuadasPorVendedor(int idVendedor, DateTime dataInicio, DateTime dataFim)
        {

             SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
                    comando.CommandText = @"Select Venda.idVenda,
                                           Venda.Data_Venda,
                                           Venda.Valor_Total
                               from Venda inner join Registro_Venda on Venda.idVenda = Registro_Venda.Venda_idVenda
                                where ((Venda.Data_Venda >= @dataInicio) and (Venda.Data_Venda <= @dataFim)) 
                                and (Registro_Venda.Vendedor_idVendedor  = @idVendedor)";

            if (idVendedor <= 0)
            {
                return null;

            }
            else
            {
                comando.Parameters.AddWithValue("@idVendedor", idVendedor);
            }
            comando.Parameters.AddWithValue("@dataInicio", dataInicio);
            comando.Parameters.AddWithValue("@dataFim", dataFim);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Venda> listaVendas = new List<Venda>();

            if (dr.HasRows)
            {
                int idVenda = dr.GetOrdinal("idVenda");
                int dataVenda = dr.GetOrdinal("Data_Venda");
                int valorVenda = dr.GetOrdinal("Valor_Total");


                while (dr.Read())
                {
                    Venda venda = new Venda();
                    venda.IdVenda = dr.GetInt32(idVenda);
                    venda.DataVenda = dr.GetDateTime(dataVenda);
                    venda.ValorTotal = dr.GetFloat(valorVenda);



                    listaVendas.Add(venda);
                }
            }
            else
            {
                listaVendas = null;
            }
            return listaVendas;
        }


          

    }

}