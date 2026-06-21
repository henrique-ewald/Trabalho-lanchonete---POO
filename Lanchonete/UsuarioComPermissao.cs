using System;
using Lanchonete;
using Projeto.Pedidos;
using Projeto.CardapioDeItens;
using Domain;


namespace Lanchonete;

public class UsuarioComPermissao : Usuario, IMenuGerenciavel
{
    protected string Senha {get;set;}
    public string Cargo {get;set;}
    private SerializerDeObjetos SerializadorOBJ { get; set; }
    public void AdicionaItem(ItemMenu novo, DadosGerais dados)
    {
        SerializadorOBJ = new SerializerDeObjetos();
        dados.Cardapio.AdicionaItem(novo);
        SerializadorOBJ.SerializarObjeto(dados);
        Console.WriteLine("Item adicionado com sucesso!\n");
    }
    public void RemoverItem(ItemMenu removido, DadosGerais dados)
    {
        SerializadorOBJ = new SerializerDeObjetos();
        dados.Cardapio.RemoverItem(removido);
        SerializadorOBJ.SerializarObjeto(dados);
        Console.WriteLine("Item removido com sucesso!\n");
    }

    public void EditarItem(ItemMenu item, DadosGerais dados)
    {
        SerializadorOBJ = new SerializerDeObjetos();
        PedidoInput inputItem = new PedidoInput();
        ItemMenu param = inputItem.EditarItemInputs();
        dados.Cardapio.EditarItem(item, param.EstaDisponivel, param.Preco);
        SerializadorOBJ.SerializarObjeto(dados);
        Console.WriteLine($"Item '{item.DescricaoBR}' editado\n");
    }

    public bool ValidarSenha(string tentativa)
    {
        return tentativa == Senha;
    }
    public void AlteraSenha(DadosGerais dados)
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
