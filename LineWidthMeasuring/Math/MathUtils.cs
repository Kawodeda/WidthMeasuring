namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math
{
    public static class MathUtils
    {
        public static float Distance(float x1, float y1, float x2, float y2)
        {
            return (float)System.Math.Sqrt(
                System.Math.Pow(x1 - x2, 2) 
              + System.Math.Pow(y1 - y2, 2));
        }

        public static float Distance(IPointInt point1, IPointInt point2)
        {
            return Distance(point1.X, point1.Y, point2.X, point2.Y);
        }

        public static float Distance(VectorF a, VectorF b)
        {
            return Distance(a.X, a.Y, b.X, b.Y);
        }

        public static float LineSlope(VectorF direction)
        {
            return direction.Y / direction.X;
        }

        public static float DotProduct(VectorF a, VectorF b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static double Clamp(double value, double min, double max)
        {
            return System.Math.Max(System.Math.Min(value, max), min);
        }

        public static bool NearlyEquals(this float number, float other, float epsilon = 0.000001f)
        {
            float diff = System.Math.Abs(number - other);

            return diff < epsilon;
        }
    }
}