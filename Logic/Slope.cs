using ShapeSharp.Models;
using System.Numerics;

namespace ShapeSharp.Logic
{
    public static class Slope
    {
        public static IEnumerable<V2<N>> Enumerate<N>(V2<N> source, Slope<N> slope, int count) where N : INumber<N>
        {
            for(int i = 0; i < count; i++)
            {
                yield return source;

                source = (source + slope);
            }
        }

        public static N FindRise<N>(V2<N> source, V2<N> target) where N : INumber<N>
        {
            return target.Y - source.Y;
        }

        public static N FindRun<N>(V2<N> source, V2<N> target) where N : INumber<N>
        {
            return target.X - source.X;
        }

        public static Slope<N> FindSlope<N>(V2<N> source, V2<N> target) where N : INumber<N>
        {
            N n = (target.Y - source.Y); // Numerator
            N d = (target.X - source.X); // Denominator
            N c = Euclidean.GCD(n, d);

            return new(n / c, d / c);
        }
    }
}
