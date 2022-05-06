using GameOfLife.Console;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        private Game game;

        public GameTests()
        {
            game = new Game();
            game.CriarGridVazio(12);
        }

        [Fact]
        public void DevePermitirSomenteGridsQuadrados()
        {
            Assert.Equal(2, game.Grid.Rank);
        }

        [Fact]
        public void DevePossuirLarguraIgualA12()
        {
            Assert.Equal(12 + 2, game.Grid.GetLength(0));
        }

        [Fact]
        public void DevePossuirAlturaIgualA12()
        {
            Assert.Equal(12 + 2, game.Grid.GetLength(1));
        }
    }
}
