using Newtonsoft.Json;
using static Triangle;

namespace BDManagerTests
{
    [TestFixture]
    public class BDManagerTests
    {
        [Test]
        public void BDManager_AddTriangleData_FileWriteCalled()
        {
            // Arrange
            var dbManager = new BDManager();
            var initialFileExists = File.Exists("C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json");

            // Act
            dbManager.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5");

            // Assert
            var fileCreated = File.Exists("C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json");
            Assert.That(fileCreated, Is.EqualTo(!initialFileExists));
        }

        [Test]
        public void AddTriangleData_FileWriteCalled()
        {
            // Arrange
            var dbManager = new BDManager();
            var initialFileExists = File.Exists("C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json");

            // Act
            dbManager.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5");

            // Assert
            var fileCreated = File.Exists("C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json");
            Assert.That(fileCreated, Is.EqualTo(!initialFileExists));
        }

        [Test]
        public void DeleteTriangleData_RemovesTriangle()
        {
            // Arrange
            var dbManager = new BDManager();
            dbManager.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5");

            // Act
            var result = dbManager.DeleteTriangleData(3, 4, 5);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateTriangleData_ModifiesTriangle()
        {
            // Arrange
            var dbManager = new BDManager();
            dbManager.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5");

            // Act
            var result = dbManager.UpdateTriangleData(3, 4, 5, "Равносторонний", "Это равносторонний треугольник");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadData_ReturnsTriangularList()
        {
            // Arrange
            var dbManager = new BDManager();

            // Act
            //    var triangles = dbManager.ReadData();

            // Assert
            //      Assert.IsNotNull(triangles);
        }

        [Test]
        public void SaveData_WritesTriangularListToFile()
        {
            // Arrange
            var dbManager = new BDManager();
            var triangles = new List<Triangle>
            {
                //     new Triangle { SideA = 3, SideB = 4, SideC = 5, TriangleType = "Прямоугольный", ErrorMessage = "Это треугольник с соотношением сторон 3:4:5" }
            };

            // Act
            //   dbManager.SaveData(triangles);

            // Assert
            var jsonData = File.ReadAllText("C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json");
            var deserializedTriangles = JsonConvert.DeserializeObject<List<Triangle>>(jsonData);
            Assert.IsNotNull(deserializedTriangles);
            Assert.AreEqual(1, deserializedTriangles.Count);
        }
    }
}