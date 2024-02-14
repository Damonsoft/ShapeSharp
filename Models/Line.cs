using System.Numerics;
using System.Runtime.CompilerServices;

namespace ShapeSharp.Models
{
    public struct Line<N> where N : INumber<N>
    {
        public readonly Slope<N> Slope { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Logic.Slope.FindSlope(Source, Target); }

        public readonly V2<N> MidPoint { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => V2.MidPoint(Source, Target); }

        public V2<N> Source;
        public V2<N> Target;

        public Line(V2<N> source, V2<N> target)
        {
            this.Source = source;
            this.Target = target;
        }

        public Line(N sourceX, N sourceY, N targetX, N targetY)
        {
            this.Source = new(sourceX, sourceY);
            this.Target = new(targetX, targetY);
        }
    }
}
