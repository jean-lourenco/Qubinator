using System;
using System.Text;

namespace Qubinator.Lib
{
    public class QuberMatrix
    {
        public string[,] Board { get; set; }

        public QuberMatrix(int size)
        {
            Board = new string[size, size];
        }

        public string[,] WriteWordToRow(string word, Point initialPosition)
        {
            return BaseBoardWrite(
                    word,
                    initialPosition,
                    (position) => new Point(position.X, position.Y + 1));
        }

        public string[,] WriteWordToRowBackwards(string word, Point initialPosition)
        {
            return BaseBoardWrite(
                    word,
                    initialPosition,
                    (position) => new Point(position.X, position.Y - 1));
        }

        public string[,] WriteWordToColumn(string word, Point initialPosition)
        {
            return BaseBoardWrite(
                    word,
                    initialPosition,
                    (position) => new Point(position.X + 1, position.Y));
        }

        public string[,] WriteWordToColumnBackwards(string word, Point initialPosition)
        {
            return BaseBoardWrite(
                    word,
                    initialPosition,
                    (position) => new Point(position.X - 1, position.Y));
        }

        private string[,] BaseBoardWrite(string word, Point position, Func<Point, Point> increment)
        {
            foreach (var letter in word)
            {
                Board[position.X, position.Y] = letter.ToString();
                position = increment(position);
            }

            return Board;
        }

        public void DrawIncrementingTimes(char letter, Point initial, int times)
        {
            for (var i = 0; i < times; i++)
            {
                Board[initial.X, initial.Y] = letter.ToString();

                initial = initial.Increment();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var x = 0; x < Board.GetLength(0); x++)
            {
                for (var y = 0; y < Board.GetLength(1); y++)
                {
                    var value = Board[x, y];

                    sb.Append(String.IsNullOrWhiteSpace(value) ? " " : value);
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}