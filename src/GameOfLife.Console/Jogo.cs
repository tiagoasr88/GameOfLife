namespace GameOfLife.Console
{
    public class Jogo
    {
        public Celula[,] Tabuleiro { get; set; }

        public void CriarTabuleiroVazio(long tamanho)
        {
            var tabuleiro = new Celula[tamanho + 2, tamanho + 2];

            this.Tabuleiro = PopularTabuleiroVazio(tabuleiro);
        }

        private Celula[,] PopularTabuleiroVazio(Celula[,] tabuleiro)
        {
            for (int x = 0; x < tabuleiro.GetLength(0); x++)
            {
                for (int y = 0; y < tabuleiro.GetLength(1); y++)
                {
                    tabuleiro[x, y] = new Celula(x, y);
                }
            }

            return tabuleiro;
        }

        public void CriarPopulacao(long quantidadeCelulas)
        {
            var rnd = new Random();

            for (int i = 1; i < quantidadeCelulas - 1; i++)
            {
                Tabuleiro[rnd.NextInt64(0, Tabuleiro.GetLength(0) - 2), rnd.NextInt64(0, Tabuleiro.GetLength(1) - 2)].Vivo = true;
            }
        }

        public Celula[,] Evoluir()
        {
            var novoTabuleiro = new Celula[this.Tabuleiro.GetLength(0), this.Tabuleiro.GetLength(1)];
            novoTabuleiro = PopularTabuleiroVazio(novoTabuleiro);

            for (int x = 1; x < Tabuleiro.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < Tabuleiro.GetLength(1) - 1; y++)
                {
                    var cell = GetCelula(Tabuleiro, x, y);
                    Celula[] celulasVizinhas = GetCelulasVizinhas(cell);

                    novoTabuleiro[x, y] = new Celula(x, y, this.Tabuleiro[x, y].Evoluir(celulasVizinhas));
                }
            }

            return novoTabuleiro;
        }

        private Celula[] GetCelulasVizinhas(Celula cell) => new Celula[] {
                        GetCelula(Tabuleiro ,cell.X - 1, cell.Y - 1), //1
                        GetCelula(Tabuleiro ,cell.X, cell.Y-1 ), //2
                        GetCelula(Tabuleiro ,cell.X + 1, cell.Y - 1), //3
                        GetCelula(Tabuleiro ,cell.X - 1, cell.Y), //4
                        GetCelula(Tabuleiro ,cell.X + 1, cell.Y), //6
                        GetCelula(Tabuleiro ,cell.X - 1, cell.Y + 1), //7
                        GetCelula(Tabuleiro ,cell.X, cell.Y + 1), //8
                        GetCelula(Tabuleiro ,cell.X + 1, cell.Y + 1) //9
                    };

        private Celula GetCelula(Celula[,] grid, long x, long y) => grid[x, y];
    }
}
