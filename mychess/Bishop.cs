using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class Bishop : Figure
    {
        public Bishop(Position pos, Side side, ChessField chessfield)
            : base(pos, side, chessfield)
        {
            FigureType = FigureTypes.Bishop;
            movepolitics = new MovePolitics[] {
                                        chessfield.DiagMovePolitics};
        }

        public override string GetImage()
        {
            if (Side == Side.Black)
                return "♝";
            else
                return "♗";
        }
    }
}
