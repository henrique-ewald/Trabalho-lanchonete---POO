using System;

namespace Lanchonete;

public class Cardapio
{
    public ItemMenu[] CardapioItens {get;set;}

    public ItemMenu[] AdicionaItem(ItemMenu novo, ItemMenu[] Cardapio)
    {
        ItemMenu[] NovoCardapio = new ItemMenu[Cardapio.Length + 1];

        int cont;
        
        for(cont = 0; cont < Cardapio.Length; cont++)
        {
            NovoCardapio[cont] = Cardapio[cont];
        }
        NovoCardapio[NovoCardapio.Length - 1] = novo;

        Console.WriteLine($"Item '{novo.DescricaoBR}' adicionado ao menu.");
        return NovoCardapio;
    }

    public void EditarItem(ItemMenu item)
    {
        throw new NotImplementedException();
    }

    public ItemMenu[] RemoverItem(ItemMenu removido, ItemMenu[] Cardapio)
    {
        ItemMenu[] NovoVetor = new ItemMenu[Cardapio.Length - 1];

        int cont;
        for (cont=0; cont < Cardapio.Length; cont++)
        {
            if(removido.Codigo != Cardapio[cont].Codigo)
            {
                NovoVetor[cont] = Cardapio[cont];
            }
        }
        Console.WriteLine($"Item de código {removido.Codigo} removido.");
        return NovoVetor;
    }

}
