using System;
using Domain;
using Lanchonete;
using Projeto.Pedidos;
using Projeto.Relatorios;
using Projeto.CardapioDeItens;
using System.Text.Json;
using System.Runtime.InteropServices;


namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        DadosGerais MockOuArquivo;
        SerializerDeObjetos serializerDeObjetos = new SerializerDeObjetos();

        if (File.Exists("DadosSalvos.json")) 
        {
            var json = File.ReadAllText("DadosSalvos.json");
            if (string.IsNullOrWhiteSpace(json))
            {
                MockDeDados mock = new MockDeDados();
                MockOuArquivo = mock.CriarCenarioCompleto();
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
                        MockOuArquivo = mock.CriarCenarioCompleto();
                    }
                }
                catch (Exception e) when (e is JsonException || e is InvalidOperationException)
                {
                    MockDeDados mock = new MockDeDados();
                    MockOuArquivo = mock.CriarCenarioCompleto();
                    serializerDeObjetos.SerializerInicial();
                    Console.WriteLine("não foi possivel abrir o .json, executando programa com mock padrão.");
                }
            }
        }
        else
        {
            MockDeDados mock = new MockDeDados();
            MockOuArquivo = mock.CriarCenarioCompleto(); 
        }
        string opcaoInvalida = "Informe uma opcao valida.";

        GerenciadorCardapio cardapio = MockOuArquivo.Cardapio;
        GerenciadorPedidos gerenciador = MockOuArquivo.Gerenciador;
        
        PrintaRelatorios PrinterRelatorio = new PrintaRelatorios(gerenciador);
        SerializadorDeRelatorio SerializadorDeRelatorio = new SerializadorDeRelatorio(gerenciador);

        PedidoInput pedidoInput = new PedidoInput();
        UsuarioInput usuarioInput = new UsuarioInput();

        Console.WriteLine("1. Português  |  2. English");
        Idioma idioma = Idioma.Portugues;
        string escolhaIdioma = Console.ReadLine();
        try { if (escolhaIdioma != null && int.Parse(escolhaIdioma) == 2) idioma = Idioma.Ingles; }
        catch { Console.WriteLine(opcaoInvalida); idioma = Idioma.Portugues; }

        bool rodando = true;
        while (rodando)
        {
            Console.WriteLine(idioma == Idioma.Portugues ? "\n1. Cliente\n2. Funcionário\n3. Administrador\n0. Sair" : "\n1. Customer\n2. Employee\n3. Administrator\n0. Exit");
            string entradaPrincipal = Console.ReadLine();
            if (entradaPrincipal == null)
            {
                break;
            }

            try
            {
                int opcao = int.Parse(entradaPrincipal);

                if (opcao == 0)
                {
                    rodando = false;
                }
                else if (opcao == 1)
                {
                    Console.WriteLine(idioma == Idioma.Portugues ? "1. Continuar sem cadastro\n2. Informar meus dados"
                                                                 : "1. Continue without registration\n2. Enter my details");
                    Cliente consumidor = null;
                    string entradaCliente = Console.ReadLine();
                    if (entradaCliente == null)
                    {
                        rodando = false;
                        break;
                    }

                    try
                    {
                        if (int.Parse(entradaCliente) == 2)
                            consumidor = usuarioInput.CriarCliente();
                    }
                    catch
                    {
                        Console.WriteLine(opcaoInvalida);
                        continue;
                    }

                    bool menuCliente = true;
                    while (menuCliente)
                    {
                        Console.WriteLine(idioma == Idioma.Portugues
                            ? "\n1. Ver cardápio\n2. Fazer pedido\n3. Adicionar item ao pedido\n4. Pagar pedido\n0. Voltar"
                            : "\n1. View menu\n2. Place order\n3. Add item to order\n4. Pay order\n0. Back");
                        string entradaClienteMenu = Console.ReadLine();
                        if (entradaClienteMenu == null)
                        {
                            menuCliente = false;
                            rodando = false;
                            break;
                        }

                        try
                        {
                            int opcaoCliente = int.Parse(entradaClienteMenu);

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
                                        string nome = idioma == Idioma.Portugues ? item.DescricaoBR : item.DescricaoEN;
                                        string cat = idioma == Idioma.Portugues ? item.Categoria.NomeBR : item.Categoria.NomeEN;
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
                                Console.WriteLine($"Pedido #{pedido.id} criado! Total: R${pedido.ValorTotal:F2}");
                            }
                            else if (opcaoCliente == 3)
                            {
                                Console.WriteLine(idioma == Idioma.Portugues ? "Número do pedido:" : "Order number:");
                                int idPedido = int.Parse(Console.ReadLine());
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
                                    Console.WriteLine(idioma == Idioma.Portugues ? "Pedido não encontrado ou já encerrado." : "Order not found or already closed.");
                            }
                            else if (opcaoCliente == 4)
                            {
                                Console.WriteLine(idioma == Idioma.Portugues ? "Número do pedido:" : "Order number:");
                                int idPedido = int.Parse(Console.ReadLine());
                                Pedido encontrado = null;
                                foreach (var p in gerenciador.TodosPedidos)
                                    if (p.id == idPedido) encontrado = p;

                                if (encontrado != null)
                                {
                                    gerenciador.AtualizarStatusPedido(encontrado);
                                    MockOuArquivo.Gerenciador.AtualizarStatusPedido(encontrado);
                                    serializerDeObjetos.SerializarObjeto(MockOuArquivo);
                                }
                                else
                                    Console.WriteLine(idioma == Idioma.Portugues ? "Pedido não encontrado." : "Order not found.");
                            }
                        }
                        catch { Console.WriteLine(opcaoInvalida); }
                    }
                }
                else if (opcao == 2)
                {
                    Console.WriteLine(idioma == Idioma.Portugues ? "Senha:" : "Password:");
                    Funcionario funcionario = new Funcionario() { Nome = "Funcionário" };
                    string senhaFuncionario = Console.ReadLine();
                    if (funcionario.ValidarSenha(senhaFuncionario))
                    {
                        bool menuFunc = true;
                        while (menuFunc)
                        {
                            Console.WriteLine(idioma == Idioma.Portugues
                                ? "\n1. Ver cardápio\n2. Adicionar item\n3. Editar item\n4. Remover item\n0. Voltar"
                                : "\n1. View menu\n2. Add item\n3. Edit item\n4. Remove item\n0. Back");
                            string entradaFuncionarioMenu = Console.ReadLine();
                            if (entradaFuncionarioMenu == null)
                            {
                                menuFunc = false;
                                rodando = false;
                                break;
                            }

                            try
                            {
                                int opcaoFunc = int.Parse(entradaFuncionarioMenu);

                                if (opcaoFunc == 0)
                                {
                                    menuFunc = false;
                                }
                                else if (opcaoFunc == 1)
                                {
                                    foreach (var item in cardapio.CardapioItens)
                                    {
                                        string nome = idioma == Idioma.Portugues ? item.DescricaoBR : item.DescricaoEN;
                                        string disp = item.EstaDisponivel ? "Disponivel" : "Indisponivel";
                                        Console.WriteLine($"[{item.Codigo}] {nome} - R${item.Preco:F2} ({disp})");
                                    }
                                }
                                else if (opcaoFunc == 2)
                                {
                                    Console.WriteLine("Código:"); int cod = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Descrição PT:"); string descBR = Console.ReadLine();
                                    Console.WriteLine("Description EN:"); string descEN = Console.ReadLine();
                                    Console.WriteLine("Preço:"); decimal preco = decimal.Parse(Console.ReadLine());
                                    ItemMenu novo = new ItemMenu { Codigo = cod, DescricaoBR = descBR, DescricaoEN = descEN, Preco = preco, EstaDisponivel = true, Categoria = cardapio.Entradas };
                                    funcionario.AdicionaItem(novo, MockOuArquivo);
                                }
                                else if (opcaoFunc == 3)
                                {
                                    Console.WriteLine("Código do item:"); int cod = int.Parse(Console.ReadLine());
                                    var item = cardapio.CardapioItens.FirstOrDefault(item => item.Codigo == cod);
                                    if (item != null)
                                        funcionario.EditarItem(item, MockOuArquivo);
                                    else
                                        Console.WriteLine("Item não encontrado.");
                                }
                                else if (opcaoFunc == 4)
                                {
                                    Console.WriteLine("Código do item:"); int cod = int.Parse(Console.ReadLine());
                                    var item = cardapio.CardapioItens.FirstOrDefault(item => item.Codigo == cod);
                                    if (item != null)
                                        funcionario.RemoverItem(item, MockOuArquivo);
                                    else
                                        Console.WriteLine("Item não encontrado.");
                                }
                            }
                            catch { Console.WriteLine(opcaoInvalida); }
                        }
                    }
                    else
                        Console.WriteLine(idioma == Idioma.Portugues ? "Senha incorreta." : "Incorrect password.");
                }
                else if (opcao == 3)
                {
                    Console.WriteLine(idioma == Idioma.Portugues ? "Senha:" : "Password:");
                    string senhaAdmin = Console.ReadLine();
                    if (new Administrador().ValidarSenha(senhaAdmin))
                    {
                        bool menuAdm = true;
                        while (menuAdm)
                        {
                            Console.WriteLine(idioma == Idioma.Portugues
                                ? "\n1. Ver pedidos\n2. Relatório por período\n3. Relatório por cliente\n4. Relatório por cliente em período\n5. Relatório por item\n0. Voltar"
                                : "\n1. View orders\n2. Report by period\n3. Report by customer\n4. Report by customer in period\n5. Report by item\n0. Back");
                            string entradaAdminMenu = Console.ReadLine();
                            if (entradaAdminMenu == null)
                            {
                                menuAdm = false;
                                rodando = false;
                                break;
                            }

                            try
                            {
                                int opcaoAdm = int.Parse(entradaAdminMenu);

                                if (opcaoAdm == 0)
                                {
                                    menuAdm = false;
                                }
                                else if (opcaoAdm == 1)
                                {
                                    foreach (var p in gerenciador.TodosPedidos)
                                    {
                                        string nomeCliente = p.Consumidor != null ? p.Consumidor.Nome : "Anonimo";
                                        Console.WriteLine($"#{p.id} | {nomeCliente} | {p.CriadoEm:dd/MM/yyyy HH:mm} | {p.StatusAtual} | R${p.ValorTotal:F2}");
                                    }
                                }
                                else if (opcaoAdm == 2)
                                {
                                    Console.WriteLine("Data inicial (dd/MM/yyyy):");
                                    DateTime inicio = DateTime.Parse(Console.ReadLine());
                                    Console.WriteLine("Data final (dd/MM/yyyy):");
                                    DateTime fim = DateTime.Parse(Console.ReadLine());
                                    SerializadorDeRelatorio.RelatorioPorPeriodo(idioma, inicio, fim);
                                    PrinterRelatorio.RelatorioPorPeriodo(idioma, inicio, fim);   
                                }
                                else if (opcaoAdm == 3)
                                {
                                    SerializadorDeRelatorio.RelatorioPorCliente(idioma);
                                    PrinterRelatorio.RelatorioPorCliente(idioma);
                                }
                                else if (opcaoAdm == 4)
                                {
                                    SerializadorDeRelatorio.RelatorioPorClienteEmPeriodo(idioma);
                                    PrinterRelatorio.RelatorioPorClienteEmPeriodo(idioma);
                                    
                                }
                                else if (opcaoAdm == 5)
                                {
                                    SerializadorDeRelatorio.RelatorioDeItemDoMenu(idioma, cardapio);
                                    PrinterRelatorio.RelatorioDeItemDoMenu(idioma, cardapio);                                    
                                }
                            }
                            catch { Console.WriteLine(opcaoInvalida); }
                        }
                    }
                    else
                        Console.WriteLine(idioma == Idioma.Portugues ? "Senha incorreta." : "Incorrect password.");
                }
            }
            catch { Console.WriteLine(opcaoInvalida); }
        }
    }
}
