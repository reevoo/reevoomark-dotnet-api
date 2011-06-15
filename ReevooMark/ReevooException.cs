using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReevooMark
{
    public class ReevooException : Exception
    {
        public ReevooException(Exception e)
            : base("An exception occurred whilst processing your ReevooMark request.", e) { }
    }
}
