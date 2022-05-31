using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp {
    class Program {

        static void Main(string[] args) {

            using (var context = new LojaContext()) {

                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());



                //Produto p1 = context
                //    .Produtos
                //    .Where(p => p.Nome == "Pão francês")
                //    .FirstOrDefault();

                //Compra c1 = new Compra(p1, 30);
                //Compra c2 = new Compra(p1, 26);
                //Compra c3 = new Compra(p1, 40);

                //context.Compras.Add(c1);
                //context.Compras.Add(c2);
                //context.Compras.Add(c3);

                //context.SaveChanges();


                Produto produto = context
                    .Produtos
                    .Include(p => p.Compras)
                    .Where(c => c.Id == 11)
                    .FirstOrDefault();

                List<Compra> compras = context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(v => v.Preco > 10)
                    .ToList();

                Console.WriteLine($"Mostrando compras do produto {produto.Nome}");
                foreach (var item in compras) {
                    Console.WriteLine(item);
                }

                Console.WriteLine("=================");
                foreach (var e in context.ChangeTracker.Entries()) {
                    Console.WriteLine(e.State);
                }
            }
        }

        static void MostraEnderecoCliente() {
            using (var context = new LojaContext()) {
                var cliente = context
                    .Clientes
                    .Include(e => e.EnderecoEntrega)
                    .First();
                Console.WriteLine($"Endereço do cliente: {cliente.EnderecoEntrega.Logradouro}");
            }
        }

        static void MostraProdutoPromocao() {
            Console.WriteLine("Gravando nova promoção...");
            using (var context = new LojaContext()) {

                var promocao = new Promocao();
                promocao.Descricao = "Queima Total 2017";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataFinal = new DateTime(2017, 1, 31);

                var produtos = context.Produtos.Where(p => p.Categoria == "Bebidas").ToList();

                foreach (var item in produtos) {
                    promocao.AdicionarProduto(item);
                }

                context.Promocoes.Add(promocao);
                context.SaveChanges();

            }

            Console.WriteLine("\nMostrando os produtos da promoção...");
            using (var context2 = new LojaContext()) {
                var promocao = context2.Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                foreach (var item in promocao.Produtos) {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        static void UmPraUm() {

            var fulano = new Cliente();
            fulano.Nome = "Bill Cooper";
            fulano.EnderecoEntrega = new Endereco {
                Numero = 12,
                Logradouro = "Brown street",
                Complemento = "h256",
                Bairro = "Bulevard",
                Cidade = "New York"
            };

            using (var context = new LojaContext()) {
                context.Clientes.Add(fulano);
                context.SaveChanges();
            }
        }
        static void MuitosParaMuitos() {

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