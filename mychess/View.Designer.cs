namespace mychess
{
    partial class View
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param Name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNewLanGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNewServerGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNewClientGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDefeat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsStats = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHUD = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lBlack = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lWhite = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lWhiteCount = new System.Windows.Forms.Label();
            this.lTurn = new System.Windows.Forms.Label();
            this.lBlackCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.gbChessField = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.gbHUD.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGame,
            this.tsHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(929, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // tsGame
            // 
            this.tsGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNewGame,
            this.tsNewLanGame,
            this.toolStripSeparator1,
            this.tsUndo,
            this.tsDefeat,
            this.toolStripSeparator2,
            this.tsStats,
            this.toolStripSeparator3,
            this.tsExit});
            this.tsGame.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsGame.Image = ((System.Drawing.Image)(resources.GetObject("tsGame.Image")));
            this.tsGame.Name = "tsGame";
            this.tsGame.Size = new System.Drawing.Size(66, 20);
            this.tsGame.Text = "Игра";
            this.tsGame.Click += new System.EventHandler(this.tsGame_Click);
            // 
            // tsNewGame
            // 
            this.tsNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsNewGame.Image = ((System.Drawing.Image)(resources.GetObject("tsNewGame.Image")));
            this.tsNewGame.Name = "tsNewGame";
            this.tsNewGame.Size = new System.Drawing.Size(200, 22);
            this.tsNewGame.Text = "Новая игра";
            this.tsNewGame.Click += new System.EventHandler(this.tsNewGame_Click);
            // 
            // tsNewLanGame
            // 
            this.tsNewLanGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNewServerGame,
            this.tsNewClientGame});
            this.tsNewLanGame.Image = ((System.Drawing.Image)(resources.GetObject("tsNewLanGame.Image")));
            this.tsNewLanGame.Name = "tsNewLanGame";
            this.tsNewLanGame.Size = new System.Drawing.Size(200, 22);
            this.tsNewLanGame.Text = "Новая игра по сети";
            // 
            // tsNewServerGame
            // 
            this.tsNewServerGame.Name = "tsNewServerGame";
            this.tsNewServerGame.Size = new System.Drawing.Size(212, 22);
            this.tsNewServerGame.Text = "Создать игру";
            this.tsNewServerGame.Click += new System.EventHandler(this.tsNewServerGame_Click);
            // 
            // tsNewClientGame
            // 
            this.tsNewClientGame.Name = "tsNewClientGame";
            this.tsNewClientGame.Size = new System.Drawing.Size(212, 22);
            this.tsNewClientGame.Text = "Подключиться к игре";
            this.tsNewClientGame.Click += new System.EventHandler(this.tsNewClientGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // tsUndo
            // 
            this.tsUndo.Enabled = false;
            this.tsUndo.Name = "tsUndo";
            this.tsUndo.Size = new System.Drawing.Size(200, 22);
            this.tsUndo.Text = "Отменить ход";
            this.tsUndo.Visible = false;
            // 
            // tsDefeat
            // 
            this.tsDefeat.Enabled = false;
            this.tsDefeat.Image = ((System.Drawing.Image)(resources.GetObject("tsDefeat.Image")));
            this.tsDefeat.Name = "tsDefeat";
            this.tsDefeat.Size = new System.Drawing.Size(200, 22);
            this.tsDefeat.Text = "Сдаться";
            this.tsDefeat.Click += new System.EventHandler(this.tsDefeat_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // tsStats
            // 
            this.tsStats.Image = ((System.Drawing.Image)(resources.GetObject("tsStats.Image")));
            this.tsStats.Name = "tsStats";
            this.tsStats.Size = new System.Drawing.Size(200, 22);
            this.tsStats.Text = "Статистика";
            this.tsStats.Click += new System.EventHandler(this.tsStats_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(200, 22);
            this.tsExit.Text = "Выход";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // tsHelp
            // 
            this.tsHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem4});
            this.tsHelp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsHelp.Image")));
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.Size = new System.Drawing.Size(90, 20);
            this.tsHelp.Text = "Справка";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem2.Text = "Правила";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem4.Text = "О программе";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // gbHUD
            // 
            this.gbHUD.Controls.Add(this.groupBox3);
            this.gbHUD.Controls.Add(this.groupBox2);
            this.gbHUD.Controls.Add(this.groupBox1);
            this.gbHUD.Controls.Add(this.rtbLog);
            this.gbHUD.Location = new System.Drawing.Point(666, 46);
            this.gbHUD.Name = "gbHUD";
            this.gbHUD.Size = new System.Drawing.Size(251, 585);
            this.gbHUD.TabIndex = 31;
            this.gbHUD.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lBlack);
            this.groupBox3.Location = new System.Drawing.Point(26, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 44);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            // 
            // lBlack
            // 
            this.lBlack.AutoSize = true;
            this.lBlack.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lBlack.Location = new System.Drawing.Point(7, 17);
            this.lBlack.Name = "lBlack";
            this.lBlack.Size = new System.Drawing.Size(23, 16);
            this.lBlack.TabIndex = 29;
            this.lBlack.Text = "...";
            this.lBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lWhite);
            this.groupBox2.Location = new System.Drawing.Point(26, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 44);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // lWhite
            // 
            this.lWhite.AutoSize = true;
            this.lWhite.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lWhite.Location = new System.Drawing.Point(7, 17);
            this.lWhite.Name = "lWhite";
            this.lWhite.Size = new System.Drawing.Size(23, 16);
            this.lWhite.TabIndex = 29;
            this.lWhite.Text = "...";
            this.lWhite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lWhiteCount);
            this.groupBox1.Controls.Add(this.lTurn);
            this.groupBox1.Controls.Add(this.lBlackCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 109);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // lWhiteCount
            // 
            this.lWhiteCount.AutoSize = true;
            this.lWhiteCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lWhiteCount.Location = new System.Drawing.Point(136, 52);
            this.lWhiteCount.Name = "lWhiteCount";
            this.lWhiteCount.Size = new System.Drawing.Size(38, 16);
            this.lWhiteCount.TabIndex = 28;
            this.lWhiteCount.Text = "0/16";
            this.lWhiteCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTurn
            // 
            this.lTurn.AutoSize = true;
            this.lTurn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTurn.Location = new System.Drawing.Point(6, 17);
            this.lTurn.Name = "lTurn";
            this.lTurn.Size = new System.Drawing.Size(115, 23);
            this.lTurn.TabIndex = 27;
            this.lTurn.Text = "Ход белых";
            this.lTurn.Click += new System.EventHandler(this.lTurn_Click);
            // 
            // lBlackCount
            // 
            this.lBlackCount.AutoSize = true;
            this.lBlackCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lBlackCount.Location = new System.Drawing.Point(136, 75);
            this.lBlackCount.Name = "lBlackCount";
            this.lBlackCount.Size = new System.Drawing.Size(38, 16);
            this.lBlackCount.TabIndex = 26;
            this.lBlackCount.Text = "0/16";
            this.lBlackCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Черных фигур:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Белых фигур:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbLog.Location = new System.Drawing.Point(26, 236);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(185, 336);
            this.rtbLog.TabIndex = 31;
            this.rtbLog.Text = "";
            this.rtbLog.Visible = false;
            // 
            // gbChessField
            // 
            this.gbChessField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gbChessField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbChessField.Location = new System.Drawing.Point(58, 46);
            this.gbChessField.Margin = new System.Windows.Forms.Padding(0);
            this.gbChessField.Name = "gbChessField";
            this.gbChessField.Padding = new System.Windows.Forms.Padding(0);
            this.gbChessField.Size = new System.Drawing.Size(560, 560);
            this.gbChessField.TabIndex = 32;
            this.gbChessField.TabStop = false;
            this.gbChessField.Visible = false;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(929, 643);
            this.Controls.Add(this.gbChessField);
            this.Controls.Add(this.gbHUD);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "View";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Power Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbHUD.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsGame;
        private System.Windows.Forms.ToolStripMenuItem tsHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripMenuItem tsNewGame;
        public System.Windows.Forms.ToolStripMenuItem tsDefeat;
        public System.Windows.Forms.ToolStripMenuItem tsNewLanGame;
        public System.Windows.Forms.ToolStripMenuItem tsStats;
        public System.Windows.Forms.ToolStripMenuItem tsUndo;
        public System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem tsNewServerGame;
        private System.Windows.Forms.ToolStripMenuItem tsNewClientGame;
        private System.Windows.Forms.GroupBox gbHUD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lBlack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lWhite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lWhiteCount;
        private System.Windows.Forms.Label lTurn;
        private System.Windows.Forms.Label lBlackCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox gbChessField;

    }
}

