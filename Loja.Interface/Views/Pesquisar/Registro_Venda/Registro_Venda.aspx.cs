using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja.Interface.Views.Pesquisar.Registro_Venda
{
    public partial class Registro_Venda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDetalhes_Click(object sender, EventArgs e)
        {
            GridViewRow row =
           (GridViewRow)((Button)sender).NamingContainer;

            Session["id"] = Convert.ToInt32(gdvRegistroVenda.DataKeys[row.RowIndex]["IdRegistroVenda"]);
            Response.Redirect("../../../Views/Pesquisar/Registro_Venda/DetalhesRegistroVenda.aspx");       
        }
    }
}