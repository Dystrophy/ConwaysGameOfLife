using System;

namespace ConwaysGameOfLife.Helpers
{
    public class GridPresentation
    {
        public void RenderArray(int[,] generationArray)
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
    }
}
