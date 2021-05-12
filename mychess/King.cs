using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class King : Figure
    {
        public King(Position pos, Side side, ChessField chessfield)
            : base(pos, side, chessfield)
        {
            FigureType = FigureTypes.King;
            movepolitics = new MovePolitics[] {
                                        chessfield.HorizontalMovePolitics,
                                        chessfield.VerticalMovePolitics,
                                        chessfield.DiagMovePolitics};
        }

        public override MyList<Position> GetMoves()
        {
            MyList<Position> moves = base.GetMoves();
           MyList<Position> newmoves = new MyList<Position>();
           Side oppositeside = GetEnemySide();
            foreach (Position pos in moves)
                if (!chessfield.isDangerPosition(oppositeside, pos,Position))
                // Fix situation of cyclic checking of two kings 
                newmoves.Add(pos);
            return newmoves;
        }

        public MyList<Position> GetCastling()
        {
            MyList<Position> castling = new MyList<Position>();
            Figure fig;
            int x = Position.GetX();
            if (ismoved())
                return castling;
            Side oppside = GetEnemySide();
            int ypos = (this.Side == Side.White) ? 1 : 8;
            if (chessfield.isDangerPosition(oppside, Position))
                return castling;

            fig = chessfield.GetFigureAt(new Position(1, ypos));
            if (fig != null &&
                !chessfield.isDangerPosition(oppside, new Position(x-1,ypos))    &&
                !chessfield.isDangerPosition(oppside, new Position(x - 2, ypos)) &&
                !chessfield.isDangerPosition(oppside, new Position(x - 3, ypos)) &&
                !chessfield.isDangerPosition(oppside, new Position(x, ypos)) &&
                !fig.ismoved() &&
                chessfield.GetFigureAt(new Position(2, ypos)) == null &&
                chessfield.GetFigureAt(new Position(3, ypos)) == null &&
                chessfield.GetFigureAt(new Position(4, ypos)) == null)
                                castling.Add(fig.Position);

             fig = chessfield.GetFigureAt(new Position(8, ypos));
             if (fig != null &&
                 !chessfield.isDangerPosition(oppside, new Position(x + 1, ypos)) &&
                 !chessfield.isDangerPosition(oppside, new Position(x + 2, ypos)) &&
                 !chessfield.isDangerPosition(oppside, new Position(x, ypos)) &&
                 !fig.ismoved() &&
                 chessfield.GetFigureAt(new Position(7, ypos)) == null &&
                 chessfield.GetFigureAt(new Position(6, ypos)) == null)
                    castling.Add(fig.Position);
            return castling;

        }

        public  MyList<Position> GetMovesWithOutChecks()
        {
            return base.GetMoves();
        }
        public override string GetImage()
        {
            if (Side == Side.Black)
                return "♚";
            else
                return "♔";
        }
    }
}
