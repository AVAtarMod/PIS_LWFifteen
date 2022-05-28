using System;
using System.Collections.Generic;

namespace _3LW
{
    internal enum GameDifficulty
    {
        Easy,
        Normal,
        Hard
    }

    internal class Game
    {
        private readonly Storage _storage;
        private static Random _rand;
        private readonly Func<long, long, bool> _defaultCoordinateChecker;
        private readonly Dictionary<GameDifficulty, int> _difficultyMovesCount = new Dictionary<GameDifficulty, int>
        {
            {GameDifficulty.Easy, 2 },
            {GameDifficulty.Normal, 150 },
            {GameDifficulty.Hard,20000 }
        };

        public uint FieldHeight { get; private set; }
        public uint FieldWidth
        {
            get { return FieldHeight; }
            private set { FieldHeight = value; }
        }
        public GameCoordinate EmptyCell { get; private set; }
        public uint[,] Field { get; }
        public uint MoveCount { get; private set; }
        public enum Status
        {
            NotBeginned,
            Running,
            Finished
        }
        public Status GameStatus { get; private set; }

        public Game(uint size = 4)
        {
            FieldHeight = size;
            Field = new uint[size, size];
            GameStatus = Status.NotBeginned;

            _storage = new Storage();
            _rand = new Random();
            _defaultCoordinateChecker = (X, Y) => 0 <= X && X < FieldWidth && 0 <= Y && Y < FieldHeight;
        }

        public bool IsGameFinished() => GameStatus == Status.Finished;

        public void Start(GameDifficulty level)
        {
            InitField();
            EmptyCellUpdate();
            int moveCount = _difficultyMovesCount[level];

            for (int i = 0; i < moveCount; i++)
            {
                EmptyCellMoveUniqueRandom();
            }
            EmptyCellUpdate();
            GameStatus = Status.Running;
            MoveCount = 0;
        }

        public uint GetValue(GamePosition position)
        {
            return GetValue((GameCoordinate)position);
        }
        public uint GetValue(GameCoordinate coordinate)
        {
            if (coordinate.Y > FieldHeight || coordinate.X > FieldHeight) throw new ArgumentOutOfRangeException();

            return Field[coordinate.Y, coordinate.X];
        }

        public void EmptyCellMove(GameCoordinate a)
        {
            DoEmptyCellMove(a, isInitialization: false);
        }

        public bool IsCanUndo() => GameStatus == Status.Running && _storage.IsExistPreviousMove();

        public Storage.FieldChange EmptyCellMoveUndo()
        {
            Storage.FieldChange change;
            if (_storage.IsExistPreviousMove())
            {
                change = _storage.GetPreviousMove();
                Swap(new GamePosition(change.NewPosition, FieldHeight), new GamePosition(change.OldPosition, FieldHeight), false);
                --MoveCount;

                return change;
            }
            else
            {
                GamePosition tmp = new GamePosition(0, FieldHeight);
                return new Storage.FieldChange(tmp, tmp);
            }
        }

        public bool IsCanRedo() => GameStatus == Status.Running && _storage.IsExistNextMove();

        public Storage.FieldChange EmptyCellMoveRedo()
        {
            if (_storage.IsExistNextMove())
            {
                Storage.FieldChange change = _storage.GetNextMove();
                Swap(new GamePosition(change.NewPosition, FieldHeight), new GamePosition(change.OldPosition, FieldHeight), false);
                ++MoveCount;

                return new Storage.FieldChange(
                    new GamePosition(change.NewPosition, FieldHeight),
                    new GamePosition(change.OldPosition, FieldHeight)
                    );
            }
            else
            {
                GamePosition tmp = new GamePosition(0, FieldHeight);
                return new Storage.FieldChange(tmp, tmp);
            }
        }

