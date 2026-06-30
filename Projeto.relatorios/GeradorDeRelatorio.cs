using System;
using System.Globalization;
using Domain;
using Projeto.Pedidos;
using Projeto.CardapioDeItens;

namespace Projeto.Relatorios;

public abstract class GeradorDeRelatorio
{
    protected readonly GerenciadorPedidos gerenciador;
    public IIdioma Idioma { get; set; }

    protected GeradorDeRelatorio(GerenciadorPedidos gerenciador, IIdioma idioma)
    {
        this.gerenciador = gerenciador;
        Idioma = idioma ?? new IdiomaPortugues();
    }

    public abstract void RegistrarInformacao(string conteudo);

    public bool GerenciadorEhNull(GerenciadorPedidos gerenciador)
    {
        return gerenciador == null;
    }

    public void RelatorioPorPeriodo(DateTime inicio, DateTime fim)
    {
        if (fim < inicio)
        {
            DateTime troca = inicio;
            inicio = fim;
            fim = troca;
        }

        bool encontrou = false;
        foreach (Pedido pedido in gerenciador.TodosPedidos)
        {
            if (pedido.CriadoEm.Date >= inicio.Date && pedido.CriadoEm.Date <= fim.Date)
            {
                MostrarPedido(pedido);
                encontrou = true;
            }
        }

        if (!encontrou)
        {
            RegistrarInformacao(Idioma.NenhumPedidoEncontradoNessePeriodo);
        }
    }

    public void RelatorioPorCliente()
    {
        string busca = LerBusca(Idioma.NomeOuEmailDoCliente);
        bool encontrou = false;

        foreach (Pedido pedido in gerenciador.TodosPedidos)
        {
            if (PedidoEhDoCliente(pedido, busca))
            {
                MostrarPedido(pedido);
                encontrou = true;
            }
        }

        if (!encontrou)
        {
            Console.WriteLine(Idioma.NenhumPedidoEncontradoParaEsseCliente);
        }
    }

    public void RelatorioPorClienteEmPeriodo()
    {
        string busca = LerBusca(Idioma.NomeOuEmailDoCliente);

        Console.WriteLine(Idioma.DataInicial);
        DateTime inicio = LerData();
        Console.WriteLine(Idioma.DataFinal);
        DateTime fim = LerData();

        if (fim < inicio)
        {
            DateTime troca = inicio;
            inicio = fim;
            fim = troca;
        }

        bool encontrou = false;
        foreach (Pedido pedido in gerenciador.TodosPedidos)
        {
            if (PedidoEhDoCliente(pedido, busca) && pedido.CriadoEm.Date >= inicio.Date && pedido.CriadoEm.Date <= fim.Date)
            {
                MostrarPedido(pedido);
                encontrou = true;
            }
        }

        if (!encontrou)
        {
            Console.WriteLine(Idioma.NenhumPedidoEncontradoParaEsseClienteNessePeriodo);
        }
    }

    public void RelatorioDeItemDoMenu(Cardapio cardapio)
    {
        Console.WriteLine(Idioma.DigiteCodigoItem);
        int codigo = int.Parse(Console.ReadLine());

        ItemMenu itemProcurado = null;
        foreach (ItemMenu item in cardapio.CardapioItens)
        {
            if (item.Codigo == codigo)
            {
                itemProcurado = item;
                break;
            }
        }
        if (itemProcurado == null)
        {
            Console.WriteLine(Idioma.ItemNaoEncontradoNoMenu);
            return;
        }
        bool encontrou = false;
        RegistrarInformacao(Idioma.ConsumoDoItem(Idioma.NomeDoItem(itemProcurado.DescricaoBR, itemProcurado.DescricaoEN, itemProcurado.DescricaoES)));
        foreach (Pedido pedido in gerenciador.TodosPedidos)
        {
            if (PedidoContemItem(pedido, codigo))
            {
                string nomeCliente = "Anonimo";
                if (pedido.Consumidor != null)
                {
                    nomeCliente = pedido.Consumidor.Nome;
                }
                RegistrarInformacao(Idioma.ResumoPedidoPorItem(pedido.id, nomeCliente, pedido.CriadoEm));
                encontrou = true;
            }
        }
        if (!encontrou)
        {
            RegistrarInformacao(Idioma.ItemNaoApareceuEmNenhumPedido);
        }
    }

    private string LerBusca(string mensagem)
    {
        Console.WriteLine(mensagem);
        string texto = Console.ReadLine();

        if (texto == null)
        {
            return "";
        }

        return texto;
    }

    private DateTime LerData()
    {
        while (true)
        {
            string texto = Console.ReadLine();

            try
            {
                return DateTime.ParseExact(texto, Idioma.FormatoData, CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine(Idioma.OpcaoInvalida);
            }
        }
    }

    private void MostrarPedido(Pedido pedido)
    {
        string nomeCliente = "Anonimo";
        if (pedido.Consumidor != null)
        {
            nomeCliente = pedido.Consumidor.Nome;
        }

        RegistrarInformacao(Idioma.ResumoPedido(pedido.id, nomeCliente, pedido.CriadoEm, pedido.StatusAtual, pedido.ValorTotal, PrintaItensPedidos(pedido)));
    }

    private string PrintaItensPedidos(Pedido pedido)
    {
        string resultado = "";
        foreach (var item in pedido.ItensPedidos)
        {
            resultado += $" | {Idioma.NomeDoItem(item.Item.DescricaoBR, item.Item.DescricaoEN, item.Item.DescricaoES)} |";
        }
        return resultado;
    }

    private bool PedidoEhDoCliente(Pedido pedido, string busca)
    {
        if (pedido.Consumidor == null)
        {
            return false;
        }

        string termo = busca.ToLower();
        return pedido.Consumidor.Nome.ToLower().Contains(termo) || pedido.Consumidor.Email.ToLower().Contains(termo);
    }

    private bool PedidoContemItem(Pedido pedido, int codigoItem)
    {
        foreach (ItemPedido item in pedido.ItensPedidos)
        {
            if (item != null && item.Item != null && item.Item.Codigo == codigoItem)
            {
                return true;
            }
        }

        return false;
    }
}
