using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConwaysGameOfLife.Models;
using System.Threading.Tasks;

namespace ConwaysGameOfLife.Models
{
    public class Grid
    {
        public int SizeX;
        public int SizeY;
        public bool[,] GridArray;

        public Grid(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.GridArray = new bool[this.SizeX, this.SizeY];
        }

        public bool[,] CreateInitialContainer(bool[,] currentGeneration = null, int xSize = 20, int ySize = 40)
        {
            var initialState = new bool[xSize, ySize];

            if (currentGeneration != null)
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

        public bool[,] GenerateNextGeneration(bool[,] currentGenerationArray)
        {
            bool[,] nextGenerationArray = new bool[currentGenerationArray.GetLength(0), currentGenerationArray.GetLength(1)];

            nextGenerationArray = GetNextCellGeneration(currentGenerationArray);

            return nextGenerationArray;
        }

        public bool[,] GetNextCellGeneration(bool[,] currentCellArray)
        {
            bool[,] nextGenerationCellArray = new bool[currentCellArray.GetLength(0), currentCellArray.GetLength(1)];
            for (int i = 0; i < nextGenerationCellArray.GetLength(0); i++)
            {
                for (int j = 0; j < nextGenerationCellArray.GetLength(1); j++)
                {
                    nextGenerationCellArray[i, j] = IsCellAlive(GetCellNeighbours(currentCellArray, i, j), currentCellArray[i, j]);
                }
            }
            return nextGenerationCellArray;
        }

        public int GetCellNeighbours(bool[,] cellArray, int i, int j)
        {
            int neighbours = 0;

            if (i + 1 < cellArray.GetLength(0))
            {
                if (cellArray[i + 1, j] == true)
                    neighbours++;
                if (j + 1 < cellArray.GetLength(1))
                {
                    if (cellArray[i + 1, j + 1] == true)
                        neighbours++;
                    if (cellArray[i, j + 1] == true)
                        neighbours++;
                }
            }

            if (i > 0)
            {
                if (cellArray[i - 1, j] == true)
                    neighbours++;
                if (j + 1 < cellArray.GetLength(1))
                {
                    if (cellArray[i - 1, j + 1] == true)
                        neighbours++;
                }
            }

            if (j > 0)
            {
                if (cellArray[i, j - 1] == true)
                    neighbours++;
                if (i + 1 < cellArray.GetLength(0))
                {
                    if (cellArray[i + 1, j - 1] == true)
                        neighbours++;
                }
            }

            if (i > 0 && j > 0)
            {
                if (cellArray[i - 1, j - 1] == true)
                    neighbours++;
            }

            return neighbours;
        }
        
        public bool IsCellAlive(int numberOfNeighbours, bool cellValue)
        {
            if (cellValue == false && numberOfNeighbours == 3)
            {
                return true;
            }

            if (cellValue == true && (numberOfNeighbours == 3 || numberOfNeighbours == 2))
            {
                return true;
            }

            return false;
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
    }
}
