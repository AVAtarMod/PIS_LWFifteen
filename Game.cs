using System;
namespace _3LW
{
    internal class Game
    {
        public struct Coordinate
        {
            public uint X { get; private set; }
            public uint Y { get; private set; }
            public uint Size { get; private set; }

            public Coordinate(uint x, uint y, uint size)
            {
                if (size == 0)
                    throw new ArgumentException("Can't be equal zero", "size");
                X = x;
                Y = y;
                Size = size;
            }

            public static explicit operator Coordinate(Position position)
            {
                return new Coordinate(position.Value / position.Size, position.Value % position.Size, position.Size);
            }
        }
        public struct Position
        {
            public uint Value { get; private set; }
            public uint Size { get; private set; }
            public Position(uint position, uint size)
            {
                if (size == 0)
                    throw new ArgumentException("Can't be equal zero", "size");
                Value = position;
                Size = size;
            }
            public static explicit operator Position(Coordinate coordinate)
            {
                return new Position(coordinate.X * coordinate.Size + coordinate.Y, coordinate.Size);
            }
        }

        private uint[,] field;
        private uint size;
        private Storage storage;

        public Game(uint size = 4)
        {
            this.size = size;
        }
    }
}
