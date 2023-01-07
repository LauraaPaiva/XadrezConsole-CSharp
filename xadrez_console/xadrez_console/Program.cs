using tabuleiro;
using xadrez;
using xadrez_console;
using exceptions;


try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();
    Tela.imprimirTabuleiro(partida.tab);
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}




Console.WriteLine();




