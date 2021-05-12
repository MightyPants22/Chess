using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public class Player
    {
        string name;
        Side side;
        ChessField chessfield = null;
        private Figure lastmoved;
        private bool shahsituation;
        private King king;
        private int win, lose;
        public MyList<Figure> alivefigures = new MyList<Figure>();
        public MyList<Figure> deadfigures = new MyList<Figure>();
        

        public Player(string name, Side side)
        {
            Name = name;
            Side = side;
            win = 0;
            lose = 0;


            
        }

        private Position SidePosition(int x, int y)
        {
            // для расстановки фигур позволяет писать один и тот же код для черных и белых
            // координаты от 0 до 7
            if (side == Side.Black)
            {
                x = 7 - x;
                y = 7 - y;
            }
            return new Position(x+1, y+1);
        }

        public void ArrangeFigures(ChessField chessfield){
            // расстановка на доске
                for (int i = 0; i < 8; i++)
                    alivefigures.Add(new Pawn(SidePosition(i, 1), side, chessfield));
                alivefigures.Add(new Rook(SidePosition(0, 0), side, chessfield));
                alivefigures.Add(new Rook(SidePosition(7, 0), side, chessfield));
                alivefigures.Add(new Knight(SidePosition(1, 0), side, chessfield));
                alivefigures.Add(new Knight(SidePosition(6, 0), side, chessfield));
                alivefigures.Add(new Bishop(SidePosition(2, 0), side, chessfield));
                alivefigures.Add(new Bishop(SidePosition(5, 0), side, chessfield));
            // король с ферзем ставяться зеркально
                Position pos = SidePosition(3, 0); // отображаем координату y если надо
                king = new King(new Position(4 + 1, pos.GetY()), side, chessfield);
                alivefigures.Add(king);
                alivefigures.Add(new Queen(new Position(3+1, pos.GetY()), side, chessfield));

                foreach (Figure figure in alivefigures)
                {
                    // устанавливаем обработчики
                    figure.MoveEvent += chessfield.MoveFigureHandler;
                    figure.KillEvent += KillFigureHandler;
                }
                this.chessfield = chessfield;
                shahsituation = false;
        }

        public void KillFigureHandler(object source, EventArgs args)
        {
            Figure fig = (Figure)source; 
            if (alivefigures.Contains(fig))
            {
                alivefigures.Remove(fig);
                deadfigures.Add(fig);

            }
        }

        /// <summary>
        /// Вызывается при шахе
        /// </summary>
        public void ShahAlert()
        {
            // шах же
            if (!shahsituation)
            {
                shahsituation = true;
                King.Shah();
            }
            else
                // а вот это уже мат
                King.Stalemate();
        }

        /// <summary>
        /// Вернет число "живых" фигур
        /// </summary>
        /// <returns></returns>
 
        public int GetCount()
        {
            return alivefigures.Count;
        }

        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        ///  Цвет игрока
        /// </summary>
        public Side Side
        {
            get
            {
                return side;
            }
            set
            {
                side = value;
            }
        }

        /// <summary>
        /// Вернет указатель на короля данного игрока
        /// </summary>
        public King King
        {
            get
            {
                return king;
            }
        }

        /// <summary>
        ///  Инкремент внутреннего счетчика поражений
        /// </summary>
        public void Lose()
        {
            lose++;
        }

        /// <summary>
        /// Инкремент внутреннего счетчика побед
        /// </summary>
        public void Win()
        {
            win++;
        }

        /// <summary>
        ///  Возвращает число поражений
        /// </summary>
        /// <returns></returns>
        public int GetLose()
        {
            return lose;
        }

        /// <summary>
        ///  Возвращает число побед
        /// </summary>
        /// <returns></returns>
        public int GetWin()
        {
            return win;
        }

        /// <summary>
        /// Вызывается если король ушел из-под шаха
        /// </summary>
        public void ResetShahSituation()
        {
            shahsituation = false;
        }

        /// <summary>
        /// Устанавливает новое значение счетчиков поражения и побед
        /// </summary>
        /// <param name="win"></param>
        /// <param name="lose"></param>
        public void SetStatistic(int win, int lose)
        {
            this.lose = lose;
            this.win = win;
        }

        public bool isShah()
        {
            return shahsituation;
        }

    }
}
