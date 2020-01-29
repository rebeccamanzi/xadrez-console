using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a'); //o char a tem o valor de um inteiro, ex: 'b' (vale 2) - 'a'(vale 1) -> 1 (nº da coluna)
        }

        public override string ToString()
        {
            return "" + coluna + linha; 
        }
    }
}
