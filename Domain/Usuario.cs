using System;

namespace Lanchonete;

public enum Idioma { Portugues, Ingles }

public enum Acesso {Cliente, Funcionario, Administrador}

public class Usuario
{
    public string id {get;set;}
    public string Nome {get;set;}
    public string Email {get;set;}
    public Acesso AcessoDoUsuario {get;set;}

    public bool EhFuncionario()
    {
        if (AcessoDoUsuario == Acesso.Funcionario || AcessoDoUsuario == Acesso.Administrador)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GeraId()
    {
        return $"{Guid.NewGuid()}";
    }



}
