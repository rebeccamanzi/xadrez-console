using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor; //irá retornar True se aquela posição estiver nula ou com uma peça do adversário
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // criando uma matriz de bool para mov possíveis [true]

            Posicao pos = new Posicao(0, 0);

            //acima:
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) // caso a posição esteja ocupada com uma peca da outra cor
                {
                    break; //interromper (não poderá passar pela peça adversária e continuar andando)
                }
                pos.linha = pos.linha - 1; // bjeto p cima (irá continuar subindo casas até chegar no limite ou capturar uma peca adversaria)
            }

            //abaixo:          
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) 
                {
                    break;
                }
                pos.linha = pos.linha + 1; // objeto p baixo
            }

            //direita:
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) 
                {
                    break;
                }
                pos.coluna = pos.coluna + 1; 
            }


            //esquerda:
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) // caso a posição esteja ocupada com uma peca da outra cor
                {
                    break; 
                }
                pos.coluna = pos.coluna - 1; // bjeto p cima (irá continuar subindo casas até chegar no limite ou capturar uma peca adversaria)
            }

            return mat;
        }
    }
}
