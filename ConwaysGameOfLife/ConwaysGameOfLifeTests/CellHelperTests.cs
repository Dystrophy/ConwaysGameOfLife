using System;
using ConwaysGameOfLife.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class CellHelperTests
    {
        GridHelper gridHelper;
        CellHelper cellHelper;
        [TestInitialize]
        public void TestInitialize()
        {
            gridHelper = new GridHelper();
            cellHelper = new CellHelper();
        }

        [TestMethod]
        public void GetNextGeneration_ReturnsAnArrayOfSameSizeAsPassedArray()
        {
            var returnedVal = cellHelper.GetNextGeneration(new int[3, 3]);

            Assert.IsTrue(returnedVal.GetLength(0) == 3);
            Assert.IsTrue(returnedVal.GetLength(1) == 3);
        }

        [TestMethod]
        public void DeadCellWithExactly3Neighbours_WillBeAliveNExtGneration()
        {
            var returnedVal = cellHelper.IsCellAlive(3, 0);

            Assert.AreEqual(1, returnedVal);
        }



        [TestMethod]
        public void IsCellAlive_Returns1WhenCellHas2Neighbours()
        {
            var returnedVal = cellHelper.IsCellAlive(2, 1);

            Assert.AreEqual(1, returnedVal);
        }

        [TestMethod]
        public void IsCellAlive_Returns0WhenCellHasMoreThan3Neighbours()
        {
            var returnedVal = cellHelper.IsCellAlive(4, 1);

            Assert.AreEqual(0, returnedVal);
        }

        [TestMethod]
        public void IsCellAlive_Returns0WhenCellHasLessThan2Neighbours()
        {
            var returnedVal = cellHelper.IsCellAlive(1, 1);

            Assert.AreEqual(0, returnedVal);
        }

        [TestMethod]
        public void GetCellNeighbours_Returns3_WhenGiveAPositionWith3Neighbours()
        {
            var cellArray = new int[2, 2];
            cellArray[0, 0] = 1;
            cellArray[0, 1] = 1;
            cellArray[1, 0] = 1;
            cellArray[1, 1] = 1;

            var neighbours = cellHelper.GetCellNeighbours(cellArray, 0, 0);

            Assert.IsTrue(neighbours == 3);
        }

        [TestMethod]
        public void GetCellNeighbours_Returns0_WhenGivenAPositionWith0Neighbours()
        {
            var cellArray = new int[3, 3];
            cellArray[0, 0] = 0;
            cellArray[0, 1] = 0;
            cellArray[0, 2] = 0;

            cellArray[1, 0] = 0;
            cellArray[1, 1] = 1;
            cellArray[1, 2] = 0;

            cellArray[2, 0] = 0;
            cellArray[2, 1] = 0;
            cellArray[2, 2] = 0;

            var neighbours = cellHelper.GetCellNeighbours(cellArray, 1, 1);

            Assert.IsTrue(neighbours == 0);
        }

        [TestMethod]
        public void GetNextGeneration_ReturnsArrayWithSameSize()
        {
            var cellArray = new int[2, 2];

            var returnedGeneration = cellHelper.GetNextGeneration(cellArray);

            Assert.IsTrue(cellArray.GetLength(0) == returnedGeneration.GetLength(0));
            Assert.IsTrue(cellArray.GetLength(1) == returnedGeneration.GetLength(1));
        }

        [TestMethod]
        public void GetNextGeneration_CellWillBecomeAliveWhen3Neighbours()
        {
            var cellArray = new int[2, 2];

            cellArray[0, 0] = 0;
            cellArray[0, 1] = 1;
            cellArray[1, 0] = 1;
            cellArray[1, 1] = 1;

            var returnedArray = cellHelper.GetNextGeneration(cellArray);

            Assert.IsTrue(returnedArray[0, 0] == 1);
        }

        [TestMethod]
        public void ACellWithLessThan2Neighbours_WillDie_NextGeneration()
        {
            var cellArray = new int[2, 2];

            cellArray[0, 0] = 1;
            cellArray[0, 1] = 0;
            cellArray[1, 0] = 0;
            cellArray[1, 1] = 0;

            var returnedArray = cellHelper.GetNextGeneration(cellArray);

            Assert.IsTrue(returnedArray[0, 0] == 0);
        }

        [TestMethod]
        public void ACellWithMoreThan3Neighbours_WillDie_NextGeneration()
        {
            var cellArray = new int[3, 3];

            cellArray[0, 0] = 1;
            cellArray[0, 1] = 0;
            cellArray[0, 2] = 1;

            cellArray[1, 0] = 0;
            cellArray[1, 1] = 1;
            cellArray[1, 2] = 0;

            cellArray[2, 0] = 1;
            cellArray[2, 1] = 0;
            cellArray[2, 2] = 1;
            var returnedArray = cellHelper.GetNextGeneration(cellArray);

            Assert.IsTrue(returnedArray[1, 1] == 0);
        }

    }
}
