using System;

namespace Lanchonete;

public enum Status {Aberto, Pago, Encerrado}

public class Pedido
{
    public int id {get;set;}
    public DateTime CriadoEm {get;set;}
    public Status StatusAtual {get;set;}
    public Cliente? Consumidor {get;set;}
    public ItemPedido[] ItensPedidos {get;set;}
    public decimal ValorTotal {get;set;}
    public int PessoasParaDividir {get;set;}


}
