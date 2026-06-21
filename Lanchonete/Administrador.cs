using System;
using Domain;


namespace Lanchonete;

public class Administrador : UsuarioComPermissao
{

    public Administrador()
    {
        id = GeraId();
        Senha = "12345";
        Cargo = "ADM anonimo";
        AcessoDoUsuario = Acesso.Administrador;
    }
}
