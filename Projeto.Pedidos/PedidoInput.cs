using System;
using System.Globalization;
using Domain;

namespace Projeto.Pedidos;

public class PedidoInput
{
    public IIdioma Idioma { get; set; }

    public PedidoInput(IIdioma idioma)
    {
        Idioma = idioma ?? new IdiomaPortugues();
    }

    public DadosPedido PedidoInputs()
    {
        DadosPedido dados = new DadosPedido();
        Console.WriteLine(Idioma.CriandoPedidoIntro);
        Console.WriteLine(Idioma.QuantosItensPedido);
        dados.Quant = LerInteiro();

        dados.CodigosItens = new int[dados.Quant];
        dados.QuantItens = new int[dados.Quant];

        for (int i = 0; i < dados.Quant; i++)
        {
            Console.WriteLine(Idioma.DigiteCodigoDoItem(i));
            dados.CodigosItens[i] = LerInteiro();

            Console.WriteLine(Idioma.DigiteQuantidadeDoItem(i));
            dados.QuantItens[i] = LerInteiro();
        }

        Console.WriteLine(Idioma.EmQuantasPessoasVaiSerDivididaConta);
        dados.PessoasPDividir = LerInteiro();
        return dados;
    }

    public ItemMenu EditarItemInputs()
    {
        ItemMenu item = new ItemMenu();

        Console.WriteLine(Idioma.NovoPrecoItem);
        item.Preco = LerDecimal();

        Console.WriteLine(Idioma.ItemDisponivelPergunta);
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
            Console.WriteLine(Idioma.OpcaoInvalida);
        }

        return item;
    }

    public DadosRelatorio RelatorioPedidosInputs()
    {
        DadosRelatorio dados = new DadosRelatorio();
        DateTime inicio = dados.inicio;
        DateTime fim = dados.fim;
        int opcao = 0;

        Console.WriteLine(Idioma.QualTipoRelatorio);
        while (opcao != 99)
        {
            Console.WriteLine(Idioma.RelatorioPorPeriodoOpcao);
            Console.WriteLine(Idioma.RelatorioPorClienteOpcao);
            Console.WriteLine(Idioma.RelatorioPorClienteEmPeriodoOpcao);
            Console.WriteLine(Idioma.RelatorioPorItemOpcao);
            Console.WriteLine(Idioma.SairMenuRelatorio);
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
        Console.WriteLine(Idioma.DigiteIdItem);
        return LerInteiro();
    }

    private string RecebeIDCliente()
    {
        Console.WriteLine(Idioma.DigiteIdCliente);
        string texto = Console.ReadLine();

        if (texto == null)
        {
            Console.WriteLine(Idioma.OpcaoInvalida);
            return "";
        }

        return texto;
    }

    private void RecebePeriodo(ref DateTime inicio, ref DateTime fim)
    {
        Console.WriteLine(Idioma.DataInicial);
        inicio = LerData();
        Console.WriteLine(Idioma.DataFinal);
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
                Console.WriteLine(Idioma.OpcaoInvalida);
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
                Console.WriteLine(Idioma.OpcaoInvalida);
            }
        }
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
}
