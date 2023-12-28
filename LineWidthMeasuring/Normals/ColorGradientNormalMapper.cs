using System;
using System.Collections.Generic;
using System.Linq;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class ColorGradientNormalMapper : IColorGradientNormalMapper
    {
        public IEnumerable<MappedNormal> MapNormals(IEnumerable<LocatedVectorF> normals, ImageColorGradient colorGradient)
        {
            var mappedNormals = new Dictionary<VectorInt, LocatedVectorF>(new VectorIntEqualityComparer());
            foreach (LocatedVectorF normal in normals)
            {
                VectorInt gridLocation = SnapToGrid(normal.Location);
                if (colorGradient.GetGradientAt(gridLocation.X, gridLocation.Y).IsZero)
                {
                    continue;
                }
                if (!mappedNormals.ContainsKey(gridLocation))
                {
                    mappedNormals.Add(gridLocation, normal);
                    continue;
                }

                mappedNormals[gridLocation] = GetCloserNormal(gridLocation, mappedNormals[gridLocation], normal);
            }

            return mappedNormals.Select(CreateMappedNormalSelector(colorGradient));
        }

        private VectorInt SnapToGrid(VectorF vector)
        {
            return new VectorInt(
                (int)System.Math.Round(vector.X),
                (int)System.Math.Round(vector.Y));
        }

        private LocatedVectorF GetCloserNormal(VectorInt gridLocation, LocatedVectorF normalA, LocatedVectorF normalB)
        {
            return GetDifference(gridLocation, normalA) > GetDifference(gridLocation, normalB)
                ? normalB
                : normalA;
        }

        private Func<KeyValuePair<VectorInt, LocatedVectorF>, MappedNormal> CreateMappedNormalSelector(ImageColorGradient colorGradient)
        {
            return mappedNormal =>
            {
                VectorInt location = mappedNormal.Key;
                VectorF normal = mappedNormal.Value.Vector;
                GradientVector gradient = colorGradient.GetGradientAt(location.X, location.Y);

                return new MappedNormal(new LocatedGradientVector(gradient, location), normal);
            };
        }

        private float GetDifference(VectorInt a, LocatedVectorF b)
        {
            return MathUtils.Distance(a, b.Location);
        }
    }
}