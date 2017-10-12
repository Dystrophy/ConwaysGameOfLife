using System;

namespace ConwaysGameOfLife.Helpers
{
    public class GridPresentation
    {
        public void RenderArray(bool[,] generationArray)
        {
            Console.Clear();
            for (int i = 0; i < generationArray.GetLength(0); i++)
            {
                for (int j = 0; j < generationArray.GetLength(1); j++)
                {
                    if (generationArray[i, j] == true)
                    {
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
