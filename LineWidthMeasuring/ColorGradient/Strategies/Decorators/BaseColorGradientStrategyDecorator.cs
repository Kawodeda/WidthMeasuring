using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Strategies.Decorators
{
    public abstract class BaseColorGradientStrategyDecorator : IColorGradientStrategy
    {
        protected readonly IColorGradientStrategy _gradientStrategy;

        public BaseColorGradientStrategyDecorator(IColorGradientStrategy gradientStrategy)
        {
            _gradientStrategy = gradientStrategy;
        }

        public abstract GradientVector GetGradientAt(GrayscaleBitmap bitmap, int x, int y);
    }
}
