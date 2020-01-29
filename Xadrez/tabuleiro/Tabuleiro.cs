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

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos); // irá testar se a posição é valida (caso não seja, pula para a exceção e gera a msg de erro)
            return peca(pos) != null; //se for True, a posição já está ocupada por uma peca
        }
        
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }
            pecas[pos.linha, pos.coluna] = p; // colocando a peça p na posição pos
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
                return null;
            Peca aux = peca(pos);
            aux.posicao = null; //deixando a posição da peca livre
            pecas[pos.linha, pos.coluna] = null; //retirando a peca da matriz pecas
            return aux; //retornará a peça que foi retirada
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
                return false;
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos)) // caso a posição não seja válida(verificada no posicaoValida), irá lançar uma exceção
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }



    }
}
