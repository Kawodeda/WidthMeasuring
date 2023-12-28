using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting.Factories;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class NormalCaster
    {
        private readonly ImageColorGradient _colorGradient;
        private readonly IRay _normalRay;

        public NormalCaster(IRayFactory rayFactory, VectorF normal, VectorInt gridLocation, ImageColorGradient colorGradient)
        {
            _colorGradient = colorGradient;
            _normalRay = rayFactory.Create(gridLocation, normal);
            UpdateState();
        }

        public State CurrentState { get; private set; }

        public LocatedGradientVector CurrentGradient
        {
            get
            {
                return new LocatedGradientVector(
                    _colorGradient.GetGradientAt(_normalRay.Current.X, _normalRay.Current.Y),
                    _normalRay.Current);
            }
        }

        public Transition Next()
        {
            State prevState = CurrentState;
            _normalRay.GetNext();
            UpdateState();

            return new Transition(prevState, CurrentState);
        }

        private void UpdateState()
        {
            if (!IsWithinImage(_normalRay.Current))
            {
                CurrentState = State.OutOfImage;

                return;
            }

            CurrentState = GetStateByGradient(CurrentGradient);
        }

        private bool IsWithinImage(VectorInt point)
        {
            return point.X >= 0
                && point.Y >= 0
                && point.X < _colorGradient.Width
                && point.Y < _colorGradient.Height;
        }

        private State GetStateByGradient(LocatedGradientVector gradient)
        {
            return gradient.IsZero ? State.InZeroGradient : State.InNonZeroGradient;
        }

        public enum State
        {
            InZeroGradient,
            InNonZeroGradient,
            OutOfImage
        }

        public class Transition
        {
            public Transition(State fromState, State toState)
            {
                FromState = fromState;
                ToState = toState;
            }

            public State FromState { get; }

            public State ToState { get; }
        }
    }
}