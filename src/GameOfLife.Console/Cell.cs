using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Console
{
    public class Cell
    {
        public bool Vivo { get; set; }
        public long X { get; set; }
        public long Y { get; set; }

        public Cell(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }

        public Cell(long x, long y, bool vivo)
        {
            Vivo = vivo;
            X = x;
            Y = y;
        }

        public bool Evoluir(Cell[,] grid)
        {
            byte vivos = 0;
            byte mortos = 0;

            var celulasVizinhas = new[] {
                new {x = X - 1, y = Y - 1}, //1
                new {x = X, y = Y-1 }, //2
                new {x = X + 1, y = Y - 1}, //3
                new {x = X - 1, y = Y}, //4
                new {x = X + 1, y = Y}, //6
                new {x = X - 1, y = Y + 1}, //7
                new {x = X, y = Y + 1}, //8
                new {x = X + 1, y = Y + 1}, //9
            };

            foreach (var celula in celulasVizinhas)
            {
                var cell = GetCell(grid, celula.x, celula.y);
                CalcularVida(ref vivos, ref mortos, cell);
            }

            if (Vivo && (vivos == 2 || vivos == 3))
                return true;

            if (!Vivo && vivos == 3)
                return true;

            return false;
        }

        private Cell GetCell(Cell[,] grid, long x, long y)
        {
            return grid[x, y];
        }

        private object[] GetCelulasVizinhas()
        {
            return new[] {
                new {x = X - 1, y = Y - 1}, //1
                new {x = X, y = Y-1 }, //2
                new {x = X + 1, y = Y - 1}, //3
                new {x = X - 1, y = Y}, //4
                new {x = X + 1, y = Y}, //6
                new {x = X - 1, y = Y + 1}, //7
                new {x = X, y = Y + 1}, //8
                new {x = X + 1, y = Y + 1} //9
            };
        }

        private static void CalcularVida(ref byte vivos, ref byte mortos, Cell cell)
        {
            if (cell.Vivo)
            {
                vivos++;
            }
            else
            {
                mortos++;
            }
        }
    }
}
