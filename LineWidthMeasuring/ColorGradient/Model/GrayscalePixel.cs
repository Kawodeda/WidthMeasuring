namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model
{
    public class GrayscalePixel
    {
        public GrayscalePixel(byte luminosity, byte alpha)
        {
            Luminosity = luminosity;
            Alpha = alpha;
        }

        public byte Luminosity { get; }

        public byte Alpha { get; }
    }
}