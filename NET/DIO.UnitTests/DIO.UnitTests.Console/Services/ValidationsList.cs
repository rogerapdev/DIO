using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.UnitTests.Console.Services
{
    public class ValidationsList
    {
        public List<int> RemoversNegativeNumbers(List<int> list)
        {
            var listNoNumbersNegatives = list.Where(x => x > 0);

            return listNoNumbersNegatives.ToList();

        }

        public bool ListContainsCertainNumber(List<int> list, int number)
        {
            var contain = list.Contains(number);
            return contain;
        }

        public List<int> MultiplyListNumber(List<int> list, int number)
        {
            var listMultiply = list.Select(x => x * number).ToList();
            return listMultiply;
        }

        public int ReturnTheLargestNumberFromTheList(List<int> list)
        {
            return list.Max();
        }

        public int ReturnLowestNumberList(List<int> list)
        {
            return list.Min();
        }
    }
}