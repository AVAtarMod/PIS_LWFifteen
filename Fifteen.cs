using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _3LW
{
    public partial class Fifteen : Form
    {
        private readonly List<Button> _buttonsArray;
        private readonly Dictionary<GameDifficulty, ToolStripMenuItem> _stripDiffLevelDict;
        private readonly Dictionary<string, FeatureData> _undoFeatureData;

        private Game _game;
        private string _barMoveTemplate;
        private string _barTimerTemplate;
        private DateTime _timeStartGame;
        private GameDifficulty _difficulty;

        private struct FeatureData
        {
            public ToolStripMenuItem UIElement { get; }
            public Func<Storage.FieldChange> Handler { get; }
            public Func<bool> Checker { get; }

            public FeatureData(ToolStripMenuItem item, Func<Storage.FieldChange> handler, Func<bool> checker)
            {
                UIElement = item;
                Handler = handler;
                Checker = checker;
            }
        }

        private Button GetButton(int index)
        {
            return _buttonsArray[index];
        }

        public Fifteen()
        {
            InitializeComponent();
            _buttonsArray = new List<Button>{
                button0, button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15 };

            _stripDiffLevelDict = new Dictionary<GameDifficulty, ToolStripMenuItem>{
                {GameDifficulty.Easy, difficultyEasy},
                {GameDifficulty.Normal, difficultyNormal },
                {GameDifficulty.Hard, difficultyHard },
            };

            _game = new Game();

            _undoFeatureData = new Dictionary<string, FeatureData> {
                { "Undo",
                    new FeatureData(undoMove, _game.EmptyCellMoveUndo, _game.IsCanUndo)
                },
                { "Redo",
                    new FeatureData(redoMove, _game.EmptyCellMoveRedo, _game.IsCanRedo)
                }
            };

            _barMoveTemplate = statusBarMoveCount.Text;
            _barTimerTemplate = statusBarTimer.Text;

            statusBarMoveCount.Text = $"{_barMoveTemplate}{0}";
            statusBarTimer.Text = $"{_barTimerTemplate}{0}";

            _difficulty = GameDifficulty.Normal;
            _stripDiffLevelDict[_difficulty].Checked = true;

            undoMove.HideDropDown();
            redoMove.HideDropDown();

            UpdateHistoryButtonsStatus();
        }

        public void RefreshGrid()
        {
            uint[,] field = _game.Field;
            uint width = (uint)field.GetLength(0);
            uint heigth = (uint)field.Length / width;
            for (uint x = 0; x < width; x++)
            {
                for (uint y = 0; y < heigth; y++)
                {
                    GamePosition position = new GameCoordinate(x, y, heigth);
                    uint value = field[x, y];
                    if (value != 0)
                    {
                        Button tmp = _buttonsArray[(int)position.Value];
                        tmp.Text = $"{value}";
                        if (!tmp.Visible)
                            tmp.Show();
                    }
                    else
                        _buttonsArray[(int)position.Value].Hide();
                }
            }

            table.Refresh();
        }

        private void StartMenu_Click(object sender, System.EventArgs e)
        {
            GameStart();
        }

        private void GameStart()
        {
            _game.Start(_difficulty);
            RefreshGrid();
            _timeStartGame = DateTime.Now;
            gameTimer.Start();
            _buttonsArray.ForEach(i => i.Enabled = true);

            UpdateHistoryButtonsStatus();
        }
        private void Shift(GamePosition position)
        {
            Button button = _buttonsArray[(GamePosition)_game.EmptyCell];
            button.Show();
            button.Select();

            _game.EmptyCellMove(position);
            statusBarMoveCount.Text = $"{_barMoveTemplate}{_game.MoveCount}";
            RefreshGrid();

            UpdateHistoryButtonsStatus();

            if (_game.IsGameFinished())
                GameFinish();
        }

        private void UpdateHistoryButtonsStatus()
        {
            foreach (FeatureData data in _undoFeatureData.Values)
            {
                if (_game.GameStatus == Game.Status.NotBeginned)
                    data.UIElement.Visible = false;
                else if (_game.GameStatus != Game.Status.NotBeginned && !data.UIElement.Visible)
                    data.UIElement.Visible = true;

                if (data.Checker())
                    data.UIElement.Enabled = true;
                else
                    data.UIElement.Enabled = false;
            }
        }

        private void GameFinish()
        {
            _buttonsArray.ForEach(i => i.Enabled = false);
            gameTimer.Stop();
            MessageBox.Show("Поздравлем! Вы победили!");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (_game.GameStatus == Game.Status.Running)
            {
                Button current = (Button)sender;
                Button previuos = _buttonsArray[(GamePosition)_game.EmptyCell];

                GamePosition position = (uint.Parse(current.Tag.ToString()), _game.FieldHeight);

                Shift(position);
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - _timeStartGame;
            string timeString = "";
            if (diff.Hours > 0)
                timeString = $"{diff.Hours} ч. ";
            if (diff.Minutes > 0)
                timeString += $"{diff.Minutes} мин. ";
            timeString += $"{diff.Seconds} сек.";
            statusBarTimer.Text = $"{_barTimerTemplate}{timeString}";
        }

        private void Difficulty_Change(object sender, EventArgs e)
        {
            GameDifficulty current = (GameDifficulty)((ToolStripMenuItem)sender).Tag;
            if (_difficulty != current)
            {
                _stripDiffLevelDict[_difficulty].Checked = false;
                _stripDiffLevelDict[current].Checked = true;
                _difficulty = current;
            }
        }

        private void UndoMove_Handler(object sender, EventArgs e)
        {
            string operation = (string)((ToolStripMenuItem)sender).Tag;
            FeatureData featureData = _undoFeatureData[operation];
            Storage.FieldChange change = featureData.Handler();
            if (change.NewPosition != change.OldPosition)
            {
                _buttonsArray[(int)change.NewPosition].Select();
                RefreshGrid();
            }

            UpdateHistoryButtonsStatus();
        }
    }
}
