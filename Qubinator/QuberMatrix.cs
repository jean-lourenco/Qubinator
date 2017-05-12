using System;
using System.Text;

namespace Qubinator
{
    public class QuberMatrix
    {
        public string[,] Board { get; set; }

        public QuberMatrix(int size)
        {
            Board = new string[size, size];
        }

        public string[,] WriteWordToRow(string word, int initialIndex)
        {
            return BaseBoardWrite(
                    word,
                    initialIndex,
                    (row, column) => (row, ++column));
        }

        public string[,] WriteWordToRowBackwards(string word, int initialIndex)
        {
            return BaseBoardWrite(
                    word,
                    initialIndex,
                    (row, column) => (row, --column));
        }

        public string[,] WriteWordToColumn(string word, int initialIndex)
        {
            return BaseBoardWrite(
                    word,
                    initialIndex,
                    (row, column) => (++row, column));
        }

        public string[,] WriteWordToColumnBackwards(string word, int initialIndex)
        {
            return BaseBoardWrite(
                    word,
                    initialIndex,
                    (row, column) => (--row, column));
        }

        private string[,] BaseBoardWrite(string word, int initialIndex, Func<int, int, ValueTuple<int, int>> increment)
        {
            var column = initialIndex;
            var row = initialIndex;

            foreach (var letter in word)
            {
                Board[row, column] = letter.ToString();
                (row, column) = increment(row, column);
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