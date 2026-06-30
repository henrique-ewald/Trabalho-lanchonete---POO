using System;
using Lanchonete;
using Projeto.Pedidos;
using Projeto.CardapioDeItens;
using Domain;
using System.Text.Json.Serialization;


namespace Lanchonete;

public class UsuarioComPermissao : Usuario, IMenuGerenciavel
{
    protected string Senha {get;set;}
    public string Cargo {get;set;}
    private SerializerDeObjetos SerializadorOBJ { get; set; }
    [JsonIgnore]
    public IIdioma Idioma { get; set; }
    protected IIdioma Texto => Idioma ?? new IdiomaPortugues();
    public void AdicionaItem(ItemMenu novo, DadosGerais dados)
    {
        SerializadorOBJ = new SerializerDeObjetos();
        dados.Cardapio.AdicionaItem(novo);
        SerializadorOBJ.SerializarObjeto(dados);
        Console.WriteLine(Texto.ItemAdicionadoComSucesso);
    }
    public void RemoverItem(ItemMenu removido, DadosGerais dados)
    {
        SerializadorOBJ = new SerializerDeObjetos();
        dados.Cardapio.RemoverItem(removido);
        SerializadorOBJ.SerializarObjeto(dados);
        Console.WriteLine(Texto.ItemRemovidoComSucesso);
    }

    public void EditarItem(ItemMenu item, DadosGerais dados)
    {
        SerializadorOBJ = new SerializerDeObjetos();
        PedidoInput inputItem = new PedidoInput(Texto);
        ItemMenu param = inputItem.EditarItemInputs();
        dados.Cardapio.EditarItem(item, param.EstaDisponivel, param.Preco);
        SerializadorOBJ.SerializarObjeto(dados);
        Console.WriteLine(Texto.ItemEditado(item.DescricaoBR));
    }

    public bool ValidarSenha(string tentativa)
    {
        return tentativa == Senha;
    }
    public void AlteraSenha(DadosGerais dados)
    {
        Console.WriteLine(Texto.PromptNovaSenha);
        string SenhaNova = Console.ReadLine();
        if (SenhaNova == Senha){Console.WriteLine(Texto.SenhaDiferenteAtual);}
        else
        {
            Senha = SenhaNova;
        }
        
    }
}
