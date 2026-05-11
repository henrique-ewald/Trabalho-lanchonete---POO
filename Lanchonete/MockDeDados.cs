using System;

namespace Lanchonete;

public class MockDeDados
{
    public Cardapio CriarCardapioPadrao()
    {
        Cardapio cardapio = new Cardapio
        {
            CardapioItens = new ItemMenu[0]
        };

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 1,
            DescricaoBR = "X-Burguer",
            DescricaoEN = "Burger",
            Preco = 22.90m,
            EstaDisponivel = true
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 2,
            DescricaoBR = "X-Salada",
            DescricaoEN = "Salad Burger",
            Preco = 24.90m,
            EstaDisponivel = true
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 3,
            DescricaoBR = "Batata Frita",
            DescricaoEN = "French Fries",
            Preco = 12.00m,
            EstaDisponivel = true
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 4,
            DescricaoBR = "Refrigerante",
            DescricaoEN = "Soda",
            Preco = 8.50m,
            EstaDisponivel = true
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 5,
            DescricaoBR = "Suco Natural",
            DescricaoEN = "Natural Juice",
            Preco = 9.90m,
            EstaDisponivel = true
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 6,
            DescricaoBR = "Milkshake de Chocolate",
            DescricaoEN = "Chocolate Milkshake",
            Preco = 16.90m,
            EstaDisponivel = true
        });

        return cardapio;
    }

    public Cliente[] CriarClientesPadrao()
    {
        Cliente[] clientes = new Cliente[3];

        clientes[0] = new Cliente
        {
            Nome = "Ana Souza",
            Email = "ana.souza@email.com",
            AcessoDoUsuario = Acesso.Cliente
        };

        clientes[1] = new Cliente
        {
            Nome = "Bruno Lima",
            Email = "bruno.lima@email.com",
            AcessoDoUsuario = Acesso.Cliente
        };

        clientes[2] = new Cliente
        {
            Nome = "Carla Mendes",
            Email = "carla.mendes@email.com",
            AcessoDoUsuario = Acesso.Cliente
        };

        return clientes;
    }

    public Administrador CriarAdministradorPadrao(Cardapio cardapio)
    {
        return new Administrador(cardapio)
        {
            Nome = "Marcos Oliveira",
            Email = "marcos.oliveira@email.com",
            AcessoDoUsuario = Acesso.Administrador
        };
    }

    public GerenciadorPedidos CriarGerenciadorPedidosPadrao()
    {
        return new GerenciadorPedidos
        {
            TodosPedidos = new Pedido[0]
        };
    }

    public Pedido[] CriarPedidosPadrao(Cardapio cardapio, Cliente[] clientes)
    {
        GerenciadorPedidos gerenciador = CriarGerenciadorPedidosPadrao();

        gerenciador.CriarPedido(clientes[0], cardapio, new int[] { 1, 2, 3 }, new int[] { 2, 1, 1 }, 2);
        gerenciador.CriarPedido(clientes[1], cardapio, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 1, 1 }, 3);
        gerenciador.CriarPedido(clientes[2], cardapio, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 1, 1, 1, 1, 1 }, 1);

        return gerenciador.TodosPedidos;
    }

    public (Cardapio Cardapio, Cliente[] Clientes, Administrador Administrador, GerenciadorPedidos Gerenciador, Pedido[] Pedidos) CriarCenarioCompleto()
    {
        Cardapio cardapio = CriarCardapioPadrao();
        Cliente[] clientes = CriarClientesPadrao();
        Administrador administrador = CriarAdministradorPadrao(cardapio);
        GerenciadorPedidos gerenciador = CriarGerenciadorPedidosPadrao();

        gerenciador.CriarPedido(clientes[0], cardapio, new int[] { 1, 2, 3 }, new int[] { 2, 1, 1 }, 2);
        gerenciador.CriarPedido(clientes[1], cardapio, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 1, 1 }, 3);
        gerenciador.CriarPedido(clientes[2], cardapio, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 1, 1, 1, 1, 1 }, 1);

        return (cardapio, clientes, administrador, gerenciador, gerenciador.TodosPedidos);
    }
}

