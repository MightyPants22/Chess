using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class HorizontalMovePolitics : MovePolitics
    {
        public MyList<Position> GetMoves(Figure figure, ChessField cf)
        {
            Position pos = figure.Position;
            MyList<Position> l = new MyList<Position>();
            switch (figure.GetFigureType())
            {
                case FigureTypes.King:
                    {
                        if (pos.GetX() >1)
                            l.Add(new Position(pos.GetX()-1, pos.GetY()));
                        if (pos.GetX() < 8)
                            l.Add(new Position(pos.GetX()+1, pos.GetY()));
                        break;

                    }

                default: // Bishop, Queen & etc.
                    {
                        // +
                        for (int i = pos.GetX() + 1; i <= 8; i++)
                        {
                            l.Add(new Position(i, pos.GetY()));
                            if (cf.GetFigureAt(new Position(i, pos.GetY())) != null)
                                break;
                        }
                        // --
                        for (int i = pos.GetX() - 1; i > 0; i--)
                        {
                            l.Add(new Position( i, pos.GetY()));
                            if (cf.GetFigureAt(new Position( i, pos.GetY())) != null)
                                break;
                        }
                        break;
                    }
            }
            return l;
        }
        
    }
}
