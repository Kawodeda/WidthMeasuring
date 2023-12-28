namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math
{
    public class VectorF
    {
        public VectorF(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }

        public float Y { get; }

        public float Magnitude
        {
            get
            {
                return MathUtils.Distance(0, 0, X, Y);
            }
        }

        public bool IsZero
        {
            get
            {
                return X.NearlyEquals(0) && Y.NearlyEquals(0);
            }
        }

        public bool IsNaN
        {
            get
            {
                return float.IsNaN(X) || float.IsNaN(Y);
            }
        }

        public VectorF Add(VectorF other)
        {
            return new VectorF(X + other.X, Y + other.Y);
        }

        public VectorF Invert()
        {
            return new VectorF(-X, -Y);
        }

        public VectorF Scale(float factor)
        {
            return new VectorF(factor * X, factor * Y);
        }

        public static VectorF operator +(VectorF a, VectorF b)
        {
            return a.Add(b);
        }

        public static VectorF operator -(VectorF vector)
        {
            return vector.Invert();
        }

        public static VectorF operator -(VectorF a, VectorF b)
        {
            return a.Add(b.Invert());
        }

        public static VectorF operator *(float factor, VectorF vector)
        {
            return vector.Scale(factor);
        }

        public static VectorF operator *(VectorF vector, float factor)
        {
            return factor * vector;
        }

        public static implicit operator VectorF(VectorInt vector)
        {
            return new VectorF(vector.X, vector.Y);
        }

        public override bool Equals(object obj)
        {
            var vectorF = obj as VectorF;

            return ReferenceEquals(this, vectorF) 
                || vectorF != null
                && X.NearlyEquals(vectorF.X)
                && Y.NearlyEquals(vectorF.Y);
        }
    }
}