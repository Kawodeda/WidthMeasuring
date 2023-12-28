using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path
{
    public abstract class Segment
    {
        protected Segment(VectorF start, VectorF end)
        {
            Start = start;
            End = end;
        }

        public VectorF Start { get; }

        public VectorF End { get; }

        /// <param name="t">Segment parameter in range [0, 1], where 0 is the start point of a segment and 1 is the end point.</param>
        public abstract VectorF GetPositionAt(float t);

        /// <param name="t">Segment parameter in range [0, 1], where 0 is the start point of a segment and 1 is the end point.</param>
        public VectorF GetNormalAt(float t)
        {
            float tangentSlope = GetTangentAt(t);
            float normalSlope = -1 / tangentSlope;
            if (tangentSlope.NearlyEquals(0))
            {
                return new VectorF(0, System.Math.Sign(normalSlope));
            }
            if (float.IsInfinity(tangentSlope))
            {
                return new VectorF(-System.Math.Sign(tangentSlope), 0);
            }

            float x = 1 / (float)System.Math.Sqrt(1 + System.Math.Pow(normalSlope, 2));
            float y = x * normalSlope;

            return new VectorF(x, y);
        }

        public override bool Equals(object obj)
        {
            var segment = obj as Segment;

            return ReferenceEquals(this, segment)
                || segment != null
                && Start.Equals(segment.Start)
                && End.Equals(segment.End);
        }

        protected abstract float GetTangentAt(float t);
    }
}