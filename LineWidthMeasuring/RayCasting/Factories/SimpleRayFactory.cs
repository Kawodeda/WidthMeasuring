using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting.Factories
{
    public class SimpleRayFactory : IRayFactory
    {
        public IRay Create(VectorInt origin, VectorF basis)
        {
            return new SimpleRay(origin, basis);
        }
    }
}
