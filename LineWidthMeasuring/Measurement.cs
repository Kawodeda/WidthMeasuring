using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring
{
    public class Measurement
    {
        public Measurement(IPointInt origin, IPointInt end)
        {
            Origin = origin;
            End = end;
        }

        public IPointInt Origin { get; }

        public IPointInt End { get; }

        public float Length
        {
            get
            {
                return MathUtils.Distance(Origin, End);
            }
        }

        public override string ToString()
        {
            return Length.ToString("N2");
        }
    }
}