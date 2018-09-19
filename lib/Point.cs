namespace Qubinator.Lib
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(int initialValue)
        {
            X = initialValue;
            Y = initialValue;
        }

        public Point Increment(int x = 1, int y = 1)
        {
            return new Point(X + x, Y + y);
        }
    }
}