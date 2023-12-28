using System.Linq;
using System.Collections.Generic;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class LineWidthNormalPresenter : INormalPresenter
    {
        public IEnumerable<LocatedVectorF> GetNormalsToMeasure(IEnumerable<MappedNormal> mappedNormals)
        {
            return GetEdgeInwardNormals(mappedNormals)
                .Concat(GetBothDirectionsNormals(GetInnerBorderNormals(mappedNormals)));
        }

        private IEnumerable<LocatedVectorF> GetBothDirectionsNormals(IEnumerable<LocatedVectorF> normals)
        {
            return normals.SelectMany(GetBothDirectionsOfNormal);
        }

        private IEnumerable<LocatedVectorF> GetInnerBorderNormals(IEnumerable<MappedNormal> mappedNormals)
        {
            return mappedNormals
                .Where(mappedNormal => !mappedNormal.Gradient.Luminosity.IsZero && mappedNormal.Gradient.Alpha.IsZero)
                .Select(mappedNormal => new LocatedVectorF(mappedNormal.Gradient.Location, mappedNormal.Normal));
        }

        private IEnumerable<LocatedVectorF> GetEdgeInwardNormals(IEnumerable<MappedNormal> mappedNormals)
        {
            return GetEdgeNormals(mappedNormals)
                .Select(mappedNormal =>
                {
                    float dotProduct = MathUtils.DotProduct(mappedNormal.Normal, mappedNormal.Gradient.Alpha);

                    // If normal and alpha gradient are pointing in the opposite directions, their dotProduct
                    // is negative, so we multiply normal by -1 (the sign of dotProduct) i.e. invert it.
                    // Thus normal will always point inward.
                    VectorF inwardNormal = mappedNormal.Normal * System.Math.Sign(dotProduct);

                    return new LocatedVectorF(mappedNormal.Gradient.Location, inwardNormal);
                })
                .Where(inwardNormal => !inwardNormal.Vector.IsZero);
        }

        private IEnumerable<MappedNormal> GetEdgeNormals(IEnumerable<MappedNormal> mappedNormals)
        {
            return mappedNormals.Where(mappedNormal => !mappedNormal.Gradient.Alpha.IsZero);
        }

        private IEnumerable<LocatedVectorF> GetBothDirectionsOfNormal(LocatedVectorF normal)
        {
            yield return normal;
            yield return new LocatedVectorF(normal.Location, -normal.Vector);
        }
    }
}