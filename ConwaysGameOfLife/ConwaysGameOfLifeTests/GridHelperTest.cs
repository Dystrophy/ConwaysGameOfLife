using System;
using ConwaysGameOfLife.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class GridHelperTest
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
        public void GenerateNextGeneration_ReturnsNewMultidimensionalIntArray()
        {
            var returnedVal = gridHelper.GenerateNextGeneration(new int[1,1]);

            Assert.IsTrue(returnedVal.GetType() == typeof(int[,]));
        }

        [TestMethod]
        public void GenerateNextGeneration_ReturnsNew2DIntArray_OfSameSizeAsPassedArray()
        {
            var returnedVal = gridHelper.GenerateNextGeneration(new int[10,10]);

            Assert.AreEqual(10, returnedVal.GetLength(0));
            Assert.AreEqual(10, returnedVal.GetLength(1));
        }

        [TestMethod]
        public void CreateInitialContainer_ReturnsArrayOfAllZeroes()
        {
            var returnedArray = gridHelper.CreateInitialContainer();

            Assert.IsTrue(returnedArray[0, 0] == 0);
            Assert.IsTrue(returnedArray[0, 9] == 0);
            Assert.IsTrue(returnedArray[9, 0] == 0);
            Assert.IsTrue(returnedArray[9, 9] == 0);
        }

        [TestMethod]
        public void GenerateGlider_ReturnsAGLider()
        {
            var returnedArray = gridHelper.GenerateGlider();

            Assert.IsTrue(returnedArray[0, 1] == 1);
            Assert.IsTrue(returnedArray[1, 2] == 1);
            Assert.IsTrue(returnedArray[2, 2] == 1);
            Assert.IsTrue(returnedArray[2, 1] == 1);
            Assert.IsTrue(returnedArray[2, 0] == 1);
        }
        [TestMethod]
        public void AGlider_WillGenerateApprpriatecells_OnNextGeneration()
        {
            var returnedArray = gridHelper.GenerateGlider();

            var nextGeneration = cellHelper.GetNextGeneration(returnedArray);

            Assert.IsTrue(nextGeneration[1, 0] == 1);
            Assert.IsTrue(nextGeneration[1, 2] == 1);
            Assert.IsTrue(nextGeneration[2, 2] == 1);
            Assert.IsTrue(nextGeneration[2, 1] == 1);
            Assert.IsTrue(nextGeneration[3, 1] == 1);
        }
        [TestMethod]
        public void CreateInitialContainer_SetsIntialStateOfGame_ToStateThatIsPassedIn()
        {
            var gliderState = gridHelper.GenerateGlider();

            var returnedArray = gridHelper.CreateInitialContainer(gliderState);

            Assert.IsTrue(returnedArray[0, 1] == 1);
            Assert.IsTrue(returnedArray[1, 2] == 1);
            Assert.IsTrue(returnedArray[2, 2] == 1);
            Assert.IsTrue(returnedArray[2, 1] == 1);
            Assert.IsTrue(returnedArray[2, 0] == 1);
        }




    }
}
