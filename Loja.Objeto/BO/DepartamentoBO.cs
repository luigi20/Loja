
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Objeto.Models;
using Loja.Objeto.DAO;

namespace Loja.Objeto.BO
{
    public class DepartamentoBO
    {
        public static void Gravar(Departamento departamento)
        {
            

            if (departamento.IdDepartamento != 0)
            {
                //altera

                DepartamentoDAO.Update(departamento);
            }
            else
            {
                //inserir
                DepartamentoDAO.Insert(departamento);
            }

        }

        public static void Apagar(int idDepartamento)
        {

             DepartamentoDAO.Delete(idDepartamento);
        }

     
    }
}
