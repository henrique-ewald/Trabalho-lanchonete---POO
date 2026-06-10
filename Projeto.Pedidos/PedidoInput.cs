using System;
using Lanchonete;

namespace Projeto.Pedidos;

public class PedidoInput
{
    private string mensagemInvalida = "Informe uma opcao valida.";

    public DadosPedido PedidoInputs()
    {
        DadosPedido dados = new DadosPedido();
        Console.WriteLine("Criando pedido! Preencha as informacoes:\n");
        Console.WriteLine("Quantos itens foram pedidos?\n");
        dados.Quant = LerInteiro();

        dados.CodigosItens = new int[dados.Quant];
        dados.QuantItens = new int[dados.Quant];

        for (int i = 0; i < dados.Quant; i++)
        {
            Console.WriteLine($"Digite o codigo do {i}° item:\n");
            dados.CodigosItens[i] = LerInteiro();

            Console.WriteLine($"Quantas unidades do {i}° item foram pedidas?:\n");
            dados.QuantItens[i] = LerInteiro();
        }

        Console.WriteLine("Em quantas pessoas vai ser dividida a conta?:\n");
        dados.PessoasPDividir = LerInteiro();
        return dados;
    }

    public ItemMenu EditarItemInputs()
    {
        ItemMenu item = new ItemMenu();

        Console.WriteLine("Qual o novo preco do item?\n");
        item.Preco = LerDecimal();

        Console.WriteLine("O item esta disponivel?: (1 para SIM / 2 para NAO)\n");
        int opcao = LerInteiro();

        if (opcao == 1)
        {
            item.EstaDisponivel = true;
        }
        else if (opcao == 2)
        {
            item.EstaDisponivel = false;
        }
        else
        {
            Console.WriteLine(mensagemInvalida);
        }

        return item;
    }

    public DadosRelatorio RelatorioPedidosInputs()
    {
        DadosRelatorio dados = new DadosRelatorio();
        DateTime inicio = dados.inicio;
        DateTime fim = dados.fim;
        int opcao = 0;

        Console.WriteLine("Qual tipo de relatorio voce quer gerar?\n");
        while (opcao != 99)
        {
            Console.WriteLine("1- Relatorio por periodo:");
            Console.WriteLine("2- Relatorio por cliente:");
            Console.WriteLine("3- Relatorio por cliente em periodo:");
            Console.WriteLine("4- Relatorio por item no menu:\n");
            Console.WriteLine("99 para sair do menu:\n");
            opcao = LerInteiro();

            if (opcao == 1)
            {
                RecebePeriodo(ref inicio, ref fim);
                dados.inicio = inicio;
                dados.fim = fim;
                break;
            }

            if (opcao == 2)
            {
                dados.IDCliente = RecebeIDCliente();
                break;
            }

            if (opcao == 3)
            {
                RecebePeriodo(ref inicio, ref fim);
                dados.inicio = inicio;
                dados.fim = fim;
                dados.IDCliente = RecebeIDCliente();
                break;
            }

            if (opcao == 4)
            {
                dados.IDItem = RecebeIDItem();
                break;
            }
        }

        return dados;
    }

    private int RecebeIDItem()
    {
        Console.WriteLine("Digite o ID do item:");
        return LerInteiro();
    }

    private string RecebeIDCliente()
    {
        Console.WriteLine("Digite o ID do cliente:");
        string texto = Console.ReadLine();

        if (texto == null)
        {
            Console.WriteLine(mensagemInvalida);
            return "";
        }

        return texto;
    }

    private void RecebePeriodo(ref DateTime inicio, ref DateTime fim)
    {
        Console.WriteLine("Insira a data de inicio do periodo:");
        inicio = LerData();
        Console.WriteLine("Insira a data de fim do periodo:");
        fim = LerData();
    }

    private int LerInteiro()
    {
        while (true)
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine(mensagemInvalida);
            }
        }
    }

    private decimal LerDecimal()
    {
        while (true)
        {
            try
            {
                return decimal.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine(mensagemInvalida);
            }
        }
    }

    private DateTime LerData()
    {
        while (true)
        {
            try
            {
                return DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine(mensagemInvalida);
            }
        }
    }
}
