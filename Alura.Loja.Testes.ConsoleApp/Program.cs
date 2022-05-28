using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp {
    class Program {
        static void Main(string[] args) {

            var paoFrances = new Produto();
            paoFrances.Nome = "Pão francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;
  
            using (var context=new LojaContext()) {
                context.Compras.Add(compra);
                context.SaveChanges();
            }

        }
    }
}