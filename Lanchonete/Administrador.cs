using System;

namespace Lanchonete;

public class Administrador : Usuario, IMenuGerenciavel
{
    private Cardapio cardapio1 {get;set;}
    private string Senha {get;set;}
    public string Cargo {get;set;}

    public Administrador(Cardapio cardapio)
    {
        id = Guid.NewGuid().ToString();
        cardapio1 = cardapio;
        Senha = "12345";
        Cargo = "ADM anonimo";
        AcessoDoUsuario = Acesso.Administrador;
    }

    public void GerarRelatorio()
    {
        throw new NotImplementedException();
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
