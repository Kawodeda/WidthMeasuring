using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Strategies;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient
{
    public class ColorGradientExtractor
    {
        private readonly IColorGradientStrategy _gradientStrategy;

        public ColorGradientExtractor(IColorGradientStrategy gradientStrategy)
        {
            _gradientStrategy = gradientStrategy;
        }

        public ImageColorGradient GetColorGradient(GrayscaleBitmap bitmap)
        {
            var gradients = new GradientVector[bitmap.Width, bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    gradients[i, j] = _gradientStrategy.GetGradientAt(bitmap, i, j);
                }
            }

            return new ImageColorGradient(gradients);
        }
    }
}
