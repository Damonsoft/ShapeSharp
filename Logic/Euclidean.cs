using ShapeSharp.Models;
using System.Numerics;

namespace ShapeSharp.Logic
{
    public static class Euclidean
    {
        public static N GCD<N>(N n, N m) where N : INumber<N>
        {
            if (n < m)
                return GCD(m, n);

            if (m == N.Zero)
                return n;

            return GCD(m, n % m);
        }

        public static N Distance<N>(V2<N> source, V2<N> target) where N : INumber<N>, IRootFunctions<N>
        {
            N x = target.X - source.X;
            N y = target.Y - source.Y;

            return N.Sqrt((x * x) + (y * y));
        }
    }
}
