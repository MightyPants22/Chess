using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public delegate void KillEventHandler(object source, EventArgs args);
    public delegate void MoveEventHandler(object source, MoveEventArgs args);
    public delegate void PawnSuperiorityHandler(object source, EventArgs args);
    public delegate void KingShahHandler(object source, EventArgs args);
    public delegate void KingStalemateHandler(object source, EventArgs args);
    public class MoveEventArgs : EventArgs
    {
        public Position oldpos, newpos;
        public MoveEventArgs(Position oldpos, Position newpos){
            this.oldpos = oldpos;
            this. newpos = newpos;
    }
    }
    
    public abstract class Figure
    {
        private Side side;
        private Position pos;
        protected MovePolitics[] movepolitics;
        protected /*readonly*/ FigureTypes FigureType;
        protected ChessField chessfield;
        private bool hasmoved;

        public Figure(Position pos, Side side, ChessField chessfield)
        {
            this.pos = pos;
            this.Side = side;
            this.chessfield = chessfield;
            hasmoved = false;
        }

        /// <summary>
        /// Позиция
        /// </summary>
        public Position Position
        {
            get
            {
                return pos;
            }
            private set
            {
                pos = value;
            }
        }

        /// <summary>
        /// Цвет фигуры
        /// </summary>
        public Side Side
        {
            get
            {
                return side;
            }
            private set
            {
                side = value;
            }
        }

        /// <summary>
        /// Возвращает список позиций в которые может пойти данная фигура
        /// </summary>
        /// <returns></returns>
        public virtual MyList<Position> GetMoves()
        {
            MyList<Position> l = new MyList<Position>();
            foreach (MovePolitics mv in movepolitics)
                l.AddRange(mv.GetMoves(this, chessfield));
            return l;
        }

        /// <summary>
        /// Установить новую позицию
        /// </summary>
        /// <param name="pos"></param>
        public void SetPosition(Position pos)
        {
            Position oldpos = Position;
            Position = pos;
            hasmoved = true;
            OnMoveEvent(oldpos, pos);
            //chessfield.PositionChanged(this, pos);
            if (this.GetFigureType() == FigureTypes.Pawn)
            {
                Position midpos = pos;
                if (Side == Side.Black)
                    midpos = Reverse(midpos);
                if (midpos.GetY() == 8)
                    OnPawnSuperiorityEvent();
            }
        }

        // Убит
        public void Kill()
        {
            OnKillEvent();
        }

        // Шах
        public void Shah()
        {
            OnKingShahEvent();
        }

        // Мат
        public void Stalemate()
        {
            OnKingStalemateEvent(); 
        }
        
        /// <summary>
        /// Возвращает список позиций которые бьет данная фигура
        /// </summary>
        /// <returns></returns>
        public virtual MyList<Position> GetAttacks()
        {
            return GetMoves();
        }

        /// <summary>
        /// Возвращает позицию инвертированную по Y
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Position Reverse(Position pos)
        {
            byte x = pos.GetX();
            byte y = pos.GetY();
            y = (byte)(9 - y);
            return new Position(x, y);
            
        }

        /// <summary>
        /// Вернуть тип фигуры
        /// </summary>
        /// <returns></returns>
        public FigureTypes GetFigureType() // запрет на переопределение метода
        {
            return FigureType;
        }

        /// <summary>
        /// Возвращает изображение фигуры
        /// </summary>
        /// <returns></returns>
        virtual public string GetImage()
        {
            throw new System.NotImplementedException();
        }

        // Move Event
        public event MoveEventHandler MoveEvent;
        public void OnMoveEvent(Position oldpos,Position newpos) // событие при перемещении фигуры
        {
            MoveEventArgs arg = new MoveEventArgs(oldpos, newpos);
            if (MoveEvent != null)
            {
                MoveEvent(this, arg);
            }
        }

        public event PawnSuperiorityHandler PawnSuperiorityEvent;
        public void OnPawnSuperiorityEvent()
        {
           if (PawnSuperiorityEvent != null)
            {
                PawnSuperiorityEvent(this, EventArgs.Empty);
            }
        }

        public event KillEventHandler KillEvent;
        public void OnKillEvent()
        {
            if (MoveEvent != null)
            {
                KillEvent(this, EventArgs.Empty);
            }
        }

        public event KingShahHandler KingShahEvent;
        public void OnKingShahEvent() // событие при уничтожении шахе
        {
            if (MoveEvent != null)
            {
                KingShahEvent(this, EventArgs.Empty);
            }
        }

        public event KingStalemateHandler KingStalemateEvent;
        public void OnKingStalemateEvent()
        {
            if (KingStalemateEvent != null)
            {

                KingStalemateEvent(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Вернет цвет противника
        /// </summary>
        /// <param name="me">Цвет, для которого надо вернуть цвет противника</param>
        /// <returns>Side</returns>
        public Side GetEnemySide(Side me)
        {
            if (me == Side.White)
                return Side.Black;
            else return Side.White;
        }

        /// <summary>
        /// Вернет цвет противника
        /// </summary>
        /// <returns></returns>
        public Side GetEnemySide()
        {
            return GetEnemySide(this.Side);
        }

        public bool ismoved()
        {
            return hasmoved;
        }


        public void SetPositionNoCheck(Position pos)
        {
            this.Position = pos;
        }

    }
}
