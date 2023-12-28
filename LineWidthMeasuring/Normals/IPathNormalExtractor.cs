using System.Collections.Generic;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public interface IPathNormalExtractor
    {
        IEnumerable<LocatedVectorF> GetNormals(IEnumerable<Segment> path, float step);
    }
}