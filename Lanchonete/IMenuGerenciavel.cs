using System;
using Domain;

namespace Lanchonete;

public interface IMenuGerenciavel
{
    public void AdicionaItem(ItemMenu item, DadosGerais dados);
    public void EditarItem(ItemMenu item, DadosGerais dados);
    public void RemoverItem(ItemMenu removido, DadosGerais dados);
}
