using System.Numerics;
using System.Runtime.CompilerServices;

namespace ShapeSharp.Models
{
    public struct Slope<N> where N : INumber<N>
    {
        public readonly N Value { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => this.Rise / this.Run; }

        public N Rise;
        public N Run;

        public Slope(N rise, N run)
        {
            this.Rise = rise;
            this.Run = run;
        }
    }
}
