using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;


public class Triangle
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
    public string TriangleType { get; set; }
    public string ErrorMessage { get; set; }




    public class BDManager
    {
        private readonly string triangleFileName = "C:/Users/naima/source/repos/Lab3_NamsaraevAR/triangles.jsontriangles.json";


        public bool AddTriangleData(double sideA, double sideB, double sideC, string triangleType, string errorMessage)
        {
            var triangles = ReadData();

            var newTriangle = new Triangle
            {
                SideA = sideA,
                SideB = sideB,
                SideC = sideC,
                TriangleType = triangleType,
                ErrorMessage = errorMessage
            };

            triangles.Add(newTriangle);
            SaveData(triangles);
            return true;
        }



        public bool DeleteTriangleData(double sideA, double sideB, double sideC)
        {
            var triangles = ReadData();
            var index = triangles.FindIndex(t => t.SideA == sideA && t.SideB == sideB && t.SideC == sideC);

            if (index != -1)
            {
                triangles.RemoveAt(index);
                SaveData(triangles);
                return true;
            }

            return false;
        }



        public bool UpdateTriangleData(double sideA, double sideB, double sideC, string newTriangleType, string newErrorMessage)
        {
            var triangles = ReadData();
            var triangle = triangles.Find(t => t.SideA == sideA && t.SideB == sideB && t.SideC == sideC);

            if (triangle != null)
            {
                triangle.TriangleType = newTriangleType;
                triangle.ErrorMessage = newErrorMessage;
                SaveData(triangles);
                return true;
            }

            return false;
        }


        private List<Triangle> ReadData()
        {
            if (!File.Exists(triangleFileName))
            {
                File.WriteAllText(triangleFileName, "[]");
            }

            string jsonData = File.ReadAllText(triangleFileName);
            return JsonConvert.DeserializeObject<List<Triangle>>(jsonData);
        }

        private void SaveData(List<Triangle> triangles)
        {
            string jsonData = JsonConvert.SerializeObject(triangles, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(triangleFileName, jsonData);
        }

    }
}