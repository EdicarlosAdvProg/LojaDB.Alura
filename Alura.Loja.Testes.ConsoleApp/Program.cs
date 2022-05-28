using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp {
    class Program {
        static void Main(string[] args) {

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataFinal = DateTime.Now.AddMonths(3);

            Produto p1 = new Produto { Nome = "Suco de laranja", PrecoUnitario = 8.79, Categoria = "Bebidas", Unidade = "Litros" };
            Produto p2 = new Produto { Nome = "Café", PrecoUnitario = 12.45, Categoria = "Bebidas", Unidade = "Gramas" };
            Produto p3 = new Produto { Nome = "Macarrao", PrecoUnitario = 4.23, Categoria = "Alimentos", Unidade = "Gramas" };

            promocaoDePascoa.AdicionarProduto(p1);
            promocaoDePascoa.AdicionarProduto(p2);
            promocaoDePascoa.AdicionarProduto(p3);


            using (var context = new LojaContext()) {
                context.Promocoes.Add(promocaoDePascoa);
                context.SaveChanges();
            }
        }
    }
}