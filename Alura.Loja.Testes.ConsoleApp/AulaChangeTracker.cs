using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class AulaChangeTracker
    {
        ///* Aula 3 - ChangeTracker e estados */
        //static void Main(string[] args)
        //{
        //    using (var context = new LojaContext())
        //    {
        //        // Logger
        //        var serviceProvider = context.GetInfrastructure<IServiceProvider>();
        //        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
        //        loggerFactory.AddProvider(SqlLoggerProvider.Create());

        //        // Busca os produtos
        //        IList<Produto> produtos = context.Produtos.ToList();

        //        // Exibe o estado dos produtos
        //        exibeEntriesComState(context.ChangeTracker.Entries().ToList());

        //        // Altera uma propriedade de um produto
        //        var p1 = produtos.First();
        //        p1.Nome = "Cassino Royale alterado sem updater";

        //        // Exibe o estado dos produtos
        //        exibeEntriesComState(context.ChangeTracker.Entries().ToList());

        //        // Desabilitar o autodetect por questões de performance
        //        //context.ChangeTracker.AutoDetectChangesEnabled = false;

        //        // Só pelo fato do produto estar "Modified" o SaveChanges fará um 
        //        // update implícito
        //        context.SaveChanges();

        //        // Pega a lista atualizada
        //        produtos = context.Produtos.ToList();

        //        exibeEntriesComState(context.ChangeTracker.Entries().ToList());

        //        var p2 = new Produto() { Nome = "Adicionado e removido antes do SaveChanges", Categoria = "Outros", Preco = 999.99 };

        //        // Adicionamos e removemos sem dar um SaveChanges
        //        context.Produtos.Add(p2);
        //        context.Produtos.Remove(p2);

        //        // Entidade deve estar Detached
        //        var detachedEntry = context.Entry(p2);
        //        Console.WriteLine(detachedEntry.Entity.ToString() + " - " + detachedEntry.State);


        //        System.Threading.Thread.Sleep(10000);
        //    }
        //}

        //public static void exibeEntriesComState(IList<EntityEntry> entries)
        //{
        //    foreach(var e in entries)
        //    {
        //        Console.WriteLine(e.Entity.ToString() + " - " + e.State);
        //    }
        //}
    }
}
