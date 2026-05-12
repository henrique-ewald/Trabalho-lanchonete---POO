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
    public ItemMenu EditarItemInputs()
    {
        ItemMenu item = new ItemMenu();

        Console.WriteLine($"Qual o novo preço do item?\n");
        item.Preco = decimal.Parse(Console.ReadLine());

        Console.WriteLine($"O item esta disponivel?: (1 para SIM / 2 para NÃO)\n");
        int opcao = int.Parse(Console.ReadLine());

        if(opcao==1)item.EstaDisponivel = true;
        else if(opcao==2)item.EstaDisponivel = false;
        
        return item;
    }


    
}
