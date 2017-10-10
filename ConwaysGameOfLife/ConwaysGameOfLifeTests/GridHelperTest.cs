using System;
using ConwaysGameOfLife.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class GridHelperTest
    {
        [TestMethod]
        public void GenerateNextGeneration_ReturnsNewMultidimensionalIntArray()
        {
            var returnedVal = GridHelper.GenerateNextGeneration(new int[1,1]);

            Assert.IsTrue(returnedVal.GetType() == typeof(int[,]));
        }

        [TestMethod]
        public void GenerateNextGeneration_ReturnsNew2DIntArray_OfSameSizeAsPassedArray()
        {
            var returnedVal = GridHelper.GenerateNextGeneration(new int[10,10]);

            Assert.AreEqual(10, returnedVal.GetLength(0));
            Assert.AreEqual(10, returnedVal.GetLength(1));
        }

        [TestMethod]
        public void CreateInitialContainer_ReturnsArrayOfAllZeroes()
        {
            var returnedArray = GridHelper.CreateInitialContainer();

            Assert.IsTrue(returnedArray[0, 0] == 0);
            Assert.IsTrue(returnedArray[0, 9] == 0);
            Assert.IsTrue(returnedArray[9, 0] == 0);
            Assert.IsTrue(returnedArray[9, 9] == 0);
        }

        [TestMethod]
        public void GenerateGlider_ReturnsAGLider()
        {
            var returnedArray = GridHelper.GenerateGlider();

            Assert.IsTrue(returnedArray[0, 1] == 1);
            Assert.IsTrue(returnedArray[1, 2] == 1);
            Assert.IsTrue(returnedArray[2, 2] == 1);
            Assert.IsTrue(returnedArray[2, 1] == 1);
            Assert.IsTrue(returnedArray[2, 0] == 1);
        }
        [TestMethod]
        public void AGlider_WillGlideOnNextGeneration()
        {
            var returnedArray = GridHelper.GenerateGlider();

            var nextGeneration = CellHelper.GetNextGeneration(returnedArray);

            Assert.IsTrue(nextGeneration[1, 0] == 1);
            Assert.IsTrue(nextGeneration[1, 2] == 1);
            Assert.IsTrue(nextGeneration[2, 2] == 1);
            Assert.IsTrue(nextGeneration[2, 1] == 1);
            Assert.IsTrue(nextGeneration[3, 1] == 1);
        }




    }
}
