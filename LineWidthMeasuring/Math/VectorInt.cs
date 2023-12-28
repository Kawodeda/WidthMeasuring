namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math
{
    public class VectorInt : IPointInt
    {
        public VectorInt(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static VectorInt Zero
        {
            get
            {
                return new VectorInt(0, 0);
            }
        }

        public int X { get; }

        public int Y { get; }

        public bool IsZero
        {
            get
            {
                return X == 0 && Y == 0;
            }
        }

        public float Magnitude
        {
            get
            {
                return MathUtils.Distance(0, 0, X, Y);
            }
        }

        public VectorInt Add(VectorInt other)
        {
            return new VectorInt(X + other.X, Y + other.Y);
        }

        public VectorInt Divide(int divider)
        {
            return new VectorInt(X / divider, Y / divider);
        }

        public static VectorInt operator +(VectorInt a, VectorInt b)
        {
            return a.Add(b);
        }

        public static VectorInt operator /(VectorInt vector, int divider)
        {
            return vector.Divide(divider);
        }

        public static explicit operator VectorInt(VectorF vector)
        {
            return new VectorInt((int)vector.X, (int)vector.Y);
        }
    }
}