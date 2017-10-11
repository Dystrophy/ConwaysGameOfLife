using ConwaysGameOfLife.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class GridHelperTest
    {
        GridDomain gridHelper;
        CellDomain cellHelper;

        [TestInitialize]
        public void TestInitialize()
        {
            gridHelper = new GridDomain(10, 10);
            cellHelper = new CellDomain();
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
            var returnedVal = gridHelper.GenerateNextGeneration(new int[10, 10]);

            Assert.AreEqual(10, returnedVal.GetLength(0));
            Assert.AreEqual(10, returnedVal.GetLength(1));
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
        public void AGlider_WillGenerateAppropriateCells_OnNextGeneration()
        {
            var returnedArray = gridHelper.GenerateGlider();

            var nextGeneration = cellHelper.GetNextCellGeneration(returnedArray);

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

        [TestMethod]
        public void GenerateNextGeneration_CellWillBecomeAliveWhenExactly3Neighbours()
        {
            var cellArray = new int[2, 2];

            cellArray[0, 0] = 0;
            cellArray[0, 1] = 1;
            cellArray[1, 0] = 1;
            cellArray[1, 1] = 1;

            var returnedArray = cellHelper.GetNextCellGeneration(cellArray);

            Assert.IsTrue(returnedArray[0, 0] == 1);
        }




    }
}
