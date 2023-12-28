using System.Collections.Generic;
using System.Linq;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Path;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class VectorNormalSource : INormalSource
    {
        private readonly IPathNormalExtractor _normalExtractor;
        private readonly IColorGradientNormalMapper _normalMapper;
        private readonly INormalPresenter _normalPresenter;
        private readonly IEnumerable<Segment> _path;
        private readonly float _step;
        private readonly ImageColorGradient _colorGradient;

        public VectorNormalSource(
            IPathNormalExtractor normalExtractor,
            IColorGradientNormalMapper normalMapper,
            INormalPresenter normalPresenter,
            IEnumerable<Segment> path,
            float step,
            ImageColorGradient colorGradient)
        {
            _normalExtractor = normalExtractor;
            _normalMapper = normalMapper;
            _normalPresenter = normalPresenter;
            _path = path;
            _step = step;
            _colorGradient = colorGradient;
        }

        public IEnumerable<LocatedVectorF> GetNormals()
        {
            return _normalPresenter.GetNormalsToMeasure(
                _normalMapper.MapNormals(
                    FilterNaNNormals(_normalExtractor.GetNormals(_path, _step)),
                    _colorGradient));
        }

        private IEnumerable<LocatedVectorF> FilterNaNNormals(IEnumerable<LocatedVectorF> normals)
        {
            return normals.Where(normal => !normal.Vector.IsNaN);
        }
    }
}