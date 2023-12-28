using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Strategies
{
    public interface IColorGradientStrategy
    {
        GradientVector GetGradientAt(GrayscaleBitmap bitmap, int x, int y);
    }
}
