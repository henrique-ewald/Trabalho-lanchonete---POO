using System;
using Domain;
using Projeto.Pedidos;
using Projeto.CardapioDeItens;
using Projeto.Relatorios;

namespace Lanchonete;

public class MockDeDados
{
    public GerenciadorCardapio CriarCardapioPadrao(IIdioma idioma)
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

        GerenciadorCardapio cardapio = new GerenciadorCardapio
        {
            CardapioItens = [],
            Entradas = entradas,
            Bebidas = bebidas,
            Pratos = pratosPrincipais,
            Sobremesas = sobremesas,
            Idioma = idioma
        };

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 1,
            DescricaoBR = "Coxinha",
            DescricaoEN = "Chicken Croquette",
            DescricaoES = "Croqueta de Pollo",
            Preco = 8.50m,
            EstaDisponivel = true,
            Categoria = entradas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 2,
            DescricaoBR = "Pao de Alho",
            DescricaoEN = "Garlic Bread",
            DescricaoES = "Pan de Ajo",
            Preco = 7.90m,
            EstaDisponivel = true,
            Categoria = entradas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 3,
            DescricaoBR = "Mini Pastel",
            DescricaoEN = "Mini Pastry",
            DescricaoES = "Mini Empanadilla",
            Preco = 9.90m,
            EstaDisponivel = true,
            Categoria = entradas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 4,
            DescricaoBR = "Refrigerante",
            DescricaoEN = "Soda",
            DescricaoES = "Refresco",
            Preco = 8.50m,
            EstaDisponivel = true,
            Categoria = bebidas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 5,
            DescricaoBR = "Suco Natural",
            DescricaoEN = "Natural Juice",
            DescricaoES = "Jugo Natural",
            Preco = 9.90m,
            EstaDisponivel = true,
            Categoria = bebidas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 6,
            DescricaoBR = "Milkshake de Chocolate",
            DescricaoEN = "Chocolate Milkshake",
            DescricaoES = "Batido de Chocolate",
            Preco = 16.90m,
            EstaDisponivel = true,
            Categoria = bebidas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 7,
            DescricaoBR = "X-Burguer",
            DescricaoEN = "Burger",
            DescricaoES = "Hamburguesa",
            Preco = 22.90m,
            EstaDisponivel = true,
            Categoria = pratosPrincipais
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 8,
            DescricaoBR = "X-Salada",
            DescricaoEN = "Salad Burger",
            DescricaoES = "Hamburguesa con Ensalada",
            Preco = 24.90m,
            EstaDisponivel = true,
            Categoria = pratosPrincipais
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 9,
            DescricaoBR = "Prato Feito",
            DescricaoEN = "Set Meal",
            DescricaoES = "Plato del Dia",
            Preco = 28.90m,
            EstaDisponivel = true,
            Categoria = pratosPrincipais
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 10,
            DescricaoBR = "Brigadeiro",
            DescricaoEN = "Chocolate Truffle",
            DescricaoES = "Brigadeiro",
            Preco = 6.50m,
            EstaDisponivel = true,
            Categoria = sobremesas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 11,
            DescricaoBR = "Pudim",
            DescricaoEN = "Custard Pudding",
            DescricaoES = "Flan",
            Preco = 7.50m,
            EstaDisponivel = true,
            Categoria = sobremesas
        });

        cardapio.AdicionaItem(new ItemMenu
        {
            Codigo = 12,
            DescricaoBR = "Sorvete",
            DescricaoEN = "Ice Cream",
            DescricaoES = "Helado",
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

    public Administrador CriarAdministradorPadrao(IIdioma idioma)
    {
        Administrador administrador = new Administrador()
        {
            Nome = "Marcos Oliveira",
            Email = "marcos.oliveira@email.com",
            AcessoDoUsuario = Acesso.Administrador,
            Idioma = idioma
        };

        return administrador;
    }

    public GerenciadorPedidos CriarGerenciadorPedidosPadrao(IIdioma idioma)
    {
        return new GerenciadorPedidos
        {
            TodosPedidos = new Pedido[0],
            Idioma = idioma
        };
    }

    public Pedido[] CriarPedidosPadrao(Cardapio cardapio, Cliente[] clientes)
    {
        GerenciadorPedidos gerenciador = CriarGerenciadorPedidosPadrao(cardapio.Idioma ?? new IdiomaPortugues());

        gerenciador.CriarPedido(clientes[0], cardapio, new int[] { 1, 2, 3 }, new int[] { 2, 1, 1 }, 2);
        gerenciador.CriarPedido(clientes[1], cardapio, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 1, 1 }, 3);
        gerenciador.CriarPedido(clientes[2], cardapio, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 1, 1, 1, 1, 1 }, 1);

        return gerenciador.TodosPedidos;
    }

    public DadosGerais CriarCenarioCompleto(IIdioma idioma)
    {
        GerenciadorCardapio cardapio = CriarCardapioPadrao(idioma);
        Cliente[] clientes = CriarClientesPadrao();
        Administrador administrador = CriarAdministradorPadrao(idioma);
        GerenciadorPedidos gerenciador = CriarGerenciadorPedidosPadrao(idioma);

        gerenciador.CriarPedido(clientes[0], cardapio, new int[] { 1, 2, 3 }, new int[] { 2, 1, 1 }, 2);
        gerenciador.CriarPedido(clientes[1], cardapio, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 1, 1 }, 3);
        gerenciador.CriarPedido(clientes[2], cardapio, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 1, 1, 1, 1, 1 }, 1);
        var DadosGerais = new DadosGerais
        {
            Clientes = clientes,
            Cardapio = cardapio,
            Gerenciador = gerenciador,
            Administrador = administrador,
            PrinterRelatorio = new PrintaRelatorios(gerenciador, idioma),
            SerializadorRelatorio = new SerializadorDeRelatorio(gerenciador, idioma)
        };
        return DadosGerais;
    }
}
