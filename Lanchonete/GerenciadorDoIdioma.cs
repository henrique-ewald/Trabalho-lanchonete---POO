using System;
using Domain;
using Projeto.CardapioDeItens;
using Projeto.Pedidos;
using Projeto.Relatorios;

namespace Lanchonete;

public class GerenciadorDoIdioma
{
    private DadosGerais? dados;

    public IIdioma IdiomaAtual { get; private set; }
    public PedidoInput PedidoInput { get; private set; }
    public UsuarioInput UsuarioInput { get; private set; }
    public PrintaRelatorios PrinterRelatorio { get; private set; }
    public SerializadorDeRelatorio SerializadorRelatorio { get; private set; }

    public GerenciadorDoIdioma(IIdioma idiomaInicial)
    {
        IdiomaAtual = idiomaInicial ?? new IdiomaPortugues();
        PedidoInput = new PedidoInput(IdiomaAtual);
        UsuarioInput = new UsuarioInput(IdiomaAtual);
    }

    public void VincularDados(DadosGerais dados)
    {
        this.dados = dados;
        PrinterRelatorio = dados.PrinterRelatorio ?? new PrintaRelatorios(dados.Gerenciador, IdiomaAtual);
        SerializadorRelatorio = dados.SerializadorRelatorio ?? new SerializadorDeRelatorio(dados.Gerenciador, IdiomaAtual);
        AplicarIdioma(IdiomaAtual);
    }

    public IIdioma? SelecionarIdiomaPeloNumero(string? valor)
    {
        return valor switch
        {
            "2" => new IdiomaIngles(),
            "3" => new IdiomaEspanhol(),
            "1" => new IdiomaPortugues(),
            _ => null,
        };
    }

    public void AplicarIdioma(IIdioma novoIdioma)
    {
        IdiomaAtual = novoIdioma ?? new IdiomaPortugues();

        if (dados == null)
        {
            PedidoInput = new PedidoInput(IdiomaAtual);
            UsuarioInput = new UsuarioInput(IdiomaAtual);
            return;
        }

        if (dados.Cardapio != null)
        {
            dados.Cardapio.Idioma = IdiomaAtual;
        }

        if (dados.Gerenciador != null)
        {
            dados.Gerenciador.Idioma = IdiomaAtual;
        }

        if (dados.Administrador != null)
        {
            dados.Administrador.Idioma = IdiomaAtual;
        }

        PedidoInput = new PedidoInput(IdiomaAtual);
        UsuarioInput = new UsuarioInput(IdiomaAtual);

        PrinterRelatorio.Idioma = IdiomaAtual;
        SerializadorRelatorio.Idioma = IdiomaAtual;

        dados.PrinterRelatorio = PrinterRelatorio;
        dados.SerializadorRelatorio = SerializadorRelatorio;
    }

    public void AlterarIdiomaEmExecucao()
    {
        Console.WriteLine(IdiomaAtual.SelecionarIdioma);
        string entradaIdioma = Console.ReadLine();
        IIdioma? novoIdioma = SelecionarIdiomaPeloNumero(entradaIdioma);

        if (novoIdioma == null)
        {
            Console.WriteLine(IdiomaAtual.OpcaoInvalida);
            return;
        }

        AplicarIdioma(novoIdioma);
        Console.WriteLine(IdiomaAtual.IdiomaAlteradoComSucesso);
    }
}
