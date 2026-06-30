using System;
using System.Globalization;
using Domain;

namespace Lanchonete;

public class UsuarioInput
{
    private readonly IIdioma Idioma;

    public UsuarioInput(IIdioma idioma)
    {
        Idioma = idioma;
    }

    public Cliente CriarCliente()
    {
        Console.WriteLine(Idioma.CadastroClienteIntro);

        return new Cliente
        {
            Nome = LerTexto(Idioma.CampoNome),
            Email = LerTexto(Idioma.CampoEmail),
            AcessoDoUsuario = Acesso.Cliente
        };
    }

    public Funcionario CriarFuncionario()
    {
        Console.WriteLine(Idioma.CadastroFuncionarioIntro);

        Funcionario funcionario = new Funcionario
        {
            Nome = LerTexto(Idioma.CampoNome),
            Email = LerTexto(Idioma.CampoEmail),
            Cargo = LerTexto(Idioma.CampoCargo)
        };

        funcionario.Idioma = Idioma;
        return funcionario;
    }

    public Administrador CriarAdministrador()
    {
        Console.WriteLine(Idioma.CadastroAdministradorIntro);

        Administrador administrador = new Administrador
        {
            Nome = LerTexto(Idioma.CampoNome),
            Email = LerTexto(Idioma.CampoEmail),
            Cargo = LerTexto(Idioma.CampoCargo)
        };

        administrador.Idioma = Idioma;
        return administrador;
    }

    public int LerInteiro(string mensagem)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int valor))
            {
                return valor;
            }

            Console.WriteLine(Idioma.OpcaoInvalida);
        }
    }

    public decimal LerDecimal(string mensagem)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            string? entrada = Console.ReadLine();

            if (decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor))
            {
                return valor;
            }

            Console.WriteLine(Idioma.OpcaoInvalida);
        }
    }

    public DateTime LerData(string mensagem)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            string? entrada = Console.ReadLine();

            if (DateTime.TryParseExact(entrada, Idioma.FormatoData, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime valor))
            {
                return valor;
            }

            Console.WriteLine(Idioma.OpcaoInvalida);
        }
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
