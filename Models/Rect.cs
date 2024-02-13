using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Models
{
    public struct Rect<N> where N : INumber<N>
    {
        public static Rect<N> Empty => new Rect<N>(N.Zero, N.Zero, N.Zero, N.Zero);

        public readonly N R { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X + W; }
        public readonly N B { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Y + H; }
        public readonly V2<N> Center { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(this.X + this.W / (N.One + N.One), this.Y + H / (N.One + N.One));  }

        public N X;
        public N Y;
        public N W;
        public N H;

        public Rect(V2<N> position, V2<N> size)
        {
            this.X = position.X;
            this.Y = position.Y;
            this.W = size.X;
            this.H = size.Y;
        }

        public Rect(N x, N y, N width, N height)
        {
            this.X = x;
            this.Y = y;
            this.W = width;
            this.H = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly V2<N> TopLeft() => new(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly V2<N> TopRight() => new(X + W, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly V2<N> BottomRight() => new(X + W, Y + H);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly V2<N> BototmLeft() => new(X, Y + H);

        public readonly bool Contains(N x, N y)
        {
            return x >= this.X && y >= this.Y && x < this.W && y < this.H;
        }

        public readonly bool Contains(V2<N> vector)
        {
            return vector.X >= this.X &&
                   vector.Y >= this.Y &&
                   vector.X < this.W &&
                   vector.Y < this.H;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly LTRB<N> ToLTRB() => new(X, Y, X + W, Y + H);
    }
}
