﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Models
{
    public struct V2<N> where N : INumber<N>
    {
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
    }

    public static class V2
    {
        public static V2<N> Center<N>(V2<N> left, V2<N> right) where N : INumber<N>
        {
            (N max, N min) x = left.X > right.X ? new(left.X, right.X) : new(right.X, left.X);
            (N max, N min) y = left.Y > right.Y ? new(left.Y, right.Y) : new(right.Y, left.Y);

            return new(x.min + (x.max - x.min), y.min + (y.max - y.min));
        }

        public static Vector2 ToNumericsVector2(this ref V2<float> value) => new Vector2(value.X, value.Y);
    }
}