using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class Rook : Figure
    {
        public Rook(Position pos, Side side, ChessField chessfield)
            : base(pos, side, chessfield)
        {
            FigureType = FigureTypes.Rook;
            movepolitics = new MovePolitics[] {
                                        chessfield.VerticalMovePolitics,
                                        chessfield.HorizontalMovePolitics};
        }
        public override string GetImage()
        {
            if (Side == Side.Black)
                return "♜";
            else
                return "♖";
        }
    }
}
