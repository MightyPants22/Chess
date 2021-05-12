using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
[Serializable()]
public class InvalidPositionException : System.Exception
{
    public InvalidPositionException() : base() { }
    public InvalidPositionException(string message) : base(message) { }
    public InvalidPositionException(string message, System.Exception inner) : base(message, inner) { }
}
}
