using Arch.Geometry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapeSharp.Models
{
    public struct Square<N> where N : INumber<N>
    {
        internal static readonly N Two = N.One + N.One;

        public readonly N W { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Size; }
        public readonly N H { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Size; }
        public readonly V2<N> Center { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(this.X + this.W / Two, this.Y + this.H / Two); }

        public N X;
        public N Y;
        public N Size;

        public Square(N x, N y, N size)
        {
            this.X = x;
            this.Y = y;
            this.Size = size;
        }
    }
}
