using System.Collections.Generic;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public interface IColorGradientNormalMapper
    {
        IEnumerable<MappedNormal> MapNormals(IEnumerable<LocatedVectorF> normals, ImageColorGradient colorGradient);
    }
}