﻿using tabuleiro;
using xadrez;
using xadrez_console;
using exceptions;


try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();
    while (!partida.terminada)
    {
        Console.Clear();
        Console.WriteLine();

        Tela.imprimirTabuleiro(partida.tab);

        Console.WriteLine();

        Console.Write("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

        Console.Clear();
        Console.WriteLine();

        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

        Console.WriteLine();
        Console.Write("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

        partida.executaMovimento(origem, destino);
    }
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}




Console.WriteLine();




