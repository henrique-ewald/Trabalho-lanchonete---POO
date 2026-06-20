using System;
using Domain;

namespace Domain;

public class Cliente : Usuario
{
    public Cliente()
    {
        id = GeraId();
        Nome = "Não informado";
        Email = "Não informado";
        AcessoDoUsuario = Acesso.Cliente;
    }

}
