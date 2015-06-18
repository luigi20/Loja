using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja.Interface.Views.Pesquisar.Venda
{
    public partial class VendaPorMes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(ddlMes.Text);
            int ano = Convert.ToInt32(ddlAno.Text);
            DateTime dataInicio = Convert.ToDateTime("01" + "/" + ddlMes.Text + "/" + ddlAno.Text);
            int quantidadeDia = DateTime.DaysInMonth(Convert.ToInt32(ddlAno.Text), Convert.ToInt32(ddlMes.Text));
            DateTime dataFim = Convert.ToDateTime(quantidadeDia + "/" + ddlMes.Text + "/" + ddlAno.Text);
            List<double> listaValores = Loja.Fachada.Fachada.RegistroVendaProdutoFachada.VendaPorMes(dataInicio, dataFim);
            if (listaValores != null)
            {
                gdvValorPorMes.Visible = true;
                gdvValorPorMes.DataSource = listaValores;
                gdvValorPorMes.DataBind();
            }
            else
            {
                gdvValorPorMes.Visible = false;
            }
        }
    }
}