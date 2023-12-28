using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting.Factories
{
    public class BresenhamRayFactory : IRayFactory
    {
        public IRay Create(VectorInt origin, VectorF basis)
        {
            return new BresenhamRay(origin, basis);
        }
    }
}
