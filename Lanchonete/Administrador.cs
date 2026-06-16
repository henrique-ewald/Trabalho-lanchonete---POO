using System;
using Domain;
using Projeto.CardapioDeItens;


namespace Lanchonete;

public class Administrador : UsuarioComPermissao
{

    public Administrador(GerenciadorCardapio cardapio)
    {
        id = GeraId();
        cardapio1 = cardapio;
        Senha = "12345";
        Cargo = "ADM anonimo";
        AcessoDoUsuario = Acesso.Administrador;
    }




}
