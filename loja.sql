CREATE TABLE Venda (
  idVenda INTEGER  NOT NULL   IDENTITY ,
  Data_Venda DATE  NOT NULL  ,
  Valor_Total REAL  NOT NULL    ,
PRIMARY KEY(idVenda));
GO




CREATE TABLE Departamento (
  idDepartamento INTEGER  NOT NULL   IDENTITY ,
  Sigla_Departamento VARCHAR(20)  NOT NULL  ,
  Perc_Departamento REAL  NOT NULL  ,
  Nome_Departamento VARCHAR(45)  NOT NULL  ,
  idChefe_Departamento INTEGER      ,
PRIMARY KEY(idDepartamento));
GO




CREATE TABLE Vendedor (
  idVendedor INTEGER  NOT NULL   IDENTITY ,
  Departamento_idDepartamento INTEGER  NOT NULL  ,
  Nome_Vendedor VARCHAR(255)  NOT NULL  ,
  RG_Vendedor INTEGER  NOT NULL  ,
  CPF_Vendedor CHAR(15)  NOT NULL  ,
  Data_admissao_Vendedor DATE  NOT NULL  ,
  Situacao_Vendedor VARCHAR(20)  NOT NULL  ,
  Nivel_Escolaridade_Vendedor VARCHAR(45)  NOT NULL    ,
PRIMARY KEY(idVendedor)  ,
  FOREIGN KEY(Departamento_idDepartamento)
    REFERENCES Departamento(idDepartamento));
GO


CREATE INDEX Vendedor_FKIndex1 ON Vendedor (Departamento_idDepartamento);
GO


CREATE INDEX IFK_tem ON Vendedor (Departamento_idDepartamento);
GO


CREATE TABLE Produto (
  idProduto INTEGER  NOT NULL   IDENTITY ,
  Preco_Produto REAL  NOT NULL  ,
  Nome_Produto VARCHAR(45)  NOT NULL  ,
  Departamento_idDepartamento INTEGER  NOT NULL  ,
  Quantidade_Produto INTEGER  NOT NULL  ,
  idProdutoSimilar INTEGER      ,
PRIMARY KEY(idProduto)  ,
  FOREIGN KEY(Departamento_idDepartamento)
    REFERENCES Departamento(idDepartamento));
GO


CREATE INDEX Produto_FKIndex1 ON Produto (Departamento_idDepartamento);
GO


CREATE INDEX IFK_tem ON Produto (Departamento_idDepartamento);
GO


CREATE TABLE Registro_Venda (
  Venda_idVenda INTEGER  NOT NULL  ,
  idRegistroVenda INTEGER  NOT NULL   IDENTITY ,
  Vendedor_idVendedor INTEGER  NOT NULL  ,
  Departamento_idDepartamento INTEGER  NOT NULL  ,
  Valor_Comissao REAL  NOT NULL    ,
PRIMARY KEY(Venda_idVenda, idRegistroVenda)      ,
  FOREIGN KEY(Venda_idVenda)
    REFERENCES Venda(idVenda),
  FOREIGN KEY(Departamento_idDepartamento)
    REFERENCES Departamento(idDepartamento),
  FOREIGN KEY(Vendedor_idVendedor)
    REFERENCES Vendedor(idVendedor));
GO


CREATE INDEX Produto_has_Venda_FKIndex2 ON Registro_Venda (Venda_idVenda);
GO
CREATE INDEX Produto_has_Venda_FKIndex3 ON Registro_Venda (Departamento_idDepartamento);
GO
CREATE INDEX Produto_has_Venda_FKIndex4 ON Registro_Venda (Vendedor_idVendedor);
GO


CREATE INDEX IFK_Rel_16 ON Registro_Venda (Venda_idVenda);
GO
CREATE INDEX IFK_Rel_17 ON Registro_Venda (Departamento_idDepartamento);
GO
CREATE INDEX IFK_Rel_18 ON Registro_Venda (Vendedor_idVendedor);
GO


CREATE TABLE Registro_Venda_Produto (
  Produto_idProduto INTEGER  NOT NULL  ,
  Registro_Venda_idRegistroVenda INTEGER  NOT NULL  ,
  Registro_Venda_Venda_idVenda INTEGER  NOT NULL  ,
  idRegistroVendaProduto INTEGER  NOT NULL   IDENTITY ,
  Preco_Unitario REAL  NOT NULL  ,
  Quantidade_Produto INTEGER  NOT NULL  ,
  SubTotal REAL  NOT NULL    ,
PRIMARY KEY(Produto_idProduto, Registro_Venda_idRegistroVenda, Registro_Venda_Venda_idVenda, idRegistroVendaProduto)    ,
  FOREIGN KEY(Produto_idProduto)
    REFERENCES Produto(idProduto),
  FOREIGN KEY(Registro_Venda_Venda_idVenda, Registro_Venda_idRegistroVenda)
    REFERENCES Registro_Venda(Venda_idVenda, idRegistroVenda));
GO


CREATE INDEX Produto_has_Produto_has_Venda_FKIndex1 ON Registro_Venda_Produto (Produto_idProduto);
GO
CREATE INDEX Produto_has_Produto_has_Venda_FKIndex2 ON Registro_Venda_Produto (Registro_Venda_Venda_idVenda, Registro_Venda_idRegistroVenda);
GO


CREATE INDEX IFK_Rel_19 ON Registro_Venda_Produto (Produto_idProduto);
GO
CREATE INDEX IFK_Rel_20 ON Registro_Venda_Produto (Registro_Venda_Venda_idVenda, Registro_Venda_idRegistroVenda);
GO



