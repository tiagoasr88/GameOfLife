using GameOfLife.Console;
using Xunit;

namespace GameOfLife.Tests
{
    public class JogoTests
    {
        private Jogo jogo;

        public JogoTests()
        {
            jogo = new Jogo();
            jogo.CriarTabuleiroVazio(12);
        }

        [Fact]
        public void DevePermitirSomenteGridsQuadrados()
        {
            Assert.Equal(2, jogo.Tabuleiro.Rank);
        }

        [Fact]
        public void DevePossuirLarguraIgualA12()
        {
            Assert.Equal(12 + 2, jogo.Tabuleiro.GetLength(0));
        }

        [Fact]
        public void DevePossuirAlturaIgualA12()
        {
            Assert.Equal(12 + 2, jogo.Tabuleiro.GetLength(1));
        }
    }
}
