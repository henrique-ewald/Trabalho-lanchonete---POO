using System;
using Lanchonete;
using Projeto.Pedidos;
using Projeto.CardapioDeItens;


namespace Domain;

public class UsuarioComPermissao : Usuario, IMenuGerenciavel
{
    protected string Senha {get;set;}
    public string Cargo {get;set;}
    protected Cardapio cardapio1 {get;set;}
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
