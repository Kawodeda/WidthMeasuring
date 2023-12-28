using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path
{
    public class LineSegment : Segment
    {
        private readonly VectorF _direction;
        private readonly float _slope;

        public LineSegment(VectorF start, VectorF end) : base(start, end)
        {
            _direction = End - Start;
            _slope = MathUtils.LineSlope(_direction);
        }

        public override VectorF GetPositionAt(float t)
        {
            return Start + t * _direction;
        }

        protected override float GetTangentAt(float t)
        {
            return _slope;
        }
    }
}