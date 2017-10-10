using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife.Helpers
{
    public static class CellHelper
    {
        public static int[,] GetNextGeneration(int[,] currentCellArray)
        {
            int[,] nextGenerationCellArray = new int[currentCellArray.GetLength(0), currentCellArray.GetLength(1)];
            for(int i = 0; i < currentCellArray.GetLength(1); i++)
            {
                for(int j = 0; j < currentCellArray.GetLength(0); j++)
                {
                    nextGenerationCellArray[i, j] = IsCellAlive(GetCellNeighbours(currentCellArray, i, j));
                }
            }

            return nextGenerationCellArray;
        }

        public static int IsCellAlive(int numberOfNeighbours)
        {
            if (numberOfNeighbours > 3 || numberOfNeighbours < 2)
            {
                return 0;
            }
            return 1;
        }

        public static int GetCellNeighbours(int[,] cellArray, int i, int j)
        {
            int neighbours = 0;


            if (i + 1 < cellArray.GetLength(0))
            {
                if (cellArray[i + 1, j] == 1)
                    neighbours++;
                if (j + 1 < cellArray.GetLength(1))
                {
                    if (cellArray[i + 1, j + 1] == 1)
                        neighbours++;
                    if (cellArray[i, j + 1] == 1)
                        neighbours++;
                }
            }



            if(i > 0)
            {
                if (cellArray[i - 1, j] == 1)
                    neighbours++;
                if (j + 1 < cellArray.GetLength(1))
                {
                    if (cellArray[i - 1, j + 1] == 1)
                        neighbours++;
                }
            }

            if(j > 0)
            {
                if (cellArray[i, j - 1] == 1)
                    neighbours++;
                if (i + 1 < cellArray.GetLength(0))
                {
                    if (cellArray[i + 1, j - 1] == 1)
                        neighbours++;
                }
            }

            if(i > 0 && j > 0)
            {
                if (cellArray[i - 1, j - 1] == 1)
                    neighbours++;
            }

            return neighbours;
        }
    }
}
