using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting
{
    public class SimpleRay : BaseRay
    {
        private readonly VectorInt _step;
        private readonly float _tXStep;
        private readonly float _tYStep;

        private float _tX;
        private float _tY;

        public SimpleRay(VectorInt origin, VectorF basis) 
            : base(origin, basis)
        {
            _step = new VectorInt(System.Math.Sign(Basis.X), System.Math.Sign(Basis.Y));
            _tXStep = System.Math.Abs(1.0f / Basis.X);
            _tYStep = System.Math.Abs(1.0f / Basis.Y);
            _tX = _tXStep;
            _tY = _tYStep;
        }

        public override VectorInt GetNext()
        {
            Current += GetIncrement();

            return Current;
        }

        private VectorInt GetIncrement()
        {
            if (_tX < _tY)
            {
                _tX += _tXStep;
                return new VectorInt(_step.X, 0);
            }

            _tY += _tYStep;

            return new VectorInt(0, _step.Y);
        }
    }
}