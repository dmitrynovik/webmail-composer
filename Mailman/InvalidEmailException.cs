using System;

namespace Mailman
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) {  }
    }
}