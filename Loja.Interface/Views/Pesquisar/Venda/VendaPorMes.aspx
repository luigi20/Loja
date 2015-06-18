<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendaPorMes.aspx.cs" Inherits="Loja.Interface.Views.Pesquisar.Venda.VendaPorMes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/Principal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Content/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/javaScript/Mascara.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="top-nav" class="navbar navbar-inverse navbar-static-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">LOJA COMPRE BEM BARATEIRO</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown"><a class="dropdown-toggle" role="button" data-toggle="dropdown"
                            href="#"><i class="glyphicon glyphicon-user"></i>Admin <span class="caret"></span>
                        </a>
                            <ul id="g-account-menu" class="dropdown-menu" role="menu">
                                <li><a href="#">My Profile</a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="glyphicon glyphicon-lock"></i>Logout</a></li>
                    </ul>
                </div>
            </div>
            <!-- /container -->
        </div>
        <!-- /Header -->
        <!-- Main -->
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-3">
                    <!-- Left column -->
                    <hr />
                    <ul class="list-unstyled">
                        <li class="nav-header"><a href="#" data-toggle="collapse" data-target="#userMenu">
                            <li class="active"><a href="../../Home/Home.aspx">Home</a></li>
                            <h5>Cadastros 
                        </h5>
                        </a>
                            <ul class="list-unstyled collapse in" id="userMenu">

                                <li><a href="../../Departamento/Departamento.aspx">Departamento</a></li>
                                <li><a href="../../Produto/Produto.aspx">Produto</a></li>
                                <li><a href="">Venda</a></li>
                                <li><a href="">Registro de Venda</a></li>
                                <li><a href="../../Vendedor/Vendedor.aspx">Vendedor</a></li>
                            </ul>
                        </li>
                        <hr />

                        <hr />
                        <li class="nav-header"><a href="#" data-toggle="collapse" data-target="#menu2">
                            <h5>Pesquisar 
                        </h5>
                        </a>
                            <ul class="list-unstyled collapse in" id="Ul1">
                                <li><a href="../Departamento/Departamento.aspx">Departamento</a></li>
                                <li><a href="Produto.aspx">Produto</a></li>
                                <li><a href="">Venda </a></li>
                                <li><a href="">Registro de Venda</a></li>
                                <li><a href="../Vendedor/Vendedor.aspx">Vendedor</a></li>

                            </ul>

                        </li>
                    </ul>
                </div>
                <!-- /col-3 -->
                <div class="col-sm-9">
                    <!-- column 2 -->
                    <ul class="list-inline pull-right">
                        <li><a href="#"><i class="glyphicon glyphicon-cog"></i></a></li>
                    </ul>
                    <a href="#"><strong><i class="glyphicon glyphicon-dashboard"></i>Pe</strong>squisar</a>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <div class="panel-title">
                                        <i class="glyphicon glyphicon-wrench pull-right"></i>
                                        <h4 id="head_pagina">Venda</h4>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="control-group col-md-10">
                                        <label>
                                            Mês</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlMes" runat="server">
                                                <asp:ListItem Selected="True" Value="01">Janeiro</asp:ListItem>
                                                <asp:ListItem Value="02">Fevereiro</asp:ListItem>
                                                <asp:ListItem Value="03">Março</asp:ListItem>
                                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                                <asp:ListItem Value="05">Maio</asp:ListItem>
                                                <asp:ListItem Value="06">Junho</asp:ListItem>
                                                <asp:ListItem Value="07">Julho</asp:ListItem>
                                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                <asp:ListItem Value="09">Setembro</asp:ListItem>
                                                <asp:ListItem Value="10">Outubro</asp:ListItem>
                                                <asp:ListItem Value="11">Novembro</asp:ListItem>
                                                <asp:ListItem Value="12">Dezembro</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;</div>
                                    </div>
                                    <div class="control-group col-md-2">
                                        <label>
                                            Ano</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlAno" runat="server">
                                                <asp:ListItem Selected="True">2015</asp:ListItem>
                                                <asp:ListItem>2016</asp:ListItem>
                                                <asp:ListItem>2017</asp:ListItem>
                                                <asp:ListItem>2018</asp:ListItem>
                                                <asp:ListItem>2019</asp:ListItem>
                                                <asp:ListItem>2020</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;</div>
                                    </div>
                                    <div class="control-group col-md-6">
                                        &nbsp;<div class="controls">
                                            <br />
                                            <asp:Button class="btn btn-success" ID="btnSalvar" Text="Pesquisar" runat="server"
                                                OnClick="btnPesquisar_Click" />
                                            <br />
                                            <br />
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODSDepartamento" ForeColor="#333333" GridLines="None" Width="292px">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:BoundField DataField="IdDepartamento" HeaderText="Id_Departamento" SortExpression="IdDepartamento" >
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NomeDepartamento" HeaderText="Nome" SortExpression="NomeDepartamento" >
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                            </asp:GridView>
                                            <p style="margin-top:-110px; "><asp:GridView ID="gdvValorPorMes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Right">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Valor Total" >
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                            </asp:GridView></p>
                                           
                                            
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <center><asp:Button ID="Button1" runat="server" Text="Relatorio" /></center>
                                        </div>
                                    </div>

                                    <div class="control-group col-md-12">
                                        <div class="controls">
                                            &nbsp;
                                      
                                        </div>
                                    </div>
                                </div>
                                <!--/panel content-->
                            </div>
                            <!--/panel-->
                        </div>
                        <!--/col-span-12-->
                    </div>
                    <!--/row-->
                    <hr />
                </div>
                <!--/col-span-9-->
            </div>
        </div>
        <!-- /Main -->
        <footer class="text-center">Páginas relacionadas à atividade de <strong>Tecnologias Web</strong>.</footer>
        <div class="modal" id="addWidgetModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            Ã—</button>
                        <h4 class="modal-title">Add Widget</h4>
                    </div>
                    <div class="modal-body">
                        <p>
                            Add a widget stuff here..
                        </p>
                    </div>
                    <div class="modal-footer">
                        <a href="#" data-dismiss="modal" class="btn">Close</a> <a href="#" class="btn btn-primary">Save changes</a>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dalog -->
        </div>
        <!-- /.modal -->
        <!-- script references -->
        <asp:ObjectDataSource ID="ODSDepartamento" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="listarDepartamento" TypeName="Loja.Fachada.Fachada.DepartamentoFachada">
            <SelectParameters>
                <asp:Parameter Name="departamento" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

