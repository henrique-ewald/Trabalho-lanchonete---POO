using System;

namespace Domain;

public class ItemNaoEncontradoException : Exception
{
    public int CodigoItem { get; }

    public ItemNaoEncontradoException(int codigoItem)
        : base($"Item de código {codigoItem} não encontrado.")
    {
        CodigoItem = codigoItem;
    }
}

public class PedidoJaEncerradoException : InvalidOperationException
{
    public int PedidoId { get; }

    public PedidoJaEncerradoException(int pedidoId)
        : base($"O pedido {pedidoId} já está encerrado.")
    {
        PedidoId = pedidoId;
    }
}
