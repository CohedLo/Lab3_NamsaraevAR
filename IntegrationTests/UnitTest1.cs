using NUnit.Framework;
using Moq;
using static Triangle;
using Lab3_NamsaraevAR;

namespace IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Controller_ManageOperation_AddsToBDManagerAndSendsToAPIMoq()
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
            apiMoqMock.Verify(a => a.SimulateDataTransfer("Test"), Times.Once);
        }

        [Test]
        public void BDManager_AddTriangleData_FileWriteCalled()
        {
            // Arrange
            var dbManager = new BDManager();
            System.IO.File.Delete("C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json");

            // Act
            dbManager.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5");

            // Assert
            Assert.That(System.IO.File.Exists("C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json"));
        }

        [Test]
        public void APIMoq_SimulateDataTransfer_CorrectlySendsData()
        {
            // Arrange
            var apiMoq = new APIMoq();
            string comment = "Test";

            // Act
            apiMoq.SimulateDataTransfer(comment);

            // Assert

        }

        [Test]
        public void UserData_GetUserInput_AddsTriangleDataToBDManager()
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
        public void Controller_GetResultFromManageOperation_ReturnsResultString()
        {
            // Arrange
            var dbManager = new BDManager();
            var userData = new UserData();
            var apiMoq = new APIMoq();

            var controller = new Controller(dbManager, userData, apiMoq);

            // Act
            string result = controller.ManageOperation();

            // Assert
            Assert.That(result, Is.EqualTo("результат операции"));
        }
    }
}