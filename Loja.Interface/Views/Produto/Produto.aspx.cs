using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loja.Objeto.DAO;
namespace Loja.Interface.Views.Produto
{
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "New")
            {

                int inserir = 0;
                if (ddlProdutoSimilar.Text == "")
                {

                    inserir = Loja.Fachada.Fachada.ProdutoFachada.InsertSemSimilar(Convert.ToInt32(ddlDepartamento.SelectedValue),
                                                                txtBoxNome.Text,
                                                                Convert.ToDouble(txtBoxPreco.Text),
                                                                Convert.ToInt32(txtBoxQuantidade.Text)
                                                                );
                }
                else
                {
                     inserir = Loja.Fachada.Fachada.ProdutoFachada.Insert(Convert.ToInt32(ddlDepartamento.SelectedValue),
                                                                        txtBoxNome.Text,
                                                                        Convert.ToDouble(txtBoxPreco.Text),
                                                                        Convert.ToInt32(txtBoxQuantidade.Text),
                                                                        Convert.ToInt32(ddlProdutoSimilar.SelectedValue));
                }


                if (inserir == 1)
                {


                    txtBoxPreco.Text = "";
                    txtBoxNome.Text = "";
                    txtBoxQuantidade.Text = "";
                    ddlDepartamento.SelectedIndex = -1;
                    this.ExibirMensagem("Produto Inserido Com Sucesso");
                    return;
                }
            }
        }

        protected void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}