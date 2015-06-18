<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="Loja.Interface.Views.Vendedor.Vendedor" %>

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
                    &nbsp;<hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <div class="panel-title">
                                        <i class="glyphicon glyphicon-wrench pull-right"></i>
                                        <h4 id="head_pagina">Vendedores</h4>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="control-group col-md-10">
                                        <label>
                                            Nome do Vendedor</label>
                                        <div class="controls">
                                            <asp:TextBox class="form-control" ID="txtBoxNome" runat="server" Width="765px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtBoxNome" runat="server"
                                                ErrorMessage="* Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="control-group col-md-12">
                                        <label>
                                            RG do Vendedor</label>
                                        <div class="controls">
                                            <asp:TextBox class="form-control" ID="txtBoxRG" runat="server" Width="765px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvRG" ControlToValidate="txtBoxRG" runat="server"
                                                ErrorMessage="* Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>
                                    <div class="control-group col-md-12">
                                        <label>
                                            Data de Admissao do Vendedor</label>
                                        <div class="controls">
                                            <asp:TextBox class="form-control" ID="txtBoxData" runat="server" Width="765px" onKeyUp=" formataData(this,event)" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvData" ControlToValidate="txtBoxData" runat="server"
                                                ErrorMessage="* Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>
                                    <div class="control-group col-md-12">
                                        <label>
                                            CPF do Vendedor</label>
                                        <div class="controls">
                                            <asp:TextBox class="form-control" ID="txtBoxCPF" runat="server" Width="765px" MaxLength="14" onKeyUp="formataCPF(this,event)" />
                                            <asp:RegularExpressionValidator ID="revCPF" runat="server" ErrorMessage="CPF Inválido"
                                                ControlToValidate="txtBoxCpf" ValidationExpression="^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$"
                                                ForeColor="Red"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvCPF" ControlToValidate="txtBoxCPF" runat="server"
                                                ErrorMessage="* Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>
                                    <div class="control-group col-md-4">
                                        <label>
                                            Departamento do Vendedor</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlDepartamento" runat="server" DataSourceID="DepartamentoODS" DataTextField="NomeDepartamento" DataValueField="IdDepartamento">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group col-md-4">
                                        <label>
                                            Nivel de Escolaridade</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlNivelEscolaridade" runat="server">
                                                <asp:ListItem Selected="True" Text="Ensino Fundamental " Value="Ensino Fundamental "></asp:ListItem>
                                                <asp:ListItem Text="Ensino Medio " Value="Ensino Medio ">Ensino Medio </asp:ListItem>
                                                <asp:ListItem Text="Ensino Superior " Value="Ensino Superior ">Ensino Superior </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group col-md-4">
                                        <label>
                                            Situacao do Vendedor</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlSituacao" runat="server">
                                                <asp:ListItem>Ativo</asp:ListItem>
                                                <asp:ListItem>Inativo</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group col-md-12">
                                        <label>
                                        </label>
                                        <div class="controls">

                                            <asp:Button class="btn btn-success" ID="btnCadastrar" Text="Cadastrar" CommandName="New" runat="server" OnCommand="btnCadastrar_Command" OnClick="btnCadastrar_Click" />
                                            <asp:Button class="btn btn-primary" ID="btnAlterar" runat="server" Text="Alterar" />
                                            <asp:Button class="btn btn-danger" ID="btnExcluir" runat="server" Text="Excluir" />

                                        </div>
                                    </div>
                                </div>
                                <!--/panel content-->
                            </div>
                            <!--/panel-->
                        </div>
                        <!--/col-span-12-->
                        <asp:ObjectDataSource ID="DepartamentoODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="listarDepartamento" TypeName="Loja.Fachada.Fachada.DepartamentoFachada">
                            <SelectParameters>
                                <asp:Parameter Name="departamento" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <!--/row-->
                    <hr />
                </div>
                <!--/col-span-9-->
            </div>
        </div>
    </form>

</body>
</html>
