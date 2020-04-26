using System;

namespace TsfUnity
{
    public class TsfException : Exception
    {
        public TsfException(string message) : base(message) { }
    }
}
