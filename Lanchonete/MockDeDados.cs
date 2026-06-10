using System;
using Domain;
using Projeto.Pedidos;
using Projeto.CardapioDeItens;


namespace Lanchonete;

public class MockDeDados
{
    public Cardapio CriarCardapioPadrao()
    {
        Categoria entradas = new Categoria
        {
            Id = 1,
            NomeBR = "Entradas",
            NomeEN = "Starters"
        };

        Categoria bebidas = new Categoria
        {
            Id = 2,
            NomeBR = "Bebidas",
            NomeEN = "Drinks"
        };

        Categoria pratosPrincipais = new Categoria
        {
            Id = 3,
            NomeBR = "Pratos Principais",
            NomeEN = "Main Dishes"
        };

        Categoria sobremesas = new Categoria
        {
            Id = 4,
            NomeBR = "Sobremesas",
            NomeEN = "Desserts"
        };

        Cardapio cardapio = new Cardapio
        {
            CardapioItens = [],
            Entradas = entradas,
            Bebidas = bebidas,
            Pratos = pratosPrincipais,
            Sobremesas = sobremesas
        };

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 1,
            DescricaoBR = "Coxinha",
            DescricaoEN = "Chicken Croquette",
            Preco = 8.50m,
            EstaDisponivel = true,
            Categoria = entradas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 2,
            DescricaoBR = "Pao de Alho",
            DescricaoEN = "Garlic Bread",
            Preco = 7.90m,
            EstaDisponivel = true,
            Categoria = entradas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 3,
            DescricaoBR = "Mini Pastel",
            DescricaoEN = "Mini Pastry",
            Preco = 9.90m,
            EstaDisponivel = true,
            Categoria = entradas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 4,
            DescricaoBR = "Refrigerante",
            DescricaoEN = "Soda",
            Preco = 8.50m,
            EstaDisponivel = true,
            Categoria = bebidas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 5,
            DescricaoBR = "Suco Natural",
            DescricaoEN = "Natural Juice",
            Preco = 9.90m,
            EstaDisponivel = true,
            Categoria = bebidas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 6,
            DescricaoBR = "Milkshake de Chocolate",
            DescricaoEN = "Chocolate Milkshake",
            Preco = 16.90m,
            EstaDisponivel = true,
            Categoria = bebidas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 7,
            DescricaoBR = "X-Burguer",
            DescricaoEN = "Burger",
            Preco = 22.90m,
            EstaDisponivel = true,
            Categoria = pratosPrincipais
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 8,
            DescricaoBR = "X-Salada",
            DescricaoEN = "Salad Burger",
            Preco = 24.90m,
            EstaDisponivel = true,
            Categoria = pratosPrincipais
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 9,
            DescricaoBR = "Prato Feito",
            DescricaoEN = "Set Meal",
            Preco = 28.90m,
            EstaDisponivel = true,
            Categoria = pratosPrincipais
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 10,
            DescricaoBR = "Brigadeiro",
            DescricaoEN = "Chocolate Truffle",
            Preco = 6.50m,
            EstaDisponivel = true,
            Categoria = sobremesas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 11,
            DescricaoBR = "Pudim",
            DescricaoEN = "Custard Pudding",
            Preco = 7.50m,
            EstaDisponivel = true,
            Categoria = sobremesas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 12,
            DescricaoBR = "Sorvete",
            DescricaoEN = "Ice Cream",
            Preco = 9.00m,
            EstaDisponivel = true,
            Categoria = sobremesas
        });

        return cardapio;
    }

    public Cliente[] CriarClientesPadrao()
    {
        Cliente[] clientes = new Cliente[5];

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

        clientes[3] = new Cliente
        {
            Nome = "Diego Alves",
            Email = "diego.alves@email.com",
            AcessoDoUsuario = Acesso.Cliente
        };

        clientes[4] = new Cliente
        {
            Nome = "Elisa Rocha",
            Email = "elisa.rocha@email.com",
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

    public (Cardapio cardapio, Cliente[] Clientes, Administrador Administrador, GerenciadorPedidos Gerenciador, Pedido[] Pedidos) CriarCenarioCompleto()
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
