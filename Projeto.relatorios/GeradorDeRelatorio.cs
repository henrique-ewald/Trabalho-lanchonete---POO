using System;
using Domain;
using Projeto.Pedidos;
using Projeto.CardapioDeItens;

namespace Lanchonete;

public abstract class GeradorDeRelatorio
{
    protected GerenciadorPedidos gerenciador;

    public abstract void RegistrarInformacao(string conteudo);

    public bool GerenciadorEhNull(GerenciadorPedidos gerenciador)
    {
        if (gerenciador == null)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
    public void RelatorioPorPeriodo(Idioma idioma, DateTime inicio, DateTime fim)
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
            RegistrarInformacao("Nenhum pedido encontrado nesse periodo.");
        }
    }

    public void RelatorioPorCliente(Idioma idioma)
    {
        string busca = LerBusca("Nome ou email do cliente:");
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
            Console.WriteLine("Nenhum pedido encontrado para esse cliente.");
        }
    }

    public void RelatorioPorClienteEmPeriodo(Idioma idioma)
    {
        string busca = LerBusca("Nome ou email do cliente:");

        Console.WriteLine("Data inicial (dd/MM/yyyy):");
        DateTime inicio = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Data final (dd/MM/yyyy):");
        DateTime fim = DateTime.Parse(Console.ReadLine());

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
            Console.WriteLine("Nenhum pedido encontrado para esse cliente nesse periodo.");
        }
    }

    public void RelatorioDeItemDoMenu(Idioma idioma, Cardapio cardapio)
    {
        Console.WriteLine("Codigo do item:");
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
            Console.WriteLine("Item nao encontrado.");
            return;
        }
        bool encontrou = false;
        RegistrarInformacao($"\nConsumo do item: {itemProcurado.DescricaoBR}");
        foreach (Pedido pedido in gerenciador.TodosPedidos)
        {
            if (PedidoContemItem(pedido, codigo))
            {
                string nomeCliente = "Anonimo";
                if (pedido.Consumidor != null)
                {
                    nomeCliente = pedido.Consumidor.Nome;
                }
                RegistrarInformacao($"Pedido #{pedido.id} | {nomeCliente} | {pedido.CriadoEm:dd/MM/yyyy HH:mm}");
                encontrou = true;
            }
        }
        if (!encontrou)
        {
            RegistrarInformacao("Esse item ainda nao apareceu em nenhum pedido.");
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

    private void MostrarPedido(Pedido pedido)
    {
        string nomeCliente = "Anonimo";
        if (pedido.Consumidor != null)
        {
            nomeCliente = pedido.Consumidor.Nome;
        }

        RegistrarInformacao($"#{pedido.id} | {nomeCliente} | {pedido.CriadoEm:dd/MM/yyyy HH:mm} | {pedido.StatusAtual} | R${pedido.ValorTotal:F2}\nItens pedidos: {PrintaItensPedidos(pedido)}");
    }

    private string PrintaItensPedidos(Pedido pedido)
    {
        string resultado = "";
        foreach (var item in pedido.ItensPedidos)
        {
            resultado += $" | {item.Item.DescricaoBR} |";
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
