using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting.Factories
{
    public interface IRayFactory
    {
        IRay Create(VectorInt origin, VectorF basis);
    }
}
