using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Negocio;

namespace Loja.Fachada.Fachada
{
    [DataObject(true)]
    public class ProdutoFachada
    {
        private static Loja.Negocio.ProdutoNg produtoNg = new Negocio.ProdutoNg();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Produto> listarProdutoVendedor(int idVendedor)
        {
            return produtoNg.listarTodosProdutosVendedor(idVendedor);

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Loja.Objeto.Models.Produto Obter(int id)
        {
            return produtoNg.Obter(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List< Loja.Objeto.Models.Produto> DepartamentoPorProduto(int id)
        {
            return produtoNg.listarProdutoPorDepartamento(id);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(Loja.Objeto.Models.Produto produto)
        {

            int inserir = produtoNg.Insert2(produto);
            return inserir;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Insert(int departamentoIdProduto, string nomeProduto, double precoProduto, int quantidadeProduto,int idProdutoSimilar)
        {
            Loja.Objeto.Models.Produto produto = new Objeto.Models.Produto();

            produto.DepartamentoProduto = departamentoIdProduto;
            produto.NomeProduto = nomeProduto;
            produto.PrecoProduto = precoProduto;
            produto.QuantidadeProduto = quantidadeProduto;
            produto.IdProdutoSimilar = idProdutoSimilar;
            int inserir = produtoNg.Insert2(produto);
            return inserir;
        }

        public static int InsertSemSimilar(int departamentoIdProduto, string nomeProduto, double precoProduto, int quantidadeProduto)
        {
            Loja.Objeto.Models.Produto produto = new Objeto.Models.Produto();

            produto.DepartamentoProduto = departamentoIdProduto;
            produto.NomeProduto = nomeProduto;
            produto.PrecoProduto = precoProduto;
            produto.QuantidadeProduto = quantidadeProduto;
            int inserir = produtoNg.Insert2(produto);
            return inserir;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Loja.Objeto.Models.Produto produto)
        {
            produtoNg.Update(produto);
        }

       

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Loja.Objeto.Models.Produto produto)
        {
            produtoNg.Delete(produto);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Loja.Objeto.Models.Produto> listarProduto(int idProduto)
        {
            return produtoNg.listarProduto(idProduto);

        }

      

        
    }
}