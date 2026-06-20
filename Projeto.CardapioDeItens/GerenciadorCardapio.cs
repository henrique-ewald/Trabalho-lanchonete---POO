using System;
using Domain;

namespace Projeto.CardapioDeItens;

public class GerenciadorCardapio : Cardapio
{
    public void AdicionaItem(ItemMenu novo)
    {
        CardapioItens.Add(novo);
        Console.WriteLine($"Item de código {novo.Codigo} Adicionado!.");
    }

    public ItemMenu EditarItem(ItemMenu item, bool estaDisponivel , decimal preco)
    {
        item.EstaDisponivel = estaDisponivel;
        item.Preco = preco;
        return item;
    }

    public void RemoverItem(ItemMenu removido)
    {
        CardapioItens.Remove(removido);
        Console.WriteLine($"Item de código {removido.Codigo} removido.");
    }

}
