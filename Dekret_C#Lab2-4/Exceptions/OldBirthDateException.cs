using System;
using System.Collections.Generic;
using System.Text;

namespace Dekret_CSharpLab2.Exceptions
{
    class OldBirthDateException : ArgumentOutOfRangeException
    {
        public DateTime Value { get; }
        public override string Message { get; }
        public OldBirthDateException(DateTime val)
        {
            Value = val;
            Message = "Welcome, time-traveler!";
        }
    }
}
