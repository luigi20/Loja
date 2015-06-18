using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Negocio;

namespace Loja.Fachada.Fachada
{
    [DataObject(true)]
    public class DepartamentoFachada

    {
       
        private static Loja.Negocio.DepartamentoNg departamentoNg = new Negocio.DepartamentoNg();

       
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.Departamento Obter(int id)
        {
            return departamentoNg.Obter(id);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(Loja.Objeto.Models.Departamento departamento)
        {
            
             int inserir = departamentoNg.Insert2(departamento);
             return inserir;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(string nomeDepartamento, string siglaDepartamento, double percDepartamento,int idChefeDepartamento)
        {
            Loja.Objeto.Models.Departamento departamento = new Objeto.Models.Departamento();
            departamento.NomeDepartamento = nomeDepartamento;
            departamento.SiglaDepartamento = siglaDepartamento;
            departamento.PercComissaoDepartamento = percDepartamento;
            departamento.ChefeDepartamentoVendedor = idChefeDepartamento;
            int inserir = departamentoNg.Insert2(departamento);
            return inserir;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Loja.Objeto.Models.Departamento departamento)
        {
            departamentoNg.Update(departamento);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(int idDepartamento)
        {
             departamentoNg.Delete(idDepartamento);
     
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Departamento> listarDepartamento(int departamento)
        {
           
            return departamentoNg.listarDepartamento(departamento);

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.Departamento listarDepartamentoPorId(int id)
        {
            return departamentoNg.Obter(id);

        }

       

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.Departamento listarChefe(int idChefe)
        {
            return departamentoNg.listarChefe(idChefe);

        }
    }
}