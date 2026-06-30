using System;
using Domain;

namespace Projeto.CardapioDeItens;

public class GerenciadorCardapio : Cardapio
{
    private IIdioma Texto => Idioma ?? new IdiomaPortugues();

    // Caso idioma seja null, ele seta em portugues como padrão

    public void AdicionaItem(ItemMenu novo)
    {
        CardapioItens.Add(novo);
        Console.WriteLine(Texto.ItemCodigoAdicionado(novo.Codigo));
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
        Console.WriteLine(Texto.ItemCodigoRemovido(removido.Codigo));
    }
}
