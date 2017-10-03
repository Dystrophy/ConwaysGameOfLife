using System;
using ConwaysGameOfLife.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class CellHelperTests
    {
        [TestMethod]
        public void IsCellAlive_GivenLessThan2Neighbours_IsDeadInNextGeneration()
        {
            var returnedVal = CellHelper.IsCellAlive(1);

            Assert.AreEqual(returnedVal, false);
        }
        [TestMethod]
        public void IsCellAlive_GivenMoreThan4Neighbours_IsDeadInNextgeneration()
        {
            var returnedVal = CellHelper.IsCellAlive(4);

            Assert.AreEqual(returnedVal, false);
        }
        [TestMethod]
        public void IsCellAlive_Given3Neighbours_IsAliveInNextGeneration()
        {
            var returnedVal = CellHelper.IsCellAlive(3);

            Assert.AreEqual(returnedVal, true);
        }
        [TestMethod]
        public void IsCellAlive_Given2Neighbours_IsAliveInNextGeneration()
        {
            var returnedVal = CellHelper.IsCellAlive(2);

            Assert.AreEqual(returnedVal, true);
        }
    }
}
