<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="Loja.Interface.Views.Departamento.Departamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../../Content/Principal.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/javaScript/Mascara.js"></script>
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
                        <li class="active"><a href="../Home/Home.aspx">Home</a></li>
                        <h5>Cadastros 
                        </h5>
                        
                    </a>
                                 <ul class="list-unstyled collapse in" id="userMenu">

                            <li><a href="../Departamento/Departamento.aspx">Departamento</a></li>
                            <li><a href="../Produto/Produto.aspx">Produto</a></li>
                            <li><a href="../Venda/Venda.aspx">Venda</a></li>
                            <li><a href="../Vendedor/Vendedor.aspx">Vendedor</a></li>
                        </ul>
                    </li>
                    <hr />
                
                    <hr />
                    <li class="nav-header"><a href="#" data-toggle="collapse" data-target="#menu2">
                        <h5>Pesquisar 
                        </h5>
                    </a>
                        <ul class="list-unstyled collapse in" id="Ul1">
                            <li><a href="../Pesquisar/Departamento/Departamento.aspx">Departamento</a></li>
                            <li><a href="../Pesquisar/Produto/Produto.aspx">Produto Por Departamento</a></li>
                            <li><a href="../Pesquisar/Venda/Venda.aspx">Venda Por Vendedor e Periodo </a></li>
                            <li><a href="../Pesquisar/Registro_Venda/Registro_Venda.aspx">Registro de Venda</a></li>
                            <li><a href="../Pesquisar/Vendedor/Vendedor.aspx">Vendedor</a></li>

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
                <a href="#"><strong></strong></a>
                &nbsp;<hr />
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    <i class="glyphicon glyphicon-wrench pull-right"></i>
                                    <h4 id="head_pagina">Departamentos</h4>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="control-group col-md-10">
                                    <label>
                                        Nome do Departamento</label>
                                    <div class="controls">
                                        <asp:TextBox class="form-control" ID="txtBoxNome" runat="server" Width="765px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtBoxNome" runat="server" 
                                            ErrorMessage="* Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group col-md-6">
                                    <label>
                                        Sigla do Departamento</label>
                                    <div class="controls">
                                        <asp:TextBox class="form-control" ID="txtBoxSigla" runat="server" Width="765px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSigla" ControlToValidate="txtBoxSigla" runat="server" 
                                            ErrorMessage="* Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group col-md-12">
                                    <label>
                                        Percentual de Comissão do Departamento</label>
                                    <div class="controls">
                                        <asp:TextBox class="form-control" ID="txtBoxComissao" runat="server" Width="765px" MaxLength="2" onKeyUp="filtraNumeros(this,event)"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvComissao" ControlToValidate="txtBoxComissao" runat="server" 
                                            ErrorMessage="* Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                         <br />
                                    </div>
                                </div>
                                 <div class="control-group col-md-6">
                                        <label>&nbsp;Chefe do Departamento</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlIdChefe" runat="server" DataSourceID="VendedorODS" DataTextField="NomeVendedor" DataValueField="IdVendedor" AppendDataBoundItems ="True">
                                               
                                            </asp:DropDownList>
                                           
                                        </div>
                                    </div>
                                <div class="control-group col-md-12">
                                    <label>
                                    </label>
                                    <div class="controls">

                                        <asp:Button class="btn btn-success" ID="btnCadastrar" Text="Cadastrar" CommandName="New" runat="server"  OnCommand="btnCadastrar_Command" OnClick="btnCadastrar_Click"   />
                                        <asp:Button class="btn btn-primary" ID="btnAlterar" runat="server" Text="Alterar" />
                                        <asp:Button class="btn btn-danger" ID="btnExcluir" runat="server" Text="Excluir" />
                                      
                        <asp:ObjectDataSource ID="VendedorODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="listarPossiveisChefes" TypeName="Loja.Fachada.Fachada.VendedorFachada"></asp:ObjectDataSource>
                                      
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
    </form>
    <!-- /Main -->
    <footer class="text-center">Páginas relacionadas à atividade de -9-->
        </div>
    </div>
    <!-- /Main -->
    <footer class="text-center">Páginas relacionadas à atividade de -9-->
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