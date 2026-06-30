using System;
using Domain;
using Projeto.Pedidos;

namespace Projeto.Relatorios;

public class PrintaRelatorios : GeradorDeRelatorio
{
    public PrintaRelatorios(GerenciadorPedidos gerenciador, IIdioma idioma) : base(gerenciador, idioma)
    {
    }

    public override void RegistrarInformacao(string conteudo)
    {
        Console.WriteLine(conteudo);
    }
}
