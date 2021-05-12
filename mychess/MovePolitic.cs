using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    /// <remarks></remarks>
    public interface MovePolitic
    {
        List<Position> GetMoves(Figure figure, ChessField cf);
    }
}
