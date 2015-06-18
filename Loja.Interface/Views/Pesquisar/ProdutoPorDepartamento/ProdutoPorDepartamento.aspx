﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdutoPorDepartamento.aspx.cs" Inherits="Loja.Interface.Views.Pesquisar.Produto_x_Departamento.ProdutoPorDepartamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../../../Content/Principal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Content/StyleSheet.css" rel="stylesheet" type="text/css" />
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
                                <li><a href="../Produto%20x%20Departamento/Produto.aspx">Produto</a></li>
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
                    <a href="#"><strong><i class="glyphicon glyphicon-dashboard"></i>Pesquisar</strong></a>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <div class="panel-title">
                                        <i class="glyphicon glyphicon-wrench pull-right"></i>
                                        <h4 id="head_pagina">Produto</h4>
                                    </div>
                                </div>
                                <div class="panel-body">

                                    <div class="control-group col-md-6">
                                        <label>
                                        </label>
                                        <div class="control-group col-md-2">
                                            &nbsp;<br />
                                            Departamento<br />

                                            <asp:DropDownList ID="ddlDepartamento" AppendDataBoundItems="True" runat="server" AutoPostBack="True" DataSourceID="ODSDepartamento" DataTextField="NomeDepartamento" DataValueField="IdDepartamento">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ODSDepartamento" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="listarDepartamento" TypeName="Loja.Fachada.Fachada.DepartamentoFachada">
                                                <SelectParameters>
                                                    <asp:Parameter Name="departamento" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>

                                            <br />
                                        </div>
                                    </div>

                                    <div class="control-group col-md-12">
                                        <div class="controls">
                                            <br />
                                            <asp:GridView ID="gdvProdutos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSProdutoGridView" CellPadding="4" ForeColor="#333333" Width="717px" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:BoundField DataField="IdProduto" HeaderText="IdProduto" SortExpression="IdProduto">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DepartamentoProduto" HeaderText="DepartamentoProduto" SortExpression="DepartamentoProduto" />
                                                    <asp:BoundField DataField="NomeProduto" HeaderText="NomeProduto" SortExpression="NomeProduto">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PrecoProduto" HeaderText="PrecoProduto" SortExpression="PrecoProduto" />
                                                    <asp:BoundField DataField="QuantidadeProduto" HeaderText="QuantidadeProduto" SortExpression="QuantidadeProduto" />
                                                   
                                                    <asp:BoundField DataField="IdProdutoSimilar" HeaderText="IdProdutoSimilar" SortExpression="IdProdutoSimilar" />
                                                   
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
                                            <asp:ObjectDataSource ID="ODSProdutoGridView" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="DepartamentoPorProduto" TypeName="Loja.Fachada.Fachada.ProdutoFachada" DataObjectTypeName="Loja.Objeto.Models.Produto" UpdateMethod="Update" DeleteMethod="Delete">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlDepartamento" Name="id" PropertyName="SelectedValue" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
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
    </form>
</body>
</html>
