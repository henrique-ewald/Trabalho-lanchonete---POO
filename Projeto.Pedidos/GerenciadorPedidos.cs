using System;
using Domain;
using Projeto.CardapioDeItens;
using System.Text.Json.Serialization;

namespace Projeto.Pedidos;

public class GerenciadorPedidos
{
    public Pedido[] TodosPedidos {get;set;}
    [JsonIgnore]
    public IIdioma Idioma { get; set; }
    private IIdioma Texto => Idioma ?? new IdiomaPortugues();

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
            for(j=0; j < cardapio.CardapioItens.Count(); j++)
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
        for(int i=0; i < quant; i++)
        {
            ItemMenu itemCardapio = BuscarItem(cardapio, codigosItens[i]);
            if (itemCardapio == null)
            {
                Console.WriteLine(Texto.ItemNaoEncontradoNoPedido(codigosItens[i]));
                continue;
            }

            ItemPedido item = new ItemPedido();
            item.Item = itemCardapio;
            item.PrecoUnitario = itemCardapio.Preco;
            item.Quantidade = quantItens[i];
            itens[i] = item;
        }
        return itens;
    }

    private ItemMenu BuscarItem(Cardapio cardapio, int codigo)
    {
        foreach (var item in cardapio.CardapioItens)
        {
            if (item.Codigo == codigo)
            {
                return item;
            }
        }

        return null;
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
        for (int i = 0; i < CodigoItem.Length; i++)
        {
            ItemMenu itemCardapio = BuscarItem(cardapio, CodigoItem[i]);
            if (itemCardapio == null)
            {
                Console.WriteLine(Texto.ItemNaoEncontradoNoPedido(CodigoItem[i]));
                continue;
            }

            ItemPedido Item = new ItemPedido
            {
                Quantidade = quantItens[i],
                PrecoUnitario = itemCardapio.Preco,
                Item = itemCardapio
            };
            pedido.ItensPedidos = AdicionaAoVetorGenerico(Item, pedido.ItensPedidos);
            pedido.ValorTotal += itemCardapio.Preco * quantItens[i];
        }
        return pedido;
    }

    public Pedido AtualizarStatusPedido(Pedido pedido)
    {
        if(pedido.StatusAtual == Status.Aberto)
        {
            PagarPedido(pedido);
            Console.WriteLine(Texto.PedidoFoiPago(pedido.id));
        }
        else if(pedido.StatusAtual == Status.Pago)
        {
            pedido.StatusAtual = Status.Encerrado;
            Console.WriteLine(Texto.PedidoFoiEncerrado(pedido.id));
        }
        else if (pedido.StatusAtual == Status.Encerrado)
        {
            Console.WriteLine(Texto.PedidoJaEncerrado);
        }
        return pedido;
    }

    private Pedido PagarPedido(Pedido pedido)
    {
        Console.WriteLine(Texto.ValorTotalPedido(pedido.ValorTotal));
        if(pedido.PessoasParaDividir > 1)
            Console.WriteLine(Texto.ValorDividido(pedido.PessoasParaDividir, pedido.ValorTotal / pedido.PessoasParaDividir));
        pedido.StatusAtual = Status.Pago;
        return pedido;
    }
}
