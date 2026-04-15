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
        Dictionary<typeBet, int> multiplicadores = new Dictionary<typeBet, int>();
        multiplicadores.Add(typeBet.numeroCheio, 36);
        multiplicadores.Add(typeBet.parImpar, 2);
        multiplicadores.Add(typeBet.coluna, 3);

        List<Bet> apostas = new List<Bet>();
        Random random = new Random();

        Console.WriteLine("JOGO ROLETA");
        Console.Write("Quantas apostas você pretende fazer? ");

        int quantidadeApostas;
        while (!int.TryParse(Console.ReadLine(), out quantidadeApostas) || quantidadeApostas <= 0)
        {
            Console.Write("Digite um número válido maior que 0: ");
        }

        for (int i = 0; i < quantidadeApostas; i++)
        {
            Bet aposta = new Bet();
            aposta.Id = i + 1;

            Console.WriteLine("\nEscolha o tipo da aposta:");
            Console.WriteLine("Número cheio: 0");
            Console.WriteLine("Par/Ímpar: 1");
            Console.WriteLine("Coluna: 2");
            Console.Write("Opção: ");

            int tipo;
            while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 0 || tipo > 2)
            {
                Console.Write("Digite 0, 1 ou 2: ");
            }

            aposta.TypeBet = (typeBet)tipo;

            Console.Write("Digite o valor apostado: ");
            decimal valor;
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.Write("Digite um valor válido: ");
            }

            aposta.Amount = valor;

            if (aposta.TypeBet == typeBet.numeroCheio)
            {
                Console.Write("Digite o número apostado (0 a 36): ");
                int numero;
                while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0 || numero > 36)
                {
                    Console.Write("Digite um número entre 0 e 36: ");
                }
                aposta.SelectedNumber = numero;
            }
            else if (aposta.TypeBet == typeBet.parImpar)
            {
                Console.Write("Digite 'par' ou 'impar': ");
                string escolha = (Console.ReadLine() ?? "").Trim().ToLower();

                while (escolha != "par" && escolha != "impar")
                {
                    Console.Write("Digite somente 'par' ou 'impar': ");
                    escolha = (Console.ReadLine() ?? "").Trim().ToLower();
                }

                aposta.ParOuImparEscolhido = escolha;
            }
            else
            {
                Console.Write("Digite a coluna ('1-12', '13-24' ou '25-36'): ");
                string coluna = (Console.ReadLine() ?? "").Trim();

                while (coluna != "1-12" && coluna != "13-24" && coluna != "25-36")
                {
                    Console.Write("Digite '1-12', '13-24' ou '25-36': ");
                    coluna = (Console.ReadLine() ?? "").Trim();
                }

                aposta.ColunaEscolhida = coluna;
            }

            apostas.Add(aposta);
        }

        int numeroSorteado = random.Next(0, 37);

        Console.WriteLine("Número sorteado: " + numeroSorteado);

        decimal totalGanho = CalculaApostas(apostas, numeroSorteado, multiplicadores);

        Console.WriteLine("Total ganho: R$ " + totalGanho);
    }

    static decimal CalculaApostas(List<Bet> apostas, int numeroSorteado, Dictionary<typeBet, int> multiplicadores)
    {
        decimal totalGanho = 0;

        foreach (Bet aposta in apostas)
        {
            bool ganhou = false;
            decimal premio = 0;

            if (aposta.TypeBet == typeBet.numeroCheio)
            {
                if (aposta.SelectedNumber == numeroSorteado)
                {
                    ganhou = true;
                    premio = aposta.Amount * multiplicadores[typeBet.numeroCheio];
                }

                Console.WriteLine($"\nAposta {aposta.Id} - Número cheio ({aposta.SelectedNumber})");
            }
            else if (aposta.TypeBet == typeBet.parImpar)
            {
                if (numeroSorteado != 0)
                {
                    bool ehPar = numeroSorteado % 2 == 0;

                    if ((aposta.ParOuImparEscolhido == "par" && ehPar) ||
                        (aposta.ParOuImparEscolhido == "impar" && !ehPar))
                    {
                        ganhou = true;
                        premio = aposta.Amount * multiplicadores[typeBet.parImpar];
                    }
                }

                Console.WriteLine($"\nAposta {aposta.Id} - Par/Ímpar ({aposta.ParOuImparEscolhido})");
            }
            else
            {
                if (numeroSorteado != 0)
                {
                    if (aposta.ColunaEscolhida == "1-12" && numeroSorteado >= 1 && numeroSorteado <= 12)
                    {
                        ganhou = true;
                    }
                    else if (aposta.ColunaEscolhida == "13-24" && numeroSorteado >= 13 && numeroSorteado <= 24)
                    {
                        ganhou = true;
                    }
                    else if (aposta.ColunaEscolhida == "25-36" && numeroSorteado >= 25 && numeroSorteado <= 36)
                    {
                        ganhou = true;
                    }

                    if (ganhou)
                    {
                        premio = aposta.Amount * multiplicadores[typeBet.coluna];
                    }
                }

                Console.WriteLine($"\nAposta {aposta.Id} - Coluna ({aposta.ColunaEscolhida})");
            }

            Console.WriteLine("Valor apostado: R$ " + aposta.Amount);

            if (ganhou)
            {
                Console.WriteLine("Resultado: GANHOU");
                Console.WriteLine("Prêmio: R$ " + premio);
            }
            else
            {
                Console.WriteLine("Resultado: PERDEU");
                Console.WriteLine("Prêmio: R$ 0");
            }

            totalGanho += premio;
        }

        return totalGanho;
    }

}

//multiplicador especifico 

//3 métodos especificos para cada tipo de aposta de acordo com a escolha


public class Bet
{
    public int Id { get; set; } //para saber qual bet está sendo instanciada 
    public typeBet TypeBet { get; set; } // qual vai ser o tipo da aposta
    public decimal Amount { get; set; }
    public int? SelectedNumber { get; set; }
    public string? ParOuImparEscolhido { get; set; }
    public string? ColunaEscolhida { get; set; }
}

public enum typeBet
{
    numeroCheio = 0,
    parImpar = 1,
    coluna = 2
}