using System;
using Lanchonete;

namespace Projeto.Relatorios;

public class PrintaRelatorios : GeradorDeRelatorio
{
    public override void RegistrarInformacao(string conteudo)
    {
        Console.WriteLine(conteudo);
    }

}
