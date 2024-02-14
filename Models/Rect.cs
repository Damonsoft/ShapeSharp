using System.Numerics;
using System.Runtime.CompilerServices;

namespace ShapeSharp.Models
{
    public struct Rect<N> where N : INumber<N>
    {
        public static Rect<N> Empty => new Rect<N>(N.Zero, N.Zero, N.Zero, N.Zero);

        public readonly V2<N> TopLeft  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(X, Y); }
        public readonly V2<N> TopRight { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(X + W, Y); }
        public readonly V2<N> BottomRight { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(X + W, Y + H); }
        public readonly V2<N> BottomLeft { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(X, Y + H); }

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

    public static class RectEx
    {
        public static System.Drawing.Rectangle ToDrawingRect(this in Rect<float> rect) => new System.Drawing.Rectangle((int)rect.X, (int)rect.Y, (int)rect.W, (int)rect.H);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect<N> Create<N>(N x, N y, N w, N h) where N : INumber<N> => new(x, y, w, h);
    }
}
