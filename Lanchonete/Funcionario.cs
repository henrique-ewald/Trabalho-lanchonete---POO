using System;

namespace Lanchonete;

public class Funcionario : Usuario, IMenuGerenciavel
{
    public string Senha {get;set;}
    public string Cargo {get;set;}

    public void AdicionaItem(ItemMenu item)
    {
        
        Console.WriteLine($"Item '{item.DescricaoBR}' adicionado ao menu.");
    }

    public void EditarItem(ItemMenu item)
    {

        Console.WriteLine($"Item '{item.DescricaoBR}' editado.");
    }
    public void RemoverItem(int id)
    {
        
        Console.WriteLine($"Item de código {id} removido.");
    }

    public bool ValidarSenha(string tentativa)
    {
        return tentativa == Senha;
    }
    


}
