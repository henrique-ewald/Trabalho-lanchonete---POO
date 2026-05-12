using System;

namespace Lanchonete;

public class Cardapio
{
    public ItemMenu[] CardapioItens {get;set;}
    public Categoria Entradas {get;set;}
    public Categoria Bebidas {get;set;}
    public Categoria Pratos {get;set;}
    public Categoria Sobremesas {get;set;}

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

    public ItemMenu EditarItem(ItemMenu item, bool estaDisponivel , decimal preco)
    {
        item.EstaDisponivel = estaDisponivel;
        item.Preco = preco;
        return item;
    }

    public void RemoverItem(ItemMenu removido)
    {
        ItemMenu[] NovoVetor = new ItemMenu[CardapioItens.Length - 1];

        int cont, i=0;
        for (cont=0; cont < CardapioItens.Length; cont++)
        {
            if(removido.Codigo != CardapioItens[cont].Codigo)
            {
                i++;
                NovoVetor[i] = CardapioItens[cont];
            }
        }
        Console.WriteLine($"Item de código {removido.Codigo} removido.");
        CardapioItens = NovoVetor;
    }

}
