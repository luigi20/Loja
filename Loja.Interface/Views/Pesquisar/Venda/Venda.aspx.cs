using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja.Interface.Views.Pesquisar.Venda
{
    public partial class Venda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = Convert.ToDateTime(txtBoxDataInicio.Text);
            DateTime dataFim = Convert.ToDateTime(txtBoxDataFim.Text);


            if (ddlVendedor.Text == "")
            {
                this.ExibirMensagem("Pesquisa Inválida. Tente Novamente !!!");
                return;

            }
            if (dataInicio > dataFim)
            {
                this.ExibirMensagem("Pesquisa Inválida. Tente Novamente !!!");
                return;
            }
            int idVendedor = Convert.ToInt32(ddlVendedor.SelectedValue);

            List<Loja.Objeto.Models.Venda> listaVenda = Loja.Fachada.Fachada.VendaFachada.VendasEfetuadasPorVendedor(idVendedor, dataInicio, dataFim);
            if (listaVenda != null)
            {
                gdvVenda.DataSource = listaVenda;
                gdvVenda.DataBind();

            }
            else
            {
                this.ExibirMensagem("Pesquisa Não Retornou Nenhum Registro !!!");
            }




        }

        protected void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        protected void gdvVenda_PreRender(object sender, EventArgs e)
        {

        }
    }
}