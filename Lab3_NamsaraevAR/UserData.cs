using System;
using Serilog;
using Lab3_NamsaraevAR;


public class UserData : IUserData
{
    public string GetUserInput()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Console.WriteLine("Введите сторону a");
        string a = Console.ReadLine();
        Console.WriteLine("Введите сторону b");
        string b = Console.ReadLine();
        Console.WriteLine("Введите сторону c");
        string c = Console.ReadLine();

        Log.Information($"Введенные данные: a={a}, b={b}, c={c}");

        Triangle.BDManager dbManager = new Triangle.BDManager();
        dbManager.AddTriangleData(Convert.ToDouble(a), Convert.ToDouble(b), Convert.ToDouble(c), "_тип", "_ошибка");

        return $"a={a}, b={b}, c={c}";
    }
}


public interface IUserData
{
    string GetUserInput();
}