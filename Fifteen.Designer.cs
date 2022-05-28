namespace _3LW
{
    partial class Fifteen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.startMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyList = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyHard = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMove = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMove = new System.Windows.Forms.ToolStripMenuItem();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarMoveCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.menu.SuspendLayout();
            this.table.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenu,
            this.difficultyList,
            this.undoMove,
            this.redoMove});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(810, 33);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // startMenu
            // 
            this.startMenu.Name = "startMenu";
            this.startMenu.Size = new System.Drawing.Size(123, 29);
            this.startMenu.Text = "Начать игру";
            this.startMenu.Click += new System.EventHandler(this.StartMenu_Click);
            // 
            // difficultyList
            // 
            this.difficultyList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyEasy,
            this.difficultyNormal,
            this.difficultyHard});
            this.difficultyList.Name = "difficultyList";
            this.difficultyList.Size = new System.Drawing.Size(186, 29);
            this.difficultyList.Text = "Уровень сложности";
            // 
            // difficultyEasy
            // 
            this.difficultyEasy.Name = "difficultyEasy";
            this.difficultyEasy.Size = new System.Drawing.Size(204, 30);
            this.difficultyEasy.Tag = _3LW.GameDifficulty.Easy;
            this.difficultyEasy.Text = "Легкий";
            this.difficultyEasy.Click += new System.EventHandler(this.Difficulty_Change);
            // 
            // difficultyNormal
            // 
            this.difficultyNormal.Name = "difficultyNormal";
            this.difficultyNormal.Size = new System.Drawing.Size(204, 30);
            this.difficultyNormal.Tag = _3LW.GameDifficulty.Normal;
            this.difficultyNormal.Text = "Нормальный";
            this.difficultyNormal.Click += new System.EventHandler(this.Difficulty_Change);
            // 
            // difficultyHard
            // 
            this.difficultyHard.Name = "difficultyHard";
            this.difficultyHard.Size = new System.Drawing.Size(204, 30);
            this.difficultyHard.Tag = _3LW.GameDifficulty.Hard;
            this.difficultyHard.Text = "Сложный";
            this.difficultyHard.Click += new System.EventHandler(this.Difficulty_Change);
            // 
            // undoMove
            // 
            this.undoMove.Name = "undoMove";
            this.undoMove.Size = new System.Drawing.Size(158, 29);
            this.undoMove.Tag = "Undo";
            this.undoMove.Text = "Отменить ход ↩";
            this.undoMove.Click += new System.EventHandler(this.UndoMove_Handler);
            // 
            // undoMoveCancel
            // 
            this.redoMove.Name = "undoMoveCancel";
            this.redoMove.Size = new System.Drawing.Size(144, 29);
            this.redoMove.Tag = "Redo";
            this.redoMove.Text = "Вернуть ход ↪";
            this.redoMove.Click += new System.EventHandler(this.UndoMove_Handler);
            // 
            // table
            // 
            this.table.ColumnCount = 4;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.Controls.Add(this.button15, 3, 3);
            this.table.Controls.Add(this.button14, 2, 3);
            this.table.Controls.Add(this.button13, 1, 3);
            this.table.Controls.Add(this.button12, 0, 3);
            this.table.Controls.Add(this.button11, 3, 2);
            this.table.Controls.Add(this.button10, 2, 2);
            this.table.Controls.Add(this.button9, 1, 2);
            this.table.Controls.Add(this.button8, 0, 2);
            this.table.Controls.Add(this.button7, 3, 1);
            this.table.Controls.Add(this.button6, 2, 1);
            this.table.Controls.Add(this.button5, 1, 1);
            this.table.Controls.Add(this.button4, 0, 1);
            this.table.Controls.Add(this.button3, 3, 0);
            this.table.Controls.Add(this.button2, 2, 0);
            this.table.Controls.Add(this.button1, 1, 0);
            this.table.Controls.Add(this.button0, 0, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 33);
            this.table.Name = "table";
            this.table.RowCount = 4;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.Size = new System.Drawing.Size(810, 405);
            this.table.TabIndex = 1;
            // 
            // button15
            // 
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button15.Location = new System.Drawing.Point(609, 306);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(198, 96);
            this.button15.TabIndex = 15;
            this.button15.Tag = "15";
            this.button15.Text = "*";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button_Click);
            // 
            // button14
            // 
            this.button14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button14.Location = new System.Drawing.Point(407, 306);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(196, 96);
            this.button14.TabIndex = 14;
            this.button14.Tag = "14";
            this.button14.Text = "*";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button_Click);
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button13.Location = new System.Drawing.Point(205, 306);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(196, 96);
            this.button13.TabIndex = 13;
            this.button13.Tag = "13";
            this.button13.Text = "*";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button_Click);
            // 
            // button12
            // 
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button12.Location = new System.Drawing.Point(3, 306);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(196, 96);
            this.button12.TabIndex = 12;
            this.button12.Tag = "12";
            this.button12.Text = "*";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button_Click);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button11.Location = new System.Drawing.Point(609, 205);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(198, 95);
            this.button11.TabIndex = 11;
            this.button11.Tag = "11";
            this.button11.Text = "*";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button_Click);
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button10.Location = new System.Drawing.Point(407, 205);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(196, 95);
            this.button10.TabIndex = 10;
            this.button10.Tag = "10";
            this.button10.Text = "*";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button_Click);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button9.Location = new System.Drawing.Point(205, 205);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(196, 95);
            this.button9.TabIndex = 9;
            this.button9.Tag = "9";
            this.button9.Text = "*";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button_Click);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button8.Location = new System.Drawing.Point(3, 205);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(196, 95);
            this.button8.TabIndex = 8;
            this.button8.Tag = "8";
            this.button8.Text = "*";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button7.Location = new System.Drawing.Point(609, 104);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(198, 95);
            this.button7.TabIndex = 7;
            this.button7.Tag = "7";
            this.button7.Text = "*";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button6.Location = new System.Drawing.Point(407, 104);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(196, 95);
            this.button6.TabIndex = 6;
            this.button6.Tag = "6";
            this.button6.Text = "*";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button5.Location = new System.Drawing.Point(205, 104);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(196, 95);
            this.button5.TabIndex = 5;
            this.button5.Tag = "5";
            this.button5.Text = "*";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button4.Location = new System.Drawing.Point(3, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 95);
            this.button4.TabIndex = 4;
            this.button4.Tag = "4";
            this.button4.Text = "*";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button3.Location = new System.Drawing.Point(609, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 95);
            this.button3.TabIndex = 3;
            this.button3.Tag = "3";
            this.button3.Text = "*";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button2.Location = new System.Drawing.Point(407, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 95);
            this.button2.TabIndex = 2;
            this.button2.Tag = "2";
            this.button2.Text = "*";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button1.Location = new System.Drawing.Point(205, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 95);
            this.button1.TabIndex = 1;
            this.button1.Tag = "1";
            this.button1.Text = "*";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Click);
            // 
            // button0
            // 
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button0.Location = new System.Drawing.Point(3, 3);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(196, 95);
            this.button0.TabIndex = 0;
            this.button0.Tag = "0";
            this.button0.Text = "*";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.Button_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarTimer,
            this.statusBarMoveCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(810, 30);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBarTimer
            // 
            this.statusBarTimer.Name = "statusBarTimer";
            this.statusBarTimer.Size = new System.Drawing.Size(147, 25);
            this.statusBarTimer.Text = "Текущее время: ";
            // 
            // statusBarMoveCount
            // 
            this.statusBarMoveCount.Name = "statusBarMoveCount";
            this.statusBarMoveCount.Size = new System.Drawing.Size(172, 25);
            this.statusBarMoveCount.Text = "Совершено ходов: ";
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // Fifteen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 468);
            this.Controls.Add(this.table);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(478, 322);
            this.Name = "Fifteen";
            this.Text = "Пятнашки";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.table.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem startMenu;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarTimer;
        private System.Windows.Forms.ToolStripStatusLabel statusBarMoveCount;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ToolStripMenuItem difficultyList;
        private System.Windows.Forms.ToolStripMenuItem difficultyEasy;
        private System.Windows.Forms.ToolStripMenuItem difficultyNormal;
        private System.Windows.Forms.ToolStripMenuItem difficultyHard;
        private System.Windows.Forms.ToolStripMenuItem undoMove;
        private System.Windows.Forms.ToolStripMenuItem redoMove;
    }
}

