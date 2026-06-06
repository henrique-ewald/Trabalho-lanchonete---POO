using System;

namespace Lanchonete;

public class SerializadorDeRelatorio : GeradorDeRelatorio
{
    public override void RegistrarInformacao(string conteudo)
    {
        File.WriteAllText("arquivo.txt", conteudo);
    }
}
