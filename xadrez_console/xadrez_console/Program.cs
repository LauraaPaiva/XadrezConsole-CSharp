using tabuleiro;
using xadrez;
using xadrez_console;
using exceptions;

Tabuleiro tab = new Tabuleiro(8, 8);

tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(0, 0));
tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(1, 1));
tab.colocarPeca(new Rei(tab, Cor.Amarela), new Posicao(2, 2));

Tela.imprimirTabuleiro(tab);




