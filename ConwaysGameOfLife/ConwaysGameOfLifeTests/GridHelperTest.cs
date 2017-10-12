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
        public void GenerateNextGeneration_ReturnsNewMultidimensionalBooleanArray()
        {
            var returnedVal = gridHelper.GenerateNextGeneration(new bool[1,1]);

            Assert.IsTrue(returnedVal.GetType() == typeof(bool[,]));
        }

        [TestMethod]
        public void GenerateNextGeneration_ReturnsNew2DIntArray_OfSameSizeAsPassedArray()
        {
            var returnedVal = gridHelper.GenerateNextGeneration(new bool[10, 10]);

            Assert.AreEqual(10, returnedVal.GetLength(0));
            Assert.AreEqual(10, returnedVal.GetLength(1));
        }
        

        [TestMethod]
        public void GenerateGlider_ReturnsAGLider()
        {
            var returnedArray = gridHelper.GenerateGlider();

            Assert.IsTrue(returnedArray[0, 1] == true);
            Assert.IsTrue(returnedArray[1, 2] == true);
            Assert.IsTrue(returnedArray[2, 2] == true);
            Assert.IsTrue(returnedArray[2, 1] == true);
            Assert.IsTrue(returnedArray[2, 0] == true);
        }
        [TestMethod]
        public void AGlider_WillGenerateAppropriateCells_OnNextGeneration()
        {
            var returnedArray = gridHelper.GenerateGlider();

            var nextGeneration = cellHelper.GetNextCellGeneration(returnedArray);

            Assert.IsTrue(nextGeneration[1, 0] == true);
            Assert.IsTrue(nextGeneration[1, 2] == true);
            Assert.IsTrue(nextGeneration[2, 2] == true);
            Assert.IsTrue(nextGeneration[2, 1] == true);
            Assert.IsTrue(nextGeneration[3, 1] == true);

            
        }
        [TestMethod]
        public void CreateInitialContainer_SetsIntialStateOfGame_ToStateThatIsPassedIn()
        {
            var gliderState = gridHelper.GenerateGlider();

            var returnedArray = gridHelper.CreateInitialContainer(gliderState);

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

            var returnedArray = cellHelper.GetNextCellGeneration(cellArray);

            Assert.IsTrue(returnedArray[0, 0] == true );
        }




    }
}
