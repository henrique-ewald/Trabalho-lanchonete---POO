using System;

namespace Lanchonete;

public interface IMenuGerenciavel
{
    public void AdicionaItem(ItemMenu item);
    public void EditarItem(ItemMenu item);
    public void RemoverItem(ItemMenu removido);
}
