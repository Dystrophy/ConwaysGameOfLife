namespace ConwaysGameOfLife.Helpers
{
    public class CellDomain
    {
        public int[,] GetNextCellGeneration(int[,] currentCellArray)
        {
            int isAlive;
            int neighbours;
            int[,] nextGenerationCellArray = new int[currentCellArray.GetLength(0), currentCellArray.GetLength(1)];
            for(int i = 0; i < nextGenerationCellArray.GetLength(0); i++)
            {
                for(int j = 0; j < nextGenerationCellArray.GetLength(1); j++)
                {
                    neighbours = GetCellNeighbours(currentCellArray, i, j);
                    isAlive = IsCellAlive(neighbours, currentCellArray[i, j]);
                    nextGenerationCellArray[i , j] = isAlive;
                }
            }

            return nextGenerationCellArray;
        }


        public int GetCellNeighbours(int[,] cellArray, int i, int j)
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

        public int IsCellAlive(int numberOfNeighbours, int cellValue)
        {
            if (cellValue == 0 && numberOfNeighbours == 3)
            {
                return 1;
            }

            if (cellValue == 1 && (numberOfNeighbours == 3 || numberOfNeighbours == 2))
            {
                return 1;
            }

            return 0;
        }
    }
}
