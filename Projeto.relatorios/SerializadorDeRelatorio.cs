using System;
using Projeto.Pedidos;

namespace Lanchonete;

public class SerializadorDeRelatorio : GeradorDeRelatorio
{
    public SerializadorDeRelatorio(GerenciadorPedidos gerenciador)
    {
        this.gerenciador = gerenciador;
    }
    public override void RegistrarInformacao(string conteudo)
    {
        File.AppendAllText("arquivo.txt", $"{conteudo}\n");
    }
}
