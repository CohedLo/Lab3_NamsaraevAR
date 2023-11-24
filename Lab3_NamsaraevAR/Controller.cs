using static Triangle;

namespace Lab3_NamsaraevAR
{
    public class Controller
    {
        private readonly BDManager _dbManager;
        private readonly IUserData _userData;
        private readonly IAPIMoq _apiMoq;

        public Controller(BDManager dbManager, IUserData userData, IAPIMoq apiMoq)
        {
            _dbManager = dbManager;
            _userData = userData;
            _apiMoq = apiMoq;
        }

        public string ManageOperation()
        {
            string inputData = _userData.GetUserInput();

            _dbManager.AddTriangleData(3, 4, 5, "Прямоугольный", "Это треугольник с соотношением сторон 3:4:5");
            _apiMoq.SimulateDataTransfer("Test");

            return "результат операции";
        }
    }
}