using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mychess
{
    public class Game
    {
        private Player player1;
        private Player player2;
        private GameState state;
        private ChessField field;
        private ServerThread server;
        private ClientThread client;
        bool blockmove =false; // блокировка хода до выбора новой фигуры пешки
        private MyList<Position> moves, attacks, castlings, inmoveattacks ;
        Position highlightedfigurepos;
        View view;
        GameType gametype;
        public GameType GameType
        {
            get
            {
                return gametype;
            }
        }
        public Game(View view)
        {
            this.view = view;
            view.ShowgbHUD(false);
        }
    
        public Player Player1
        {
            get
            {
                return player1;
            }
        }

        public Player Player2
        {
            get
            {
                return player2;
            }
        }

        public ChessField Field
        {
            get
            {
                return field;
                
            }
            private set
            {
                field = value;
            }
        }

        /// <summary>
        /// Получить текущее состояние игры
        /// </summary>
        /// <returns></returns>
        public GameState GetState()
        {
            return state;
        }

        /// <summary>
        /// Подсветка хода
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="moves"></param>
        /// <param name="attacks"></param>
        /// <returns></returns>
        public bool Hightlight(Position pos, out MyList<Position> moves, out MyList<Position> attacks,
            out MyList<Position> castlings, out MyList<Position> inmoveattacks)
        {
            moves = new MyList<Position>();
            attacks = new MyList<Position>();
            castlings = new MyList<Position>();
            inmoveattacks = new MyList<Position>();
            MyList<Position> moves0, attacks0, inmoveattacks0;
            if (state != GameState.WaitWhite && state!= GameState.WaitBlack)
                return false;
            Figure fig = Field.GetFigureAt(pos);
            if (fig != null)
            {
                if ((state == GameState.WaitBlack && fig.Side == Side.Black) ||
                    (state == GameState.WaitWhite && fig.Side == Side.White))
                {
                    // highlighting code
                    attacks0 = GetAttacks(fig);
                    moves0 = GetMoves(fig, attacks0);
                    foreach (Position move in attacks0)
                        if (!Field.IsBadMove(pos, move, fig.Side))
                            attacks.Add(move);
                    foreach (Position move in moves0)
                        if (!Field.IsBadMove(pos, move, fig.Side))
                            moves.Add(move);
                    if (fig.GetFigureType() == FigureTypes.King)
                    {
                        castlings = (fig as King).GetCastling();
                    }
                    if (fig.GetFigureType() == FigureTypes.Pawn)
                    {
                        inmoveattacks0 = (fig as Pawn).GetInMoveAttacks();
                        foreach (Position move in inmoveattacks0)
                            if (!Field.IsBadMove(pos, move, fig.Side))
                                inmoveattacks.Add(move);
                    }
                    // Если король под шахом и возможных ходов нет то конец игры FIX IT
                    //if (fig.GetFigureType() == FigureTypes.King & moves.Count == 0 & attacks.Count == 0)
                    //    EndGame(fig);
                    if (state == GameState.WaitBlack)
                        state = GameState.HighlightedBlack;
                    if (state == GameState.WaitWhite)
                        state = GameState.HighlightedWhite;
                    this.moves = moves;
                    this.attacks = attacks;
                    this.castlings = castlings;
                    this.inmoveattacks = inmoveattacks;
                    highlightedfigurepos = pos;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }


        }

        /// <summary>
        /// Отмена подсветки хода
        /// </summary>
        /// <returns></returns>
        public MyList<Position> Escape()
        {

            if (state == GameState.HighlightedBlack)
            {
                state = GameState.WaitBlack;
            }
            if (state == GameState.HighlightedWhite)
                state = GameState.WaitWhite;
            MyList<Position> movs = new MyList<Position>();
            movs.AddRange(moves);
            movs.AddRange(attacks);
            movs.AddRange(castlings);
            movs.Add(highlightedfigurepos);
            movs.AddRange(inmoveattacks);
            moves = null;
            attacks = null;
            castlings = null;
            inmoveattacks = null;
            return movs;
            
        }

        /// <summary>
        ///  Находимся в состоянии выделения?
        /// </summary>
        /// <returns></returns>
        public bool isHighlighted()
        {
            if (state == GameState.HighlightedBlack || state == GameState.HighlightedWhite)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Эта клетка была выделена?
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool isCorrectMove(Position pos)
        {
            if (!isHighlighted())
                return false;
            if (moves.Contains(pos) || attacks.Contains(pos))
                return true;
            else
                return false;
        }


        public bool isCorrectCastling(Position pos)
        {
            if (!isHighlighted())
                return false;
            if (castlings.Contains(pos))
                return true;
            else
                return false;
        }

        public bool isCorrectInMoveAttack(Position pos)
        {
            if (!isHighlighted())
                return false;
            if (inmoveattacks.Contains(pos))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Является ли фигура той которая инициировала выделение?
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool isHighlightedFigure(Position pos)
        {
            if (!isHighlighted())
                return false;
            if (highlightedfigurepos == pos)
                return true;
            else
                return false;

        }

        public bool Move(Position pos)
        {
            if (!isHighlighted())
                return false;
            if (!isCorrectMove(pos))
                return false;
              
            if (moves.Contains(pos) || attacks.Contains(pos))
            {

                if (gametype == GameType.ServerGame && state == GameState.HighlightedWhite)
                {
                    server.NewMove(highlightedfigurepos, pos);
                }

                if (gametype == GameType.ClientGame && state == GameState.HighlightedBlack)
                {
                    client.NewMove(highlightedfigurepos, pos);
                }
                Figure fig = Field.GetFigureAt(highlightedfigurepos);
                fig.SetPosition(pos);
            }
            if (!blockmove)
            {
                switch (state)
                {
                    case GameState.HighlightedBlack:
                        state = GameState.WaitWhite;
                        break;
                    case GameState.HighlightedWhite:
                        state = GameState.WaitBlack;
                        break;
                }
            }
            return true;
        }

        public bool Castle(Position pos)
        {
            if (!isHighlighted())
                return false;
            if (!isCorrectCastling(pos))
                return false;

            if (gametype == GameType.ServerGame && state == GameState.HighlightedWhite)
            {
                server.NewMove(highlightedfigurepos, pos);
            }

            if (gametype == GameType.ClientGame && state == GameState.HighlightedBlack)
            {
                client.NewMove(highlightedfigurepos, pos);
            }
            Figure fig = Field.GetFigureAt(highlightedfigurepos);
            Figure rook = Field.GetFigureAt(pos);
            if (pos.GetX() == 1)
            {
                // длинная рокировка
                int y = pos.GetY();
                fig.SetPosition(new Position(pos.GetX() + 2, y));
                rook.SetPosition(new Position(pos.GetX() + 3, y));
            }
            if (pos.GetX() == 8)
            {
                // короткая рокировка
                int y = pos.GetY();
                fig.SetPosition(new Position(pos.GetX() - 1, y));
                rook.SetPosition(new Position(pos.GetX() - 2, y));
            }

            switch (state)
            {
                case GameState.HighlightedBlack:
                    state = GameState.WaitWhite;
                    break;
                case GameState.HighlightedWhite:
                    state = GameState.WaitBlack;
                    break;
            }
            return true;
        }

        public bool InMoveAttack(Position pos)
        {
            if (!isHighlighted())
                return false;
            if (!isCorrectInMoveAttack(pos))
                return false;
            if (inmoveattacks.Contains(pos))
            {

                if (gametype == GameType.ServerGame && state == GameState.HighlightedWhite)
                {
                    server.NewMove(highlightedfigurepos, pos);
                }

                if (gametype == GameType.ClientGame && state == GameState.HighlightedBlack)
                {
                    client.NewMove(highlightedfigurepos, pos);
                }
                Figure fig = Field.GetFigureAt(highlightedfigurepos);
                int delta = (fig.Side == Side.Black) ? +1 : -1;
                fig.SetPosition(new Position(pos.GetX(), pos.GetY()-delta));
                Figure killedfig = Field.GetFigureAt(pos);
                Field.Kill(killedfig);
            }

            switch (state)
            {
                case GameState.HighlightedBlack:
                    state = GameState.WaitWhite;
                    break;
                case GameState.HighlightedWhite:
                    state = GameState.WaitBlack;
                    break;
            }
            return true;
        }

        /// <summary>
        /// Конец игры
        /// </summary>
        public void EndGame(Figure king)
        {
            //
            king.Stalemate();

            if (gametype == GameType.ServerGame && state == GameState.HighlightedWhite)
            {
                server.Close();
            }

            if (gametype == GameType.ClientGame && state == GameState.HighlightedBlack)
            {
                client.Close();
            }
        }

        public MyList<Position> GetAttacks(Figure fig)
        {
            MyList<Position> lattacks = new MyList<Position>();
            MyList<Position> attacks = new MyList<Position>();
            lattacks = fig.GetAttacks();
            foreach (Position attack in lattacks) //для всех направлений удара проверям есть ли там фигура
                if (Field.GetFigureAt(attack) != null && Field.GetFigureAt(attack).Side != fig.Side
                        && Field.GetFigureAt(attack).GetFigureType() != FigureTypes.King)
                    attacks.Add(attack);
            return attacks;
        }

        public MyList<Position> GetMoves(Figure fig, MyList<Position> attacks)
        {
            MyList<Position> lmoves = new MyList<Position>();
            MyList<Position> moves = new MyList<Position>();
            lmoves = fig.GetMoves();
            foreach (Position move in lmoves)
                if (!attacks.Contains(move) && Field.GetFigureAt(move) == null)
                    moves.Add(move);
            return moves;

        }


        /// <summary>
        /// Создает нового игрока или использует статистику старого если username == null
        /// </summary>
        private Player CreateUser(string username, Side side,Player player)
        {
            if (username == null && player != null && player.Side == side)
                return player;
            else
            {
                if (username == null)
                {
                    if (side == Side.White)
                        username = "Белый игрок";
                    else
                        username = "Черный игрок";
                }
                return new Player(username, side);
            }
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        public void NewGame(){
            gametype = GameType.LocalGame;
            this.player1 = CreateUser(view.GetUserName(Side.White), Side.White, player1);
            this.player2 = CreateUser(view.GetUserName(Side.Black), Side.Black, player2);
            //this.player1 = new Player("", Side.White);
            //this.player2 = new Player("", Side.Black);
            state = GameState.WaitWhite;
            Field = new ChessField(player1, player2);

            view.ClearLog();
            view.ShowgbChessField(true);
            view.ShowrtbLog(true);
            view.EnableDefeat(true);
            view.EnableSave(true);
            view.EnableUndo(true);
            view.EnableNewGame(false);
            view.EnableNewLanGame(false);
            view.EnableLoad(false);
            view.ShowgbHUD(true);
            field.SetPawnSuperiousListener(PawnSuperiorityHandler);
            field.SetKingShahListener(KingShahHandler);
            field.SetKingStalemateListener(KingStalemateHandler);
            view.DrawField();
            view.SetWhiteName(player1.Name);
            view.SetBlackName(player2.Name);
            view.WhiteCount(player1.GetCount());
            view.BlackCount(player2.GetCount());
            view.SetTurnText();
        }

        public void NewServerGame()
        {
            gametype = GameType.ServerGame;
            this.player1 = CreateUser(view.GetUserName(Side.White), Side.White, player1);
            this.player2 = new Player("", Side.Black);
            //this.player1 = new Player("", Side.White);
            //this.player2 = new Player("", Side.Black);
            
            state = GameState.WaitWhite;
            Field = new ChessField(player1, player2);
            field.SetPawnSuperiousListener(PawnSuperiorityHandler);
            field.SetKingShahListener(KingShahHandler);
            field.SetKingStalemateListener(KingStalemateHandler);

            view.ClearLog();
            server = new ServerThread(view, this);
            Thread thread = new Thread(server.Run);
            thread.Start();
            thread.IsBackground = true;
            DialogResult dialogresult = view.ShowServerBanner();
            
            if (dialogresult == DialogResult.Abort)
                {
                    server.listener.Stop();
                    thread.Abort();
                    return;
                }
            //thread.Join();

            view.ShowgbChessField(true);
            view.ShowrtbLog(true);
            view.EnableDefeat(true);
            view.EnableSave(true);
            view.EnableUndo(true);
            view.EnableNewGame(false);
            view.EnableNewLanGame(false);
            view.EnableLoad(false);
            view.ShowgbHUD(true);
            view.DrawField();
            view.SetWhiteName(player1.Name);
            view.SetBlackName(player2.Name);
            view.WhiteCount(player1.GetCount());
            view.BlackCount(player2.GetCount());
            view.SetTurnText();
        }


        public void NewClientGame()
        {
            gametype = GameType.ClientGame;

            this.player1 = new Player("", Side.White);
            this.player2 = CreateUser(view.GetUserName(Side.Black), Side.Black, player2);
            //this.player1 = new Player("", Side.White);
            //this.player2 = new Player("", Side.Black);

            state = GameState.WaitWhite;
            Field = new ChessField(player1, player2);
            field.SetPawnSuperiousListener(PawnSuperiorityHandler);
            field.SetKingShahListener(KingShahHandler);
            field.SetKingStalemateListener(KingStalemateHandler);
            view.ClearLog();
            client = new ClientThread(view, this, view.GetServerAddress(), 12000);
            Thread thread = new Thread(client.Run);
            thread.Start();
            thread.IsBackground = true;
            //thread.Join();
        }

        public void ClientGameView(){
            view.ShowgbChessField(true);
            view.ShowrtbLog(true);
            view.EnableDefeat(true);
            view.EnableSave(true);
            view.EnableUndo(true);
            view.EnableNewGame(false);
            view.EnableNewLanGame(false);
            view.EnableLoad(false);
            view.ShowgbHUD(true);
            view.DrawField();
            view.SetWhiteName(player1.Name);
            view.SetBlackName(player2.Name);
            view.WhiteCount(player1.GetCount());
            view.BlackCount(player2.GetCount());
            view.SetTurnText();
        }

        public void Close()
        {
            view.Close();
        }

        public void Cell_Click(Position pos)
        {
            MyList<Position> moves, attacks,castlings, inmoveattacks;
            Figure fig = Field.GetFigureAt(pos);
            if (!isHighlighted())
            {
                if (Hightlight(pos, out moves, out attacks, out castlings, out inmoveattacks))
                {
                    foreach (Position move in moves)
                    {
                        view.CellMove(move);
                    }
                    view.CellMove(pos);
                    foreach (Position move in attacks)
                    {
                        view.CellAttack(move);
                    }
                    foreach (Position castle in castlings)
                    {
                        view.CellCastling(castle);
                    }
                    foreach (Position attack in inmoveattacks)
                    {
                        view.CellAttack(attack);
                    }
                }


            }
            else
            {
                if (isCorrectMove(pos))
                {
                    view.AddToLog(Field.GetFigureAt(highlightedfigurepos).GetImage() + " " + highlightedfigurepos.ToString() + "-" + pos.ToString());
                    Move(pos);
                    view.DrawField();
                }

                if (isCorrectCastling(pos))
                {
                    view.AddToLog(Field.GetFigureAt(highlightedfigurepos).GetImage() + " Рокировка " + pos.ToString());
                    Castle(pos);
                    view.DrawField();
                }

                if (isCorrectInMoveAttack(pos))
                {
                    view.AddToLog(Field.GetFigureAt(highlightedfigurepos).GetImage() + " " + highlightedfigurepos.ToString() + "-" + pos.ToString());
                    InMoveAttack(pos);
                    view.DrawField();
                }

                // снять выделение
                if (isHighlightedFigure(pos))
                {
                    MyList<Position> needunhighlight = Escape();
                    foreach (Position unhpos in needunhighlight)
                    {
                        view.CellDefault(unhpos);
                    }
                }

            }

            view.SetTurnText();

            view.WhiteCount(player1.GetCount());
            view.BlackCount(player2.GetCount());


        }

        public void ReplacePawn(Position pos)
        {
            Figure fig = Field.GetFigureAt(pos);
            FigureTypes figtype;
            if (isRemoteJob())
            {
                figtype = FigureTypes.Queen;
                blockmove = true;
            }
            else
            {
                blockmove = false;
                figtype = view.SelectFigure();
                Field.TransformPawn(pos, figtype);
                if (GameType != GameType.LocalGame)
                {
                    switch (GameType)
                    {
                        case GameType.ClientGame:
                            client.NewSuperiority(figtype, pos);
                            break;
                        case GameType.ServerGame:
                            server.NewSuperiority(figtype, pos);
                            break;
                    }
                }
                view.DrawField();
                Field.ShahCheck(Field.GetFigureAt(pos));
            }
        }

        public void Defeat()
        {
            Side side; 
            // если локальная игра чей сейчас ход тот и проиграл
            switch (GameType)
            {
                case GameType.LocalGame:
                    {
                        side = GetTurnOwner();
                        break;
                    }
                case GameType.ServerGame:
                    {
                        side = Side.White;
                        server.NewDefeat(side);
                        break;
                    }
                case GameType.ClientGame:
                    {
                        side = Side.Black;
                        client.NewDefeat(side);
                        break;
                    }
                default: { side = Side.White; break; }
            }

            EndGame(Field.SideToPlayer(side).King);
        }

        public Side GetTurnOwner()
        {

            switch (state)
            {
                case GameState.HighlightedBlack:
                case GameState.WaitBlack:
                    return Side.Black;

                case GameState.HighlightedWhite:
                case GameState.WaitWhite:
                    return Side.White;
                default:
                    return Side.Black;

            }
        }

        private void PawnSuperiorityHandler(object obj, EventArgs args)
        {
            Figure fig = (Figure)obj;
            ReplacePawn(fig.Position);
        }

        private void KingShahHandler(object source, EventArgs args)
        {
            Figure fig = (Figure)source;
            view.ShahWarning(fig.Side);
            if (!HasAnyMoves(fig.Side))
                EndGame(fig);
            

        }
        private void KingStalemateHandler(object source, EventArgs args)
        {
            Figure fig = (Figure)source;
            if (fig.Side == Side.Black)
                state = GameState.LoseBlack;
            else
                state = GameState.LoseWhite;
            view.StalemateWarning(fig.Side);
            foreach (Player pl in new Player[] { player1, player2 })
                if (pl.Side == fig.Side)
                    pl.Lose();
                else
                    pl.Win();
            view.SetTurnText();
            view.EnableDefeat(false);
            view.EnableLoad(true);
            view.EnableNewGame(true);
            view.EnableNewLanGame(true);
            view.EnableSave(false);
            view.EnableUndo(false);

        }

        public bool isRemoteJob()
        {
            if ((GameType == GameType.ClientGame && GetState() == GameState.WaitWhite) ||
            (GameType == GameType.ServerGame && GetState() == GameState.WaitBlack)||
             (GameType == GameType.ClientGame && GetState() == GameState.HighlightedWhite) 
            || (GameType == GameType.ServerGame && GetState() == GameState.HighlightedBlack) )
                return true;
            else
                return false;
        }

        public void DirectStateCycle()
        {
            blockmove = false;
            switch (state)
            {
                case GameState.HighlightedBlack:
                    state = GameState.WaitWhite;
                    break;
                case GameState.HighlightedWhite:
                    state = GameState.WaitBlack;
                    break;
            }
            
        }
        /// <summary>
        /// Вызывается во время шаха и проверяет есть ли доступные ходы
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public bool HasAnyMoves(Side side) 
        {
            Player player = Field.SideToPlayer(side);
            foreach (Figure fig in player.alivefigures)
            {
                // for any alive figure check moves
                MyList<Position> moves, attacks, inmoveattacks;
                Position pos = fig.Position;
                    // highlighting code
                attacks = GetAttacks(fig);
                moves = GetMoves(fig, attacks);
                foreach (Position move in attacks)
                    if (!Field.IsBadMove(pos, move, side))
                        return true;
                foreach (Position move in moves)
                    if (!Field.IsBadMove(pos, move, side))
                        return true;
                if (fig.GetFigureType() == FigureTypes.Pawn)
                    {
                        inmoveattacks = (fig as Pawn).GetInMoveAttacks();
                        foreach (Position move in inmoveattacks)
                            if (!Field.IsBadMove(pos, move, fig.Side))
                                return true;
                    }
            }
            return false;
        }
    }

}
