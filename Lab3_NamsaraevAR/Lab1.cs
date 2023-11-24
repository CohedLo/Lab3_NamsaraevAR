using System;
using Serilog;

namespace Lab3_NamsaraevAR
{
    public class Triangle
    {
        public string TriType(string a, string b, string c)
        {
            float? sideA = ToSingleNullable(a);
            float? sideB = ToSingleNullable(b);
            float? sideC = ToSingleNullable(c);
            string triangleType = DetermineTriangleType(sideA.Value, sideB.Value, sideC.Value);
            return triangleType;
        }
        public Tuple<string, Tuple<int, int>[]> OutputCheck(string a, string b, string c)
        {
            float? sideA = ToSingleNullable(a);
            float? sideB = ToSingleNullable(b);
            float? sideC = ToSingleNullable(c);

            if (sideA.HasValue && sideB.HasValue && sideC.HasValue)
            {
                if (IsTriangle(sideA.Value, sideB.Value, sideC.Value))
                {
                    Log.Information($"Успешный запрос, a={a}, b={b}, c={c}, Треугольник");

                    string triangleType = DetermineTriangleType(sideA.Value, sideB.Value, sideC.Value);
                    Console.WriteLine("Тип треугольника: " + triangleType);

                    if (triangleType != "Не треугольник")
                    {
                        var vertices = CalculateVertices(sideA.Value, sideB.Value, sideC.Value);
                        Console.WriteLine("Координаты вершин:");

                        Log.Information($"Вершина A: ({vertices[0].Item1}, {vertices[0].Item2})");
                        Log.Information($"Вершина B: ({vertices[1].Item1}, {vertices[1].Item2})");
                        Log.Information($"Вершина C: ({vertices[2].Item1}, {vertices[2].Item2})");

                        return Tuple.Create(triangleType, vertices);
                    }
                    else
                    {
                        return Tuple.Create(triangleType, new Tuple<int, int>[] { Tuple.Create(-1, -1), Tuple.Create(-1, -1), Tuple.Create(-1, -1) });
                    }
                }
                else
                {
                    Log.Information($"Неуспешный запрос a={a}, b={b}, c={c}, Не треугольник");
                    return Tuple.Create("Не треугольник", new Tuple<int, int>[] { Tuple.Create(-1, -1), Tuple.Create(-1, -1), Tuple.Create(-1, -1) });
                }
            }
            else
            {
                Log.Information($"Неуспешный запрос. a={a}, b={b}, c={c}, переданы нечисловые данные.");
                return Tuple.Create("", new Tuple<int, int>[] { Tuple.Create(-2, -2), Tuple.Create(-2, -2), Tuple.Create(-2, -2) });
            }
        }

        private bool IsTriangle(float a, float b, float c)
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }

        private string DetermineTriangleType(float a, float b, float c)
        {
            if (a == b && b == c)
                return "Равносторонний";
            else if (a == b || a == c || b == c)
                return "Равнобедренный";
            else
                return "Разносторонний";
        }

        private Tuple<int, int>[] CalculateVertices(float a, float b, float c)
        {
            int fieldWidth = 100;
            int fieldHeight = 100;
            int xA, yA, xB, yB, xC, yC;

            if (IsTriangle(a, b, c))
            {
                xA = 0;
                yA = fieldHeight;
                xB = (int)(a / c * fieldWidth);
                yB = fieldHeight;
                xC = (int)(0.5 * a / c * fieldWidth);
                yC = 0;
            }
            else
            {
                xA = -1;
                yA = -1;
                xB = -1;
                yB = -1;
                xC = -1;
                yC = -1;
            }

            return new Tuple<int, int>[] { Tuple.Create(xA, yA), Tuple.Create(xB, yB), Tuple.Create(xC, yC) };
        }

        private float? ToSingleNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            else
            {
                float number;
                if (float.TryParse(value, out number))
                    return number;
                return null;
            }
        }
    }
}