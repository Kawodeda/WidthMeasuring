using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model
{
    public class LocatedGradientVector
    {
        public LocatedGradientVector(GradientVector gradientVector, VectorInt location)
        {
            GradientVector = gradientVector;
            Location = location;
        }

        public VectorInt Location { get; }

        public GradientVector GradientVector { get; }

        public VectorInt Luminosity
        {
            get
            {
                return GradientVector.Luminosity;
            }
        }

        public VectorInt Alpha
        {
            get
            {
                return GradientVector.Alpha;
            }
        }

        public bool IsZero
        {
            get
            {
                return GradientVector.IsZero;
            }
        }
    }
}