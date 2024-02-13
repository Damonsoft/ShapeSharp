using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Models
{
    public struct LTRB<N> where N : INumber<N>
    {
        public readonly N W { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => R - L; }
        public readonly N H { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => B - T; }

        public N L;
        public N T;
        public N R;
        public N B;

        public LTRB(N l, N t, N r, N b)
        {
            this.L = l;
            this.T = t;
            this.R = r;
            this.B = b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Rect<N> ToRect()
        {
            return new(L, T, R - L, B - T);
        }
    }
}
