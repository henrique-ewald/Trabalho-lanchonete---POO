using System;

namespace Domain;

public interface IIdioma
{
    string NaoFoiPossivelAbrirJson { get; }
    string OpcaoInvalida { get; }

    string MenuPrincipal { get; }
    string SelecionarIdioma { get; }
    string IdiomaAlteradoComSucesso { get; }
    string MenuClienteSemCadastro { get; }
    string MenuCliente { get; }
    string MenuFuncionario { get; }
    string MenuAdministrador { get; }

    string CadastroClienteIntro { get; }
    string CadastroFuncionarioIntro { get; }
    string CadastroAdministradorIntro { get; }
    string CampoNome { get; }
    string CampoEmail { get; }
    string CampoCargo { get; }

    string SenhaPrompt { get; }
    string SenhaIncorreta { get; }
    string PromptNovaSenha { get; }
    string SenhaDiferenteAtual { get; }

    string CriandoPedidoIntro { get; }
    string QuantosItensPedido { get; }
    string EmQuantasPessoasVaiSerDivididaConta { get; }
    string NovoPrecoItem { get; }
    string ItemDisponivelPergunta { get; }
    string DigiteCodigoDoItem(int indice);
    string DigiteQuantidadeDoItem(int indice);
    string DigiteCodigoItem { get; }
    string NumeroPedido { get; }
    string DescricaoPT { get; }
    string DescricaoEN { get; }
    string DescricaoES { get; }
    string Preco { get; }

    string QualTipoRelatorio { get; }
    string RelatorioPorPeriodoOpcao { get; }
    string RelatorioPorClienteOpcao { get; }
    string RelatorioPorClienteEmPeriodoOpcao { get; }
    string RelatorioPorItemOpcao { get; }
    string SairMenuRelatorio { get; }
    string NomeOuEmailDoCliente { get; }
    string DataInicial { get; }
    string DataFinal { get; }
    string DigiteIdItem { get; }
    string DigiteIdCliente { get; }

    string ItemNaoEncontrado { get; }
    string ItemNaoEncontradoNoMenu { get; }
    string ItemAdicionadoComSucesso { get; }
    string ItemRemovidoComSucesso { get; }
    string ItemEditado(string descricao);
    string ItemCodigoAdicionado(int codigo);
    string ItemCodigoRemovido(int codigo);
    string ItemNaoEncontradoNoPedido(int codigo);

    string PedidoNaoEncontrado { get; }
    string PedidoNaoEncontradoOuEncerrado { get; }
    string PedidoJaEncerrado { get; }
    string PedidoCriado(int id, decimal total);
    string PedidoFoiPago(int id);
    string PedidoFoiEncerrado(int id);
    string ValorTotalPedido(decimal total);
    string ValorDividido(int pessoas, decimal valorPorPessoa);
    string FormatoData { get; }
    string FormatoDataHora { get; }

    string NenhumPedidoEncontradoNessePeriodo { get; }
    string NenhumPedidoEncontradoParaEsseCliente { get; }
    string NenhumPedidoEncontradoParaEsseClienteNessePeriodo { get; }
    string ItemNaoApareceuEmNenhumPedido { get; }
    string ConsumoDoItem(string item);
    string ResumoPedido(int id, string nomeCliente, DateTime criadoEm, Status status, decimal valorTotal, string itens);
    string ResumoPedidoPorItem(int id, string nomeCliente, DateTime criadoEm);

    string NomeDoItem(string descricaoBR, string descricaoEN, string descricaoES);
    string NomeDaCategoria(string nomeBR, string nomeEN);
    string Disponibilidade(bool estaDisponivel);
}
