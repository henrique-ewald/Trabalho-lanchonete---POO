using System;
using Domain;

namespace Lanchonete;

public class UsuarioInput
{
    public Cliente CriarCliente()
    {
        Console.WriteLine("Cadastro de cliente. Preencha as informacoes:\n");

        return new Cliente
        {
            Nome = LerTexto("Nome:"),
            Email = LerTexto("Email:"),
            AcessoDoUsuario = Acesso.Cliente
        };
    }

    public Funcionario CriarFuncionario()
    {
        Console.WriteLine("Cadastro de funcionario. Preencha as informacoes:\n");

        Funcionario funcionario = new Funcionario()
        {
            Nome = LerTexto("Nome:"),
            Email = LerTexto("Email:"),
            Cargo = LerTexto("Cargo:")
        };

        return funcionario;
    }

    public Administrador CriarAdministrador()
    {
        Console.WriteLine("Cadastro de administrador. Preencha as informacoes:\n");

        Administrador administrador = new Administrador()
        {
            Nome = LerTexto("Nome:"),
            Email = LerTexto("Email:"),
            Cargo = LerTexto("Cargo:")
        };

        return administrador;
    }

    public string LerTexto(string mensagem)
    {
        Console.WriteLine(mensagem);
        string texto = Console.ReadLine();

        if (texto == null)
        {
            return "";
        }

        texto = texto.Trim();

        while (texto == "")
        {
            Console.WriteLine(mensagem);
            texto = Console.ReadLine();

            if (texto == null)
            {
                return "";
            }

            texto = texto.Trim();
        }

        return texto;
    }


}
