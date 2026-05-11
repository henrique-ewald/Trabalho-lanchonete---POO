using System;

namespace Lanchonete;

public class GerenciadorPedidos
{
    public Pedido[] TodosPedidos {get;set;}

    public Pedido CriarPedido(Cliente? consumidor, Cardapio cardapio, int[] codigosItens, int[] quantItens, int PessoasPDividir)
    {
        Pedido pedido = new Pedido
        {
            id = TodosPedidos.Length+1,
            CriadoEm = DateTime.Now,
            StatusAtual = Status.Aberto,
            Consumidor = consumidor,
            ItensPedidos = PreencherItensPedidos(cardapio, codigosItens, quantItens),
            ValorTotal = CalcularValor(codigosItens, quantItens, cardapio),
            PessoasParaDividir = PessoasPDividir
        };
        TodosPedidos = AdicionaAoVetorGenerico(pedido, TodosPedidos);
        return pedido;
    }

    private decimal CalcularValor(int[] codigosItens, int[] quantItens, Cardapio cardapio)
    {
        int i,j;
        decimal ValorTotal=0;
        for(i=0; i< codigosItens.Length; i++)
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
    private ItemPedido[] PreencherItensPedidos(Cardapio cardapio, int[] codigosItens, int[] quantItens)
    {
        int quant = codigosItens.Length;
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
    private TipoGenerico[] AdicionaAoVetorGenerico<TipoGenerico>(TipoGenerico Novo, TipoGenerico[] VetorGenerico)
    {
        TipoGenerico[] novoVetor = new TipoGenerico[VetorGenerico.Length + 1];

        int cont;

        for (cont = 0; cont < VetorGenerico.Length; cont++)
        {
            novoVetor[cont] = VetorGenerico[cont];
        }

        novoVetor[novoVetor.Length - 1] = Novo;

        return novoVetor;
    }
    public Pedido AdicionarItemAoPedido(Pedido pedido, Cardapio cardapio, int[] CodigoItem, int[] quantItens)
    {   
        int i;
        foreach (var itemCardapio in cardapio.CardapioItens)
        {
            for(i=0; i < CodigoItem.Length; i++)
            {
                if(itemCardapio.Codigo == CodigoItem[i])
                {
                    ItemPedido Item = new ItemPedido
                    {
                        Quantidade = quantItens[i],
                        PrecoUnitario = itemCardapio.Preco,
                        Item = itemCardapio
                    };
                    pedido.ItensPedidos = AdicionaAoVetorGenerico(Item, pedido.ItensPedidos);
                    pedido.ValorTotal = CalcularValor(CodigoItem, quantItens, cardapio);
                }
            }
        }
        return pedido;
    }
    public Pedido AtualizarStatusPedido(Pedido pedido)
    {
        if(pedido.StatusAtual == Status.Aberto)
        {
            PagarPedido(pedido);
            Console.WriteLine($"O pedido {pedido.id} foi pago!\n");
        }
        else if(pedido.StatusAtual == Status.Pago)
        {
            pedido.StatusAtual = Status.Encerrado;
            Console.WriteLine($"O pedido {pedido.id} foi encerrado!\n");
        }
        else if (pedido.StatusAtual == Status.Encerrado)
        {
            Console.WriteLine("O pedido já esta encerrado, não é possivel alterar o status do pedido.\n");
        }
        return pedido;
    }
    private Pedido PagarPedido(Pedido pedido)
    {
        Console.WriteLine($"O valor total do pedido eh:{pedido.ValorTotal}\n");
        if(pedido.PessoasParaDividir > 1)
            Console.WriteLine($"O valor dividido entre {pedido.PessoasParaDividir} pessoas ficou:{pedido.ValorTotal / pedido.PessoasParaDividir} para cada\n");
        pedido.StatusAtual = Status.Pago;
        return pedido;
    }
}
