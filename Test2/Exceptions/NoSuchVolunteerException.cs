using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Exceptions
{
    public class NoSuchVolunteerException : Exception
    {
        public NoSuchVolunteerException(string msg) : base(msg) { }
    }
}
