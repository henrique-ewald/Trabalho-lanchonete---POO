using System;

namespace Domain;

public class IdiomaPortugues : IIdioma
{
    public string NaoFoiPossivelAbrirJson => "nao foi possivel abrir o .json, executando programa com mock padrao.";
    public string OpcaoInvalida => "Informe uma opcao valida.";

    public string MenuPrincipal => "\n1. Cliente\n2. Funcionário\n3. Administrador\n4. Alterar idioma\n0. Sair";
    public string SelecionarIdioma => "1. Português  |  2. English  |  3. Español";
    public string IdiomaAlteradoComSucesso => "Idioma alterado com sucesso.";
    public string MenuClienteSemCadastro => "1. Continuar sem cadastro\n2. Informar meus dados";
    public string MenuCliente => "\n1. Ver cardápio\n2. Fazer pedido\n3. Adicionar item ao pedido\n4. Pagar pedido\n0. Voltar";
    public string MenuFuncionario => "\n1. Ver cardápio\n2. Adicionar item\n3. Editar item\n4. Remover item\n0. Voltar";
    public string MenuAdministrador => "\n1. Ver pedidos\n2. Relatório por período\n3. Relatório por cliente\n4. Relatório por cliente em período\n5. Relatório por item\n0. Voltar";

    public string CadastroClienteIntro => "Cadastro de cliente. Preencha as informacoes:\n";
    public string CadastroFuncionarioIntro => "Cadastro de funcionario. Preencha as informacoes:\n";
    public string CadastroAdministradorIntro => "Cadastro de administrador. Preencha as informacoes:\n";
    public string CampoNome => "Nome:";
    public string CampoEmail => "Email:";
    public string CampoCargo => "Cargo:";

    public string SenhaPrompt => "Senha:";
    public string SenhaIncorreta => "Senha incorreta.";
    public string PromptNovaSenha => "Digite a sua nova senha:\n";
    public string SenhaDiferenteAtual => "Digite uma senha diferente da atual.\n";

    public string CriandoPedidoIntro => "Criando pedido! Preencha as informacoes:\n";
    public string QuantosItensPedido => "Quantos itens foram pedidos?\n";
    public string EmQuantasPessoasVaiSerDivididaConta => "Em quantas pessoas vai ser dividida a conta?:\n";
    public string NovoPrecoItem => "Qual o novo preco do item?\n";
    public string ItemDisponivelPergunta => "O item esta disponivel?: (1 para SIM / 2 para NAO)\n";
    public string DigiteCodigoDoItem(int indice) => $"Digite o codigo do {indice}° item:\n";
    public string DigiteQuantidadeDoItem(int indice) => $"Quantas unidades do {indice}° item foram pedidas?:\n";
    public string DigiteCodigoItem => "Código do item:";
    public string NumeroPedido => "Número do pedido:";
    public string DescricaoPT => "Descrição PT:";
    public string DescricaoEN => "Description EN:";
    public string DescricaoES => "Descrição ES:";
    public string Preco => "Preço:";

    public string QualTipoRelatorio => "Qual tipo de relatorio voce quer gerar?\n";
    public string RelatorioPorPeriodoOpcao => "1- Relatorio por periodo:";
    public string RelatorioPorClienteOpcao => "2- Relatorio por cliente:";
    public string RelatorioPorClienteEmPeriodoOpcao => "3- Relatorio por cliente em periodo:";
    public string RelatorioPorItemOpcao => "4- Relatorio por item no menu:\n";
    public string SairMenuRelatorio => "99 para sair do menu:\n";
    public string NomeOuEmailDoCliente => "Nome ou email do cliente:";
    public string DataInicial => $"Data inicial ({FormatoData}):";
    public string DataFinal => $"Data final ({FormatoData}):";
    public string DigiteIdItem => "Digite o ID do item:";
    public string DigiteIdCliente => "Digite o ID do cliente:";

    public string ItemNaoEncontrado => "Item nao encontrado.";
    public string ItemNaoEncontradoNoMenu => "Item nao encontrado.";
    public string ItemAdicionadoComSucesso => "Item adicionado com sucesso!\n";
    public string ItemRemovidoComSucesso => "Item removido com sucesso!\n";
    public string ItemEditado(string descricao) => $"Item '{descricao}' editado\n";
    public string ItemCodigoAdicionado(int codigo) => $"Item de código {codigo} Adicionado!.";
    public string ItemCodigoRemovido(int codigo) => $"Item de código {codigo} removido.";
    public string ItemNaoEncontradoNoPedido(int codigo) => $"Item de código {codigo} não encontrado.";

    public string PedidoNaoEncontrado => "Pedido não encontrado.";
    public string PedidoNaoEncontradoOuEncerrado => "Pedido não encontrado ou já encerrado.";
    public string PedidoJaEncerrado => "O pedido já esta encerrado, não é possivel alterar o status do pedido.\n";
    public string PedidoCriado(int id, decimal total) => $"Pedido #{id} criado! Total: R${total:F2}";
    public string PedidoFoiPago(int id) => $"O pedido {id} foi pago!\n";
    public string PedidoFoiEncerrado(int id) => $"O pedido {id} foi encerrado!\n";
    public string ValorTotalPedido(decimal total) => $"O valor total do pedido eh:{total}\n";
    public string ValorDividido(int pessoas, decimal valorPorPessoa) => $"O valor dividido entre {pessoas} pessoas ficou:{valorPorPessoa} para cada\n";
    public string FormatoData => "dd/MM/yyyy";
    public string FormatoDataHora => "dd/MM/yyyy HH:mm";

    public string NenhumPedidoEncontradoNessePeriodo => "Nenhum pedido encontrado nesse periodo.";
    public string NenhumPedidoEncontradoParaEsseCliente => "Nenhum pedido encontrado para esse cliente.";
    public string NenhumPedidoEncontradoParaEsseClienteNessePeriodo => "Nenhum pedido encontrado para esse cliente nesse periodo.";
    public string ItemNaoApareceuEmNenhumPedido => "Esse item ainda nao apareceu em nenhum pedido.";
    public string ConsumoDoItem(string item) => $"\nConsumo do item: {item}";
    public string ResumoPedido(int id, string nomeCliente, DateTime criadoEm, Status status, decimal valorTotal, string itens)
        => $"#{id} | {nomeCliente} | {criadoEm.ToString(FormatoDataHora)} | {status} | R${valorTotal:F2}\nItens pedidos: {itens}";
    public string ResumoPedidoPorItem(int id, string nomeCliente, DateTime criadoEm)
        => $"Pedido #{id} | {nomeCliente} | {criadoEm.ToString(FormatoDataHora)}";

    public string NomeDoItem(string descricaoBR, string descricaoEN, string descricaoES) => descricaoBR;
    public string NomeDaCategoria(string nomeBR, string nomeEN) => nomeBR;
    public string Disponibilidade(bool estaDisponivel) => estaDisponivel ? "Disponivel" : "Indisponivel";
}
