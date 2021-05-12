using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class DiagMovePolitics : MovePolitics
    {
        public MyList<Position> GetMoves(Figure figure, ChessField cf)
        {
            Position pos = figure.Position, tmppos;
            MyList<Position> l = new MyList<Position>();
            switch (figure.GetFigureType())
            {
                case FigureTypes.Pawn:
                    {
                        if (figure.Side == Side.Black)
                            pos = figure.Reverse(pos);
                        if (pos.GetY() < 8)
                        {
                        if (pos.GetX() < 8)
                            {
                                tmppos = new Position(pos.GetX()+1, pos.GetY()+1);
                                l.Add(figure.Side == Side.White ? tmppos : figure.Reverse(tmppos));
                            }
                        if (pos.GetX() > 1)
                        {
                            tmppos = new Position(pos.GetX()- 1, pos.GetY() + 1);
                            l.Add(figure.Side == Side.White ? tmppos : figure.Reverse(tmppos));
                        }

                        }
                        break;
                    }
                case FigureTypes.King:
                    {

                        int x,y;
                        x = pos.GetX();
                        y = pos.GetY();
                        if (x<8)
                        {
                            if (y<8)
                                l.Add(new Position(x+1,y+1));
                            if (y>1)
                                l.Add(new Position(x+1,y-1));
                        }
                        if (x>1)
                        {
                            if (y<8)
                                l.Add(new Position(x-1,y+1));
                            if (y>1)
                                l.Add(new Position(x-1, y-1));
                        }
                        break;
                    }
                default:
                    {
                        for (int i = pos.GetX()+1, j = pos.GetY()+1; i <= 8 && j <= 8; i++, j++)
                        {
                            l.Add(new Position(i, j));
                            if (cf.GetFigureAt(new Position(i, j)) != null)
                                break;
                        }

                        for (int i = pos.GetX() - 1, j = pos.GetY() - 1; i >=1  && j >=1 ; i--, j--)
                        {
                            l.Add(new Position(i, j));
                            if (cf.GetFigureAt(new Position(i, j)) != null)
                                break;
                        }
                        for (int i = pos.GetX() + 1, j = pos.GetY() - 1; i <= 8 && j >= 1; i++, j--)
                        {
                            l.Add(new Position(i, j));
                            if (cf.GetFigureAt(new Position(i, j)) != null)
                                break;
                        }
                        for (int i = pos.GetX() -1, j = pos.GetY() + 1; i >= 1 && j <= 8; i--, j++)
                        {
                            l.Add(new Position(i, j));
                            if (cf.GetFigureAt(new Position(i, j)) != null)
                                break;
                        }
                        break;
                    }
            }
            return l;
        }
    }
}
