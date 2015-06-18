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
    public class DepartamentoNg
    {
        public Loja.Objeto.Models.Departamento listarChefe(int idChefe)
        {
            return Loja.Objeto.DAO.DepartamentoDAO.listarChefe(idChefe);
        }
        public Loja.Objeto.Models.Departamento Obter(int id)
        {
            return Loja.Objeto.DAO.DepartamentoDAO.BuscarPorId(id);
        }
        public  List<Loja.Objeto.Models.Departamento> listarDepartamento(int idDepartamento)
        {
            return Loja.Objeto.DAO.DepartamentoDAO.listarTodos(idDepartamento);
        }

        public  void Insert(Loja.Objeto.Models.Departamento departamento)
        {
            Loja.Objeto.DAO.DepartamentoDAO.Insert(departamento);
        }


        public  int Insert2(Loja.Objeto.Models.Departamento departamento)
        {
            ConnectionStringSettingsCollection strConnection = ConfigurationManager.ConnectionStrings;
            SqlConnection conn = new SqlConnection(strConnection["ConnectionString"].ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                Loja.Objeto.BO.DepartamentoBO.Gravar(departamento);

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

        public  void Update(Loja.Objeto.Models.Departamento departamento)
        {
            Loja.Objeto.DAO.DepartamentoDAO.Update(departamento);
        }

        public void Delete(int idDepartamento)
        {

            Loja.Objeto.BO.DepartamentoBO.Apagar(idDepartamento);

        }


     
    }
}