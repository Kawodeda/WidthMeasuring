using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model
{
    public class GradientVector
    {
        public GradientVector(VectorInt luminosityGradient, VectorInt alphaGradient)
        {
            Luminosity = luminosityGradient;
            Alpha = alphaGradient;
        }

        public static GradientVector Zero
        {
            get
            {
                return new GradientVector(VectorInt.Zero, VectorInt.Zero);
            }
        }

        public VectorInt Luminosity { get; }

        public VectorInt Alpha { get; }

        public bool IsZero
        {
            get
            {
                return Luminosity.IsZero && Alpha.IsZero;
            }
        }
    }
}