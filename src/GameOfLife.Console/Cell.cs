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

        public bool Evoluir(Cell[] celulasVizinhas)
        {
            var vivos = CalcularSobreviventes(celulasVizinhas);

            if (Vivo && (vivos == 2 || vivos == 3))
                return true;

            if (!Vivo && vivos == 3)
                return true;

            return false;
        }

        private byte CalcularSobreviventes(Cell[] celulasVizinhas)
        {
            byte vivos = 0;

            foreach (var celula in celulasVizinhas)
            {
                if (celula.Vivo) vivos++;
            }

            return vivos;
        }
    }
}
