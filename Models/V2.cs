using ShapeSharp.Models;
using System.Numerics;

namespace ShapeSharp.Models
{
    public struct V2<N> where N : INumber<N>
    {
        public static V2<N> Empty => new(N.Zero, N.Zero);

        public N this[int index]
        {
            get
            {
                if (index is 0) return X;
                if (index is 1) return Y;
                throw new IndexOutOfRangeException();
            }
        }

        public N X;
        public N Y;

        public V2(N x, N y)
        {
            this.X = x;
            this.Y = y;
        }

        public static V2<N> operator *(in V2<N> left, N right)
        {
            return new(left.X * right, left.Y * right);
        }

        public static V2<N> operator +(in V2<N> left, N right)
        {
            return new(left.X + right, left.Y + right);
        }

        public static V2<N> operator -(in V2<N> left, N right)
        {
            return new(left.X - right, left.Y - right);
        }

        public static V2<N> operator /(in V2<N> left, N right)
        {
            return new(left.X / right, left.Y / right);
        }

        public static V2<N> operator *(V2<N> left, V2<N> right)
        {
            return new(left.X * right.X, left.Y * right.Y); 
        }

        public static V2<N> operator +(V2<N> left, V2<N> right)
        {
            return new(left.X + right.X, left.Y + right.Y);
        }

        public static V2<N> operator -(V2<N> left, V2<N> right)
        {
            return new(left.X - right.X, left.Y - right.Y);
        }

        public static V2<N> operator /(V2<N> left, V2<N> right)
        {
            return new(left.X / right.X, left.Y / right.Y);
        }

        public static V2<N> operator +(V2<N> left, Slope<N> right)
        {
            return new(left.X + right.Run, left.Y + right.Rise);
        }
    }

    public static class V2
    {
        public static V2<N> MidPoint<N>(V2<N> left, V2<N> right) where N : INumber<N>
        {
            (N max, N min) x = left.X > right.X ? new(left.X, right.X) : new(right.X, left.X);
            (N max, N min) y = left.Y > right.Y ? new(left.Y, right.Y) : new(right.Y, left.Y);

            return new(x.min + (x.max - x.min), y.min + (y.max - y.min));
        }

        public static Vector2 ToNumericsVector2(this ref V2<float> value) => new Vector2(value.X, value.Y);
    }
}
