using System;
using ConwaysGameOfLife.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife.Helpers
{
    public static class GridHelper
    {
        
        public static void RenderGrid(int[,] nextGenerationArray)
        {
            Console.Clear();
            for (int i = 0; i < nextGenerationArray.GetLength(0); i++)
            {
                for (int j = 0; j < nextGenerationArray.GetLength(1); j++)
                {
                    Console.Write(nextGenerationArray[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static int[,] GenerateNextGeneration(int[,] currentGenerationArray)
        {
            int[,] nextGenerationArray = new int[currentGenerationArray.GetLength(0),currentGenerationArray.GetLength(1)];

            for(int i = 0; i < currentGenerationArray.GetLength(0); i++)
            {
                for (int j = 0; j < currentGenerationArray.GetLength(1); j++)
                {
                    CellHelper.GetNextGeneration(currentGenerationArray);
                }
            }
            return nextGenerationArray;
        }

        public static int[,] CreateInitialContainer(int[,] currentGeneration = null, int xSize = 10, int ySize = 10)
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

        

        public static int[,] GenerateGlider()
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
