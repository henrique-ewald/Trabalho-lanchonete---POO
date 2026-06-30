using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using Domain;
using Projeto;
using Projeto.CardapioDeItens;
using Projeto.Pedidos;
using Projeto.Relatorios;

namespace Lanchonete;

public class SerializerDeObjetos
{
    public string jsonString {get;set;}
    public void SerializarObjeto(DadosGerais Dados)
    {
        jsonString = JsonSerializer.Serialize(Dados);
        File.WriteAllText("DadosSalvos.json", jsonString);
    }
    public void SerializerInicial(IIdioma idioma)
    {
        MockDeDados mock = new MockDeDados();
        DadosGerais dados;
        dados = mock.CriarCenarioCompleto(idioma);
        jsonString = JsonSerializer.Serialize(dados);
        File.WriteAllText("DadosSalvos.json", jsonString);
    }
}
