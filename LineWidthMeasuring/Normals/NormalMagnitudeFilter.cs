using System;
using System.Collections.Generic;
using System.Linq;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.ColorGradient.Model;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Math;
using Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.RayCasting.Factories;

namespace Aurigma.DesignAtoms.ImageProcessing.LineWidthMeasuring.Normals
{
    public class NormalMagnitudeFilter
    {
        private readonly IRayFactory _rayFactory = new SimpleRayFactory();

        public IEnumerable<MappedNormal> Filter(IEnumerable<MappedNormal> mappedNormals, ImageColorGradient colorGradient)
        {
            Dictionary<VectorInt, MappedNormal> result = mappedNormals.ToDictionary(
                mappedNormal => mappedNormal.Gradient.Location,
                new VectorIntEqualityComparer());

            foreach (MappedNormal normal in mappedNormals)
            {
                FilterByNormal(normal, colorGradient, toRemove => result.Remove(toRemove));
            }

            return result.Values;
        }

        private void FilterByNormal(MappedNormal mappedNormal, ImageColorGradient colorGradient, Action<VectorInt> removeNormalAt)
        {
            var normalCaster = new NormalCaster(_rayFactory, mappedNormal.Normal, mappedNormal.Gradient.Location, colorGradient);
            while (true)
            {
                NormalCaster.Transition transition = normalCaster.Next();
                if (transition.ToState != NormalCaster.State.InNonZeroGradient)
                {
                    return;
                }
                if (transition.FromState == NormalCaster.State.InNonZeroGradient)
                {
                    VectorInt toRemove = GetMagnitude(normalCaster.CurrentGradient.GradientVector) >= GetMagnitude(mappedNormal.Gradient.GradientVector)
                        ? mappedNormal.Gradient.Location
                        : normalCaster.CurrentGradient.Location;

                    removeNormalAt(toRemove);
                }
            }
        }

        private float GetMagnitude(GradientVector gradient)
        {
            return gradient.Luminosity.IsZero 
                ? gradient.Alpha.Magnitude 
                : gradient.Luminosity.Magnitude;
        }
    }
}