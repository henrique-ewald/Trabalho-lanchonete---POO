using System;

namespace Domain;

public class IdiomaEspanhol : IIdioma
{
    public string NaoFoiPossivelAbrirJson => "no se pudo abrir el .json, ejecutando el programa con el mock predeterminado.";
    public string OpcaoInvalida => "Ingrese una opcion valida.";

    public string MenuPrincipal => "\n1. Cliente\n2. Empleado\n3. Administrador\n4. Cambiar idioma\n0. Salir";
    public string SelecionarIdioma => "1. Portugués  |  2. Inglés  |  3. Español";
    public string IdiomaAlteradoComSucesso => "Idioma cambiado con exito.";
    public string MenuClienteSemCadastro => "1. Continuar sin registro\n2. Ingresar mis datos";
    public string MenuCliente => "\n1. Ver menu\n2. Hacer pedido\n3. Agregar item al pedido\n4. Pagar pedido\n0. Volver";
    public string MenuFuncionario => "\n1. Ver menu\n2. Agregar item\n3. Editar item\n4. Eliminar item\n0. Volver";
    public string MenuAdministrador => "\n1. Ver pedidos\n2. Reporte por periodo\n3. Reporte por cliente\n4. Reporte por cliente en periodo\n5. Reporte por item\n0. Volver";

    public string CadastroClienteIntro => "Registro de cliente. Complete la informacion:\n";
    public string CadastroFuncionarioIntro => "Registro de empleado. Complete la informacion:\n";
    public string CadastroAdministradorIntro => "Registro de administrador. Complete la informacion:\n";
    public string CampoNome => "Nombre:";
    public string CampoEmail => "Email:";
    public string CampoCargo => "Cargo:";

    public string SenhaPrompt => "Contrasena:";
    public string SenhaIncorreta => "Contrasena incorrecta.";
    public string PromptNovaSenha => "Digite su nueva contrasena:\n";
    public string SenhaDiferenteAtual => "Digite una contrasena diferente de la actual.\n";

    public string CriandoPedidoIntro => "Creando pedido! Complete la informacion:\n";
    public string QuantosItensPedido => "Cuantos items fueron pedidos?\n";
    public string EmQuantasPessoasVaiSerDivididaConta => "Entre cuantas personas se dividira la cuenta?:\n";
    public string NovoPrecoItem => "Cual es el nuevo precio del item?\n";
    public string ItemDisponivelPergunta => "El item esta disponible?: (1 para SI / 2 para NO)\n";
    public string DigiteCodigoDoItem(int indice) => $"Digite el codigo del item {indice}:\n";
    public string DigiteQuantidadeDoItem(int indice) => $"Cuantas unidades del item {indice} fueron pedidas?:\n";
    public string DigiteCodigoItem => "Codigo del item:";
    public string NumeroPedido => "Numero del pedido:";
    public string DescricaoPT => "Descripcion PT:";
    public string DescricaoEN => "Descripcion EN:";
    public string DescricaoES => "Descripcion ES:";
    public string Preco => "Precio:";

    public string QualTipoRelatorio => "Que tipo de reporte quiere generar?\n";
    public string RelatorioPorPeriodoOpcao => "1- Reporte por periodo:";
    public string RelatorioPorClienteOpcao => "2- Reporte por cliente:";
    public string RelatorioPorClienteEmPeriodoOpcao => "3- Reporte por cliente en periodo:";
    public string RelatorioPorItemOpcao => "4- Reporte por item del menu:\n";
    public string SairMenuRelatorio => "99 para salir del menu:\n";
    public string NomeOuEmailDoCliente => "Nombre o email del cliente:";
    public string DataInicial => $"Fecha inicial ({FormatoData}):";
    public string DataFinal => $"Fecha final ({FormatoData}):";
    public string DigiteIdItem => "Digite el ID del item:";
    public string DigiteIdCliente => "Digite el ID del cliente:";

    public string ItemNaoEncontrado => "Item no encontrado.";
    public string ItemNaoEncontradoNoMenu => "Item no encontrado.";
    public string ItemAdicionadoComSucesso => "Item agregado con exito!\n";
    public string ItemRemovidoComSucesso => "Item eliminado con exito!\n";
    public string ItemEditado(string descricao) => $"Item '{descricao}' editado\n";
    public string ItemCodigoAdicionado(int codigo) => $"Item de codigo {codigo} agregado!.";
    public string ItemCodigoRemovido(int codigo) => $"Item de codigo {codigo} eliminado.";
    public string ItemNaoEncontradoNoPedido(int codigo) => $"Item de codigo {codigo} no encontrado.";

    public string PedidoNaoEncontrado => "Pedido no encontrado.";
    public string PedidoNaoEncontradoOuEncerrado => "Pedido no encontrado o ya cerrado.";
    public string PedidoJaEncerrado => "El pedido ya esta cerrado, no es posible cambiar su estado.\n";
    public string PedidoCriado(int id, decimal total) => $"Pedido #{id} creado! Total: R${total:F2}";
    public string PedidoFoiPago(int id) => $"El pedido {id} fue pagado!\n";
    public string PedidoFoiEncerrado(int id) => $"El pedido {id} fue cerrado!\n";
    public string ValorTotalPedido(decimal total) => $"El valor total del pedido es:{total}\n";
    public string ValorDividido(int pessoas, decimal valorPorPessoa) => $"El valor dividido entre {pessoas} personas quedo:{valorPorPessoa} para cada una\n";
    public string FormatoData => "dd/MM/yyyy";
    public string FormatoDataHora => "dd/MM/yyyy HH:mm";

    public string NenhumPedidoEncontradoNessePeriodo => "No se encontraron pedidos en este periodo.";
    public string NenhumPedidoEncontradoParaEsseCliente => "No se encontraron pedidos para este cliente.";
    public string NenhumPedidoEncontradoParaEsseClienteNessePeriodo => "No se encontraron pedidos para este cliente en este periodo.";
    public string ItemNaoApareceuEmNenhumPedido => "Este item todavia no aparecio en ningun pedido.";
    public string ConsumoDoItem(string item) => $"\nConsumo del item: {item}";
    public string ResumoPedido(int id, string nomeCliente, DateTime criadoEm, Status status, decimal valorTotal, string itens)
        => $"#{id} | {nomeCliente} | {criadoEm.ToString(FormatoDataHora)} | {status} | R${valorTotal:F2}\nItems pedidos: {itens}";
    public string ResumoPedidoPorItem(int id, string nomeCliente, DateTime criadoEm)
        => $"Pedido #{id} | {nomeCliente} | {criadoEm.ToString(FormatoDataHora)}";

    public string NomeDoItem(string descricaoBR, string descricaoEN, string descricaoES) => descricaoES;
    public string NomeDaCategoria(string nomeBR, string nomeEN) => nomeBR;
    public string Disponibilidade(bool estaDisponivel) => estaDisponivel ? "Disponible" : "No disponible";
}
