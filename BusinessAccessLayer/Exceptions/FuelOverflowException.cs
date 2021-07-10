using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Exceptions
{
    public class FuelOverflowException : Exception
    {
        public override string Message => new string("Fuel Overflow");
    }
}
