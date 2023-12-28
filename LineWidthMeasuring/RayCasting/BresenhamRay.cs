using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting
{
    public class BresenhamRay : BaseRay
    {
        private readonly int _stepX;
        private readonly int _stepY;
        private readonly float _a;
        private readonly float _b;

        public BresenhamRay(VectorInt origin, VectorF basis) 
            : base(origin, basis)
        {
            _stepX = System.Math.Sign(Basis.X);
            _stepY = System.Math.Sign(Basis.Y);
            _a = Basis.Y / Basis.X;
            _b = Origin.Y - _a * Origin.X;
        }

        public override VectorInt GetNext()
        {
            if (Basis.X.NearlyEquals(0))
            {
                Current += new VectorInt(0, _stepY);

                return Current;
            }
            if (Basis.Y.NearlyEquals(0))
            {
                Current += new VectorInt(_stepX, 0);

                return Current;
            }

            Current = GetNextBresenhamPoint();

            return Current;
        }

        private VectorInt GetNextBresenhamPoint()
        {
            VectorInt s = System.Math.Abs(Basis.Y) < System.Math.Abs(Basis.X)
                ? Current + new VectorInt(_stepX, 0)
                : Current + new VectorInt(0, _stepY);
            VectorInt t = Current + new VectorInt(_stepX, _stepY);

            float dS = System.Math.Abs(s.Y - GetActualLineAt(s.X));
            float dT = System.Math.Abs(t.Y - GetActualLineAt(t.X));

            return dT < dS 
                ? t 
                : s;
        }

        private float GetActualLineAt(float x)
        {
            return _a * x + _b;
        }
    }
}