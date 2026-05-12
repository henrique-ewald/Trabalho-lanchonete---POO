using System;
using System.Security.Cryptography;

namespace Lanchonete;

public class Funcionario : Usuario, IMenuGerenciavel
{
    private string Senha {get;set;}
    public string Cargo {get;set;}
    private Cardapio cardapio1 {get;set;}
    public Funcionario(Cardapio cardapio)
    {
        id = GeraId();
        cardapio1 = cardapio;
        Senha = "12345";
        Cargo = "anonimo";
        AcessoDoUsuario = Acesso.Funcionario;
    }
    public void AdicionaItem(ItemMenu novo)
    {
        cardapio1.AdicionaItem(novo);
        Console.WriteLine("Item adicionado com sucesso!\n");
    }
    public void RemoverItem(ItemMenu removido)
    {
        cardapio1.RemoverItem(removido);
        Console.WriteLine("Item removido com sucesso!\n");
    }

    public void EditarItem(ItemMenu item)
    {
        PedidoInput inputItem = new PedidoInput();
        ItemMenu param = inputItem.EditarItemInputs();
        cardapio1.EditarItem(item, param.EstaDisponivel, param.Preco);
        Console.WriteLine($"Item '{item.DescricaoBR}' editado\n");
    }

    public bool ValidarSenha(string tentativa)
    {
        return tentativa == Senha;
    }
    public void AlteraSenha()
    {
        Console.WriteLine("Digite a sua nova senha:\n");
        string SenhaNova = Console.ReadLine();
        if (SenhaNova == Senha){Console.WriteLine("Digite uma senha diferente da atual.\n");}
        else
        {
            Senha = SenhaNova;
        }
    }


}
