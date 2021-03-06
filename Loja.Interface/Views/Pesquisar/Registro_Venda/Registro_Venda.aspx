﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro_Venda.aspx.cs" Inherits="Loja.Interface.Views.Pesquisar.Registro_Venda.Registro_Venda" %>

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

                            <li><a href="../Departamento/Departamento.aspx">Departamento</a></li>
                            <li><a href="../Produto/Produto.aspx">Produto</a></li>
                            <li><a href="../../Venda/Venda.aspx">Venda</a></li>
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
                            <li><a href="../Produto/Produto.aspx">Produto Por Departamento</a></li>
                            <li><a href="../Venda/Venda.aspx">Venda Por Vendedor e Periodo </a></li>
                            <li><a href="Registro_Venda.aspx">Registro de Venda</a></li>
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
                                    <h4 id="head_pagina">
                                        Registro de Venda</h4>
                                </div>
                            </div>
                            <div class="panel-body">
                                
                                <div class="control-group col-md-6">
                                    <label>
                                        
                                        </label>
                                    <div class="control-group col-md-2">
                                        &nbsp;<br />
                                        <br />
                                        <br />

                                        <br />
                                    </div>
                                </div>
                          
                                <div class="control-group col-md-12">
                                    <label>
                                    </label>
                                    <div class="controls">
                                        <br />
                                        <asp:GridView ID="gdvRegistroVenda" runat="server" DataKeyNames ="IdRegistroVenda" AutoGenerateColumns="False" DataSourceID="ODSRegistroVendaGridView" CellPadding="4" ForeColor="#333333" Width="717px">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Vendedor" SortExpression="IdVendedor">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Vendedor.NomeVendedor") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Vendedor.NomeVendedor") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdVenda" HeaderText="IdVenda" SortExpression="IdVenda" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IdRegistroVenda" HeaderText="IdRegistroVenda" SortExpression="IdRegistroVenda" >
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Departamento" SortExpression="IdDepartamento">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Departamento.NomeDepartamento") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Departamento.NomeDepartamento") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="Comissao" HeaderText="Comissao" SortExpression="Comissao" DataFormatString="{0:c} " />
                                                <asp:TemplateField HeaderText="Detalhes">

                                                        <ItemTemplate>

                                                            <asp:Button runat="server" ID="btnDetalhes" OnClick="btnDetalhes_Click" Text="Detalhes" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                        <asp:ObjectDataSource ID="ODSRegistroVendaGridView" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="listarTodos" TypeName="Loja.Fachada.Fachada.RegistroVendaFachada">
                                            <SelectParameters>
                                                <asp:Parameter Name="idRegistroVenda" Type="Int32" />
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
                    <h4 class="modal-title">
                        Add Widget</h4>
                </div>
                <div class="modal-body">
                    <p>
                        Add a widget stuff here..</p>
                </div>
                <div class="modal-footer">
                    <a href="#" data-dismiss="modal" class="btn">Close</a> <a href="#" class="btn btn-primary">
                        Save changes</a>
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
