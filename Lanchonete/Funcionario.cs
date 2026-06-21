using System;
using Domain;

namespace Lanchonete;

public class Funcionario : UsuarioComPermissao
{
    public Funcionario()
    {
        id = GeraId();
        Senha = "12345";
        Cargo = "anonimo";
        AcessoDoUsuario = Acesso.Funcionario;
    }
    

}
