using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja.Interface.Views.Vendedor
{
    public partial class Vendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "New")
            {


                int inserir = Loja.Fachada.Fachada.VendedorFachada.Insert(txtBoxNome.Text,
                                                                         txtBoxCPF.Text, Convert.ToInt32(txtBoxRG.Text), 
                                                                         Convert.ToDateTime(txtBoxData.Text), 
                                                                         Convert.ToInt32(ddlDepartamento.SelectedValue),
                                                                         ddlNivelEscolaridade.Text, ddlSituacao.Text);

                if (inserir == 1)
                {

                    txtBoxNome.Text = "";
                    txtBoxCPF.Text = "";
                    txtBoxData.Text = "";
                    txtBoxRG.Text = "";
                    ddlDepartamento.SelectedIndex = -1;
                    ddlNivelEscolaridade.SelectedIndex = -1;
                    ddlSituacao.SelectedIndex = -1;
               
                    this.ExibirMensagem("Vendedor Inserido Com Sucesso");
                    return;
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        protected void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

    }
}