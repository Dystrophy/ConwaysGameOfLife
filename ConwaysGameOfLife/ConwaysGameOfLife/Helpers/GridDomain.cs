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

        public bool[,]  GenerateNextGeneration(bool[,] currentGenerationArray)
        {
            //Remove all Int Arrays and begin refactoring
            bool[,] nextGenerationArray = new bool[currentGenerationArray.GetLength(0),currentGenerationArray.GetLength(1)];

            nextGenerationArray = CellHelper.GetNextCellGeneration(currentGenerationArray);
            
            return nextGenerationArray;
        }

        public bool[,] CreateInitialContainer(bool[,] currentGeneration = null, int xSize = 20, int ySize = 40)
        {
            //Begin Refactoring - Remove all the Int Arrays and Replace with Grid Objects
            //var initialS = new Grid(this.SizeX, this.SizeY);
            var initialState = new bool[xSize, ySize];

            if(currentGeneration != null)
            {
                initialState = currentGeneration;
                return initialState;
            }

            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    initialState[i, j] = false;
                }
            }
            return initialState;
        }

        public bool[,] GenerateGlider()
        {
            var gliderState = CreateInitialContainer();
            gliderState[0, 1] = true;
            gliderState[1, 2] = true;
            gliderState[2, 2] = true;
            gliderState[2, 1] = true;
            gliderState[2, 0] = true;

            return gliderState;
        }

        //public int[,] GenerateBlinker()
        //{
        //    var blinkerState = CreateInitialContainer();
        //    blinkerState[2, 1] = 1;
        //    blinkerState[2, 2] = 1;
        //    blinkerState[2, 3] = 1;
        //    return blinkerState;
        //}

        public bool[,] GenerateGosperGliderGun()
        {
            var gosperState = CreateInitialContainer();

            gosperState[5, 1] = true;
            gosperState[5, 2] = true;
            gosperState[6, 1] = true;
            gosperState[6, 2] = true;

            gosperState[5, 11] = true;
            gosperState[6, 11] = true;
            gosperState[7, 11] = true;
            gosperState[4, 12] = true;
            gosperState[8, 12] = true;
            gosperState[3, 13] = true;
            gosperState[9, 13] = true;
            gosperState[3, 14] = true;
            gosperState[9, 14] = true;
            gosperState[6, 15] = true;
            gosperState[4, 16] = true;
            gosperState[8, 16] = true;
            gosperState[5, 17] = true;
            gosperState[6, 17] = true;
            gosperState[7, 17] = true;
            gosperState[6, 19] = true;
            gosperState[3, 21] = true;
            gosperState[4, 21] = true;
            gosperState[5, 21] = true;
            gosperState[3, 22] = true;
            gosperState[4, 22] = true;
            gosperState[5, 22] = true;
            gosperState[2, 23] = true;
            gosperState[6, 23] = true;
            gosperState[1, 25] = true;
            gosperState[2, 25] = true;
            gosperState[6, 25] = true;
            gosperState[7, 25] = true;
            gosperState[3, 35] = true;
            gosperState[4, 35] = true;
            gosperState[3, 36] = true;
            gosperState[4, 36] = true;

            return gosperState;
        }


    }
}
