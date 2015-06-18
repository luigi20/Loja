using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja.Interface.Views
{
    public partial class Venda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ddlVendedores.Text != "")
            {
                gdvDepartamento.Visible = true;
            }
            else
            {
                gdvDepartamento.Visible = false;
            }

            int lista = DateTime.DaysInMonth(2015, 1);
      
            
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

            List<Loja.Objeto.Models.Produto> listaProduto = new List<Loja.Objeto.Models.Produto>();
            foreach (GridViewRow row in gdvDepartamento.Rows)
            {


                if (((CheckBox)row.FindControl("checkComprar")).Checked)
                {
                    int id = Convert.ToInt32(gdvDepartamento.DataKeys[row.RowIndex]["IdProduto"]);

                    Loja.Objeto.Models.Produto produto = Loja.Fachada.Fachada.ProdutoFachada.Obter(id);
                    DropDownList quantidade = (DropDownList)gdvDepartamento.Rows[row.RowIndex].FindControl("ddlQuantidade");

                    int quantidadeProd = Convert.ToInt32(quantidade.SelectedItem.ToString());
                    for (int i = 0; i < quantidadeProd; i++)
                    {
                        listaProduto.Add(produto);
                    }



                }
            }
            DateTime data = DateTime.Today;
            Loja.Objeto.Models.Venda venda = new Loja.Objeto.Models.Venda();
            venda.DataVenda = data;
            venda.ValorTotal = Convert.ToDouble(Session["valor"].ToString());
            venda.ListaProduto = listaProduto;
            try
            {
                Loja.Fachada.Fachada.VendaFachada.Insert(venda);
                Loja.Fachada.Fachada.RegistroVendaFachada.Insert(Convert.ToInt32(ddlVendedores.SelectedValue),
                                                                    listaProduto, venda.ValorTotal);

                Loja.Fachada.Fachada.RegistroVendaProdutoFachada.Insert(listaProduto);

                gdvDepartamento.DataBind();

                this.ExibirMensagem("Venda Efetuada Com Sucesso. Obrigado Pela Preferência !!!");

            }
            catch (Exception)
            {
                
                throw;
            }
            foreach (GridViewRow row in gdvDepartamento.Rows)
            {
                if (((DropDownList)row.FindControl("ddlQuantidade")).Text == "")
                {
                    ((CheckBox)row.FindControl("checkComprar")).Enabled = false;
                }

            }
        }

        protected void gdvDepartamento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Loja.Objeto.Models.Produto prod = (Loja.Objeto.Models.Produto)e.Row.DataItem;
                DropDownList ddlList = (DropDownList)e.Row.FindControl("ddlQuantidade");
                for (int i = 1; i <= prod.QuantidadeProduto; i++)
                {
                    ddlList.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ddlList.DataBind();

            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Session["valor"] = 0;
            foreach (GridViewRow row1 in gdvDepartamento.Rows)
            {

                if (((CheckBox)row1.FindControl("checkComprar")).Checked)
                {

                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    DropDownList valor = (DropDownList)gdvDepartamento.Rows[row1.RowIndex].FindControl("ddlQuantidade");

                    string prod = valor.SelectedItem.ToString();
                    int id = Convert.ToInt32(gdvDepartamento.DataKeys[row1.RowIndex]["IdProduto"]);
                    List<Loja.Objeto.Models.Produto> listaProduto = Loja.Fachada.Fachada.ProdutoFachada.listarProduto(id);

                    foreach (Loja.Objeto.Models.Produto produto in listaProduto)
                    {
                        double valorProduto = produto.PrecoProduto * Convert.ToInt32(prod);
                        Session["valor"] = Convert.ToDouble(Session["valor"]) + (valorProduto);
                    }
                    lblValor.Text = "Valor Total: R$" + Convert.ToString(Session["valor"].ToString());
                }
            }

        }

        protected void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        protected void ddlQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gdvDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void gdvDepartamento_PreRender(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gdvDepartamento.Rows)
            {
                if (((DropDownList)row.FindControl("ddlQuantidade")).Text == "")
                {
                    ((CheckBox)row.FindControl("checkComprar")).Enabled = false;
                }

            }
        }



    }
}