        private void Swap(GameCoordinate a, GameCoordinate b, bool isInitialization)
        {
            uint buffer = GetValue(a);
            SetValue(a, GetValue(b), isInitialization);
            SetValue(b, buffer, isInitialization);

            EmptyCellUpdate();

            if (!isInitialization && IsGameFinishedCheck())
                GameStatus = Status.Finished;
        }
        private void EmptyCellMoveRandom()
        {
            Func<long, long, bool> checker = _defaultCoordinateChecker;
            EmptyCellMoveRandom(checker);
        }
        private void EmptyCellMoveUniqueRandom()
        {
            bool checker(long newX, long newY) => _defaultCoordinateChecker(newX, newY) && (newX != EmptyCell.X || newY != EmptyCell.Y);
            EmptyCellMoveRandom(checker);
        }
        private bool IsPointsOnSameDiagonal(GameCoordinate a, GameCoordinate b)
        {
            return Math.Abs((long)a.Y - b.Y) == Math.Abs((long)a.X - b.X);
        }
        private void EmptyCellMoveRandom(Func<long, long, bool> checker)
        {
            bool isValidValue = false;
            const int maxDiffCoordinateValue = 4;
            GameCoordinate a = EmptyCell;
            long newX, newY;

            while (!isValidValue)
            {
                (int, int) diff = MoveToCoordinateDiff(_rand.Next(maxDiffCoordinateValue));

                newX = a.X + diff.Item1;
                newY = a.Y + diff.Item2;

                isValidValue = checker(newX, newY);

                if (isValidValue)
                    (a.X, a.Y) = ((uint)newX, (uint)newY);
            }

            DoEmptyCellMove(a, true);
        }
        private static (int, int) MoveToCoordinateDiff(int value)
        {
            switch (value)
            {
                case 0:
                    return (0, 1); //Up
                case 1:
                    return (1, 0); //Right
                case 2:
                    return (0, -1); //Down
                case 3:
                    return (-1, 0); //Left
                default:
                    return (0, 0);
            }
        }

        private void InitField()
        {
            for (uint x = 0; x < FieldHeight; x++)
            {
                for (uint y = 0; y < FieldHeight; y++)
                {
                    Field[x, y] = ((GamePosition)new GameCoordinate(x, y, FieldHeight)).Value + 1;
                }
            }
            Field[FieldHeight - 1, FieldWidth - 1] = 0;
        }

        private void EmptyCellUpdate()
        {
            for (uint x = 0; x < FieldHeight; x++)
            {
                for (uint y = 0; y < FieldHeight; y++)
                {
                    if (Field[x, y] == 0)
                    {
                        EmptyCell = new GameCoordinate(x, y, FieldHeight);
                    }
                }
            }
        }
        private void SetValue(GamePosition position, uint value, bool force)
        {
            SetValue((GameCoordinate)position, value, force);
        }
        private void SetValue(GameCoordinate coordinate, uint value, bool force)
        {
            if (coordinate.Y > FieldHeight || coordinate.X > FieldHeight)
                throw new ArgumentOutOfRangeException();
            if (GameStatus != Status.Running && !force)
                throw new InvalidOperationException("Cannot modify field if game not running");
            Field[coordinate.Y, coordinate.X] = value;
        }

        private bool IsGameFinishedCheck()
        {
            if (GameStatus == Status.Running)
            {
                if (EmptyCell != new GamePosition(FieldHeight * FieldWidth - 1, FieldHeight))
                    return false;

                for (uint x = 0; x < FieldWidth; x++)
                {
                    for (uint y = 0; y < FieldHeight; y++)
                    {
                        if (Field[x, y] != (GamePosition)new GameCoordinate(x, y, FieldHeight) + 1 && Field[x, y] != 0)
                            return false;
                    }
                }

                return true;
            }
            else if (GameStatus == Status.Finished)
                return true;
            else
                throw new InvalidOperationException("Cannot check status of not beginned game");
        }

        private void DoEmptyCellMove(GameCoordinate a, bool isInitialization)
        {
            bool diffX = false, diffY = false;

            if (IsPointsOnSameDiagonal(EmptyCell, a))
                return;
            try
            {
                GameCoordinate diff = (EmptyCell > a) ? EmptyCell - a : a - EmptyCell;

                diffY = diff.Y == 1 && diff.X == 0;
                diffX = diff.X == 1 && diff.Y == 0;
            }
            catch (Exception)
            {
                return;
            }

            if (diffX || diffY)
            {
                if (!isInitialization)
                    _storage.AddMove(EmptyCell, a);
                Swap(EmptyCell, a, isInitialization);

                ++MoveCount;
            }
        }

    }
}
