using System.Collections.Generic;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class VectorIntEqualityComparer : IEqualityComparer<VectorInt>
    {
        public bool Equals(VectorInt a, VectorInt b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public int GetHashCode(VectorInt vector)
        {
            unchecked
            {
                return 17 * 23 
                    ^ vector.X * 23 
                    ^ vector.Y;
            }
        }
    }
}