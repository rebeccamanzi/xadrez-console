namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas,colunas];
        }

        public Peca peca(int linha, int coluna) // para poder acessar uma peça (pois a matriz pecas[,] está protegida)
        {
            return pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p; // colocando a peça p na posição pos
            p.posicao = pos;
        }


    }
}
