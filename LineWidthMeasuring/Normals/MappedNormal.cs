using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class MappedNormal
    {

        public MappedNormal(LocatedGradientVector gradient, VectorF normal)
        {
            Gradient = gradient;
            Normal = normal;
        }

        public LocatedGradientVector Gradient { get; }

        public VectorF Normal { get; }
    }
}