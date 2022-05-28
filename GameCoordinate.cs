using System;

namespace _3LW
{
    internal struct GameCoordinate
    {
        public uint Y { get; set; }
        public uint X { get; set; }
        public uint FieldHeight { get; private set; }

        public GameCoordinate(Tuple<uint, uint, uint> tuple)
        {
            Y = tuple.Item1;
            X = tuple.Item2;
            FieldHeight = tuple.Item3;
        }

        public GameCoordinate(uint x, uint y, uint fieldHeight)
        {
            if (fieldHeight == 0)
                throw new ArgumentException("Can't be equal zero", "size");
            Y = x;
            X = y;
            FieldHeight = fieldHeight;
        }

        public static implicit operator GameCoordinate(GamePosition position)
        {
            return new GameCoordinate(position.Value / position.FieldHeight, position.Value % position.FieldHeight, position.FieldHeight);
        }

        public static GameCoordinate operator -(GameCoordinate left, GameCoordinate right)
        {
            bool isValidRight = right.Y <= left.Y && right.X <= left.X && left.FieldHeight == right.FieldHeight;

            if (!isValidRight)
            {
                throw new ArgumentException("Right operand must be not greater than left, and fieldSize must be equal", "right");
            }

            return new GameCoordinate(left.Y - right.Y, left.X - right.X, left.FieldHeight);
        }

        public static bool operator ==(GameCoordinate a, GameCoordinate b) => a.Y == b.Y && a.X == b.X && a.FieldHeight == b.FieldHeight;
        public static bool operator !=(GameCoordinate a, GameCoordinate b) => !(a == b);

        public static implicit operator GameCoordinate((uint, uint, uint) tuple)
        {
            return new GameCoordinate(tuple.Item1, tuple.Item2, tuple.Item3);
        }
        public static bool operator >(GameCoordinate a, GameCoordinate b)
        {
            return (a.Y > b.Y && a.X >= b.X) || (a.Y >= b.Y && a.X > b.X);
        }
        public static bool operator <(GameCoordinate a, GameCoordinate b)
        {
            return (a.Y < b.Y && a.X <= b.X) || (a.Y <= b.Y && a.X < b.X);
        }
    }
}
