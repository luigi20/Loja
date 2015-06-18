using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Objeto.Models
{
    public class ProdutoSimilar
    {

        private int idProdutoSimilar;
        private int produto;
        private string nomeProdutoSimilar;

        public ProdutoSimilar(int idProdutoSimilar,int produto,string nomeProdutoSimilar)
        {
            this.produto = produto;
            this.idProdutoSimilar = idProdutoSimilar;
            this.nomeProdutoSimilar = nomeProdutoSimilar;
        }

        public string NomeProdutoSimilar
        {
            get { return nomeProdutoSimilar; }
            set { nomeProdutoSimilar = value; }
        }
        public int Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        public int IdProdutoSimilar
        {
            get { return idProdutoSimilar; }
            set { idProdutoSimilar = value; }
        }
    }
}