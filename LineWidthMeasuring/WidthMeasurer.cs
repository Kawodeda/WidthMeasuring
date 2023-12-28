using System;
using System.Collections.Generic;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting.Factories;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring
{
    public class WidthMeasurer
    {
        private readonly IRayFactory _rayFactory;

        public WidthMeasurer(IRayFactory rayFactory)
        {
            _rayFactory = rayFactory;
        }

        public IEnumerable<Measurement> Measure(INormalSource normalSource, ImageColorGradient colorGradient)
        {
            foreach (LocatedVectorF normal in normalSource.GetNormals())
            {
                Tuple<bool, Measurement> result = TryMeasure(normal, colorGradient);
                if (result.Item1)
                {
                    yield return result.Item2;
                }
            }
        }

        private Tuple<bool, Measurement> TryMeasure(LocatedVectorF normal, ImageColorGradient colorGradient)
        {
            var gridLocation = (VectorInt)normal.Location;
            var normalCaster = new NormalCaster(_rayFactory, normal.Vector, gridLocation, colorGradient);
            while (true)
            {
                NormalCaster.Transition transition = normalCaster.Next();
                if (transition.ToState == NormalCaster.State.OutOfImage)
                {
                    return new Tuple<bool, Measurement>(false, null);
                }
                if (transition.FromState == NormalCaster.State.InZeroGradient
                    && transition.ToState == NormalCaster.State.InNonZeroGradient)
                {
                    return new Tuple<bool, Measurement>(
                        true, 
                        new Measurement(gridLocation, normalCaster.CurrentGradient.Location));
                }
            }
        }
    }
}