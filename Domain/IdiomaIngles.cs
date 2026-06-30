using System;

namespace Domain;

public class IdiomaIngles : IIdioma
{
    public string NaoFoiPossivelAbrirJson => "could not open the .json, running the program with the default mock.";
    public string OpcaoInvalida => "Please enter a valid option.";

    public string MenuPrincipal => "\n1. Customer\n2. Employee\n3. Administrator\n4. Change language\n0. Exit";
    public string SelecionarIdioma => "1. Português  |  2. English  |  3. Español";
    public string IdiomaAlteradoComSucesso => "Language changed successfully.";
    public string MenuClienteSemCadastro => "1. Continue without registration\n2. Enter my details";
    public string MenuCliente => "\n1. View menu\n2. Place order\n3. Add item to order\n4. Pay order\n0. Back";
    public string MenuFuncionario => "\n1. View menu\n2. Add item\n3. Edit item\n4. Remove item\n0. Back";
    public string MenuAdministrador => "\n1. View orders\n2. Report by period\n3. Report by customer\n4. Report by customer in period\n5. Report by item\n0. Back";

    public string CadastroClienteIntro => "Customer registration. Fill in the information:\n";
    public string CadastroFuncionarioIntro => "Employee registration. Fill in the information:\n";
    public string CadastroAdministradorIntro => "Administrator registration. Fill in the information:\n";
    public string CampoNome => "Name:";
    public string CampoEmail => "Email:";
    public string CampoCargo => "Role:";

    public string SenhaPrompt => "Password:";
    public string SenhaIncorreta => "Incorrect password.";
    public string PromptNovaSenha => "Type your new password:\n";
    public string SenhaDiferenteAtual => "Enter a password different from the current one.\n";

    public string CriandoPedidoIntro => "Creating order! Fill in the information:\n";
    public string QuantosItensPedido => "How many items were ordered?\n";
    public string EmQuantasPessoasVaiSerDivididaConta => "How many people will split the bill?:\n";
    public string NovoPrecoItem => "What is the new item price?\n";
    public string ItemDisponivelPergunta => "Is the item available?: (1 for YES / 2 for NO)\n";
    public string DigiteCodigoDoItem(int indice) => $"Enter the code for item {indice}:\n";
    public string DigiteQuantidadeDoItem(int indice) => $"How many units of item {indice} were ordered?:\n";
    public string DigiteCodigoItem => "Item code:";
    public string NumeroPedido => "Order number:";
    public string DescricaoPT => "PT description:";
    public string DescricaoEN => "EN description:";
    public string DescricaoES => "ES description:";
    public string Preco => "Price:";

    public string QualTipoRelatorio => "What kind of report do you want to generate?\n";
    public string RelatorioPorPeriodoOpcao => "1- Report by period:";
    public string RelatorioPorClienteOpcao => "2- Report by customer:";
    public string RelatorioPorClienteEmPeriodoOpcao => "3- Report by customer in period:";
    public string RelatorioPorItemOpcao => "4- Report by menu item:\n";
    public string SairMenuRelatorio => "99 to exit the menu:\n";
    public string NomeOuEmailDoCliente => "Customer name or email:";
    public string DataInicial => $"Start date ({FormatoData}):";
    public string DataFinal => $"End date ({FormatoData}):";
    public string DigiteIdItem => "Enter the item ID:";
    public string DigiteIdCliente => "Enter the customer ID:";

    public string ItemNaoEncontrado => "Item not found.";
    public string ItemNaoEncontradoNoMenu => "Item not found.";
    public string ItemAdicionadoComSucesso => "Item added successfully!\n";
    public string ItemRemovidoComSucesso => "Item removed successfully!\n";
    public string ItemEditado(string descricao) => $"Item '{descricao}' edited\n";
    public string ItemCodigoAdicionado(int codigo) => $"Item code {codigo} added!.";
    public string ItemCodigoRemovido(int codigo) => $"Item code {codigo} removed.";
    public string ItemNaoEncontradoNoPedido(int codigo) => $"Item code {codigo} not found.";

    public string PedidoNaoEncontrado => "Order not found.";
    public string PedidoNaoEncontradoOuEncerrado => "Order not found or already closed.";
    public string PedidoJaEncerrado => "The order is already closed; it is not possible to change its status.\n";
    public string PedidoCriado(int id, decimal total) => $"Order #{id} created! Total: R${total:F2}";
    public string PedidoFoiPago(int id) => $"Order {id} was paid!\n";
    public string PedidoFoiEncerrado(int id) => $"Order {id} was closed!\n";
    public string ValorTotalPedido(decimal total) => $"The total order value is:{total}\n";
    public string ValorDividido(int pessoas, decimal valorPorPessoa) => $"The amount split between {pessoas} people is:{valorPorPessoa} each\n";
    public string FormatoData => "MM/dd/yyyy";
    public string FormatoDataHora => "MM/dd/yyyy HH:mm";

    public string NenhumPedidoEncontradoNessePeriodo => "No orders found in this period.";
    public string NenhumPedidoEncontradoParaEsseCliente => "No orders found for this customer.";
    public string NenhumPedidoEncontradoParaEsseClienteNessePeriodo => "No orders found for this customer in this period.";
    public string ItemNaoApareceuEmNenhumPedido => "This item has not appeared in any order yet.";
    public string ConsumoDoItem(string item) => $"\nItem consumption: {item}";
    public string ResumoPedido(int id, string nomeCliente, DateTime criadoEm, Status status, decimal valorTotal, string itens)
        => $"#{id} | {nomeCliente} | {criadoEm.ToString(FormatoDataHora)} | {status} | R${valorTotal:F2}\nOrdered items: {itens}";
    public string ResumoPedidoPorItem(int id, string nomeCliente, DateTime criadoEm)
        => $"Order #{id} | {nomeCliente} | {criadoEm.ToString(FormatoDataHora)}";

    public string NomeDoItem(string descricaoBR, string descricaoEN, string descricaoES) => descricaoEN;
    public string NomeDaCategoria(string nomeBR, string nomeEN) => nomeEN;
    public string Disponibilidade(bool estaDisponivel) => estaDisponivel ? "Available" : "Unavailable";
}
