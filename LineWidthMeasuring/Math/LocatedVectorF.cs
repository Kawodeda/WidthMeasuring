namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math
{
    public class LocatedVectorF
    {
        public LocatedVectorF(VectorF location, VectorF vector)
        {
            Location = location;
            Vector = vector;
        }

        public VectorF Location { get; }

        public VectorF Vector { get; }

        public LocatedVectorF Translate(float xShift, float yShift)
        {
            return new LocatedVectorF(Location + new VectorF(xShift, yShift), Vector);
        }
    }
}