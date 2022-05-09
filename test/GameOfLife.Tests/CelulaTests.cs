using GameOfLife.Console;
using Xunit;

namespace GameOfLife.Tests
{
    public class CelulaTests
    {
        public Jogo jogo { get; set; }

        public CelulaTests()
        {
            jogo = new Jogo();
            jogo.CriarTabuleiroVazio(200);

            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    jogo.Tabuleiro[x, y] = new Celula(x, y);
                }
            }

            jogo.Tabuleiro[20, 20] = new Celula(20, 20, true); //5
            jogo.Tabuleiro[21, 19] = new Celula(21, 19, true); //3
            jogo.Tabuleiro[19, 20] = new Celula(19, 20, true); //4
            jogo.Tabuleiro[21, 20] = new Celula(21, 20, true); //6
            jogo.Tabuleiro[19, 21] = new Celula(19, 21, true); //7


            jogo.Tabuleiro[40, 40] = new Celula(40, 40, true); //5


            jogo.Tabuleiro[120, 120] = new Celula(120, 120, true); //5
            jogo.Tabuleiro[121, 119] = new Celula(119, 120, true); //3
            jogo.Tabuleiro[119, 120] = new Celula(119, 120, true); //4


            jogo.Tabuleiro[150, 150] = new Celula(150, 150, true); //5
            jogo.Tabuleiro[151, 149] = new Celula(151, 149, true); //3
            jogo.Tabuleiro[149, 150] = new Celula(149, 150, true); //4
            jogo.Tabuleiro[151, 150] = new Celula(151, 150, true); //6


            jogo.Tabuleiro[80, 80] = new Celula(80, 80, false); //5
            jogo.Tabuleiro[81, 79] = new Celula(81, 79, true); //3
            jogo.Tabuleiro[79, 80] = new Celula(79, 80, true); //4
            jogo.Tabuleiro[81, 80] = new Celula(81, 80, true); //6

        }

        [Fact]
        public void DeveMorrerCelulaComMenosDeDoisVizinhosVivos()
        {
            bool ret = ExecutarTeste(40, 40);
            Assert.False(ret);
        }

        [Fact]
        public void DeveMorrerCelulaComMaisDeTresVizinhosVivos()
        {
            bool ret = ExecutarTeste(20, 20);
            Assert.False(ret);
        }

        [Fact]
        public void DeveContinuarVivaCelulaComDoisVizinhosVivos()
        {
            bool ret = ExecutarTeste(120, 120);

            Assert.True(ret);
        }

        [Fact]
        public void DeveContinuarVivaCelulaComTresVizinhosVivos()
        {
            bool ret = ExecutarTeste(150, 150);

            Assert.True(ret);
        }

        [Fact]
        public void DeveNascerCelulaComTresVizinhosVivos()
        {
            bool ret = ExecutarTeste(80, 80);

            Assert.True(ret);
        }

        private bool ExecutarTeste(byte x, byte y)
        {
            var celula = jogo.Tabuleiro[x, y];
            Celula[] celulasvizinhas = GetCelulasVizinhas(celula);

            var ret = celula.Evoluir(celulasvizinhas);
            return ret;
        }

        private Celula[] GetCelulasVizinhas(Celula celula)
        {
            Celula[] celulasvizinhas = new[]
            {
                jogo.Tabuleiro[celula.X - 1, celula.Y - 1], //1
                jogo.Tabuleiro[celula.X, celula.Y - 1], //2
                jogo.Tabuleiro[celula.X + 1, celula.Y - 1], //3
                jogo.Tabuleiro[celula.X - 1, celula.Y], //4
                jogo.Tabuleiro[celula.X + 1, celula.Y], //6
                jogo.Tabuleiro[celula.X - 1, celula.Y + 1], //7
                jogo.Tabuleiro[celula.X, celula.Y + 1], //8
                jogo.Tabuleiro[celula.X + 1, celula.Y + 1] //9
            };
            return celulasvizinhas;
        }
    }
}
