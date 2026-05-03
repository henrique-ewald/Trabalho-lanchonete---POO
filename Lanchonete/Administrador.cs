using System;

namespace Lanchonete;

public class Administrador : Usuario, IMenuGerenciavel
{
    public void AdicionaItem(ItemMenu item)
    {

        Console.WriteLine($"Item '{item.DescricaoBR}' adicionado ao menu.");
    }

    public void EditarItem(ItemMenu item)
    {

        Console.WriteLine($"Item '{item.DescricaoBR}' editado.");
    }

    public void RemoverItem(int id)
    {

        Console.WriteLine($"Item de código {id} removido.");
    }
    public void GerarRelatorio()
    {
        throw new NotImplementedException();
    }

}
