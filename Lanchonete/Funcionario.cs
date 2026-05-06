using System;
using System.Security.Cryptography;

namespace Lanchonete;

public class Funcionario : Usuario, IMenuGerenciavel
{
    public string Senha {get;set;}
    public string Cargo {get;set;}

    private Cardapio cardapio1 {get;set;}
    public Funcionario(Cardapio cardapio)
    {
        this.cardapio1 = cardapio;
        Senha = "12345";
        Cargo = "anonimo";
    }
    public void AdicionaItem(ItemMenu novo)
    {
        cardapio1.AdicionaItem(novo, cardapio1.CardapioItens);
    }
    public void RemoverItem(ItemMenu removido)
    {
        cardapio1.RemoverItem(removido, cardapio1.CardapioItens);
    }

    public void EditarItem(ItemMenu item)
    {
        Console.WriteLine($"Item '{item.DescricaoBR}' editado.");
    }

    public bool ValidarSenha(string tentativa)
    {
        return tentativa == Senha;
    }



}
