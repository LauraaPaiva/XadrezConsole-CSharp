using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPeca(Peca p)
        {
            if (p == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (p.cor == Cor.Vermelho)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(p);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(p);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkMagenta;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("(");
            Console.Write(conjunto.Count().ToString());
            Console.Write("): ");
            foreach (Peca p in conjunto)
            {
                Console.Write(p + " ");
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine();
            Console.WriteLine("Peças capturadas:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Azuis ");            
            imprimirConjunto(partida.pecasCapturadas(Cor.Azul));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Vermelhas ");            
            imprimirConjunto(partida.pecasCapturadas(Cor.Vermelho));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }

        public static void imprimirJogador(PartidaDeXadrez partida)
        {
            if(partida.jogadorAtual == Cor.Azul)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (partida.jogadorAtual == Cor.Vermelho)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(partida.jogadorAtual);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void imprimirInformacoesDoTurno(PartidaDeXadrez partida)
        {
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.Write("Aguardando jogador: ");
            Tela.imprimirJogador(partida);

            Console.WriteLine();
        }

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            Console.Clear();
            Console.WriteLine();

            Tela.imprimirTabuleiro(partida.tab);

            Tela.imprimirPecasCapturadas(partida);

            Tela.imprimirInformacoesDoTurno(partida);

        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

    }
}
