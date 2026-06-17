using System;
using System.Text.Json;
using Domain;
using Projeto;
using Projeto.CardapioDeItens;
using Projeto.Pedidos;
using Projeto.Relatorios;

namespace Lanchonete;

public class SerializerDeObjetos
{
    public string jsonString {get;set;}
    public SerializerDeObjetos(DadosGerais Dados)
    {
        jsonString = JsonSerializer.Serialize(Dados);
    }
}
