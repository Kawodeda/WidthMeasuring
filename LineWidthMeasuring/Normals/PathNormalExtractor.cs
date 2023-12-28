using System.Collections.Generic;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class PathNormalExtractor : IPathNormalExtractor
    {
        private readonly IPathSegmentMeasurer _pathSegmentMeasurer;

        public PathNormalExtractor(IPathSegmentMeasurer pathSegmentMeasurer)
        {
            _pathSegmentMeasurer = pathSegmentMeasurer;
        }

        public IEnumerable<LocatedVectorF> GetNormals(IEnumerable<Segment> path, float step)
        {
            float remainingLength = 0;
            foreach (Segment segment in path)
            {
                float length = _pathSegmentMeasurer.MeasureLength(segment);
                if (remainingLength >= length)
                {
                    remainingLength -= length;

                    continue;
                }
                if (length < step)
                {
                    remainingLength += step;
                }

                foreach (LocatedVectorF normal in GetNormals(segment, step, length))
                {
                    yield return normal;
                }
            }
        }

        private IEnumerable<LocatedVectorF> GetNormals(Segment segment, float step, float segemtLength)
        {
            float tStep = step / segemtLength;
            for (float t = 0; t < 1; t += tStep)
            {
                VectorF position = segment.GetPositionAt(t);
                VectorF normal = segment.GetNormalAt(t);

                yield return new LocatedVectorF(position, normal);
            }
        }
    }
}