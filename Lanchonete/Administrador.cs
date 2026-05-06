using System;

namespace Lanchonete;

public class Administrador : Usuario, IMenuGerenciavel
{
    private Cardapio cardapio1 {get;set;}
    public Administrador(Cardapio cardapio)
    {
        cardapio1 = cardapio;
    }
    public void AdicionaItem(ItemMenu novo)
    {
        cardapio1.AdicionaItem(novo, cardapio1.CardapioItens);
    }
    public void RemoverItem(ItemMenu removido)
    {
        cardapio1.RemoverItem(removido, cardapio1.CardapioItens);
    }

    public void EditarItem(ItemMenu item)
    {
        Console.WriteLine($"Item '{item.DescricaoBR}' editado.");
    }
    public void GerarRelatorio()
    {
        throw new NotImplementedException();
    }

}
