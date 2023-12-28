using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public interface IPathSegmentMeasurer
    {
        float MeasureLength(Segment segment);
    }
}
