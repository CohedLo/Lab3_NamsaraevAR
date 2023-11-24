using static Triangle;


namespace Lab3_NamsaraevAR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbManager = new BDManager();
            var userData = new UserData();
            var apiMoq = new APIMoq();

            var controller = new Controller(dbManager, userData, apiMoq);

            string result = controller.ManageOperation();

            Console.WriteLine($"Результат операции: {result}");

            apiMoq.SimulateDataTransfer("Test comment");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}