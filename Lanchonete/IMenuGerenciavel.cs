using System;

namespace Lanchonete;

public interface IMenuGerenciavel
{
    void AdicionaItem(ItemMenu item);
    void EditarItem(ItemMenu item);
    void RemoverItem(int id);
}
