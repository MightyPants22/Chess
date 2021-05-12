using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class DiagMovePolitic : MovePolitic
    {
        public List<Position> GetMoves(Figure figure, ChessField cf)
        {
            Position pos = figure.Position;
            List<Position> l = new List<Position>();
            switch (figure.GetFigureType())
            {
                case FigureTypes.King:
                    {

                        break;
                    }
            }
        }
    }
}
