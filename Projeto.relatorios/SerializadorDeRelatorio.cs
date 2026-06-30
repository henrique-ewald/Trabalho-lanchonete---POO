using System;
using Domain;
using Projeto.Pedidos;

namespace Projeto.Relatorios;

public class SerializadorDeRelatorio : GeradorDeRelatorio
{
    public SerializadorDeRelatorio(GerenciadorPedidos gerenciador, IIdioma idioma) : base(gerenciador, idioma)
    {
    }

    public override void RegistrarInformacao(string conteudo)
    {
        File.AppendAllText("arquivo.txt", $"{conteudo}\n");
    }
}
