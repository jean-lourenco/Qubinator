using System;
using System.Linq;
using System.Text;

namespace Qubinator
{
    public static class Quber
    {
        public static string To2DSimple(string word)
        {
            ValidateInput(word);

            var matrix = new QuberMatrix(word.Length);

            WriteHalfBoard(matrix, word);

            return matrix.ToString();
        }

        public static string To2DFull(string word)
        {
            ValidateInput(word);

            var matrix = new QuberMatrix(word.Length);

            WriteAllBoard(matrix, word);

            return matrix.ToString();
        }

        public static string To3D(string word)
        {
            ValidateInput(word);

            var matrix = new QuberMatrix(GetBoardBoundaryFor3D(word));
            var offset = GetWordLengthByTwo(word);

            WriteAllBoard(matrix, word);
            WriteAllBoard(matrix, word, offset);

            matrix.DrawIncrementingTimes('\\', new Point(1, 1), offset - 1);
            matrix.DrawIncrementingTimes('\\', new Point(1, word.Length), offset - 1);
            matrix.DrawIncrementingTimes('\\', new Point(word.Length, 1), offset - 1);
            matrix.DrawIncrementingTimes('\\', new Point(word.Length, word.Length), offset - 1);

            return matrix.ToString();
        }

        public static string ToFullTextOffset(string word)
        {
            ValidateInput(word);

            var len = word.Length;
            var baseWord = word + word;
            var sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                sb.AppendLine(String.Join("", baseWord.Skip(i).Take(len)));
            }

            return sb.ToString();
        }

        private static void ValidateInput(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
                throw new ArgumentNullException(nameof(word));

            if (word.Length < 3)
                throw new ArgumentException("Word must have at least 3 characters", nameof(word));
        }

        private static void WriteHalfBoard(QuberMatrix matrix, string word, int offset = 0)
        {
            matrix.WriteWordToRow(word, offset);
            matrix.WriteWordToColumn(word, offset);
        }

        private static void WriteAllBoard(QuberMatrix matrix, string word, int offset = 0)
        {
            WriteHalfBoard(matrix, word, offset);

            matrix.WriteWordToRowBackwards(word, word.Length + offset - 1);
            matrix.WriteWordToColumnBackwards(word, word.Length + offset - 1);
        }

        private static int GetWordLengthByTwo(string word)
        {
            var len = (int)Math.Floor((double)word.Length / 2);

            return  word.Length > 7 ? len - 1: len;
        }

        private static int GetBoardBoundaryFor3D(string word)
        {
            return GetWordLengthByTwo(word) + word.Length;
        }
    }
}