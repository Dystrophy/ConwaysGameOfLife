using ConwaysGameOfLife.Helpers;
using ConwaysGameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class GridTests
    {
        public Grid GameGrid;

        [TestInitialize]
        public void TestInitialize()
        {
            GameGrid = new Grid(10, 10);
        }

        [TestMethod]
        public void GenerateNextGeneration_ReturnsNewMultidimensionalBooleanArray()
        {
            var returnedVal = GameGrid.GenerateNextGeneration(new bool[1,1]);

            Assert.IsTrue(returnedVal.GetType() == typeof(bool[,]));
        }

        [TestMethod]
        public void GenerateNextGeneration_ReturnsNew2DBooleanArray_OfSameSizeAsPassedArray()
        {
            var returnedVal = GameGrid.GenerateNextGeneration(new bool[10, 10]);

            Assert.AreEqual(10, returnedVal.GetLength(0));
            Assert.AreEqual(10, returnedVal.GetLength(1));
        }

        [TestMethod]
        public void GenerateGlider_ReturnsAGLider()
        {
            var returnedArray = GameGrid.GenerateGlider();

            Assert.IsTrue(returnedArray[0, 1] == true);
            Assert.IsTrue(returnedArray[1, 2] == true);
            Assert.IsTrue(returnedArray[2, 2] == true);
            Assert.IsTrue(returnedArray[2, 1] == true);
            Assert.IsTrue(returnedArray[2, 0] == true);
        }

        [TestMethod]
        public void AGlider_WillGenerateAppropriateCells_OnNextGeneration()
        {
            var returnedArray = GameGrid.GenerateGlider();

            var nextGeneration = GameGrid.GetNextCellGeneration(returnedArray);

            Assert.IsTrue(nextGeneration[1, 0] == true);
            Assert.IsTrue(nextGeneration[1, 2] == true);
            Assert.IsTrue(nextGeneration[2, 2] == true);
            Assert.IsTrue(nextGeneration[2, 1] == true);
            Assert.IsTrue(nextGeneration[3, 1] == true);

            
        }

        [TestMethod]
        public void CreateInitialContainer_SetsIntialStateOfGame_ToStateThatIsPassedIn()
        {
            var gliderState = GameGrid.GenerateGlider();

            var returnedArray = GameGrid.CreateInitialContainer(gliderState);

            Assert.IsTrue(returnedArray[0, 1] == true);
            Assert.IsTrue(returnedArray[1, 2] == true);
            Assert.IsTrue(returnedArray[2, 2] == true);
            Assert.IsTrue(returnedArray[2, 1] == true);
            Assert.IsTrue(returnedArray[2, 0] == true);
        }

        [TestMethod]
        public void GenerateNextGeneration_CellWillBecomeAliveWhenExactly3Neighbours()
        {
            var cellArray = new bool[2, 2];

            cellArray[0, 0] = false;
            cellArray[0, 1] = true;
            cellArray[1, 0] = true;
            cellArray[1, 1] = true;

            var returnedArray = GameGrid.GetNextCellGeneration(cellArray);

            Assert.IsTrue(returnedArray[0, 0] == true );
        }

        [TestMethod]
        public void GetNextGeneration_ReturnsAnArrayOfSameSizeAsPassedArray()
        {
            var returnedVal = GameGrid.GetNextCellGeneration(new bool[3, 3]);

            Assert.IsTrue(returnedVal.GetLength(0) == 3);
            Assert.IsTrue(returnedVal.GetLength(1) == 3);
        }

        [TestMethod]
        public void DeadCellWithExactly3Neighbours_WillBeAliveNextGneration()
        {
            var returnedVal = GameGrid.IsCellAlive(3, false);

            Assert.AreEqual(true, returnedVal);
        }

        [TestMethod]
        public void IsCellAlive_ReturnsTrueWhenCellHas2Neighbours()
        {
            var returnedVal = GameGrid.IsCellAlive(2, true);

            Assert.AreEqual(true, returnedVal);
        }

        [TestMethod]
        public void IsCellAlive_ReturnsFalseWhenCellHasMoreThan3Neighbours()
        {
            var returnedVal = GameGrid.IsCellAlive(4, true);

            Assert.AreEqual(false, returnedVal);
        }

        [TestMethod]
        public void IsCellAlive_ReturnsFalseWhenCellHasLessThan2Neighbours()
        {
            var returnedVal = GameGrid.IsCellAlive(1, true);

            Assert.AreEqual(false, returnedVal);
        }

        [TestMethod]
        public void GetCellNeighbours_Returns3_WhenGiveAPositionWith3Neighbours()
        {
            var cellArray = new bool[2, 2];
            cellArray[0, 0] = true;
            cellArray[0, 1] = true;
            cellArray[1, 0] = true;
            cellArray[1, 1] = true;

            var neighbours = GameGrid.GetCellNeighbours(cellArray, 0, 0);

            Assert.IsTrue(neighbours == 3);
        }

        [TestMethod]
        public void GetCellNeighbours_Returns0_WhenGivenAPositionWith0Neighbours()
        {
            var cellArray = new bool[3, 3];
            cellArray[0, 0] = false;
            cellArray[0, 1] = false;
            cellArray[0, 2] = false;

            cellArray[1, 0] = false;
            cellArray[1, 1] = true;
            cellArray[1, 2] = false;

            cellArray[2, 0] = false;
            cellArray[2, 1] = false;
            cellArray[2, 2] = false;

            var neighbours = GameGrid.GetCellNeighbours(cellArray, 1, 1);

            Assert.IsTrue(neighbours == 0);
        }

        [TestMethod]
        public void GetNextGeneration_ReturnsArrayWithSameSize()
        {
            var cellArray = new bool[2, 2];

            var returnedGeneration = GameGrid.GetNextCellGeneration(cellArray);

            Assert.IsTrue(cellArray.GetLength(0) == returnedGeneration.GetLength(0));
            Assert.IsTrue(cellArray.GetLength(1) == returnedGeneration.GetLength(1));
        }

        [TestMethod]
        public void GetNextGeneration_CellWillBecomeAliveWhen3Neighbours()
        {
            var cellArray = new bool[2, 2];

            cellArray[0, 0] = false;
            cellArray[0, 1] = true;
            cellArray[1, 0] = true;
            cellArray[1, 1] = true;

            var returnedArray = GameGrid.GetNextCellGeneration(cellArray);

            Assert.IsTrue(returnedArray[0, 0] == true);
        }

        [TestMethod]
        public void ACellWithLessThan2Neighbours_WillDie_NextGeneration()
        {
            var cellArray = new bool[2, 2];

            cellArray[0, 0] = true;
            cellArray[0, 1] = false;
            cellArray[1, 0] = false;
            cellArray[1, 1] = false;

            var returnedArray = GameGrid.GetNextCellGeneration(cellArray);

            Assert.IsTrue(returnedArray[0, 0] == false);
        }

        [TestMethod]
        public void ACellWithMoreThan3Neighbours_WillDie_NextGeneration()
        {
            var cellArray = new bool[3, 3];

            cellArray[0, 0] = true;
            cellArray[0, 1] = false;
            cellArray[0, 2] = true;

            cellArray[1, 0] = false;
            cellArray[1, 1] = true;
            cellArray[1, 2] = false;

            cellArray[2, 0] = true;
            cellArray[2, 1] = false;
            cellArray[2, 2] = true;
            var returnedArray = GameGrid.GetNextCellGeneration(cellArray);

            Assert.IsTrue(returnedArray[1, 1] == false);
        }



    }
}
