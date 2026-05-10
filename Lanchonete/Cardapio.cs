using System;

namespace Lanchonete;

public class Cardapio
{
    public ItemMenu[] CardapioItens {get;set;}

    public void AdicionaItem(ItemMenu novo)
    {
        ItemMenu[] NovoCardapio = new ItemMenu[CardapioItens.Length + 1];

        int cont;
        
        for(cont = 0; cont < CardapioItens.Length; cont++)
        {
            NovoCardapio[cont] = CardapioItens[cont];
        }
        NovoCardapio[NovoCardapio.Length - 1] = novo;

        Console.WriteLine($"Item '{novo.DescricaoBR}' adicionado ao menu.");

        CardapioItens = NovoCardapio;
    }

    public void EditarItem(ItemMenu item)
    {
        throw new NotImplementedException();
    }

    public void RemoverItem(ItemMenu removido)
    {
        ItemMenu[] NovoVetor = new ItemMenu[CardapioItens.Length - 1];

        int cont;
        for (cont=0; cont < CardapioItens.Length; cont++)
        {
            if(removido.Codigo != CardapioItens[cont].Codigo)
            {
                NovoVetor[cont] = CardapioItens[cont];
            }
        }
        Console.WriteLine($"Item de código {removido.Codigo} removido.");
        CardapioItens = NovoVetor;
    }

}
