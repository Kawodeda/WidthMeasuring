namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model
{
    public class GrayscaleBitmap
    {
        private readonly GrayscalePixel[,] _pixels;

        public GrayscaleBitmap(GrayscalePixel[,] pixels)
        {
            _pixels = (GrayscalePixel[,])pixels.Clone();
        }

        public int Width
        {
            get
            {
                return _pixels.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return _pixels.GetLength(1);
            }
        }

        public GrayscalePixel GetPixelAt(int x, int y)
        {
            return _pixels[x, y];
        }
    }
}
