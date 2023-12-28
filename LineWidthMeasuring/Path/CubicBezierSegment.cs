using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path
{
    public class CubicBezierSegment : Segment
    {
        public CubicBezierSegment(VectorF start, VectorF control1, VectorF control2, VectorF end) : base(start, end)
        {
            Control1 = control1;
            Control2 = control2;
        }

        public VectorF Control1 { get; }

        public VectorF Control2 { get; }

        public override VectorF GetPositionAt(float t)
        {
            return (float)System.Math.Pow((1 - t), 3) * Start
                + 3 * (float)System.Math.Pow((1 - t), 2) * t * Control1
                + 3 * (1 - t) * t * t * Control2
                + t * t * t * End;
        }

        public override bool Equals(object obj)
        {
            var cubicBezier = obj as CubicBezierSegment;

            return base.Equals(cubicBezier)
                && Control1.Equals(cubicBezier.Control1)
                && Control2.Equals(cubicBezier.Control2);
        }

        protected override float GetTangentAt(float t)
        {
            VectorF derivative = 3 * (float)System.Math.Pow((1 - t), 2) * (Control1 - Start)
                + 6 * (1 - t) * t * (Control2 - Control1)
                + 3 * t * t * (End - Control2);

            return MathUtils.LineSlope(derivative);
        }
    }
}