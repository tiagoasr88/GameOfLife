using GameOfLife.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTests
    {
        public Game game { get; set; }

        public CellTests()
        {
            game = new Game();
            game.CriarGridVazio(200);

            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    game.Grid[x, y] = new Cell(x, y);
                }
            }

            game.Grid[20, 20] = new Cell(20, 20, true); //5
            game.Grid[21, 19] = new Cell(21, 19, true); //3
            game.Grid[19, 20] = new Cell(19, 20, true); //4
            game.Grid[21, 20] = new Cell(21, 20, true); //6
            game.Grid[19, 21] = new Cell(19, 21, true); //7


            game.Grid[40, 40] = new Cell(40, 40, true); //5


            game.Grid[120, 120] = new Cell(120, 120, true); //5
            game.Grid[121, 119] = new Cell(119, 120, true); //3
            game.Grid[119, 120] = new Cell(119, 120, true); //4


            game.Grid[150, 150] = new Cell(150, 150, true); //5
            game.Grid[151, 149] = new Cell(151, 149, true); //3
            game.Grid[149, 150] = new Cell(149, 150, true); //4
            game.Grid[151, 150] = new Cell(151, 150, true); //6


            game.Grid[80, 80] = new Cell(80, 80, false); //5
            game.Grid[81, 79] = new Cell(81, 79, true); //3
            game.Grid[79, 80] = new Cell(79, 80, true); //4
            game.Grid[81, 80] = new Cell(81, 80, true); //6

        }

        [Fact]
        public void DeveMorrerCelulaComMenosDeDoisVizinhosVivos()
        {
            var ret = game.Grid[40, 40].Evoluir(game.Grid);

            Assert.False(ret);
        }

        [Fact]
        public void DeveMorrerCelulaComMaisDeTresVizinhosVivos()
        {
            var ret = game.Grid[20, 20].Evoluir(game.Grid);

            Assert.False(ret);
        }

        [Fact]
        public void DeveContinuarVivaCelulaComDoisVizinhosVivos()
        {
            var ret = game.Grid[120, 120].Evoluir(game.Grid);

            Assert.True(ret);
        }

        [Fact]
        public void DeveContinuarVivaCelulaComTresVizinhosVivos()
        {
            var ret = game.Grid[150, 150].Evoluir(game.Grid);

            Assert.True(ret);
        }

        [Fact]
        public void DeveNascerCelulaComTresVizinhosVivos()
        {
            var ret = game.Grid[80, 80].Evoluir(game.Grid);

            Assert.True(ret);
        }
    }
}
