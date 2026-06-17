using System;
using Domain;
using Projeto.CardapioDeItens;
using Projeto.Relatorios;
using Projeto.Pedidos;

namespace Lanchonete;

public class DadosGerais
{
    public MockDeDados Mock { get; set; }
    public Cliente[] clientes {get;set;}
    public Cardapio Cardapio {get;set;} 
    public GerenciadorCardapio CardapioADM {get;set;} 
    public Administrador Administrador {get;set;}
    public GerenciadorPedidos Gerenciador {get;set;}
    public PrintaRelatorios PrinterRelatorio {get;set;}
    public SerializadorDeRelatorio SerializadorRelatorio {get;set;}

    public DadosGerais()
        {
            
        }
    public DadosGerais(MockDeDados mock,Cardapio cardapio, GerenciadorCardapio cardapioADM, Administrador administrador, GerenciadorPedidos gerenciador, PrintaRelatorios printerRelatorio, SerializadorDeRelatorio serializadorRelatorio)
    {
        Mock = mock;
        Cardapio = cardapio;
        CardapioADM = cardapioADM;
        Administrador = administrador;
        Gerenciador = gerenciador;
        PrinterRelatorio = printerRelatorio;
        SerializadorRelatorio = serializadorRelatorio;
    }
    
}
