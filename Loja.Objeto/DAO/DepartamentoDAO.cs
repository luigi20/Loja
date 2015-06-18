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

    public class DepartamentoDAO
    {
        public static Departamento listarChefe(int idChefe)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select Departamento.idDepartamento,
                                           Departamento.Nome_Departamento,
                                           Departamento.Sigla_Departamento, 
                                           Departamento.Perc_Departamento,
                                           Departamento.idChefe_Departamento 
                                    from Departamento,Vendedor 
                                    Where (Departamento.idChefe_Departamento = @idChefe) ";
            comando.Parameters.AddWithValue("@idChefe", idChefe);


            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            Departamento listaDepartamentos = new Departamento();


            int idDepartamento = dr.GetOrdinal("idDepartamento");
            int nomeDepartamento = dr.GetOrdinal("Nome_Departamento");
            int siglaDepartamento = dr.GetOrdinal("Sigla_Departamento");
            int percDepartamento = dr.GetOrdinal("Perc_Departamento");
            int idChefeDepartamento = dr.GetOrdinal("idChefe_Departamento");
            if (dr.HasRows)
            {
                dr.Read();
                Departamento departamento = new Departamento();
                departamento.IdDepartamento = dr.GetInt32(idDepartamento);
                departamento.NomeDepartamento = dr.GetString(nomeDepartamento);
                departamento.ChefeDepartamentoVendedor = dr.GetValue(idChefeDepartamento) == DBNull.Value ? -1 : dr.GetInt32(idChefeDepartamento);
                departamento.PercComissaoDepartamento = dr.GetFloat(percDepartamento);
                departamento.SiglaDepartamento = dr.GetString(siglaDepartamento);




            }
            else
            {
                listaDepartamentos = null;
            }
            return listaDepartamentos;

        }

        public static void Insert(Departamento departamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Insert into Departamento(Nome_Departamento,
                                                             Sigla_Departamento,
                                                             Perc_Departamento,
                                                             idChefe_Departamento) 
                                           values(@nomeDepartamento,
                                                  @siglaDepartamento,
                                                  @percComissaoDepartamento,
                                                  @idChefe_Departamento)";

            comando.Parameters.AddWithValue("@nomeDepartamento", departamento.NomeDepartamento);
            comando.Parameters.AddWithValue("@siglaDepartamento", departamento.SiglaDepartamento);
            comando.Parameters.AddWithValue("@percComissaoDepartamento", departamento.PercComissaoDepartamento);

            comando.Parameters.AddWithValue("@idChefe_Departamento", departamento.ChefeDepartamentoVendedor);
            ConexãoBanco.CRUD(comando);
        }

        public static void Update(Departamento departamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Update Departamento set Nome_Departamento = @nomeDepartamento,
                                                            Sigla_Departamento = @siglaDepartamento,
                                                            Perc_Departamento = @percComissaoDepartamento
                                  where idDepartamento = @idDepartamento";
            comando.Parameters.AddWithValue("@nomeDepartamento", departamento.NomeDepartamento);
            comando.Parameters.AddWithValue("@siglaDepartamento", departamento.SiglaDepartamento);
            comando.Parameters.AddWithValue("@percComissaoDepartamento", departamento.PercComissaoDepartamento);
            ConexãoBanco.CRUD(comando);
        }

        public static void Delete(int idDepartamento)
        {
            SqlCommand comando = new SqlCommand();

            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete from Departamento where idDepartamento = @idDepartamento";
            comando.Parameters.AddWithValue("@idDepartamento", idDepartamento);
            ConexãoBanco.CRUD(comando);


        }

       

        public static Departamento BuscarPorId(int idDepartamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idDepartamento,
                                           Nome_Departamento,
                                           Sigla_Departamento,
                                           Perc_Departamento,
                                           idChefe_Departamento from Departamento 
                                        where idDepartamento = @idDepartamento";
            comando.Parameters.AddWithValue("@idDepartamento", idDepartamento);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            Departamento departamento = new Departamento();
            if (dr.HasRows)
            {
                int departamentoId = dr.GetOrdinal("idDepartamento");
                int nomeDepartamento = dr.GetOrdinal("Nome_Departamento");
                int siglaDepartamento = dr.GetOrdinal("Sigla_Departamento");
                int percDepartamento = dr.GetOrdinal("Perc_Departamento");
                int idChefeDepartamento = dr.GetOrdinal("idChefe_Departamento");
                while (dr.Read())
                {

                    departamento.IdDepartamento = dr.GetInt32(departamentoId);
                    departamento.NomeDepartamento = dr.GetString(nomeDepartamento);
                    departamento.SiglaDepartamento = dr.GetString(siglaDepartamento);
                    departamento.PercComissaoDepartamento = dr.GetFloat(percDepartamento);
                    departamento.ChefeDepartamentoVendedor = dr.GetValue(idChefeDepartamento) == DBNull.Value ? -1 : dr.GetInt32(idChefeDepartamento);
                    //preenche o objeto
                }
            }
            else
            {
                departamento = null;
            }
            return departamento;
        }

        public static List<Departamento> listarTodos(int departamentoId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idDepartamento,Nome_Departamento,Sigla_Departamento, Perc_Departamento,idChefe_Departamento 
                                    from Departamento 
                                    Where (idDepartamento = @idDepartamento) or @idDepartamento is null";

            if (departamentoId <= 0)
            {
                comando.Parameters.AddWithValue("@idDepartamento", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idDepartamento", departamentoId);
            }

            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Departamento> listaDepartamentos = new List<Departamento>();

            if (dr.HasRows)
            {
                int idDepartamento = dr.GetOrdinal("idDepartamento");
                int nomeDepartamento = dr.GetOrdinal("Nome_Departamento");
                int siglaDepartamento = dr.GetOrdinal("Sigla_Departamento");
                int percDepartamento = dr.GetOrdinal("Perc_Departamento");
                int idChefeDepartamento = dr.GetOrdinal("idChefe_Departamento");

                while (dr.Read())
                {
                    Departamento departamento = new Departamento();
                    departamento.IdDepartamento = dr.GetInt32(idDepartamento);
                    departamento.NomeDepartamento = dr.GetString(nomeDepartamento);
                    departamento.ChefeDepartamentoVendedor = dr.GetValue(idChefeDepartamento) == DBNull.Value ? -1 : dr.GetInt32(idChefeDepartamento);
                    departamento.PercComissaoDepartamento = dr.GetFloat(percDepartamento);
                    departamento.SiglaDepartamento = dr.GetString(siglaDepartamento);


                    listaDepartamentos.Add(departamento);
                }
            }
            else
            {
                listaDepartamentos = null;
            }
            return listaDepartamentos;
        }

        public static double ValorComissao(int idDepartamento,double valorCompra)
        {
            Loja.Objeto.Models.Departamento departamento = BuscarPorId(idDepartamento);
            return (departamento.PercComissaoDepartamento * valorCompra) / 100;
        }
    }
}
