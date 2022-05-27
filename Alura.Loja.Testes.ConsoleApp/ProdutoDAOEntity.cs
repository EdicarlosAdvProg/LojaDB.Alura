using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp {
    internal class ProdutoDAOEntity : IProdutoDAO, IDisposable {
        
        private LojaContext Context;
        public ProdutoDAOEntity() {
            this.Context = new LojaContext();
        }

        public void Adicionar(Produto p) {          //C
            Context.Produtos.Add(p);
            Context.SaveChanges();
        }

        public IList<Produto> Produtos() {          //R
            return Context.Produtos.ToList();
        }

        public void Atualizar(Produto p) {          //U
            Context.Produtos.Update(p);
            Context.SaveChanges();
        }

        public void Remover(Produto p) {            //D
            Context.Produtos.Remove(p);
            Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }
    }
}
