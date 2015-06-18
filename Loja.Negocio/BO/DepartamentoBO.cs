using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Negocio.Models;
using Loja.Negocio.DAO;

namespace Loja.Negocio.BO
{
    public class DepartamentoBO
    {
        public void Gravar(Departamento departamento)
        {
            DepartamentoDAO departDAO = new DepartamentoDAO();

            if (departamento.IdDepartamento != 0)
            {
                //altera
                departDAO.Update(departamento);
            }
            else
            {
                //inserir
                departDAO.Insert(departamento);
            }

        }

        public void Apagar(Departamento departamento)
        {
            DepartamentoDAO departDAO = new DepartamentoDAO();
            departDAO.Delete(departamento);
        }
    }
}
