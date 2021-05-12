using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class Pawn : Figure
    {
        private MovePolitics[] attackpolitics;
        public Pawn(Position pos, Side side, ChessField chessfield):base(pos,side, chessfield)
        {
            FigureType = FigureTypes.Pawn;
            movepolitics = new MovePolitics[] { chessfield.VerticalMovePolitics};
            attackpolitics = new MovePolitics[] { chessfield.DiagMovePolitics};
            
        }
    
        public override MyList<Position> GetAttacks()
        {
            MyList<Position> l = new MyList<Position>();
            foreach (MovePolitics mp in attackpolitics)
                    l.AddRange(mp.GetMoves(this, chessfield));
            return l;
            
        }

        /// <summary>
        /// Вернет список бьющихся фигур на проходе
        /// </summary>
        /// <returns></returns>
        public MyList<Position> GetInMoveAttacks()
        {
            int delta = (Side == Side.Black) ? +1 : -1;
            Position pos;
            Side oppside = GetEnemySide();
            Figure fig;
            MyList<Position> moves = new MyList<Position>();
            foreach (Position attack in GetAttacks())
            {
                try{
                    pos = new Position(attack.GetX(), attack.GetY() + delta);
                    fig = chessfield.GetFigureAt(pos);
                    if (fig != null && fig.GetFigureType() == FigureTypes.Pawn &&
                        fig.Side == oppside &&
                        chessfield.GetlastMoved(oppside) == fig)
                        moves.Add(pos);
                    {
                       
                    }

                }
                catch {}
              
            }
            return moves;
        }

        public override string GetImage()
        {
            if (Side == Side.Black)
                return "♟";
            else
                return "♙";
        }
    }
}
