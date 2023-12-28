using System.Collections.Generic;
using System.Linq;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class RasterNormalSource : INormalSource
    {
        private readonly NormalMagnitudeFilter _normalMagnitudeFilter;
        private readonly INormalPresenter _normalPresenter;
        private readonly ImageColorGradient _colorGradient;

        public RasterNormalSource(INormalPresenter normalPresenter, ImageColorGradient colorGradient)
        {
            _normalPresenter = normalPresenter;
            _colorGradient = colorGradient;
            _normalMagnitudeFilter = new NormalMagnitudeFilter();
        }

        private IEnumerable<LocatedGradientVector> _locatedGradients
        {
            get
            {
                for (int i = 0; i < _colorGradient.Width; i++)
                {
                    for (int j = 0; j < _colorGradient.Height; j++)
                    {
                        GradientVector gradient = _colorGradient.GetGradientAt(i, j);

                        yield return new LocatedGradientVector(gradient, new VectorInt(i, j));
                    }
                }
            }
        }

        public IEnumerable<LocatedVectorF> GetNormals()
        {
            return _normalPresenter.GetNormalsToMeasure(
                _normalMagnitudeFilter.Filter(
                    ExtractNormals().ToList(),
                    _colorGradient));
        }

        private IEnumerable<MappedNormal> ExtractNormals()
        {
            return _locatedGradients
                .Where(gradient => !gradient.IsZero)
                .Select(gradient =>
                {
                    VectorInt normal = gradient.Luminosity.IsZero
                        ? gradient.Alpha
                        : gradient.Luminosity;

                    return new MappedNormal(gradient, normal);
                });
        }
    }
}