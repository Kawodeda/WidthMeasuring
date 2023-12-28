namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model
{
    public class ImageColorGradient
    {
        private readonly GradientVector[,] _gradientVectors;

        public ImageColorGradient(GradientVector[,] gradientVectors)
        {
            _gradientVectors = (GradientVector[,])gradientVectors.Clone();
        }

        public int Width
        {
            get
            {
                return _gradientVectors.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return _gradientVectors.GetLength(1);
            }
        }

        public GradientVector GetGradientAt(int x, int y)
        {
            return _gradientVectors[x, y];
        }
    }
}
