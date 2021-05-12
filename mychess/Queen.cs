using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class Queen : Figure
    {
        public Queen(Position pos, Side side, ChessField chessfield)
            : base(pos, side, chessfield)
        {
            FigureType = FigureTypes.Queen;
            movepolitics = new MovePolitics[] {
                                        chessfield.HorizontalMovePolitics,
                                        chessfield.VerticalMovePolitics,
                                        chessfield.DiagMovePolitics};
        }


        public override string GetImage()
        {
            if (Side == Side.Black)
                return "♛";
            else
                return "♕";
        }
    }
}
