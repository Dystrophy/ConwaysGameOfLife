namespace ConwaysGameOfLife.Helpers
{
    public class CellDomain
    {

        //Begin Refactoring - Remove all Integer arrays and replace with Grid Objects
        //Remove all instances of Integers being set to 0 or 1 and replace with a Cell object
        //Cell objects should have a factory method

        public int[,] GetNextCellGeneration(int[,] currentCellArray)
        {
            int[,] nextGenerationCellArray = new int[currentCellArray.GetLength(0), currentCellArray.GetLength(1)];
            for(int i = 0; i < nextGenerationCellArray.GetLength(0); i++)
            {
                for(int j = 0; j < nextGenerationCellArray.GetLength(1); j++)
                {
                    nextGenerationCellArray[i, j] = IsCellAlive(GetCellNeighbours(currentCellArray, i, j), currentCellArray[i, j]);
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
