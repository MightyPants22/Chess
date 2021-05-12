namespace mychess
{
    partial class StatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lName1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lLose1 = new System.Windows.Forms.Label();
            this.lWin1 = new System.Windows.Forms.Label();
            this.lPlayed1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lLose2 = new System.Windows.Forms.Label();
            this.lWin2 = new System.Windows.Forms.Label();
            this.lPlayed2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lName2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // okbtn
            // 
            this.okbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okbtn.Location = new System.Drawing.Point(86, 256);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(75, 23);
            this.okbtn.TabIndex = 0;
            this.okbtn.Text = "OK";
            this.okbtn.UseVisualStyleBackColor = false;
            this.okbtn.Click += new System.EventHandler(this.okbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // lName1
            // 
            this.lName1.AutoSize = true;
            this.lName1.Location = new System.Drawing.Point(123, 16);
            this.lName1.Name = "lName1";
            this.lName1.Size = new System.Drawing.Size(39, 13);
            this.lName1.TabIndex = 2;
            this.lName1.Text = "\"Имя\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Игр сыграно";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lLose1);
            this.groupBox1.Controls.Add(this.lWin1);
            this.groupBox1.Controls.Add(this.lPlayed1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lName1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 116);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Белый игрок";
            // 
            // lLose1
            // 
            this.lLose1.AutoSize = true;
            this.lLose1.Location = new System.Drawing.Point(123, 90);
            this.lLose1.Name = "lLose1";
            this.lLose1.Size = new System.Drawing.Size(75, 13);
            this.lLose1.TabIndex = 9;
            this.lLose1.Text = "\"Поражений\"";
            // 
            // lWin1
            // 
            this.lWin1.AutoSize = true;
            this.lWin1.Location = new System.Drawing.Point(123, 65);
            this.lWin1.Name = "lWin1";
            this.lWin1.Size = new System.Drawing.Size(49, 13);
            this.lWin1.TabIndex = 8;
            this.lWin1.Text = "\"Побед\"";
            // 
            // lPlayed1
            // 
            this.lPlayed1.AutoSize = true;
            this.lPlayed1.Location = new System.Drawing.Point(123, 40);
            this.lPlayed1.Name = "lPlayed1";
            this.lPlayed1.Size = new System.Drawing.Size(61, 13);
            this.lPlayed1.TabIndex = 7;
            this.lPlayed1.Text = "\"Сыграно\"";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Поражений";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Побед";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lLose2);
            this.groupBox2.Controls.Add(this.lWin2);
            this.groupBox2.Controls.Add(this.lPlayed2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lName2);
            this.groupBox2.Location = new System.Drawing.Point(12, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 116);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Черный игрок";
            // 
            // lLose2
            // 
            this.lLose2.AutoSize = true;
            this.lLose2.Location = new System.Drawing.Point(123, 90);
            this.lLose2.Name = "lLose2";
            this.lLose2.Size = new System.Drawing.Size(75, 13);
            this.lLose2.TabIndex = 9;
            this.lLose2.Text = "\"Поражений\"";
            // 
            // lWin2
            // 
            this.lWin2.AutoSize = true;
            this.lWin2.Location = new System.Drawing.Point(123, 65);
            this.lWin2.Name = "lWin2";
            this.lWin2.Size = new System.Drawing.Size(49, 13);
            this.lWin2.TabIndex = 8;
            this.lWin2.Text = "\"Побед\"";
            // 
            // lPlayed2
            // 
            this.lPlayed2.AutoSize = true;
            this.lPlayed2.Location = new System.Drawing.Point(123, 40);
            this.lPlayed2.Name = "lPlayed2";
            this.lPlayed2.Size = new System.Drawing.Size(61, 13);
            this.lPlayed2.TabIndex = 7;
            this.lPlayed2.Text = "\"Сыграно\"";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Поражений";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Побед";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Имя";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Игр сыграно";
            // 
            // lName2
            // 
            this.lName2.AutoSize = true;
            this.lName2.Location = new System.Drawing.Point(123, 16);
            this.lName2.Name = "lName2";
            this.lName2.Size = new System.Drawing.Size(39, 13);
            this.lName2.TabIndex = 2;
            this.lName2.Text = "\"Имя\"";
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StatisticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Статистика";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lName1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lLose1;
        private System.Windows.Forms.Label lWin1;
        private System.Windows.Forms.Label lPlayed1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lLose2;
        private System.Windows.Forms.Label lWin2;
        private System.Windows.Forms.Label lPlayed2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lName2;
    }
}