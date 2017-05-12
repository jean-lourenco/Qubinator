namespace Qubinator
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

        public Point Increment(int x = 1, int y = 1)
        {
            return new Point(X + x, Y + y);
        }
    }
}