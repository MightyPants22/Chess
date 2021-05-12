using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class VerticalMovePolitic : MovePolitics
    {

        public MyList<Position> GetMoves(Figure figure, ChessField cf)
        {
            Position pos = figure.Position;
            Position tmppos;
            MyList<Position> l = new MyList<Position>();
            switch (figure.GetFigureType())
            {
                case FigureTypes.Pawn:
                    {
                        
                        if (figure.Side == Side.Black)
                            pos = figure.Reverse(pos);
                        if (pos.GetY() == 2)
                        { 
                           
                            Position middlepos = new Position(pos.GetX(), pos.GetY()+1);
                            middlepos = figure.Side == Side.White ? middlepos : figure.Reverse(middlepos);
                            if (cf.GetFigureAt(middlepos) == null)
                            {
                                tmppos = new Position(pos.GetX(), pos.GetY() + 2);
                                l.Add(figure.Side == Side.White ? tmppos : figure.Reverse(tmppos));
                            }
                        }
                        
                        int y = pos.GetY();
                        if (y+1 <9)
                        {
                            tmppos = new Position(pos.GetX(), y+1); 
                            l.Add(figure.Side == Side.White ? tmppos : figure.Reverse(tmppos) );
                        }
                        break;
                    }
                case FigureTypes.King:
                    {
                        if (pos.GetY() >1)
                            l.Add(new Position(pos.GetX(), pos.GetY()-1));
                        if (pos.GetY() < 8)
                            l.Add(new Position(pos.GetX(), pos.GetY()+1));
                        break;

                    }

                default: // Bishop, Queen & etc.
                    {
                        // +
                        for (int i = pos.GetY() + 1; i <= 8; i++)
                        {
                            l.Add(new Position(pos.GetX(), i));
                            if (cf.GetFigureAt(new Position(pos.GetX(), i)) != null)
                                break;
                        }
                        //--
                        for (int i = pos.GetY() - 1; i > 0; i--)
                        {
                            l.Add(new Position(pos.GetX(), i));
                            if (cf.GetFigureAt(new Position(pos.GetX(), i)) != null)
                                break;
                        }
                        break;
                    }
            }
            return l;
        }
    }
}
