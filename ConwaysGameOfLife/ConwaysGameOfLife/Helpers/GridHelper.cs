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
        public CellHelper CellHelper;

        public GridHelper()
        {
            CellHelper = new CellHelper();
        }

        public void RenderGrid(int[,] generationArray)
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
            
        }

        public int[,]  GenerateNextGeneration(int[,] currentGenerationArray)
        {
            int[,] nextGenerationArray = new int[currentGenerationArray.GetLength(0),currentGenerationArray.GetLength(1)];

            nextGenerationArray = CellHelper.GetNextGeneration(currentGenerationArray);
            
            return nextGenerationArray;
        }

        public int[,] CreateInitialContainer(int[,] currentGeneration = null, int xSize = 20, int ySize = 40)
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
