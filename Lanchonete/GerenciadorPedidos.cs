using System;

namespace Lanchonete;

public class GerenciadorPedidos
{
    public Pedido[] TodosPedidos {get;set;}

    public Pedido CriarPedido(Cliente consumidor, Cardapio cardapio, int quant, int[] codigosItens, int[] quantItens, int PessoasPDividir)
    {
        // Console.WriteLine("Criando pedido! Preencha as informações:\n");
        // Console.WriteLine("Quantos itens foram pedidos?\n");
        // int quant = int.Parse(Console.ReadLine());
        // int i;
        // int[] codigosItens = new int[quant];
        // int[] quantItens = new int[quant];
        // for(i=0; i < quant; i++)
        // {
        //     Console.WriteLine($"Digite o código do {i}° item:\n");
        //     codigosItens[i] = int.Parse(Console.ReadLine());
        //     Console.WriteLine($"Quantas unidades do {i}° item foram pedidas?:\n");
        //     quantItens[i] = int.Parse(Console.ReadLine());
        // }
        // Console.WriteLine("Em quantas pessoas vai ser divida a conta?:\n");
        // int PessoasPDividir = int.Parse(Console.ReadLine());
        Pedido pedido = new Pedido
        {
            CriadoEm = DateTime.Now,
            StatusAtual = Status.Aberto,
            Consumidor = consumidor,
            ItensPedidos = PreencherItensPedidos(cardapio, quant, codigosItens, quantItens),
            ValorTotal = CalcularValor(codigosItens, quantItens, quant, cardapio),
            PessoasParaDividir = PessoasPDividir
        };
        TodosPedidos = AdicionaAoVetor(pedido, TodosPedidos);
        return pedido;
    }

    public decimal CalcularValor(int[] codigosItens, int[] quantItens, int quant, Cardapio cardapio)
    {
        int i,j;
        decimal ValorTotal=0;
        for(i=0; i< quant; i++)
        {
            for(j=0; j < cardapio.CardapioItens.Length; j++)
            {
                if (codigosItens[i] == cardapio.CardapioItens[j].Codigo)
                {
                    ValorTotal += cardapio.CardapioItens[j].Preco * quantItens[i];
                }
            }
        }
        return ValorTotal;
    }
    public ItemPedido[] PreencherItensPedidos(Cardapio cardapio, int quant, int[] codigosItens, int[] quantItens)
    {
        ItemPedido[] itens = new ItemPedido[quant];
        int j;
        for(int i=0; i < quant; i++)
        {
            ItemPedido item = new ItemPedido();
            for(j=0; j < cardapio.CardapioItens.Length ;j++)
            {
                if (codigosItens[i] == cardapio.CardapioItens[j].Codigo)
                {
                    item.Item = cardapio.CardapioItens[j];
                    break;
                }
            }
            item.PrecoUnitario = cardapio.CardapioItens[j].Preco;
            item.Quantidade = quantItens[j];
            itens[i] = item;
        }
        return itens;
    }
    public Pedido[] AdicionaAoVetor(Pedido pedido, Pedido[] todosPedidos)
    {
        Pedido[] novoVetor = new Pedido[todosPedidos.Length + 1];

        int cont;

        for (cont = 0; cont < todosPedidos.Length; cont++)
        {
            novoVetor[cont] = todosPedidos[cont];
        }

        novoVetor[novoVetor.Length - 1] = pedido;

        return novoVetor;
    }
    

}
