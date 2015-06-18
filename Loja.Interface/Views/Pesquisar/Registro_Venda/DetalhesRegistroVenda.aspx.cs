using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja.Interface.Views.Pesquisar.Registro_Venda
{
    public partial class DetalhesRegistroVenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Session["id"].ToString());
                List<Loja.Objeto.Models.RegistroVendaProduto> registroVendaProduto = Loja.Fachada.Fachada.RegistroVendaProdutoFachada.Obter(id);
               int soma = 0;
                gdvRegistroVenda.DataSource = registroVendaProduto;
                gdvRegistroVenda.DataBind();
                foreach (GridViewRow row in gdvRegistroVenda.Rows)
	            {
		            soma = soma + Convert.ToInt32( row.Cells[6].Text);
	            }
                lblTotalCompra.Text = lblTotalCompra.Text + soma;

            }
        }
    }
}