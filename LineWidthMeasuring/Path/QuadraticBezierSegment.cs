using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path
{
    public class QuadraticBezierSegment : Segment
    {
        public QuadraticBezierSegment(VectorF start, VectorF control, VectorF end) : base(start, end)
        {
            Control = control;
        }

        public VectorF Control { get; }

        public override VectorF GetPositionAt(float t)
        {
            return (float)System.Math.Pow((1 - t), 2) * Start 
                + 2 * (1 - t) * t * Control 
                + t * t * End;
        }

        public override bool Equals(object obj)
        {
            var quadraticBezier = obj as QuadraticBezierSegment;

            return base.Equals(quadraticBezier)
                && Control.Equals(quadraticBezier.Control);
        }

        protected override float GetTangentAt(float t)
        {
            VectorF derivative = 2 * (1 - t) * (Control - Start) + 2 * t * (End - Control);

            return MathUtils.LineSlope(derivative);
        }
    }
}