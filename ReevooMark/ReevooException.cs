using System;

namespace ReevooMark
{
    public class ReevooException : Exception
    {
        public ReevooException (Exception e)
            : base ("An exception occurred whilst processing your ReevooMark request.", e)
        {
        }
    }
}
