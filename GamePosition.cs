using System;

namespace _3LW
{
    internal struct GamePosition
    {
        public uint Value { get; private set; }
        public uint FieldHeight { get; private set; }

        public GamePosition(Tuple<uint, uint> tuple)
        {
            Value = tuple.Item1;
            FieldHeight = tuple.Item2;
        }

        public GamePosition(uint position, uint fieldHeight)
        {
            if (fieldHeight == 0)
                throw new ArgumentException("Can't be equal zero", "size");
            Value = position;
            FieldHeight = fieldHeight;
        }
        public static implicit operator GamePosition(GameCoordinate coordinate)
        {
            return new GamePosition(coordinate.Y * coordinate.FieldHeight + coordinate.X, coordinate.FieldHeight);
        }

        public static long operator -(GamePosition a, GamePosition b)
        {
            return a.Value - b.Value;
        }

        public static implicit operator uint(GamePosition a)
        {
            return a.Value;
        }
        public static implicit operator int(GamePosition a)
        {
            return (int)a.Value;
        }
        public static implicit operator GamePosition((uint, uint) pair)
        {
            return new GamePosition(pair.Item1, pair.Item2);
        }
    }
}
