using System;
using Domain;
using System.Text.Json.Serialization;

namespace Projeto.CardapioDeItens;

public class Cardapio
{
    public List<ItemMenu> CardapioItens {get;set;}
    public Categoria Entradas {get;set;}
    public Categoria Bebidas {get;set;}
    public Categoria Pratos {get;set;}
    public Categoria Sobremesas {get;set;}
    [JsonIgnore]
    public IIdioma Idioma { get; set; }


}
