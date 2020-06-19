using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Exceptions
{
    public class NoSuchPetException : Exception
    {
        public NoSuchPetException(string msg) : base(msg) { }
    }
}
