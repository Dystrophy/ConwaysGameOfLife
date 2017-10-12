using ConwaysGameOfLife.Models;

namespace ConwaysGameOfLife.Helpers
{
    public class GridDomain
    {
        public CellDomain CellHelper;
       
        public int SizeX;
        public int SizeY;
        
        public GridDomain(int x, int y)
        {
            this.CellHelper = new CellDomain();
            this.SizeX = x;
            this.SizeY = y;
        }

        public int[,]  GenerateNextGeneration(int[,] currentGenerationArray)
        {
            //Remove all Int Arrays and begin refactoring
            int[,] nextGenerationArray = new int[currentGenerationArray.GetLength(0),currentGenerationArray.GetLength(1)];

            nextGenerationArray = CellHelper.GetNextCellGeneration(currentGenerationArray);
            
            return nextGenerationArray;
        }

        public int[,] CreateInitialContainer(int[,] currentGeneration = null, int xSize = 20, int ySize = 40)
        {
            //Begin Refactoring - Remove all the Int Arrays and Replace with Grid Objects
            //var initialS = new Grid(this.SizeX, this.SizeY);
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

        public int[,] GenerateBlinker()
        {
            var blinkerState = CreateInitialContainer();
            blinkerState[2, 1] = 1;
            blinkerState[2, 2] = 1;
            blinkerState[2, 3] = 1;
            return blinkerState;
        }

        public int[,] GenerateGosperGliderGun()
        {
            var gosperState = CreateInitialContainer();

            gosperState[5, 1] = 1;
            gosperState[5, 2] = 1;
            gosperState[6, 1] = 1;
            gosperState[6, 2] = 1;

            gosperState[5, 11] = 1;
            gosperState[6, 11] = 1;
            gosperState[7, 11] = 1;

            gosperState[4, 12] = 1;
            gosperState[8, 12] = 1;

            gosperState[3, 13] = 1;
            gosperState[9, 13] = 1;
            gosperState[3, 14] = 1;
            gosperState[9, 14] = 1;

            gosperState[6, 15] = 1;

            gosperState[4, 16] = 1;
            gosperState[8, 16] = 1;

            gosperState[5, 17] = 1;
            gosperState[6, 17] = 1;
            gosperState[7, 17] = 1;

            gosperState[6, 19] = 1;

            gosperState[3, 21] = 1;
            gosperState[4, 21] = 1;
            gosperState[5, 21] = 1;

            gosperState[3, 22] = 1;
            gosperState[4, 22] = 1;
            gosperState[5, 22] = 1;

            gosperState[2, 23] = 1;
            gosperState[6, 23] = 1;

            gosperState[1, 25] = 1;
            gosperState[2, 25] = 1;
            gosperState[6, 25] = 1;
            gosperState[7, 25] = 1;

            gosperState[3, 35] = 1;
            gosperState[4, 35] = 1;

            gosperState[3, 36] = 1;
            gosperState[4, 36] = 1;

            return gosperState;
        }

        
    }
}
