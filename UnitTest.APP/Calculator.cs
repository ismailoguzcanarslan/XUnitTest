using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.APP
{
    public class Calculator
    {
        private readonly ICalculatorService _service;

        public Calculator(ICalculatorService service)
        {
            _service = service;
        }

        public int Add(int a, int b)
        {
            return _service.Add(a, b);
        }

        public int Mult(int a, int b)
        {
            return _service.Mult(a, b);
        }
    }
}
