using System;
using Lanchonete;
using Projeto.Pedidos;

namespace Projeto.Relatorios;

public class PrintaRelatorios : GeradorDeRelatorio
{
    public PrintaRelatorios(GerenciadorPedidos gerenciador)
    {
        this.gerenciador = gerenciador;
    }
    public override void RegistrarInformacao(string conteudo)
    {
        Console.WriteLine(conteudo);
    }

}
