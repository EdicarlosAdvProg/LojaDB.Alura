using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp {
    internal interface IProdutoDAO {
        void Adicionar(Produto p);      //C
        IList<Produto> Produtos();      //R
        void Atualizar(Produto p);      //U
        void Remover(Produto p);        //D
    }
}
