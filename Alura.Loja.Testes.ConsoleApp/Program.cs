using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp {
    class Program {
        static void Main(string[] args) {
            //GravarUsandoAdoNet();     //C
            //GravarUsandoEntity();     //C
            RecuperarProdutos();        //R
            RemoverProdutos();          //D
            RecuperarProdutos();        //R
            //AtualizarProdutos();        //U
            //RecuperarProdutos();

        }

        private static void AtualizarProdutos() {
            using (var repo =new ProdutoDAOEntity()) {
                Produto primeiro=repo.Produtos().First();
                primeiro.Nome = "Harry Potter e as Relíquias da Morte";
                repo.Atualizar(primeiro);
            }
        }

        private static void RemoverProdutos() {
            using (var repo = new ProdutoDAOEntity()) {
                IList<Produto> produtos = repo.Produtos();
                foreach(var item in produtos) {
                    repo.Remover(item);
                }
            }
        }

        private static void RecuperarProdutos() {
            using (var repo = new ProdutoDAOEntity()) {
               
                IList<Produto> produtos = repo.Produtos();
                
                Console.WriteLine("Foram recuperados {0} produto(s)",produtos.Count());
                
                foreach (var item in produtos) {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEntity() {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var context = new ProdutoDAOEntity()) {
                context.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet() {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO()) {
                repo.Adicionar(p);
            }
        }
    }
}
