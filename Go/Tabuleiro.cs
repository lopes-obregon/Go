public class Tabuleiro
{
    private int x;
    private int y;
    private char[,] campo;
    private int pontuacaoJogador1;
    private int pontuacaoJogador2;

    public Tabuleiro(int x, int y)
    {
        this.x = x;
        this.y = y;
        campo = new char[x, y];
        pontuacaoJogador1 = 0;
        pontuacaoJogador2 = 0;
    }

    public void InicializaTabuleiro()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                campo[i, j] = '-';
            }
        }
    }

    public void ExibirTabuleiro()
    {
     

        Console.WriteLine("  1 2 3 4 5 6 7 8 9");

        for (int i = 0; i < 9; i++)
        {
            Console.Write((i + 1) + " ");

            for (int j = 0; j < 9; j++)
            {
                Console.Write(campo[i, j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public bool MovimentoValido(int linha, int coluna, char jogador)
    {
        if (linha < 0 || linha >= x || coluna < 0 || coluna >= y)
        {
            Console.WriteLine("Movimento inválido - posição fora do tabuleiro");
            return false;
        }

        if (campo[linha, coluna] != '-')
        {
            Console.WriteLine("Movimento inválido - posição já ocupada");
            return false;
        }

        // Verifica a liberdade das pedras adjacentes
        bool vizinhoSuperior = false;
        bool vizinhoInferior = false;
        bool vizinhoEsquerdo = false;
        bool vizinhoDireito = false;
        // se igual '-' tem liberdade disponivel
        if (linha - 1 > 0)
            vizinhoSuperior = campo[linha - 1, coluna] == '-';
        if (linha + 1 < x)
            vizinhoInferior = campo[linha + 1, coluna] == '-';
        if(coluna - 1 > 0)
            vizinhoEsquerdo = campo[linha, coluna - 1] == '-';
        if(coluna + 1 < y)
            vizinhoDireito = campo[linha, coluna + 1] == '-';
        Console.WriteLine(vizinhoSuperior + " " + vizinhoInferior + " " + vizinhoEsquerdo + " " + vizinhoDireito);

        if (!(vizinhoSuperior || vizinhoInferior || vizinhoEsquerdo || vizinhoDireito))
        {
            Console.WriteLine("Movimento inválido - sem liberdade");
            return false;
        }



        // Captura de pedras adversárias sem liberdade
        int pedrasCapturadas = 0;
        if (linha > 0 && campo[linha - 1, coluna] != jogador && !VerificaLiberdade(linha - 1, coluna, campo[linha - 1, coluna]))
        {
            campo[linha - 1, coluna] = '-';
            pedrasCapturadas++;
        }
        if (linha < x - 1 && campo[linha + 1, coluna] != jogador && !VerificaLiberdade(linha + 1, coluna, campo[linha + 1, coluna]))
        {
            campo[linha + 1, coluna] = '-';
            pedrasCapturadas++;
        }
        if (coluna > 0 && campo[linha, coluna - 1] != jogador && !VerificaLiberdade(linha, coluna - 1, campo[linha, coluna - 1]))
        {
            campo[linha, coluna - 1] = '-';
            pedrasCapturadas++;
        }
        if (coluna < y - 1 && campo[linha, coluna + 1] != jogador && !VerificaLiberdade(linha, coluna + 1, campo[linha, coluna + 1]))
        {
            campo[linha, coluna + 1] = '-';
            pedrasCapturadas++;
        }

        // Atualiza as pontuações
        int pontos = pedrasCapturadas * 2;
        if (jogador == 'X')
        {
            pontuacaoJogador1 -= pontos;
            pontuacaoJogador2 += pontos;
        }
        else
        {
            pontuacaoJogador1 += pontos;
            pontuacaoJogador2 -= pontos;
        }

        return true;
    }

    private bool VerificaLiberdade(int linha, int coluna, char jogador)
    {
        // Verifica se a pedra tem liberdade
        if (linha > 0 && campo[linha - 1, coluna] == '-')
            return true;
        if (linha < x - 1 && campo[linha + 1, coluna] == '-')
            return true;
        if (coluna > 0 && campo[linha, coluna - 1] == '-')
            return true;
        if (coluna < y - 1 && campo[linha, coluna + 1] == '-')
            return true;

        // Verifica se a pedra faz parte de um grupo com liberdade
        if (linha > 0 && campo[linha - 1, coluna] == jogador && VerificaLiberdade(linha - 1, coluna, jogador))
            return true;
        if (linha < x - 1 && campo[linha + 1, coluna] == jogador && VerificaLiberdade(linha + 1, coluna, jogador))
            return true;
        if (coluna > 0 && campo[linha, coluna - 1] == jogador && VerificaLiberdade(linha, coluna - 1, jogador))
            return true;
        if (coluna < y - 1 && campo[linha, coluna + 1] == jogador && VerificaLiberdade(linha, coluna + 1, jogador))
            return true;

        return false;
    }

    public bool setCampo(int linha, int coluna, char jogador, bool jogador1)
    {
        campo[linha, coluna] = jogador;

        return !jogador1;
    }

    public bool VerificaVitória(int contadorJogador1, int contadorJogador2)
    {
        // Verifica se ambos os jogadores ficaram sem pedras
        if(contadorJogador1  <= 0 && contadorJogador2 <= 0)
        {
            bool jogador1SemPedras = pontuacaoJogador1 >= 0;
            bool jogador2SemPedras = pontuacaoJogador2 >= 0;
            if (jogador1SemPedras && jogador2SemPedras)
            {
                Console.WriteLine("Ambos os jogadores ficaram sem pedras. Jogo encerrado!");
                return true;
            }

        }

        return false;
    }
}
