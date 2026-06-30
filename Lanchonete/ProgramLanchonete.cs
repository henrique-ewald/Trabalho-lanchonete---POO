using System;
using System.Globalization;
using Domain;
using Lanchonete;
using Projeto.CardapioDeItens;
using Projeto.Pedidos;
using Projeto.Relatorios;
using System.Text.Json;

namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        SerializerDeObjetos serializerDeObjetos = new SerializerDeObjetos();

        Console.WriteLine("1. Portugues  |  2. English  |  3. Espanol");
        string escolhaIdioma = Console.ReadLine();
        GerenciadorDoIdioma gerenciadorIdioma = new GerenciadorDoIdioma(new IdiomaPortugues());
        IIdioma? idiomaEscolhido = gerenciadorIdioma.SelecionarIdiomaPeloNumero(escolhaIdioma);

        if (idiomaEscolhido != null)
        {
            gerenciadorIdioma.AplicarIdioma(idiomaEscolhido);
        }

        IIdioma idioma = gerenciadorIdioma.IdiomaAtual;

        DadosGerais MockOuArquivo;
        if (File.Exists("DadosSalvos.json"))
        {
            var json = File.ReadAllText("DadosSalvos.json");
            if (string.IsNullOrWhiteSpace(json))
            {
                MockDeDados mock = new MockDeDados();
                MockOuArquivo = mock.CriarCenarioCompleto(idioma);
            }
            else
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        IncludeFields = true,
                        WriteIndented = true
                    };

                    MockOuArquivo = JsonSerializer.Deserialize<DadosGerais>(json, options);
                    if (MockOuArquivo == null)
                    {
                        MockDeDados mock = new MockDeDados();
                        MockOuArquivo = mock.CriarCenarioCompleto(idioma);
                    }
                }
                catch (Exception e) when (e is JsonException || e is InvalidOperationException)
                {
                    MockDeDados mock = new MockDeDados();
                    MockOuArquivo = mock.CriarCenarioCompleto(idioma);
                    serializerDeObjetos.SerializerInicial(idioma);
                    Console.WriteLine(idioma.NaoFoiPossivelAbrirJson);
                }
            }
        }
        else
        {
            MockDeDados mock = new MockDeDados();
            MockOuArquivo = mock.CriarCenarioCompleto(idioma);
        }

        GerenciadorCardapio cardapio = MockOuArquivo.Cardapio;
        GerenciadorPedidos gerenciador = MockOuArquivo.Gerenciador;
        Administrador administrador = MockOuArquivo.Administrador;

        gerenciadorIdioma.VincularDados(MockOuArquivo);

        PedidoInput pedidoInput = gerenciadorIdioma.PedidoInput;
        UsuarioInput usuarioInput = gerenciadorIdioma.UsuarioInput;
        PrintaRelatorios PrinterRelatorio = gerenciadorIdioma.PrinterRelatorio;
        SerializadorDeRelatorio SerializadorDeRelatorio = gerenciadorIdioma.SerializadorRelatorio;


        bool rodando = true;
        while (rodando)
        {
            int opcao = usuarioInput.LerInteiro(idioma.MenuPrincipal);

            try
            {

                if (opcao == 0)
                {
                    rodando = false;
                }
                else if (opcao == 1)
                {
                    Cliente consumidor = null;
                    int entradaCliente = usuarioInput.LerInteiro(idioma.MenuClienteSemCadastro);
                    if (entradaCliente == 2)
                    {
                        consumidor = usuarioInput.CriarCliente();
                    }

                    bool menuCliente = true;
                    while (menuCliente)
                    {
                        int opcaoCliente = usuarioInput.LerInteiro(idioma.MenuCliente);

                        try
                        {

                            if (opcaoCliente == 0)
                            {
                                menuCliente = false;
                            }
                            else if (opcaoCliente == 1)
                            {
                                foreach (var item in cardapio.CardapioItens)
                                {
                                    if (item.EstaDisponivel)
                                    {
                                        string nome = idioma.NomeDoItem(item.DescricaoBR, item.DescricaoEN, item.DescricaoES);
                                        string cat = idioma.NomeDaCategoria(item.Categoria.NomeBR, item.Categoria.NomeEN);
                                        Console.WriteLine($"[{item.Codigo}] {nome} - R${item.Preco:F2} ({cat})");
                                    }
                                }
                            }
                            else if (opcaoCliente == 2)
                            {
                                DadosPedido dados = pedidoInput.PedidoInputs();
                                Pedido pedido = gerenciador.CriarPedido(consumidor, cardapio, dados.CodigosItens, dados.QuantItens, dados.PessoasPDividir);
                                MockOuArquivo.Gerenciador.CriarPedido(consumidor, cardapio, dados.CodigosItens, dados.QuantItens, dados.PessoasPDividir);
                                serializerDeObjetos.SerializarObjeto(MockOuArquivo);
                                Console.WriteLine(idioma.PedidoCriado(pedido.id, pedido.ValorTotal));
                            }
                            else if (opcaoCliente == 3)
                            {
                                int idPedido = usuarioInput.LerInteiro(idioma.NumeroPedido);
                                Pedido encontrado = null;
                                foreach (var p in gerenciador.TodosPedidos)
                                    if (p.id == idPedido) encontrado = p;

                                if (encontrado != null && encontrado.StatusAtual == Status.Aberto)
                                {
                                    DadosPedido dados = pedidoInput.PedidoInputs();
                                    gerenciador.AdicionarItemAoPedido(encontrado, cardapio, dados.CodigosItens, dados.QuantItens);
                                    MockOuArquivo.Gerenciador.AdicionarItemAoPedido(encontrado, cardapio, dados.CodigosItens, dados.QuantItens);
                                    serializerDeObjetos.SerializarObjeto(MockOuArquivo);
                                }
                                else
                                {
                                    Console.WriteLine(idioma.PedidoNaoEncontradoOuEncerrado);
                                }
                            }
                            else if (opcaoCliente == 4)
                            {
                                int idPedido = usuarioInput.LerInteiro(idioma.NumeroPedido);
                                Pedido encontrado = null;
                                foreach (var p in gerenciador.TodosPedidos)
                                    if (p.id == idPedido) encontrado = p;

                                if (encontrado != null)
                                {
                                    try
                                    {
                                        gerenciador.AtualizarStatusPedido(encontrado);
                                        MockOuArquivo.Gerenciador.AtualizarStatusPedido(encontrado);
                                        serializerDeObjetos.SerializarObjeto(MockOuArquivo);
                                    }
                                    catch (PedidoJaEncerradoException)
                                    {
                                        Console.WriteLine(idioma.PedidoJaEncerrado);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(idioma.PedidoNaoEncontrado);
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine(idioma.OpcaoInvalida);
                        }
                    }
                }
                else if (opcao == 2)
                {
                    Funcionario funcionario = new Funcionario { Nome = "Funcionario", Idioma = idioma };
                    string senhaFuncionario = usuarioInput.LerTexto(idioma.SenhaPrompt);
                    if (funcionario.ValidarSenha(senhaFuncionario))
                    {
                        bool menuFunc = true;
                        while (menuFunc)
                        {
                            int opcaoFunc = usuarioInput.LerInteiro(idioma.MenuFuncionario);

                            try
                            {

                                if (opcaoFunc == 0)
                                {
                                    menuFunc = false;
                                }
                                else if (opcaoFunc == 1)
                                {
                                    foreach (var item in cardapio.CardapioItens)
                                    {
                                        string nome = idioma.NomeDoItem(item.DescricaoBR, item.DescricaoEN, item.DescricaoES);
                                        string disp = idioma.Disponibilidade(item.EstaDisponivel);
                                        Console.WriteLine($"[{item.Codigo}] {nome} - R${item.Preco:F2} ({disp})");
                                    }
                                }
                                else if (opcaoFunc == 2)
                                {
                                    int cod = usuarioInput.LerInteiro(idioma.DigiteCodigoItem);
                                    string descBR = usuarioInput.LerTexto(idioma.DescricaoPT);
                                    string descEN = usuarioInput.LerTexto(idioma.DescricaoEN);
                                    string descES = usuarioInput.LerTexto(idioma.DescricaoES);
                                    decimal preco = usuarioInput.LerDecimal(idioma.Preco);
                                    ItemMenu novo = new ItemMenu { Codigo = cod, DescricaoBR = descBR, DescricaoEN = descEN, DescricaoES = descES, Preco = preco, EstaDisponivel = true, Categoria = cardapio.Entradas };
                                    funcionario.AdicionaItem(novo, MockOuArquivo);
                                }
                                else if (opcaoFunc == 3)
                                {
                                    int cod = usuarioInput.LerInteiro(idioma.DigiteCodigoItem);
                                    var item = cardapio.CardapioItens.FirstOrDefault(item => item.Codigo == cod);
                                    if (item != null)
                                    {
                                        funcionario.EditarItem(item, MockOuArquivo);
                                    }
                                    else
                                    {
                                        Console.WriteLine(idioma.ItemNaoEncontrado);
                                    }
                                }
                                else if (opcaoFunc == 4)
                                {
                                    int cod = usuarioInput.LerInteiro(idioma.DigiteCodigoItem);
                                    var item = cardapio.CardapioItens.FirstOrDefault(item => item.Codigo == cod);
                                    if (item != null)
                                    {
                                        funcionario.RemoverItem(item, MockOuArquivo);
                                    }
                                    else
                                    {
                                        Console.WriteLine(idioma.ItemNaoEncontrado);
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine(idioma.OpcaoInvalida);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(idioma.SenhaIncorreta);
                    }
                }
                else if (opcao == 3)
                {
                    string senhaAdmin = usuarioInput.LerTexto(idioma.SenhaPrompt);
                    if (administrador.ValidarSenha(senhaAdmin))
                    {
                        bool menuAdm = true;
                        while (menuAdm)
                        {
                            int opcaoAdm = usuarioInput.LerInteiro(idioma.MenuAdministrador);

                            try
                            {

                                if (opcaoAdm == 0)
                                {
                                    menuAdm = false;
                                }
                                else if (opcaoAdm == 1)
                                {
                                    foreach (var p in gerenciador.TodosPedidos)
                                    {
                                        string nomeCliente = p.Consumidor != null ? p.Consumidor.Nome : "Anonimo";
                                        Console.WriteLine($"#{p.id} | {nomeCliente} | {p.CriadoEm.ToString(idioma.FormatoDataHora)} | {p.StatusAtual} | R${p.ValorTotal:F2}");
                                    }
                                }
                                else if (opcaoAdm == 2)
                                {
                                    DateTime inicio = usuarioInput.LerData(idioma.DataInicial);
                                    DateTime fim = usuarioInput.LerData(idioma.DataFinal);
                                    SerializadorDeRelatorio.RelatorioPorPeriodo(inicio, fim);
                                    PrinterRelatorio.RelatorioPorPeriodo(inicio, fim);
                                }
                                else if (opcaoAdm == 3)
                                {
                                    SerializadorDeRelatorio.RelatorioPorCliente();
                                    PrinterRelatorio.RelatorioPorCliente();
                                }
                                else if (opcaoAdm == 4)
                                {
                                    SerializadorDeRelatorio.RelatorioPorClienteEmPeriodo();
                                    PrinterRelatorio.RelatorioPorClienteEmPeriodo();
                                }
                                else if (opcaoAdm == 5)
                                {
                                    SerializadorDeRelatorio.RelatorioDeItemDoMenu(cardapio);
                                    PrinterRelatorio.RelatorioDeItemDoMenu(cardapio);
                                }
                            }
                            catch
                            {
                                Console.WriteLine(idioma.OpcaoInvalida);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(idioma.SenhaIncorreta);
                    }
                }
                else if (opcao == 4)
                {
                    gerenciadorIdioma.AlterarIdiomaEmExecucao();
                    idioma = gerenciadorIdioma.IdiomaAtual;
                    pedidoInput = gerenciadorIdioma.PedidoInput;
                    usuarioInput = gerenciadorIdioma.UsuarioInput;
                    PrinterRelatorio = gerenciadorIdioma.PrinterRelatorio;
                    SerializadorDeRelatorio = gerenciadorIdioma.SerializadorRelatorio;
                }
            }
            catch
            {
                Console.WriteLine(idioma.OpcaoInvalida);
            }
        }
    }
}
