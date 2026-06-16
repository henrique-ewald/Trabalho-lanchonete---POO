using System;
using System.Security.Cryptography;
using Domain;
using Projeto.CardapioDeItens;

namespace Lanchonete;

public class Funcionario : UsuarioComPermissao
{
    public Funcionario(GerenciadorCardapio cardapio)
    {
        id = GeraId();
        cardapio1 = cardapio;
        Senha = "12345";
        Cargo = "anonimo";
        AcessoDoUsuario = Acesso.Funcionario;
    }
    

}
