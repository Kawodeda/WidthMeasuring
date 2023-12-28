using System.Collections.Generic;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public interface INormalPresenter
    {
        IEnumerable<LocatedVectorF> GetNormalsToMeasure(IEnumerable<MappedNormal> mappedNormals);
    }
}
