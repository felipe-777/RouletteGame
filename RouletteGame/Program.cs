// ========================================
// 🎯 TESTE TÉCNICO - INSTRUÇÕES
// ========================================
//
// Você precisa implementar um sistema de jogo de roleta.
//
// PASSOS:
// 1. Criar pastas Models e Services
// 2. Criar as classes necessárias
// 3. Implementar a lógica do jogo
// 4. Substituir este código pelo código do jogo
//
// DICA: Leia o arquivo teste-backend-csharp.md para ver
// todos os detalhes do desafio!
//
// ========================================

// See https://aka.ms/new-console-template for more information

class Program
{
     
    static void Main(string[] args)
    {
        string quantidadeApostasString = "";
        int quantidadeApostas = 0;

        Console.WriteLine("JOGO ROLETA");
        Console.WriteLine("Quantas apostas você pretende fazer?");
        try
        {
            quantidadeApostasString = Console.ReadLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato de cadeia não permitido, insira um número");
        }
        quantidadeApostas = Int32.Parse(quantidadeApostasString);

        for(int i = 0; i <= quantidadeApostas; i++)
        {
            Console.WriteLine("Para a aposta, escolha o tipo e valor a ser apostado. Segue abaixo os tipos de aposta:");
            Console.WriteLine("Número cheio: 0");
            Console.WriteLine("Par/Ímpar: 1");
            Console.WriteLine("Coluna: 2");
            Console.WriteLine("");
        }
    }


    public string CalculaApostas(typeBet tipoAposta, int valor)
    {
        if(tipoAposta == typeBet.numeroCheio)
        {
            
        }
        else if (tipoAposta == typeBet.parImpar)
        {

        }
        else
        {

        }
        return  "";
    }
}



//leonardo.camargo@tglab.com
//multiplicador especifico 

//3 métodos especificos para cada tipo de aposta de acordo com a escolha


public class Bet
{
    public int Id { get; set; } //para saber qual bet está sendo instanciada 
    public typeBet TypeBet { get; set; } // qual vai ser o tipo da aposta
}

public enum typeBet
{
    numeroCheio = 0,
    parImpar = 1,
    coluna = 2
}