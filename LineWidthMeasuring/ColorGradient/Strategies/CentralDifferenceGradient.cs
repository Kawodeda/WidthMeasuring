using System;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Strategies
{
    public class CentralDifferenceGradient : IColorGradientStrategy
    {
        public GradientVector GetGradientAt(GrayscaleBitmap bitmap, int x, int y)
        {
            return new GradientVector(
                GetLuminosityGradient(bitmap, x, y),
                GetAlphaGradient(bitmap, x, y));
        }

        private VectorInt GetLuminosityGradient(GrayscaleBitmap bitmap, int x, int y)
        {
            return new VectorInt(
                GetLuminosityDx(bitmap, x, y), 
                GetLuminosityDy(bitmap, x, y));
        }

        private VectorInt GetAlphaGradient(GrayscaleBitmap bitmap, int x, int y)
        {
            return new VectorInt(
                GetAlphaDx(bitmap, x, y),
                GetAlphaDy(bitmap, x, y));
        }

        private int GetLuminosityDx(GrayscaleBitmap bitmap, int x, int y)
        {
            return GetComponentDx(bitmap, x, y, pixel => pixel.Luminosity);
        }

        private int GetLuminosityDy(GrayscaleBitmap bitmap, int x, int y)
        {
            return GetComponentDy(bitmap, x, y, pixel => pixel.Luminosity);
        }

        private int GetAlphaDx(GrayscaleBitmap bitmap, int x, int y)
        {
            return GetComponentDx(bitmap, x, y, pixel => pixel.Alpha);
        }

        private int GetAlphaDy(GrayscaleBitmap bitmap, int x, int y)
        {
            return GetComponentDy(bitmap, x, y, pixel => pixel.Alpha);
        }

        private int GetComponentDx(GrayscaleBitmap bitmap, int x, int y, Func<GrayscalePixel, byte> getComponent)
        {
            if (x - 1 < 0 || x + 1 >= bitmap.Width)
            {
                return 0;
            }

            return getComponent(bitmap.GetPixelAt(x + 1, y)) - getComponent(bitmap.GetPixelAt(x - 1, y));
        }

        private int GetComponentDy(GrayscaleBitmap bitmap, int x, int y, Func<GrayscalePixel, byte> getComponent)
        {
            if (y - 1 < 0 || y + 1 >= bitmap.Height)
            {
                return 0;
            }

            return getComponent(bitmap.GetPixelAt(x, y + 1)) - getComponent(bitmap.GetPixelAt(x, y - 1));
        }
    }
}