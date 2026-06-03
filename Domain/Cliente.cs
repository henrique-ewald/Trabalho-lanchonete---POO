using System;

namespace Lanchonete;

public class Cliente : Usuario
{
    public Cliente()
    {
        id = GeraId();
        Nome = "Não informado";
        Email = "Não informado";
        AcessoDoUsuario = Acesso.Cliente;
    }

    public Lanchonete.Acesso AcessoDoUsuario { get; set; }
}
