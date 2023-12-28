using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Strategies.Decorators
{
    public class AdjacentPixelsAverageGradient : BaseColorGradientStrategyDecorator
    {
        public AdjacentPixelsAverageGradient(IColorGradientStrategy gradientStrategy) : base(gradientStrategy)
        {

        }

        public override GradientVector GetGradientAt(GrayscaleBitmap bitmap, int x, int y)
        {
            GradientVector targetGradient = GetBaseStrategyGradient(bitmap, x, y);
            GradientVector leftGradient = GetBaseStrategyGradient(bitmap, x - 1, y);
            GradientVector rightGradient = GetBaseStrategyGradient(bitmap, x + 1, y);
            GradientVector topGradient = GetBaseStrategyGradient(bitmap, x, y - 1);
            GradientVector bottomGradient = GetBaseStrategyGradient(bitmap, x, y + 1);

            var luminosityGradient = new VectorInt(
                GetAverageDx(bitmap, y, targetGradient.Luminosity, leftGradient.Luminosity, rightGradient.Luminosity),
                GetAverageDy(bitmap, x, targetGradient.Luminosity, topGradient.Luminosity, bottomGradient.Luminosity));

            var alphaGradient = new VectorInt(
                GetAverageDx(bitmap, y, targetGradient.Alpha, leftGradient.Alpha, rightGradient.Alpha),
                GetAverageDy(bitmap, x, targetGradient.Alpha, topGradient.Alpha, bottomGradient.Alpha));

            return new GradientVector(luminosityGradient, alphaGradient);
        }

        private GradientVector GetBaseStrategyGradient(GrayscaleBitmap bitmap, int x, int y)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
            {
                return GradientVector.Zero;
            }

            return _gradientStrategy.GetGradientAt(bitmap, x, y);
        }

        private int GetAverageDx(GrayscaleBitmap bitmap, int y, VectorInt targetComponent, VectorInt leftComponent, VectorInt rightComponent)
        {
            if (y - 1 < 0 || y + 1 >= bitmap.Height)
            {
                return 0;
            }

            return (targetComponent.X
                + leftComponent.X
                + rightComponent.X) / 3;
        }

        private int GetAverageDy(GrayscaleBitmap bitmap, int x, VectorInt targetComponent, VectorInt topComponent, VectorInt bottomComponent)
        {
            if (x - 1 < 0 || x + 1 >= bitmap.Width)
            {
                return 0;
            }

            return (targetComponent.Y
                + topComponent.Y
                + bottomComponent.Y) / 3;
        }
    }
}