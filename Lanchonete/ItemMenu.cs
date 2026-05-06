using System;

namespace Lanchonete;

public enum Descricao {BR, EN}
public class ItemMenu
{
    public int Codigo {get;set;}
    public string DescricaoBR {get;set;}
    public string DescricaoEN {get;set;}
    public decimal Preco {get;set;}
    public bool EstaDisponivel {get;set;}




    // não deve ficar nessa classe!
    // public Categoria Entradas {get;set;}
    // public Categoria Bebidas {get;set;}
    // public Categoria Pratos {get;set;}
    // public Categoria Sobremesas {get;set;}
    
    
}
