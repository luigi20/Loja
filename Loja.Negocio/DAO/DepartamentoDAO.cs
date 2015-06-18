using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Negocio.Models;
using System.Data.SqlClient;
using System.Data;
using Loja.Negocio.BO;
using System.ComponentModel;

namespace Loja.Negocio.DAO
{
   
    public class DepartamentoDAO
    {
        public void Insert(Departamento departamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Insert into Departamento(Nome_Departamento,Sigla_Departamento,Comissao_Departamento) "
                                   + "values(@nomeDepartamento,@siglaDepartamento,@comissaoDepartamento)";
            comando.Parameters.AddWithValue("@nomeDepartamento", departamento.NomeDepartamento);
            comando.Parameters.AddWithValue("@siglaDepartamento", departamento.SiglaDepartamento);
            comando.Parameters.AddWithValue("@comissaoDepartamento", departamento.ComissaoDepartamento);
            ConexãoBanco.CRUD(comando);
        }

        public void Update(Departamento departamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Update Departamento set Nome_Departamento =@nomeDepartamento," +
                                  "Sigla_Departamento = @siglaDepartamento,Comissao_Departamento= @comissaoDepartamento"+
                                  "where idDepartamento = @idDepartamento";
            comando.Parameters.AddWithValue("@nomeDepartamento", departamento.NomeDepartamento);
            comando.Parameters.AddWithValue("@siglaDepartamento", departamento.SiglaDepartamento);
            comando.Parameters.AddWithValue("@comissaoDepartamento", departamento.ComissaoDepartamento);
            ConexãoBanco.CRUD(comando);                   
        }

        public void Delete(Departamento departamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete from Departamento where idDepartamento=@idDepartamento";
            comando.Parameters.AddWithValue("@idDepartamento", departamento.IdDepartamento);
            ConexãoBanco.CRUD(comando);    
        }

        public Departamento BuscarPorId(int idDepartamento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Departamento where idDepartamento = @idDepartamento";
            comando.Parameters.AddWithValue("@idDepartamento", idDepartamento);
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            Departamento departamento = Departamento.getInstance;
            if (dr.HasRows)
            {
                dr.Read();
                departamento.IdDepartamento = (int) dr["idDepartamento"];
                departamento.NomeDepartamento = (string)dr["Nome_Departamento"];
                departamento.SiglaDepartamento = (string)dr["Sigla_Departamento"];
                departamento.ComissaoDepartamento = (double)dr["Comissao_Departamento"];
                //preenche o objeto
            }
            else
            {
                departamento = null;
            }
            return departamento;
        }

        public List<Departamento> listarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Departamentos";
            SqlDataReader dr = ConexãoBanco.Selecionar(comando);
            List<Departamento> listaDepartamentos = new List<Departamento>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Departamento departamento = Departamento.getInstance;
                    departamento.IdDepartamento = (int)dr["idDepartamento"];
                    departamento.NomeDepartamento = (string)dr["Nome_Departamento"];
                    departamento.SiglaDepartamento = (string)dr["Sigla_Departamento"];
                    departamento.ComissaoDepartamento = (double)dr["Comissao_Departamento"];
                    listaDepartamentos.Add(departamento);
                }
            }
            else
            {
                listaDepartamentos = null;
            }
            return listaDepartamentos;
        }
    }
}
