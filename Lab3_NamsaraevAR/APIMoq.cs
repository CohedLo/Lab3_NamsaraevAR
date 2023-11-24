using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3_NamsaraevAR
{
    public interface IAPIMoq
    {
        void SimulateDataTransfer(string data);
    }

    public class APIMoq : IAPIMoq
    {
        public void SimulateDataTransfer(string comment)
        {
            Console.WriteLine($"simulationsms : {comment}");
        }
    }

    public class APIMoq1 : IAPIMoq
    {
        public void SimulateDataTransfer(string comment)
        {
            Console.WriteLine($"simulationsms : {comment}");
        }
    }
}
