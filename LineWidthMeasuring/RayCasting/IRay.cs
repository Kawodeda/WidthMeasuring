using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting
{
    public interface IRay
    {
        VectorF Basis { get; }

        VectorInt Origin { get; }

        VectorInt Current { get; }

        VectorInt GetNext();
    }
}