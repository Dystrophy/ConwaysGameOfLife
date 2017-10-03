using System;
using ConwaysGameOfLife.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife.Helpers
{
    public static class CellHelper
    {
        public static bool IsCellAlive(int numberOfNeighbours)
        {
            if (!(numberOfNeighbours >= 2 && numberOfNeighbours <= 3))
            {
                return false;
            }
            return true;
        }

        public static int NumberOfNeighbours(Cell cell)
        {
            return 0;
        }
    }
}
