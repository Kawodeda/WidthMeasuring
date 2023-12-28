using System;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting
{
    public abstract class BaseRay : IRay
    {
        public BaseRay(VectorInt origin, VectorF basis)
        {
            Origin = origin;
            Basis = ValidateBasis(basis);
            Current = Origin;
        }

        public VectorInt Origin { get; }

        public VectorF Basis { get; }

        public VectorInt Current { get; protected set; }

        public abstract VectorInt GetNext();

        private VectorF ValidateBasis(VectorF basis)
        {
            if (basis.IsZero)
            {
                throw new ArgumentException($"{nameof(basis)} must not be a zero vector");
            }

            return basis;
        }
    }
}