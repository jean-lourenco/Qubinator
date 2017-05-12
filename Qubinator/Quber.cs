using System;

namespace Qubinator
{
    public class Quber
    {
        public bool AllUpperCase { get; set; }

        private void WriteHalfBoard(QuberMatrix matrix, string word, int offset = 0)
        {
            matrix.WriteWordToRow(word, offset);
            matrix.WriteWordToColumn(word, offset);
        }

        private void WriteAllBoard(QuberMatrix matrix, string word, int offset = 0)
        {
            WriteHalfBoard(matrix, word, offset);

            matrix.WriteWordToRowBackwards(word, word.Length + offset - 1);
            matrix.WriteWordToColumnBackwards(word, word.Length + offset - 1);
        }

        public string To2DSimple(string word)
        {
            word = Transform(word);

            var matrix = new QuberMatrix(word.Length);

            WriteHalfBoard(matrix, word);

            return matrix.ToString();
        }

        public string To2DFull(string word)
        {
            word = Transform(word);

            var matrix = new QuberMatrix(word.Length);

            WriteAllBoard(matrix, word);

            return matrix.ToString();
        }

        public string To3D(string word)
        {
            word = Transform(word);

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

        private string Transform(string word)
        {
            if (AllUpperCase)
                word = word.ToUpper();

            return word;
        }

        private int GetWordLengthByTwo(string word)
        {
            var len = (int)Math.Floor((double)word.Length / 2);

            return  word.Length > 7 ? len - 1: len;
        }

        private int GetBoardBoundaryFor3D(string word)
        {
            return GetWordLengthByTwo(word) + word.Length;
        }
    }
}