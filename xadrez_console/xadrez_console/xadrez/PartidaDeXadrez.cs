using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using exceptions;


namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada  { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Azul;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQuantidadeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

        }
        
        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Azul)
            {
                jogadorAtual = Cor.Vermelho;
            }
            else
            {
                jogadorAtual = Cor.Azul;
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Vermelho), new PosicaoXadrez('a', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Vermelho), new PosicaoXadrez('b', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Vermelho), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Vermelho), new PosicaoXadrez('d', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Azul), new PosicaoXadrez('a', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Azul), new PosicaoXadrez('b', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Azul), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Azul), new PosicaoXadrez('d', 1).toPosicao());

        }

    }
}
