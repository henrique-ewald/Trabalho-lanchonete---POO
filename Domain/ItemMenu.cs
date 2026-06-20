using System;

namespace Domain;

public class ItemMenu
{
    public int Codigo {get;set;}
    public string DescricaoBR {get;set;}
    public string DescricaoEN {get;set;}
    public decimal Preco {get;set;}
    public bool EstaDisponivel {get;set;}
    public Categoria Categoria {get;set;}

    
}
