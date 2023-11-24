using Lab3_NamsaraevAR;
using Moq;
using NUnit.Framework;
using static Triangle;


namespace UserDataTests
{
    [TestFixture]
    public class ControllerTests
    {
        [Test]
        public void ManageOperation_AddsToBDManager()
        {
            // Arrange
            var dbManagerMock = new Mock<BDManager>();
            var userDataMock = new Mock<UserData>();
            var apiMoqMock = new Mock<APIMoq>();

            userDataMock.Setup(u => u.GetUserInput()).Returns("3, 4, 5");
            var controller = new Controller(dbManagerMock.Object, userDataMock.Object, apiMoqMock.Object);

            // Act
            string result = controller.ManageOperation();

            // Assert
            dbManagerMock.Verify(d => d.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5"), Times.Once);
        }

        [Test]
        public void ManageOperation_SendsToAPIMoq()
        {
            // Arrange
            var dbManagerMock = new Mock<BDManager>();
            var userDataMock = new Mock<UserData>();
            var apiMoqMock = new Mock<APIMoq>();

            userDataMock.Setup(u => u.GetUserInput()).Returns("3, 4, 5");
            var controller = new Controller(dbManagerMock.Object, userDataMock.Object, apiMoqMock.Object);

            // Act
            string result = controller.ManageOperation();

            // Assert
            apiMoqMock.Verify(a => a.SimulateDataTransfer("Tests"), Times.Once);
        }

        [Test]
        public void UserData_AddsTriangleDataToFile()
        {
            // Arrange
            var dbManagerMock = new Mock<BDManager>();
            var userData = new UserData();

            // Act
            userData.GetUserInput();

            // Assert
            dbManagerMock.Verify(d => d.AddTriangleData(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), "_тип", "_ошибка"), Times.Once);
        }

        [Test]
        public void BDManager_AddTriangleData_FileWriteCalled()
        {
            // Arrange
            var dbManager = new BDManager();
            File.Delete("triangles.json");

            // Act
            dbManager.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5");

            // Assert
            Assert.That(File.Exists("triangles.json"));
        }

        [Test]
        public void UserData_CorrectInput_ReturnsUserData()
        {
            // Arrange
            var userData = new UserData();
            var input = "3\n4\n5\n";

            // Act
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var output = userData.GetUserInput();
                // Assert
                Assert.That(output, Is.EqualTo("a=3, b=4, c=5"));
            }
        }
    }
}