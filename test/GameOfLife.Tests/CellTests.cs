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
            var cell = game.Grid[x, y];
            Cell[] celulasvizinhas = GetCelulasVizinhas(cell);

            var ret = cell.Evoluir(celulasvizinhas);
            return ret;
        }

        private Cell[] GetCelulasVizinhas(Cell cell)
        {
            Cell[] celulasvizinhas = new[]
            {
                game.Grid[cell.X - 1, cell.Y - 1], //1
                game.Grid[cell.X, cell.Y - 1], //2
                game.Grid[cell.X + 1, cell.Y - 1], //3
                game.Grid[cell.X - 1, cell.Y], //4
                game.Grid[cell.X + 1, cell.Y], //6
                game.Grid[cell.X - 1, cell.Y + 1], //7
                game.Grid[cell.X, cell.Y + 1], //8
                game.Grid[cell.X + 1, cell.Y + 1] //9
            };
            return celulasvizinhas;
        }
    }
}
