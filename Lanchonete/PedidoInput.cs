using System;

namespace Lanchonete;

public class PedidoInput
{

    public DadosPedido PedidoInputs()
    {
        DadosPedido dados = new DadosPedido();
        Console.WriteLine("Criando pedido! Preencha as informações:\n");
        Console.WriteLine("Quantos itens foram pedidos?\n");
        dados.Quant = int.Parse(Console.ReadLine());
        int i;
        dados.CodigosItens = new int[dados.Quant];
        dados.QuantItens = new int[dados.Quant];
        for(i=0; i < dados.Quant; i++) 
        {
            Console.WriteLine($"Digite o código do {i}° item:\n");
            dados.CodigosItens[i] = int.Parse(Console.ReadLine());
            Console.WriteLine($"Quantas unidades do {i}° item foram pedidas?:\n");
            dados.QuantItens[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Em quantas pessoas vai ser divida a conta?:\n");
        dados.PessoasPDividir = int.Parse(Console.ReadLine());
        return dados;
    }

    
}
