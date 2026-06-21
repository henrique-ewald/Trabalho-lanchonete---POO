using System;
using Domain;
using Projeto.CardapioDeItens;
using Projeto.Relatorios;
using Projeto.Pedidos;
using System.Text.Json.Serialization;

namespace Lanchonete;

public class DadosGerais
{
    public Cliente[] Clientes {get;set;}
    public GerenciadorCardapio Cardapio {get;set;} 
    public Administrador Administrador {get;set;}
    public GerenciadorPedidos Gerenciador {get;set;}
    [JsonIgnore]
    public PrintaRelatorios PrinterRelatorio {get;set;}
    [JsonIgnore]
    public SerializadorDeRelatorio SerializadorRelatorio {get;set;}

    public DadosGerais()
        {
            //
        }
    public DadosGerais(GerenciadorCardapio cardapio, Administrador administrador, GerenciadorPedidos gerenciador, PrintaRelatorios printerRelatorio, SerializadorDeRelatorio serializadorRelatorio, Cliente[] clientes)
    {
        Cardapio = cardapio;
        Administrador = administrador;
        Gerenciador = gerenciador;
        PrinterRelatorio = printerRelatorio;
        SerializadorRelatorio = serializadorRelatorio;
        Clientes = clientes;
    }
    
}
