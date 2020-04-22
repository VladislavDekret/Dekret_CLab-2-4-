using System;
using System.Collections.Generic;
using System.Text;

namespace Dekret_CSharpLab2.Exceptions
{
    class FutureBirthDateException : ArgumentOutOfRangeException
    {
        public DateTime Value{ get; }
        public override string Message { get; }
        public FutureBirthDateException(DateTime val)
        {
            Value = val;
            Message = "Incorrect birthday, can't be in the future!";
        }
    }
}
