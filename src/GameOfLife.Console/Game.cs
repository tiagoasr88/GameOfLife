using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Console
{
    public class Game
    {
        public Cell[,] Grid { get; set; }

        public void CriarGridVazio(long tamanho)
        {
            var grid = new Cell[tamanho + 2, tamanho + 2];

            this.Grid = PopularGridVazio(grid);
        }

        private Cell[,] PopularGridVazio(Cell[,] grid)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    grid[x, y] = new Cell(x, y);
                }
            }

            return grid;
        }

        public void CriarPopulacao(long quantidadeCelulas)
        {
            var rnd = new Random();

            for (int i = 1; i < quantidadeCelulas - 1; i++)
            {
                Grid[rnd.NextInt64(0, Grid.GetLength(0) - 2), rnd.NextInt64(0, Grid.GetLength(1) - 2)].Vivo = true;
            }
        }

        public Cell[,] Evoluir()
        {
            var novoGrid = new Cell[this.Grid.GetLength(0), this.Grid.GetLength(1)];
            novoGrid = PopularGridVazio(novoGrid);

            for (int x = 1; x < Grid.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < Grid.GetLength(1) - 1; y++)
                {
                    var cell = GetCell(Grid, x, y);
                    Cell[] celulasVizinhas = GetCelulasVizinhas(cell);

                    novoGrid[x, y] = new Cell(x, y, this.Grid[x, y].Evoluir(celulasVizinhas));
                }
            }

            return novoGrid;
        }

        private Cell[] GetCelulasVizinhas(Cell cell) => new Cell[] {
                        GetCell(Grid ,cell.X - 1, cell.Y - 1), //1
                        GetCell(Grid ,cell.X, cell.Y-1 ), //2
                        GetCell(Grid ,cell.X + 1, cell.Y - 1), //3
                        GetCell(Grid ,cell.X - 1, cell.Y), //4
                        GetCell(Grid ,cell.X + 1, cell.Y), //6
                        GetCell(Grid ,cell.X - 1, cell.Y + 1), //7
                        GetCell(Grid ,cell.X, cell.Y + 1), //8
                        GetCell(Grid ,cell.X + 1, cell.Y + 1) //9
                    };

        private Cell GetCell(Cell[,] grid, long x, long y) => grid[x, y];
    }
}
