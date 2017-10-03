using System;
using ConwaysGameOfLife.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class GridHelperTest
    {
        [TestMethod]
        public void GenerateNextGeneration_ReturnsNew2DIntArray()
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
    }
}
