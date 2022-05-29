using System;

namespace _3LW
{
    /// <summary>
    /// Container for coordinates with several basic checks
    /// </summary>
    internal struct GameCoordinate
    {
        public uint Y { get; set; }
        public uint X { get; set; }
        public uint FieldHeight { get; private set; }

        public GameCoordinate(Tuple<uint, uint, uint> tuple)
        {
            X = tuple.Item1;
            Y = tuple.Item2;
            FieldHeight = tuple.Item3;
        }

        /// <summary>
        /// Construct coordinate by x,y without checking x,y is out
        /// of bounds the game field 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fieldHeight"></param>
        public GameCoordinate(uint x, uint y, uint fieldHeight)
        {
            if (fieldHeight == 0)
                throw new ArgumentException("Can't be equal zero", "size");
            X = x;
            Y = y;
            FieldHeight = fieldHeight;
        }

        public static implicit operator GameCoordinate(GamePosition position)
        {
            return new GameCoordinate(position.Value % position.FieldHeight,  position.Value / position.FieldHeight, position.FieldHeight);
        }

        public static GameCoordinate operator -(GameCoordinate left, GameCoordinate right)
        {
            bool isValidRight = right.Y <= left.Y && right.X <= left.X && left.FieldHeight == right.FieldHeight;

            if (!isValidRight)
            {
                throw new ArgumentException("Right operand must be not greater than left, and fieldSize must be equal", "right");
            }

            return new GameCoordinate(left.X - right.X, left.Y - right.Y, left.FieldHeight);
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
