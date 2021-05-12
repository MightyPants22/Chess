using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mychess
{
    public partial class View : Form
    {
        private Button[,] buttons;
        private Game game;
        private ServerBannerForm serverbannerform;
        delegate void CloseFormDelegate();

        public View()
        {
            InitializeComponent();
            buttons = new Button[8, 8];
            game = new Game(this);
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            SuspendLayout();
            Font font = new System.Drawing.Font("Arial Unicode MS", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            int size = 70;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Button btn = new Button();
                    btn.Parent = gbChessField;
                    btn.Height = size;
                    btn.Width = size;
                    btn.Font = font;
                    btn.BackgroundImageLayout = ImageLayout.Center;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    if ((i + j) % 2 == 0)
                        btn.BackColor = Color.Gray;
                    else
                        btn.BackColor = Color.White;
                    btn.Left = size * i;
                    btn.Top = size * (7 - j);
                    buttons[i, j] = btn;
                    btn.Click += Cell_Click;
                    btn.Tag = (Object)(new Position(i + 1, j + 1));
                }
            ResumeLayout(false);
        }

        public void DrawField()
        {
            Figure figure;
            Button btn;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    //btn.Enabled = false;

                    btn = buttons[i, j];
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.BorderColor = Color.White;
                    figure = game.Field.GetFigureAt((Position)btn.Tag);
                    if (figure != null)
                        btn.Text = figure.GetImage();
                    else
                        btn.Text = string.Empty;
                }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (game.isRemoteJob())
                return;
            Button btn = (Button)sender;
            Position pos = (Position)btn.Tag;
            game.Cell_Click(pos);
        }

        public void CellAttack(Position pos)
        {
            Button btn = buttons[pos.GetX0(), pos.GetY0()];
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = Color.Red;
        }

        public void CellMove(Position pos)
        {
            Button btn = buttons[pos.GetX0(), pos.GetY0()];
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = Color.Green;
        }


        public void CellDefault(Position pos)
        {
            Button btn = buttons[pos.GetX0(), pos.GetY0()];
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.BorderColor = Color.White;
        }

        public void CellCastling(Position pos)
        {
            Button btn = buttons[pos.GetX0(), pos.GetY0()];
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = Color.Yellow;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void tsNewGame_Click(object sender, EventArgs e)
        {
            game.NewGame();
        }

        private void gbChessField_Enter(object sender, EventArgs e)
        {

        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void gbChessField_Enter_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        public void EnableNewGame(bool enable)
        {
            tsNewGame.Enabled = enable;
        }

        public void EnableDefeat(bool enable)
        {
            tsDefeat.Enabled = enable;
        }
        public void EnableSave(bool enable)
        {
            //tsSave.Enabled = enable;
        }

        public void EnableUndo(bool enable)
        {
            tsUndo.Enabled = enable;
        }
        public void EnableNewLanGame(bool enable)
        {
            tsNewLanGame.Enabled = enable;
        }

        public void EnableLoad(bool enable)
        {
           //
        }

        public void ShowgbChessField(bool enable)
        {
            gbChessField.Visible = enable;
        }

        public void ShowrtbLog(bool enable)
        {
            rtbLog.Visible = enable;
        }

        public void ShowgbHUD(bool enable)
        {
            gbHUD.Visible = enable;
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            game.Close();
        }

        public string GetUserName(Side side)
        {
            Form1 form = new Form1(side);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
                return form.GetName();
            else
                // если не нажата OK оставить предыдущего игрока
                return null;
        }

        public void WhiteCount(int count)
        {
            lWhiteCount.Text = count.ToString() + "/16";
        }

        public void BlackCount(int count)
        {
            lBlackCount.Text = count.ToString() + "/16";
        }

        public void AddToLog(string message)
        {
            if (rtbLog.InvokeRequired)
                Invoke(new Action(() => rtbLog.AppendText(message + "\n")));
            else
                rtbLog.AppendText(message + "\n");
            
        }

        public void SetTurnText()
        {
            switch (game.GetState())
            {
                case GameState.WaitBlack:
                case GameState.HighlightedBlack: lTurn.Text = "Ход чёрных"; break;
                case GameState.HighlightedWhite:
                case GameState.WaitWhite: lTurn.Text = "Ход белых"; break;
                case GameState.LoseBlack: lTurn.Text = "Черные проиграли"; break;
                case GameState.LoseWhite: lTurn.Text = "Белые проиграли"; break;
                default: lTurn.Text = "Состояние не определено"; break;
            }

        }


        public void SetWhiteName(string s)
        {
            lWhite.Text = s;
        }

        public void SetBlackName(string s)
        {
            lBlack.Text = s;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Шахматы ver 1.0");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RulesForm form = new RulesForm();
            DialogResult result = form.ShowDialog();
        }

        /// <summary>
        /// Вызвать диалог выбора новой фигуры
        /// </summary>
        /// <returns></returns>
        public FigureTypes SelectFigure()
        {
            ChooseFigureForm form = new ChooseFigureForm();
            form.ShowDialog();
            return form.GetFigureType();
        }

        private void tsLoad_Click(object sender, EventArgs e)
        {
        }

        private void tsDefeat_Click(object sender, EventArgs e)
        {
            game.Defeat();
        }

        public void ClearLog()
        {
            rtbLog.Clear();
        }

        public void ShahWarning(Side side)
        {
            if (side == Side.Black)
                MessageBox.Show("Чёрный Король под шахом. Хьюстон, у нас проблема.");
            else
                MessageBox.Show("Белый Король под шахом. Хьюстон, у нас проблема.");
        }

        public void StalemateWarning(Side side)
        {
            if (side == Side.Black)
                MessageBox.Show("Тучи расступились, и с неба засветило яркое солнце. Поверженные чёрные фигуры тускло блестели...");
            else
                MessageBox.Show("Солнце скрылось за тучами, на поле боя пала тень. Поверженные белые фигуры пропали во мраке...");
        }

        public void Message(string s){
            MessageBox.Show(s);
        }

        private void tsNewServerGame_Click(object sender, EventArgs e)
        {
            game.NewServerGame();
        }

        private void tsNewClientGame_Click(object sender, EventArgs e)
        {
            game.NewClientGame();
        }

        private void lTurn_Click(object sender, EventArgs e)
        {

        }

        public DialogResult ShowServerBanner()
        {
            serverbannerform =new  ServerBannerForm();
            DialogResult dialogresult = serverbannerform.ShowDialog();
            return dialogresult;
        }

        public void HideServerBanner()
        {
            if (serverbannerform.InvokeRequired)
                Invoke(new Action(() => serverbannerform.Close()));
            else
            serverbannerform.Close();
        }

        private void tsGame_Click(object sender, EventArgs e)
        {

        }

        public string GetServerAddress()
        {
            ServerAddressDialog form = new ServerAddressDialog();
            DialogResult result = form.ShowDialog();
            return form.GetAddress();
        }

        private void tsStats_Click(object sender, EventArgs e)
        {
            ShowStatistic();
        }

        public void ShowStatistic() {
            if (game.Player1 != null && game.Player2 != null)
            {
                StatisticForm form = new StatisticForm(game.Player1, game.Player2);
                form.ShowDialog();
            }
        }
    }

}
