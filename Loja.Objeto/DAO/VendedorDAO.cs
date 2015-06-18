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
    public class VendedorDAO
    {
        public static void Insert(Vendedor vendedor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Insert into Vendedor(Departamento_idDepartamento,Nome_Vendedor,RG_Vendedor,CPF_Vendedor," +
                                    "Data_admissao_Vendedor,Situacao_Vendedor,Nivel_Escolaridade_Vendedor)"
                                   + "values(@Departamento_idDepartamento,@Nome_Vendedor,@RG_Vendedor," +
                                   "@CPF_Vendedor,@Data_admissao_Vendedor,@Situacao_Vendedor,@Nivel_Escolaridade_Vendedor)";



            comando.Parameters.AddWithValue("@Departamento_idDepartamento", vendedor.DepartamentoVendedor);
            comando.Parameters.AddWithValue("@Nome_Vendedor", vendedor.NomeVendedor);
            comando.Parameters.AddWithValue("@RG_Vendedor", vendedor.RgVendedor);
            comando.Parameters.AddWithValue("@CPF_Vendedor", vendedor.CpfVendedor);
            comando.Parameters.AddWithValue("@Data_admissao_Vendedor", vendedor.DataAdmissaoVendedor);
            comando.Parameters.AddWithValue("@Situacao_Vendedor", vendedor.SituacaoVendedor);
            comando.Parameters.AddWithValue("@Nivel_Escolaridade_Vendedor", vendedor.NivelEscolaridade);
            ConexãoBanco.CRUD(comando);
        }

        public static void Update(Vendedor vendedor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Update Vendedor set Departamento_idDepartamento = @Departamento_idDepartamento,
                                                        Nome_Vendedor = @Nome_Vendedor,
                                                        RG_Vendedor = @RG_Vendedor,
                                                        CPF_Vendedor = @CPF_Vendedor,
                                                        Data_admissao_Vendedor = @Data_admissao_Vendedor,
                                                        Situacao_Vendedor = @Situacao_Vendedor,
                                                        Nivel_Escolaridade = @Nivel_Escolaridade
                                      where idVendedor = @idVendedor";


            comando.Parameters.AddWithValue("@Departamento_idDepartamento", vendedor.DepartamentoVendedor);
            comando.Parameters.AddWithValue("@Nome_Vendedor", vendedor.NomeVendedor);
            comando.Parameters.AddWithValue("@RG_Vendedor", vendedor.RgVendedor);
            comando.Parameters.AddWithValue("@CPF_Vendedor", vendedor.CpfVendedor);
            comando.Parameters.AddWithValue("@Data_admissao_Vendedor", vendedor.DataAdmissaoVendedor);
            comando.Parameters.AddWithValue("@Situacao_Vendedor", vendedor.SituacaoVendedor);
            comando.Parameters.AddWithValue("@Nivel_Escolaridade", vendedor.NivelEscolaridade);
            ConexãoBanco.CRUD(comando);
        }

        public static void Delete(Vendedor vendedor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete from Vendedor where idVendedor = @idVendedor";
            comando.Parameters.AddWithValue("@idVendedor", vendedor.IdVendedor);
            ConexãoBanco.CRUD(comando);
        }

        public static Vendedor BuscarPorId(int idVendedor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Vendedor where idVendedor = @idVendedor";
            comando.Parameters.AddWithValue("@idVendedor", idVendedor);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            Vendedor vendedor = new Vendedor();
            int vendedorId = dr.GetOrdinal("idVendedor");

            int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
            int nomeVendedor = dr.GetOrdinal("Nome_Vendedor");
            int rgVendedor = dr.GetOrdinal("RG_Vendedor");
            int cpfVendedor = dr.GetOrdinal("CPF_Vendedor");
            int dataAdmissaoVendedor = dr.GetOrdinal("Data_admissao_Vendedor");
            int situacaoVendedor = dr.GetOrdinal("Situacao_Vendedor");
            int nivelEscolaridade = dr.GetOrdinal("Nivel_Escolaridade_Vendedor");
            if (dr.HasRows)
            {
                dr.Read();
                vendedor.IdVendedor = dr.GetInt32(vendedorId);

                vendedor.DepartamentoVendedor = dr.GetInt32(idDepartamento);
                vendedor.NomeVendedor = dr.GetString(nomeVendedor);
                vendedor.RgVendedor = dr.GetInt32(rgVendedor);
                vendedor.CpfVendedor = dr.GetString(cpfVendedor);
                vendedor.DataAdmissaoVendedor = dr.GetDateTime(dataAdmissaoVendedor);
                vendedor.SituacaoVendedor = dr.GetString(situacaoVendedor);
                vendedor.NivelEscolaridade = dr.GetString(nivelEscolaridade);
                //preenche o objeto
            }
            else
            {
                vendedor = null;
            }
            return vendedor;
        }

        public static List<Vendedor> listarTodos(int vendedorId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idVendedor,Departamento_idDepartamento,RG_Vendedor,Nome_Vendedor,CPF_Vendedor,
                                   Data_admissao_Vendedor,Situacao_Vendedor 
                                   from Vendedor
                                   where(idVendedor = @idVendedor) or @idVendedor is null";
            if (vendedorId <= 0)
            {
                comando.Parameters.AddWithValue("@idVendedor", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idVendedor", vendedorId);
            }
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Vendedor> listaVendedores = new List<Vendedor>();

            if (dr.HasRows)
            {
                int idVendedor = dr.GetOrdinal("idVendedor");

                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int nomeVendedor = dr.GetOrdinal("Nome_Vendedor");
                int cpfVendedor = dr.GetOrdinal("CPF_Vendedor");
                int dataAdmissao = dr.GetOrdinal("Data_admissao_Vendedor");
                int rgVendedor = dr.GetOrdinal("RG_Vendedor");
                int situacaoVendedor = dr.GetOrdinal("Situacao_Vendedor");

                while (dr.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.IdVendedor = dr.GetInt32(idVendedor);


                    vendedor.DepartamentoVendedor = dr.GetInt32(idDepartamento);
                    vendedor.NomeVendedor = dr.GetString(nomeVendedor);
                    vendedor.CpfVendedor = dr.GetString(cpfVendedor);
                    vendedor.RgVendedor = dr.GetInt32(rgVendedor);
                    vendedor.DataAdmissaoVendedor = dr.GetDateTime(dataAdmissao);
                    vendedor.SituacaoVendedor = dr.GetString(situacaoVendedor);

                    listaVendedores.Add(vendedor);
                }
            }
            else
            {
                listaVendedores = null;
            }
            return listaVendedores;
        }

        public static Vendedor listarVendedor(int vendedorId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idVendedor,Departamento_idDepartamento,Nome_Vendedor,CPF_Vendedor,
                                   Data_admissao_Vendedor,Situacao_Vendedor 
                                   from Vendedor
                                   where(idVendedor = @idVendedor) ";
            if (vendedorId <= 0)
            {
                comando.Parameters.AddWithValue("@idVendedor", DBNull.Value);

            }
            else
            {
                comando.Parameters.AddWithValue("@idVendedor", vendedorId);
            }
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            Vendedor vendedor = new Vendedor();

            if (dr.HasRows)
            {
                int idVendedor = dr.GetOrdinal("idVendedor");

                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int nomeVendedor = dr.GetOrdinal("Nome_Vendedor");
                int cpfVendedor = dr.GetOrdinal("CPF_Vendedor");
                int situacaoVendedor = dr.GetOrdinal("Situacao_Vendedor");

                dr.Read();
                vendedor.IdVendedor = dr.GetInt32(idVendedor);
                vendedor.DepartamentoVendedor = dr.GetInt32(idDepartamento);
                vendedor.NomeVendedor = dr.GetString(nomeVendedor);
                vendedor.CpfVendedor = dr.GetString(cpfVendedor);
                vendedor.SituacaoVendedor = dr.GetString(situacaoVendedor);
            }

            else
            {
                vendedor = null;
            }
            return vendedor;
        }
        public static List<Vendedor> listarTodosPossiveisChefes()
        {
            string nivelEscolaridade = "Ensino Superior";
            string Situacao = "Ativo";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"(Select idVendedor,
                                            Departamento_idDepartamento,
                                            Nome_Vendedor,
                                            CPF_Vendedor,
                                            Nivel_Escolaridade_Vendedor
                                   from Vendedor where Nivel_Escolaridade_Vendedor = @nivelEscolaridade 
                                                      and Situacao_Vendedor = @situacaoVendedor) ";

       
            comando.Parameters.AddWithValue("@nivelEscolaridade", nivelEscolaridade);
            comando.Parameters.AddWithValue("@situacaoVendedor", Situacao);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Vendedor> listaVendedores = new List<Vendedor>();

            if (dr.HasRows)
            {
                int idVendedor = dr.GetOrdinal("idVendedor");

                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int nomeVendedor = dr.GetOrdinal("Nome_Vendedor");
                int cpfVendedor = dr.GetOrdinal("CPF_Vendedor");
                int nivelEscolaridadeVendedor = dr.GetOrdinal("Nivel_Escolaridade_Vendedor");

                while (dr.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.IdVendedor = dr.GetInt32(idVendedor);

                    vendedor.DepartamentoVendedor = dr.GetInt32(idDepartamento);
                    vendedor.NomeVendedor = dr.GetString(nomeVendedor);
                    vendedor.CpfVendedor = dr.GetString(cpfVendedor);
                    vendedor.NivelEscolaridade = dr.GetString(nivelEscolaridadeVendedor);

                    listaVendedores.Add(vendedor);
                }
            }
            else
            {
                listaVendedores = null;
            }
            return listaVendedores;
        }

        public static List<Vendedor> listarTodosChefes()
        {
            string nivelEscolaridade = "Ensino Superior";
            string Situacao = "Ativo";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"(Select idVendedor,
                                            Departamento_idDepartamento,
                                            Nome_Vendedor,
                                            CPF_Vendedor,
                                            Nivel_Escolaridade_Vendedor
                                   from Vendedor, Departamento where Departamento.idChefe_Departamento = Vendedor.idVendedor ";

    
            comando.Parameters.AddWithValue("@nivelEscolaridade", nivelEscolaridade);
            comando.Parameters.AddWithValue("@situacaoVendedor", Situacao);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Vendedor> listaVendedores = new List<Vendedor>();

            if (dr.HasRows)
            {
                int idVendedor = dr.GetOrdinal("idVendedor");

                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int nomeVendedor = dr.GetOrdinal("Nome_Vendedor");
                int cpfVendedor = dr.GetOrdinal("CPF_Vendedor");
                int nivelEscolaridadeVendedor = dr.GetOrdinal("Nivel_Escolaridade_Vendedor");

                while (dr.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.IdVendedor = dr.GetInt32(idVendedor);

                    vendedor.DepartamentoVendedor = dr.GetInt32(idDepartamento);
                    vendedor.NomeVendedor = dr.GetString(nomeVendedor);
                    vendedor.CpfVendedor = dr.GetString(cpfVendedor);
                    vendedor.NivelEscolaridade = dr.GetString(nivelEscolaridadeVendedor);

                    listaVendedores.Add(vendedor);
                }
            }
            else
            {
                listaVendedores = null;
            }
            return listaVendedores;
        }
        public static List<Vendedor> listarTodosIdDiferente(int vendedorId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"Select idVendedor,
                                           Departamento_idDepartamento,
                                           Nome_Vendedor,
                                           CPF_Vendedor from Vendedor 
                                    where idVendedor <> @idVendedor ";
            comando.Parameters.AddWithValue("@idVendedor", vendedorId);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Vendedor> listaVendedores = new List<Vendedor>();

            if (dr.HasRows)
            {
                int idVendedor = dr.GetOrdinal("idVendedor");

                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int nomeVendedor = dr.GetOrdinal("Nome_Vendedor");
                int cpfVendedor = dr.GetOrdinal("CPF_Vendedor");


                while (dr.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.IdVendedor = dr.GetInt32(idVendedor);

                    vendedor.DepartamentoVendedor = dr.GetInt32(idDepartamento);
                    vendedor.NomeVendedor = dr.GetString(nomeVendedor);
                    vendedor.CpfVendedor = dr.GetString(cpfVendedor);


                    listaVendedores.Add(vendedor);
                }
            }
            else
            {
                listaVendedores = null;
            }
            return listaVendedores;
        }

        public static List<Vendedor> VendedoresPorDepartamento()
        {

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = @"(Select Vendedor.idVendedor,
                                            Vendedor.Departamento_idDepartamento,
                                            Vendedor.Nome_Vendedor,
                                            Vendedor.CPF_Vendedor,
                                            Vendedor.Nivel_Escolaridade_Vendedor
                                   from Vendedor, Departamento where Vendedor.Departamento_idDepartamento = Departamento.idDepartamento) ";


            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Vendedor> listaVendedores = new List<Vendedor>();

            if (dr.HasRows)
            {
                int idVendedor = dr.GetOrdinal("idVendedor");

                int idDepartamento = dr.GetOrdinal("Departamento_idDepartamento");
                int nomeVendedor = dr.GetOrdinal("Nome_Vendedor");
                int cpfVendedor = dr.GetOrdinal("CPF_Vendedor");
                int nivelEscolaridadeVendedor = dr.GetOrdinal("Nivel_Escolaridade_Vendedor");

                while (dr.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.IdVendedor = dr.GetInt32(idVendedor);

                    vendedor.DepartamentoVendedor = dr.GetInt32(idDepartamento);
                    vendedor.NomeVendedor = dr.GetString(nomeVendedor);
                    vendedor.CpfVendedor = dr.GetString(cpfVendedor);
                    vendedor.NivelEscolaridade = dr.GetString(nivelEscolaridadeVendedor);

                    listaVendedores.Add(vendedor);
                }
            }
            else
            {
                listaVendedores = null;
            }
            return listaVendedores;
        }


    }
}
