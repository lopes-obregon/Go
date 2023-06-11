using System.ComponentModel.Design;

namespace Go
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /*cria o metodo do tabuleiro*/
            Tabuleiro tabuleiro = new Tabuleiro(9, 9);
            /*inicializa o tabuleiro*/
            tabuleiro.InicializaTabuleiro();
            bool jogador1 = true; //define como sendo o primeiro a jogar
            int contadorJogador1 = 41; // contador de jogadas do jogador 1
            int contadorJogador2 = 40; // contador de jogadas do jogador 2

            Console.WriteLine("-------------Menu------------------------");
            Console.WriteLine("0-2 Jogadores\t1-1 Jogador\t 2-Sair");
            Console.Write("Opção:");
            int opção = int.Parse(Console.ReadLine());
            switch (opção)
            {
                case 0:
                    while (true)
                    {
                        /*exibi o tabuleiro*/
                        tabuleiro.ExibirTabuleiro();
                        /*indica a vez do jogador e espera os comandos para jogar*/
                        Console.WriteLine("É a vez do jogador " + (jogador1 ? "1" : "2"));
                        Console.WriteLine("Infome linha 1-9");
                        int linha = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Informe coluna 1-9");
                        int coluna = int.Parse(Console.ReadLine()) - 1;
                        /*verifica se o movimento do jogador é válido*/
                        if (tabuleiro.MovimentoValido(linha, coluna, jogador1 ? 'X' : 'O'))
                        {
                            /*seta o campo e alterna para o próximo jogador*/
                            jogador1 = tabuleiro.setCampo(linha, coluna, jogador1 ? 'X' : 'O', jogador1);

                            // Incrementa o contador de jogadas do jogador atual
                            if (jogador1)
                            {
                                contadorJogador1--;
                            }
                            else
                            {
                                contadorJogador2--;
                            }

                            /*Verifica se ambos os jogadores ficaram sem pedras e encerra o jogo*/
                            if (contadorJogador1 <= 0 && contadorJogador2 <= 0)
                            {
                                Console.WriteLine("Ambos os jogadores ficaram sem pedras. Jogo encerrado!");
                                break;
                            }

                            /*Verifica se alguém venceu*/
                            if (tabuleiro.VerificaVitória(contadorJogador1, contadorJogador2))
                            {
                                Console.WriteLine("O jogador " + (jogador1 ? "1" : "2") + " venceu!");
                                break;
                            }
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("Versusu IA");
                    break;
                case 2:
                    break;

            }

        }

    }
}
