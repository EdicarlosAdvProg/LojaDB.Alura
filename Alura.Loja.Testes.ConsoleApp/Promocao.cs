using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp {
    public class Promocao {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataFinal { get; internal set; }
        public IList<ProdutoPromocao> Produtos { get; set; }

        public Promocao() {
            Produtos = new List<ProdutoPromocao>();
        }

        internal void AdicionarProduto(Produto produto) {
            Produtos.Add(new ProdutoPromocao() { Produto = produto });
        }

        public override string ToString() {

            return Descricao + "\n" +
                DataInicio + "\n" +
                DataFinal + "\n";
            
        }
    }
}