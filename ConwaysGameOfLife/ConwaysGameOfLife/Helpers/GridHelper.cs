using System;
using ConwaysGameOfLife.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConwaysGameOfLife.Helpers
{
    public class GridHelper
    {
        CellHelper cellHelper;

        public GridHelper()
        {
            cellHelper = new CellHelper();
        }

        public int[,] RenderGrid(int[,] generationArray)
        {
            Console.Clear();
            for (int i = 0; i < generationArray.GetLength(0); i++)
            {
                for (int j = 0; j < generationArray.GetLength(1); j++)
                {
                    Console.Write(generationArray[i, j]);
                }
                Console.WriteLine();
            }
            return GenerateNextGeneration(generationArray);
        }

        public int[,] GenerateNextGeneration(int[,] currentGenerationArray)
        {
            int[,] nextGenerationArray = new int[currentGenerationArray.GetLength(0),currentGenerationArray.GetLength(1)];

            for(int i = 0; i < currentGenerationArray.GetLength(0); i++)
            {
                for (int j = 0; j < currentGenerationArray.GetLength(1); j++)
                {
                    cellHelper.GetNextGeneration(currentGenerationArray);
                }
            }
            return nextGenerationArray;
        }

        public int[,] CreateInitialContainer(int[,] currentGeneration = null, int xSize = 10, int ySize = 10)
        {
            var initialState = new int[xSize, ySize];

            if(currentGeneration != null)
            {
                initialState = currentGeneration;
                return initialState;
            }

            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    initialState[i, j] = 0;
                }
            }
            return initialState;
        }

        public int[,] GenerateGlider()
        {
            var gliderState = CreateInitialContainer();
            gliderState[0, 1] = 1;
            gliderState[1, 2] = 1;
            gliderState[2, 2] = 1;
            gliderState[2, 1] = 1;
            gliderState[2, 0] = 1;

            return gliderState;
        }


    }
}
