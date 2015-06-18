using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loja.Fachada.Fachada;

namespace Loja.Interface.Views.Pesquisar.Departamento
{
    public partial class Departamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnDeletar_Command(object sender, CommandEventArgs e)
        {
           /*   if (e.CommandName == "Delete")
            {

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                int idDepartamento = Convert.ToInt32(gdvDepartamento.DataKeys[row.RowIndex]["IdDepartamento"]);


              try
                {
                    Loja.Fachada.Fachada.DepartamentoFachada.Delete(idDepartamento);
                    gdvDepartamento.DataBind();
                    this.ExibirMensagem("Departamento Excluído com Sucesso !!!");

                }
                catch
                {
                    this.ExibirMensagem("Departamento Não Foi Excluído com Sucesso !!!");
                    return;
                }
                


            }*/

        }
  

        protected void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        protected void ODSDepartamentoGridView_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {

        }
    }
}